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

    
    getAll() {
        return this.http.get<Issue[]>(`${environment.apiUrl}/api/issue/issues`);
    }

    getById(id: string) {
        return this.http.get<Issue>(`${environment.apiUrl}/Issues/${id}`);
    }

    update(id, params) {
        return this.http.put(`${environment.apiUrl}/Issues/${id}`, params)
            .pipe(map(x => {
                
                if (id == this.IssueValue.client_Id) {
                    // update local storage
                    const Issue = { ...this.IssueValue, ...params };
                    localStorage.setItem('Issue', JSON.stringify(Issue));

                    // publish updated Client to subscribers
                    this.IssueSubject.next(Issue);
                }
                return x;
            }));
    }

    delete(id: number) {
        return this.http.delete(`${environment.apiUrl}/Issues/${id}`)
            .pipe(map(x => {
                // auto logout if the logged in Client deleted their own record
                if (id == this.IssueValue.client_Id) {
                    
                }
                return x;
            }));
    }
}