import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { AuthGuard } from './components/_helper/AuthGuard';
const accountModule = () => import('src/app/layout-component/account-module').then(x => x.AccountModule);
const homeModule = () => import('src/app/components/home/home-module').then(x => x.HomeModule);


const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthGuard] },
  {path: 'account', loadChildren: accountModule },
  {path: 'home', loadChildren: homeModule },
  //{path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
