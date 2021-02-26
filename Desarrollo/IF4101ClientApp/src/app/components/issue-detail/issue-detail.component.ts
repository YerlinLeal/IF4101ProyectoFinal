import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { from, Observable } from 'rxjs';
import { first } from 'rxjs/operators';
import { CommentService } from 'src/app/service/comment/comments.service';
import { IssueService } from 'src/app/service/issue/issue.service'


@Component({
  selector: 'app-issue-detail',
  templateUrl: './issue-detail.component.html',
  styleUrls: ['./issue-detail.component.css']
})
export class IssueDetailComponent implements OnInit {
  form: FormGroup;
  loading = false;
  submitted = false;
  initial = true;
  errors = -1;
  commentSelected = -1;
  issued_Id : number;
  comments: any = [];
  formIssue: FormGroup;
  obs: Observable<any>;
  dataSource: MatTableDataSource<any> = new MatTableDataSource<any>();
  @ViewChild(MatPaginator) paginator: MatPaginator;
  constructor(
    private formBuilder: FormBuilder,
    private commentService: CommentService,
    private formModule: FormsModule,
    private changeDetectorRef: ChangeDetectorRef,
    private issueService: IssueService,
    private snackbar: MatSnackBar

  ) { 
    this.formIssue = this.formBuilder.group({
      description: ['', Validators.required],
      creation_Date: ['', Validators.required],
      state: ['', Validators.required],
      report_Number: ['', Validators.required],
    });

  }

  ngAfterViewInit() {
    this.comments = [];

    this.commentService.getAll().subscribe((data: {}) => {
      this.loading = false;
      this.comments = data;
      this.dataSource.data = (this.comments)
      this.changeDetectorRef.detectChanges();
      this.obs = this.dataSource.connect();
      this.dataSource.paginator = this.paginator;
    })
  }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      description: ['', Validators.required],
    });
    this.issueService.getIssueInfo(sessionStorage.getItem("issue_id")).pipe(first())
    .subscribe(x => {
      if(x.status == 'I') x.status='Sent'
      else if(x.status == 'A') x.status = 'Asigned'
      else if(x.status == 'P') x.status = 'In Process'
      else x.status = 'Resolved'
      this.formIssue.patchValue({
        description : x.description,
        state: x.status,
        creation_Date: x.creation_Date,
        report_Number: x.report_Number
      });

    });
    this.formIssue.disable();
  }
  get f() { return this.form.controls; }

  onSubmit() {
    this.submitted = true;
    if (this.form.invalid) {
      return;
    }
    this.loading = true;
    this.commentService.register(this.form.value, sessionStorage.getItem("issue_id"))
      .pipe(first())
      .subscribe(data => {
        this.comments.push(data);
        this.dataSource.data = (this.comments)
        this.changeDetectorRef.detectChanges();
        this.obs = this.dataSource.connect();
        this.dataSource.paginator = this.paginator;
        this.loading = false;
        this.form.reset();
        this.submitted = false;
        this.snackbar.open("Successfully Register!", "OK!", {
          duration: 5000,
          panelClass: ['red-snackbar', 'login-snackbar'],
        });
      },
        err => {
          this.snackbar.open("An error has occurred", "Try Again!", {
            duration: 4000,
            panelClass: ['red-snackbar', 'login-snackbar'],
          });
          this.loading = false;
        }
      );
  }

  removeComment(id) {
    this.commentService.delete(id).subscribe((result) => {
      this.removeCommentFromDOM(id);
      this.dataSource.data = (this.comments)
      this.changeDetectorRef.detectChanges();
      this.obs = this.dataSource.connect();
      this.dataSource.paginator = this.paginator;
      this.snackbar.open("Successfully removed!", "OK!", {
        duration: 4000,
        panelClass: ['green-snackbar', 'login-snackbar'],
      });
    }, (err) => {
      this.snackbar.open("An error has occurred", "Try Again!", {
        duration: 4000,
        panelClass: ['red-snackbar', 'login-snackbar'],
      });
    });
  }

  editComment(id) {
    this.initial = false;
    this.commentSelected = id;
  }

  removeCommentFromDOM(id: number) {
    this.comments.forEach((value, index) => {
      if (value.comment_Id == id) this.comments.splice(index, 1);
    });
  }

  updateComment(id: number) {

    let desc = (document.getElementById("description-" + id) as HTMLTextAreaElement).value;
    if (desc.length > 0) {
      this.comments.forEach((value, index) => {
        if (value.comment_Id == id) {
          this.comments[index].description = desc;
          this.commentService.update(this.comments[index]).subscribe((result) => {
            this.comments = [...this.comments];
            this.initial = true;
            this.snackbar.open("Successfully Update!", "OK!", {
              duration: 5000,
              verticalPosition: 'top'
            });
          }, (err) => {
            this.snackbar.open("An error has occurred", "Try Again!", {
              duration: 4000,
              panelClass: ['red-snackbar', 'login-snackbar'],
            });
          });
        }
      });
    } else {
      this.errors = id;
    }

  }

  backComment() {
    this.initial = true;
    this.errors = -1;
  }
}