import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { AlertService } from 'src/app/service/alert.service';
import { ClientService } from 'src/app/service/client.service';

@Component({
  selector: 'app-edit-client',
  templateUrl: './edit-client.component.html',
  styleUrls: ['./edit-client.component.css']
})
export class EditClientComponent implements OnInit {

  form: FormGroup;
  id: string;
  isAddMode: boolean;
  loading = false;
  submitted = false;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private clientService: ClientService,
    private alertService: AlertService
  ) { }

  ngOnInit() {
    this.id = sessionStorage.getItem("client_Id");//this.route.snapshot.params['id'];
    this.isAddMode = !this.id;

    // password not required in edit mode
    const passwordValidators = [Validators.minLength(6)];
    if (this.isAddMode) {
      passwordValidators.push(Validators.required);
    }

    this.form = this.formBuilder.group({
      name: ['', Validators.required],
      first_Surname: ['', Validators.required],
      second_Surname: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', passwordValidators],
      adress: [''] ,
      phone: ['']
    });

    if (!this.isAddMode) {
      this.clientService.getById(this.id)
        .pipe(first())
        .subscribe(x => {
          this.form.patchValue({
            name : x.name,
            first_Surname: x.first_Surname,
            second_Surname: x.second_Surname,
            email: x.email,
            adress: x.adress,
            phone: x.phone,
            password: x.password
          });

        });
    }
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
    if (this.isAddMode) {
      this.createUser();
    } else {
      this.updateUser();
    }
  }

  private createUser() {
    this.clientService.register(this.form.value,'')
      .pipe(first())
      .subscribe(
        data => {
          this.alertService.success('User added successfully', { keepAfterRouteChange: true });
          this.router.navigate(['.', { relativeTo: this.route }]);
        },
        error => {
          this.alertService.error(error);
          this.loading = false;
        });
  }

  private updateUser() {
    
    this.clientService.update(this.id, this.form.value)
      .pipe(first())
      .subscribe(
        data => {
          this.alertService.success('Update successful', { keepAfterRouteChange: true });
          this.router.navigate(['..', { relativeTo: this.route }]);
        },
        error => {
          this.alertService.error(error);
          this.loading = false;
        });
  }
}