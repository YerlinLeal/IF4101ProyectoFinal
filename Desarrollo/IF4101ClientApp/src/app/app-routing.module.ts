import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddClientComponent} from './components/add-client/add-client.component'
import { ListIssuesComponent } from './components/list-issues/list-issues.component';
import { RegisterComponent} from './components/register/register.component'


import { IssueComponent } from './components/issue/issue.component';
import { CommentsComponent } from './components/comments/comments.component';
import { EditClientComponent } from './components/edit-client/edit-client.component';
import { AuthGuard } from './components/_helper/AuthGuard';


const routes: Routes = [
  {path: "login", component: AddClientComponent },
  {path: "addReport", component: IssueComponent, canActivate: [AuthGuard]},
  {path: "register", component: RegisterComponent },
  {path: "list-issues", component: ListIssuesComponent,canActivate: [AuthGuard] },
  {path: "edit-client", component: EditClientComponent,canActivate: [AuthGuard] },
  {path: "comments", component: CommentsComponent, canActivate: [AuthGuard]},
  {path: "**", redirectTo: '/'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
