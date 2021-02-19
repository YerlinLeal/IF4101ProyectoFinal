import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validator, Validators, FormControl } from "@angular/forms";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { first } from 'rxjs/operators';
import { IssueService } from 'src/app/service/issue.service';
import { Issue } from 'src/app/models/Issue';

@Component({
  selector: 'app-issue',
  templateUrl: './issue.component.html',
  styleUrls: ['./issue.component.css']
})

export class IssueComponent implements OnInit {

  reportForm: FormGroup;
  submitted = false;
  ok = false;
  loading = false;
  returnUrl: string;
  services: any[];

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private issueService: IssueService,
    private router: Router) { }

  ngOnInit() {

    this.services = [
      {id:1, name: 'Telefonía Fija'},
      {id:2, name: 'Telefonía Móvil'},
      {id:3, name: 'Cable'},
      {id:4, name: 'Internet'}
    ];

    this.reportForm = this.formBuilder.group({
      description: ['', Validators.required],
      phoneContact: new FormControl(''),
      emailContact: ['', Validators.email],
      addressC: [''],
      service: [this.services[0].id]
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
    this.submitted = true;

    if (this.reportForm.invalid) {
        return;
    }

    this.loading = true;

    let issue = new Issue();
    issue.description = this.reportForm.get("description").value;
    issue.contact_Phone = this.reportForm.get("phoneContact").value;
    issue.contact_Email = this.reportForm.get("emailContact").value;
    issue.adress = this.reportForm.get("addressC").value;
    issue.service_Id = this.reportForm.get("service").value;
    issue.client_Id = 2;
    issue.created_By = 2;

    this.issueService.add(issue).subscribe((result) => {

        if(result.report_Number != null && result.report_Number != 0){
          this.loading = false;
          this.ok=true;
          this.reportForm.reset();
          this.reportForm.get("service").setValue(this.services[0].id);
          this.submitted=false;
        }

        console.log(result);
    }, (err) => {
      console.log(err);
    });

  }

  resetForm(){
    this.ok=false;
    this.reportForm.reset();


    this.reportForm.get("service").setValue(this.services[0].id);
  }

}
