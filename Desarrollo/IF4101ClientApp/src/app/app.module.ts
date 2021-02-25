import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";


import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MainNavComponent } from './components/main-nav/main-nav.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import {MatSelectModule} from '@angular/material/select';
import { AddClientComponent } from './components/add-client/add-client.component';
import { RegisterComponent } from './components/register/register.component';
import { AlertComponent } from './components/alert/alert.component';
import { ListIssuesComponent } from './components/list-issues/list-issues.component';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatTableModule} from '@angular/material/table';
import {MatSortModule} from '@angular/material/sort';
import { RouterModule, Routes } from '@angular/router';
import { IssueComponent } from './components/issue/issue.component';
import { EditClientComponent } from './components/edit-client/edit-client.component';
import { CommentsComponent } from './components/comments/comments.component';
import { SelectServicesComponent } from './components/select-services/select-services.component';
import { AuthHtppInterceptorService } from './service/Interceptor/auth-htpp-interceptor.service';



const appRoutes: Routes = [
  
  {path: 'lista',
  component: ListIssuesComponent,
  data: { title: 'Issue List' }
  },
  {
    path: 'pagination',
    component: ListIssuesComponent,
    data: { title: 'Issue List' }
  },
  { path: '',
    redirectTo: '/pagination',
    pathMatch: 'full'
  }
];
@NgModule({
  declarations: [
    AppComponent,
    MainNavComponent,
    AddClientComponent,
    IssueComponent,
    RegisterComponent,
    AlertComponent,
    ListIssuesComponent,
    EditClientComponent,
    CommentsComponent,
    SelectServicesComponent
  ],
  imports: [
    RouterModule.forRoot(appRoutes),
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatSelectModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatPaginatorModule,
    MatTableModule,
    MatSortModule,
    RouterModule,
    
    FormsModule
  ],
  providers: [{
    provide:HTTP_INTERCEPTORS, useClass:AuthHtppInterceptorService, multi:true
  }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
