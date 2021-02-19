import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddClientComponent} from './components/add-client/add-client.component'
import { EditClientComponent } from './components/edit-client/edit-client.component';
import { RegisterComponent} from './components/register/register.component'


const routes: Routes = [
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
