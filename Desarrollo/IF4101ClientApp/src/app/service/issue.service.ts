import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';

import { environment } from '@environments/environment';
import { Issue } from 'src/app/models/Issue';

const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json'
    })
  };

@Injectable({ providedIn: 'root' })
export class IssueService {
    private IssueSubject: BehaviorSubject<Issue>;
    public Issue: Observable<Issue>;

    constructor(
        private router: Router,
        private http: HttpClient
    ) {
        this.IssueSubject = new BehaviorSubject<Issue>(JSON.parse(localStorage.getItem('Issue')));
        this.Issue = this.IssueSubject.asObservable();
    }

    public get IssueValue(): Issue {
        return this.IssueSubject.value;
    }

    add(Issue: Issue) {
        return this.http.post<any>(`${environment.apiUrl}/api/issue/add`, JSON.stringify(Issue), httpOptions).pipe(
            tap((issue) => console.log('added issue'))
          );
    }
/*
    getAll() {
        return this.http.get<Client[]>(`${environment.apiUrl}/Clients`);
    }

    getById(id: string) {
        return this.http.get<Client>(`${environment.apiUrl}/api/client/clients/${id}`);
    }

    update(id, params) {
        return this.http.put(`${environment.apiUrl}/Clients/${id}`, params)
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
    }*/
}