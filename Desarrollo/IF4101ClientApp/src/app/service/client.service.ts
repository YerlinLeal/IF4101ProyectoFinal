import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';

import { environment } from '@environments/environment';
import { Client } from 'src/app/models/Client';
import { Service } from '../models/Service';

const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json'
    })
  };

@Injectable({ providedIn: 'root' })
export class ClientService {
    private ClientSubject: BehaviorSubject<Client>;
    public Client: Observable<Client>;

    constructor(
        private router: Router,
        private http: HttpClient
    ) {
        this.ClientSubject = new BehaviorSubject<Client>(JSON.parse(localStorage.getItem('Client')));
        this.Client = this.ClientSubject.asObservable();
    }

    public get ClientValue(): Client {
        return this.ClientSubject.value;
    }

    login(Clientname, password) {
        return this.http.post<Client>(`${environment.apiUrl}/api/clients/authenticate`, { Clientname, password })
            .pipe(map(Client => {
                // store Client details and jwt token in local storage to keep Client logged in between page refreshes
                localStorage.setItem('Client', JSON.stringify(Client));
                this.ClientSubject.next(Client);
                return Client;
            }));
    }

    logout() {
        // remove Client from local storage and set current Client to null
        localStorage.removeItem('Client');
        this.ClientSubject.next(null);
        this.router.navigate(['/account/login']);
    }

    register(Client: Client, param) {
        Client.services = param;
        return this.http.post<any>(`${environment.apiUrl}/api/client/add`, JSON.stringify(Client), httpOptions).pipe(
            tap((student) => console.log('added student'))
          );
    }

    getAll() {
        return this.http.get<Client[]>(`${environment.apiUrl}/Clients`);
    }

    getById(id: string) {
        return this.http.get<Client>(`${environment.apiUrl}/api/client/clients/${id}`);
    }

    update(id, params) {
        return this.http.put(`${environment.apiUrl}/api/client/update/${id}`, params)
            .pipe(map(x => {
                // update stored Client if the logged in Client updated their own record
                if (id == this.ClientValue.client_Id) {
                    // update local storage
                    const Client = { ...this.ClientValue, ...params };
                    localStorage.setItem('Client', JSON.stringify(Client));

                    // publish updated Client to subscribers
                    this.ClientSubject.next(Client);
                }
                return x;
            }));
    }

    delete(id: number) {
        return this.http.delete(`${environment.apiUrl}/Clients/${id}`)
            .pipe(map(x => {
                // auto logout if the logged in Client deleted their own record
                if (id == this.ClientValue.client_Id) {
                    this.logout();
                }
                return x;
            }));
    }

    getServices(id: number) {
        return this.http.get<Service[]>(`${environment.apiUrl}/api/services/byClient/${id}`);
    }
}