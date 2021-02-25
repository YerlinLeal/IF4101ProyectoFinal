import { Component } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { AuthGuard } from './components/_helper/AuthGuard';
import { AuthenticationService } from './service/Auth/authentication.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  private userSubject: BehaviorSubject<any>;
  user: Observable<any>;
  
  title = 'proyecto';
  constructor(private auth: AuthenticationService) {
    this.userSubject = new BehaviorSubject<any>(JSON.parse(localStorage.getItem('username')));
    this.user = this.userSubject.asObservable();
    this.auth.user.subscribe(x => this.user = x);
  }
}
