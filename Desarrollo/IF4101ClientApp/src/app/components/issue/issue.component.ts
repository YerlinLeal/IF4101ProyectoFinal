import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validator, Validators, FormControl } from "@angular/forms";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { first } from 'rxjs/operators';
import { Issue } from 'src/app/models/Issue';
import { IssueService } from 'src/app/service/issue/issue.service';
import { AlertService } from 'src/app/service/alert.service';
import { Service } from 'src/app/models/Service';
import { ClientService } from 'src/app/service/client.service';

@Component({
  selector: 'app-issue',
  templateUrl: './issue.component.html',
  styleUrls: ['./issue.component.css']
})

export class IssueComponent implements OnInit {

  reportForm: FormGroup;
  submitted = false;
  ok = false;
  error = false;
  textError = "";
  loading = false;
  returnUrl: string;
  services: any = [];
  serviceSelected: number;
  service = new FormControl('',Validators.required);

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private issueService: IssueService,
    private clientService: ClientService,
    private alertService: AlertService,
    private router: Router) { }

  ngOnInit() {

    // Cambiar id por el del usuario actual
    this.clientService.getServices(9).subscribe((data:{})=>{
      this.services=data;
      console.log(data);
      });

    this.reportForm = this.formBuilder.group({
      description: ['', Validators.required],
      phoneContact: new FormControl(''),
      emailContact: ['', Validators.email],
      addressC: [''],
    });

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';

    this.reportForm.get("phoneContact").valueChanges.subscribe(value => {
      let oldValue = this.reportForm.value.phoneContact;

      if(value!= null && value.toString().length > 8){
        this.reportForm.get("phoneContact").setValue(oldValue, {onlySelf: true});
      }
    })
  }

  get f() { return this.reportForm.controls; }

  onSubmit() {
    this.alertService.clear();

    this.submitted = true;

    if (this.reportForm.invalid || this.service.invalid) {
        return;
    }

    this.loading = true;

    let issue = new Issue();
    issue.description = this.reportForm.get("description").value;
    issue.contact_Phone = this.reportForm.get("phoneContact").value;
    issue.contact_Email = this.reportForm.get("emailContact").value;
    issue.adress = this.reportForm.get("addressC").value;
    issue.service_Id = this.serviceSelected;
    issue.client_Id = 2;// Cambiar id por el del usuario actual----------------------------------------------
    issue.created_By = 2;// Cambiar id por el del usuario actual---------------------------------------------g

    this.issueService.add(issue)
    .pipe(first())
    .subscribe(
      (result) => {
        if(result.report_Number != null && result.report_Number != 0){
          this.loading = false;
          this.ok=true;
          this.reportForm.reset();
          this.service.reset();
          this.submitted=false;
          this.error=false;
        }
        console.log(result);
    }, errorResult => {
      console.log(errorResult);
      this.error = true;
      this.textError = "An unexpected error has occurred. Please try again later.";
      this.loading = false;
    });

  }

  resetForm(){
    this.submitted = false;
    this.ok=false;
    this.error=false;
    this.reportForm.reset();
    this.service.reset();
  }

}
