import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { LoginModule } from './login/login.module';
import { HttpService } from '../service/http.service';
import { TokenService } from '../service/token.service';
import { HomeModule } from './home/home.module';

const appRoutes: Routes = [
  {
    path: '',
    loadChildren: () => import('./home/home.module').then(h=>HomeModule)
  },
  {
    path: 'login',
    loadChildren: () => import('./login/login.module').then(l => LoginModule)
  }
];

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    HomeModule,
    LoginModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [HttpService, TokenService],
  bootstrap: [AppComponent]
})
export class AppModule { }
