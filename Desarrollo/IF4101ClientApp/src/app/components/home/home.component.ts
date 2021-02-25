import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AuthenticationService } from 'src/app/service/Auth/authentication.service';
import { MainNavComponent} from "src/app/components/main-nav/main-nav.component"

@Component({ templateUrl: 'home.component.html' })
export class HomeComponent {
    user: any;

    constructor(private auth: AuthenticationService,private router: Router) {
        this.user = sessionStorage.getItem("username");
    }

    ngOnInit() {
        if (sessionStorage.getItem("username")) {
            //  this.router.navigate(['/login']);
        }
    }

    logOut(){
        this.auth.logOut();
        this.router.navigateByUrl('/list-issues', { skipLocationChange: true }).then(() => {
          this.router.navigate(['/list-issues']);
        });
      }
}