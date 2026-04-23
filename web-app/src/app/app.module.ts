import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from "@angular/common/http";
import { LeadListComponent } from './components/lead-list/lead-list.component';
import {FormsModule,ReactiveFormsModule} from "@angular/forms";
import { LeadFormComponent } from './components/lead-form/lead-form.component';
import { TaskManagerComponent } from './components/task-manager/task-manager.component';

@NgModule({
  declarations: [
    AppComponent,
    LeadListComponent,
    LeadFormComponent,
    TaskManagerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
