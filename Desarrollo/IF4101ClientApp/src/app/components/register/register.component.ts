import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators, FormControl, FormsModule } from '@angular/forms';
import { first } from 'rxjs/operators';

import { AlertService } from 'src/app/service/alert.service';
import { ClientService } from 'src/app/service/client.service'
import { Service } from 'src/app/models/Service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
    form: FormGroup;
    loading = false;
    submitted = false;
    service = new FormControl('',Validators.required);
    selected: Service[];
    servicesList: Service[]=[{'service_Id':1,'name':'Telefonía Fija'},
    {'service_Id':2,'name':'Telefonía Movil'},
    {'service_Id':3,'name':'Cable'},
    {'service_Id':4,'name':'Internet'}];
    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private clientService: ClientService,
        private alertService: AlertService,
        private formModule: FormsModule
    ) { }

    ngOnInit() {
        
        localStorage.setItem('id', '2');
        this.form = this.formBuilder.group({
            name: ['', Validators.required],
            first_Surname: ['', Validators.required],
            second_Surname: ['', Validators.required],
            email: ['',[Validators.required, Validators.email]],
            password: ['', [Validators.required, Validators.minLength(6)]],
               
            
        });
    }

   

    // convenience getter for easy access to form fields
    get f() { return this.form.controls; }

    onSubmit() {
        this.submitted = true;

        // reset alerts on submit
        this.alertService.clear();

        // stop here if form is invalid
        if (this.form.invalid) {
            return;
        }

        

        this.loading = true;
        // alert(JSON.stringify(this.selected));
        this.clientService.register(this.form.value,this.selected)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Registration successful', { keepAfterRouteChange: true });
                    this.router.navigate(['../login'], { relativeTo: this.route });
                },
                error => {
                    this.alertService.error(error);
                    this.loading = false;
                });
        
        
    }
}