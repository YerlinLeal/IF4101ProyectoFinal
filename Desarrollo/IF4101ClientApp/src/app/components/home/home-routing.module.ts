import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from 'src/app/components/_helper/AuthGuard';
import { ListIssuesComponent } from 'src/app/components/list-issues/list-issues.component';
import { IssueComponent } from 'src/app/components/issue/issue.component';
import { CommentsComponent } from 'src/app/components/comments/comments.component';
import { EditClientComponent } from 'src/app/components/edit-client/edit-client.component';
import { HomeComponent } from './home.component';

const routes: Routes = [
    {
        path: '', component: HomeComponent,
        children: [
            {path: 'addReport', component: IssueComponent, canActivate: [AuthGuard]},
            {path: 'list-issues', component: ListIssuesComponent,canActivate: [AuthGuard] },
            {path: 'edit-client', component: EditClientComponent,canActivate: [AuthGuard] },
            {path: 'comments', component: CommentsComponent, canActivate: [AuthGuard]},
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class HomeRoutingModule { }