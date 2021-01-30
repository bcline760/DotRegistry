import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';

import { LoginModule } from './login/login.module';
import { HomeModule } from './home/home.module';
import { BrowseModule } from './browse/browse.module';
import { PublishModule } from './publish/publish.module';
import { ProfileModule } from './profile/profile.module';

import { ProfileService } from '../service/profile.service';
import { ProviderService } from '../service/provider.service';
import { AuthGuardService } from '../service/auth-guard.service';
import { ModuleService } from '../service/module.service';
import { HttpService } from '../service/http.service';

const appRoutes: Routes = [
  { path: '', loadChildren: () => import('./home/home.module').then(h => h.HomeModule) },
  { path: 'browse', loadChildren: () => import('./browse/browse.module').then(b => b.BrowseModule) },
  { path: 'login', loadChildren: () => import('./login/login.module').then(l => l.LoginModule) },
  { path: 'profile', loadChildren: () => import('./profile/profile.module').then(pr => pr.ProfileModule) },
  { path: 'publish', loadChildren: () => import('./publish/publish.module').then(pu => pu.PublishModule) }
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
    BrowseModule,
    PublishModule,
    ProfileModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [HttpService, ProfileService, ProviderService, AuthGuardService, ModuleService],
  bootstrap: [AppComponent]
})
export class AppModule { }
