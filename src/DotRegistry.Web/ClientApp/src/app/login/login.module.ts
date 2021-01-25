import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoginRoutingModule } from './login-routing.module';
import { SigninComponent } from './signin/signin.component';
import { LoginComponent } from './login.component';


@NgModule({
  declarations: [SigninComponent, LoginComponent],
  imports: [
    CommonModule,
    LoginRoutingModule
  ],
  entryComponents: [SigninComponent]
})
export class LoginModule { }
