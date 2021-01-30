import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BrowseComponent } from './browse.component';
import { ProvidersComponent } from './providers/providers.component';
import { ModulesComponent } from './modules/modules.component';


const routes: Routes = [
  {
    path: '',
    component: BrowseComponent,
    children: [
      {
        path: 'providers',
        component: ProvidersComponent,
        pathMatch: 'full'
      },
      {
        path: 'modules',
        component: ModulesComponent,
        pathMatch: 'full'
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BrowseRoutingModule { }
