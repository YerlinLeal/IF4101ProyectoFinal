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

   
    add(Issue: Issue) {
        return this.http.post<any>(`${environment.apiUrl}/api/issue/add`, JSON.stringify(Issue), httpOptions).pipe(
            tap((issue) => console.log('added issue'))
          );
    }

    
       
}