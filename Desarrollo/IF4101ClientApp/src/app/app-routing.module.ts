import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddClientComponent} from './components/add-client/add-client.component'
import { IssueComponent } from './components/issue/issue.component';
import { EditClientComponent } from './components/edit-client/edit-client.component';
import { RegisterComponent} from './components/register/register.component'


const routes: Routes = [
  {path: "addReport", component: IssueComponent},
  {path: "add", component: AddClientComponent },
  {path: "register", component: RegisterComponent },
  {path: "edit-client", component: EditClientComponent },
  {path: "**", redirectTo: '/'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
