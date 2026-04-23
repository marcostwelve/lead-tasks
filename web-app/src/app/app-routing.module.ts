import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LeadFormComponent } from './components/lead-form/lead-form.component';
import { LeadListComponent } from './components/lead-list/lead-list.component';
import { TaskManagerComponent } from './components/task-manager/task-manager.component';
const routes: Routes = [
  { path: '', redirectTo: '/leads', pathMatch: 'full' },
  { path: 'leads', component: LeadListComponent },
  { path: 'leads/new', component: LeadFormComponent },
  { path: 'leads/edit/:id', component: LeadFormComponent },
  { path: 'leads/:leadId/tasks', component: TaskManagerComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
