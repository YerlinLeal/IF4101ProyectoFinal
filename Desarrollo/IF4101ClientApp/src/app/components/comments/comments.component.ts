import { AfterViewInit, ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';

import { FormBuilder, FormControl, FormGroup, FormsModule, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Observable } from 'rxjs';
import { first } from 'rxjs/operators';
import { Comment } from 'src/app/models/Comment';
import { CommentService } from 'src/app/service/comment/comments.service'

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.css']
})
export class CommentsComponent implements OnInit {
  form: FormGroup;
  loading = false;
  submitted = false;
  initial = true;
  errors = -1;
  commentSelected = -1;

  comments: any = [];

  obs: Observable<any>;
  dataSource: MatTableDataSource<any> = new MatTableDataSource<any>();
  @ViewChild(MatPaginator) paginator: MatPaginator;
  constructor(
    private formBuilder: FormBuilder,
    private commentService: CommentService,
    private formModule: FormsModule,
    private changeDetectorRef: ChangeDetectorRef

  ) { }

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
  }
  get f() { return this.form.controls; }

  onSubmit() {
    this.submitted = true;
    if (this.form.invalid) {
      return;
    }
    this.loading = true;
    this.commentService.register(this.form.value, 1)
      .pipe(first())
      .subscribe(data => {
        console.log(data);
        this.comments.push(data);
        this.dataSource.data = (this.comments)
        this.changeDetectorRef.detectChanges();
        this.obs = this.dataSource.connect();
        this.dataSource.paginator = this.paginator;
        this.loading = false;
        this.form.reset();
        this.submitted = false;
      },
        err => {
          // this.alertService.error(error);
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

    }, (err) => {
      console.log(err);
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
          }, (err) => {
            console.log(err);
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
