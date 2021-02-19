import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validator, Validators, FormControl } from "@angular/forms";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-issue',
  templateUrl: './issue.component.html',
  styleUrls: ['./issue.component.css']
})

export class IssueComponent implements OnInit {

  reportForm: FormGroup;
  submitted = false;
  loading = false;
  returnUrl: string;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.reportForm = this.formBuilder.group({
      description: ['', Validators.required],
      phoneContact: new FormControl('', [Validators.required]),
      emailContact: new FormControl('', [Validators.required, Validators.email]),
      addressC: ['', Validators.required]
    });

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';

    this.reportForm.get("phoneContact").valueChanges.subscribe(value => {
      let oldValue = this.reportForm.value.phoneContact;

      if(value.toString().length > 8){
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

  }

}
