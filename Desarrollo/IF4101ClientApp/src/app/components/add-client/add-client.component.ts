import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validator, Validators, FormControl } from "@angular/forms";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AuthenticationService}  from "src/app/service/Auth/authentication.service"
import { state } from '@angular/animations';


@Component({
  selector: 'app-login',
  templateUrl: './add-client.component.html',
  styleUrls: ['./add-client.component.css']
})
export class AddClientComponent implements OnInit {
    user: FormGroup;
    loading = false;
    submitted = false;
    returnUrl: string;

    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private authentication: AuthenticationService
    ) { }

    ngOnInit() {
        if (sessionStorage.getItem("username")) {
            this.router.navigate(['']);
        }
        this.user = this.formBuilder.group({
            username: ['', Validators.required],
            password: ['', Validators.required]
        });
        // get return url from route parameters or default to '/'
        //this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    }

    // convenience getter for easy access to form fields
    get f() { return this.user.controls; }

    onSubmit() {
        this.submitted = true;

        // reset alerts on submit
        // this.alertService.clear();

        // stop here if form is invalid
        if (this.user.invalid) {
            return;
        }

        this.loading = true;
        // this.router.navigateByUrl('/RefreshComponent', { skipLocationChange: true }).then(() => {
        //     this.router.navigate(['register']);
        // }); 
        this.authentication.authenticate(this.f.username.value, this.f.password.value)
            .pipe(first())
            .subscribe(
                data => {
                    this.router.navigateByUrl('', { skipLocationChange: true }).then(() => {
                        this.router.navigate(['']);
                }); 
                },
                error => {
                    this.loading = false;
                });
    }
}
