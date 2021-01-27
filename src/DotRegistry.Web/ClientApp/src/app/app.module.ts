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
  {
    path: '',
    loadChildren: () => import('./home/home.module').then(h => HomeModule)
  },
  {
    path: 'browse',
    loadChildren: () => import('./browse/browse.module').then(b => BrowseModule)
  },
  {
    path: 'login',
    loadChildren: () => import('./login/login.module').then(l => LoginModule)
  },
  {
    path: 'profile',
    loadChildren: () => import('./profile/profile.module').then(pr => ProfileModule)
  },
  {
    path: 'publish',
    loadChildren: () => import('./publish/publish.module').then(pu => PublishModule)
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
    RouterModule.forRoot(appRoutes),
    BrowseModule,
    PublishModule,
    ProfileModule
  ],
  providers: [HttpService, ProfileService, ProviderService, AuthGuardService, ModuleService],
  bootstrap: [AppComponent]
})
export class AppModule { }
