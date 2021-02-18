import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddClientComponent} from './components/add-client/add-client.component'
import { RegisterComponent} from './components/register/register.component'


const routes: Routes = [
  {path: "add", component: AddClientComponent },
  {path: "register", component: RegisterComponent },
  {path: "**", redirectTo: '/'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
