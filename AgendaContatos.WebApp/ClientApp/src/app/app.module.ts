import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { NewContactComponent } from './new-contact/new-contact.component';
import { MessageOperationComponent } from './message-operation/message-operation.component';
import { MessageOperationService } from './services/message-operation.service';
import { ContactTypeService } from './services/contact-type.service';
import { ContactService } from './services/contact.service';
import { EditContactComponent } from './edit-contact/edit-contact.component';
import { ContactPhoneService } from './services/contact-phone.service';
import { ContactMailService } from './services/contact-mail.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    NewContactComponent,
    MessageOperationComponent,
    EditContactComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' }  ,
      { path: 'new', component: NewContactComponent, pathMatch: 'full' },        
      { path: 'edit/:id', component: EditContactComponent, pathMatch: 'full' }        
    ])
  ],
  providers: [MessageOperationService,ContactTypeService,ContactService,ContactPhoneService,ContactMailService],
  bootstrap: [AppComponent]
})
export class AppModule { }
