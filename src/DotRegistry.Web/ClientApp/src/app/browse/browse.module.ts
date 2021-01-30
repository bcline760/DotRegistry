import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BrowseRoutingModule } from './browse-routing.module';
import { ProvidersComponent } from './providers/providers.component';
import { ModulesComponent } from './modules/modules.component';
import { BrowseComponent } from './browse.component';
import { ProviderListComponent } from './providers/provider-list.component';
import { ProviderCategoriesComponent } from './providers/provider-categories.component';


@NgModule({
  declarations: [ProvidersComponent, ModulesComponent, BrowseComponent, ProviderListComponent, ProviderCategoriesComponent],
  imports: [
    CommonModule,
    BrowseRoutingModule
  ]
})
export class BrowseModule { }
