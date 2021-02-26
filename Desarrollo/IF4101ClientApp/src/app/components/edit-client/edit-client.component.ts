import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { AlertService } from 'src/app/service/alert.service';
import { ClientService } from 'src/app/service/client.service';
import { MatSnackBar } from '@angular/material/snack-bar';

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
    private alertService: AlertService,
    private snackbar: MatSnackBar
  ) { }

  ngOnInit() {
    this.id = sessionStorage.getItem("client_Id");//this.route.snapshot.params['id'];
    this.isAddMode = !this.id;


    this.form = this.formBuilder.group({
      name: ['', Validators.required],
      first_Surname: ['', Validators.required],
      second_Surname: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      adress: [''],
      phone: ['']
    });

    if (!this.isAddMode) {
      this.clientService.getById(this.id)
        .pipe(first())
        .subscribe(x => {
          this.form.patchValue({
            name: x.name,
            first_Surname: x.first_Surname,
            second_Surname: x.second_Surname,
            email: x.email,
            adress: x.adress,
            phone: x.phone,

          });

        });
    }
  }

  // convenience getter for easy access to form fields
  get f() { return this.form.controls; }

  onSubmit() {
    this.submitted = true;


    if (this.form.invalid) {
      return;
    }

    this.loading = true;

    this.updateUser();

  }

  private updateUser() {

    this.clientService.update(sessionStorage.getItem("client_Id"), this.form.value)
      .pipe(first())
      .subscribe(
        data => {
          this.snackbar.open("Successfully updated!", "OK!", {
            duration: 4000,
            panelClass: ['green-snackbar', 'login-snackbar'],
          });
          this.loading = false;
        },
        error => {
          this.snackbar.open("An error has occurred", "Try Again!", {
            duration: 4000,
            panelClass: ['red-snackbar', 'login-snackbar'],
          });
          this.loading = false;
        });
  }
}