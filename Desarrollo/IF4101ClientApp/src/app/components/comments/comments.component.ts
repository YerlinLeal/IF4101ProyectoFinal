import { Component, OnInit } from '@angular/core';
import { Comment } from 'src/app/models/Comment';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.css']
})
export class CommentsComponent implements OnInit {
  form: FormGroup;
  comments : Comment[]=[
    { "comment_Id": 0, "description": "Available" },
    { "comment_Id": 1, "description": "Available" },
    { "comment_Id": 2, "description": "Available" },
];
 
  constructor(
    private formBuilder: FormBuilder,
  ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      
  });

  }

  onSubmit(){

  }

}
