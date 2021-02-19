import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import {IssueService } from 'src/app/service/issue.service';
import {ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-list-issues',
  templateUrl: './list-issues.component.html',
  styleUrls: ['./list-issues.component.css']
})
export class ListIssuesComponent implements AfterViewInit {
  displayedColumns: string[] = ['report_Number', 'service_Id', 'register_Timestamp', 'status'];
  dataSource = new MatTableDataSource<any>();

  element:any=[];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  constructor(public rest: IssueService,  private route: ActivatedRoute,   private router: Router){}

  ngOnInit(): void {
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.getIssues();
  }

  getIssues(){
    this.element=[];
    this.rest.getAll().subscribe((data:{})=>{
    this.element=data;
    this.dataSource.data=(this.element)
    console.log(this.element);

    });
  }
}
