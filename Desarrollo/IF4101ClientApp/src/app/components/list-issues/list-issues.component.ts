import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import {ActivatedRoute, Router } from '@angular/router';
import { IssueService } from 'src/app/service/issue/issue.service';

@Component({
  selector: 'app-list-issues',
  templateUrl: './list-issues.component.html',
  styleUrls: ['./list-issues.component.css']
})
export class ListIssuesComponent implements AfterViewInit {
  displayedColumns: string[] = ['report_Number', 'service_Id', 'register_Timestamp', 'status','actions'];
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
    this.rest.getById(sessionStorage.getItem("client_Id")).subscribe((data:{})=>{
    this.element=data;
    this.dataSource.data=(this.element)
    console.log(this.element);

    });
  }

  viewDetails(id){
    sessionStorage.setItem("issue_id",id); 
    this.router.navigateByUrl('home/issue-detail', { skipLocationChange: false }).then(() => {
      this.router.navigate(['home/issue-detail']);
  })
  }

}
