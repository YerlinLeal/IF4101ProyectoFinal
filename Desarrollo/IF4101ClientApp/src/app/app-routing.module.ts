import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddClientComponent} from './components/add-client/add-client.component'
import { ListIssuesComponent } from './components/list-issues/list-issues.component';
import { RegisterComponent} from './components/register/register.component'


import { IssueComponent } from './components/issue/issue.component';
import { CommentsComponent } from './components/comments/comments.component';
import { EditClientComponent } from './components/edit-client/edit-client.component';


const routes: Routes = [
  {path: "addReport", component: IssueComponent},
  {path: "add", component: AddClientComponent },
  {path: "register", component: RegisterComponent },
  {path: "list-issues", component: ListIssuesComponent },
  {path: "edit-client", component: EditClientComponent },
  {path: "comments", component: CommentsComponent },
  {path: "**", redirectTo: '/'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
