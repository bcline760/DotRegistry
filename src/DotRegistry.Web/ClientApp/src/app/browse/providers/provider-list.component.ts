import { Component, OnInit, Input } from '@angular/core';
import { ProviderService } from '../../../service/provider.service';
import { Provider } from '../../../models/provider.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-provider-list',
  templateUrl: './provider-list.component.html',
  styleUrls: ['./provider-list.component.scss']
})
export class ProviderListComponent implements OnInit {
  @Input() selectedCategories: string[]

  public providers: Observable<Provider[]> | null;

  constructor(protected providerService:ProviderService) {
    this.selectedCategories = [];
    this.providers = null;
  }

  ngOnInit() {
    this.getProviders();
  }

  getProviders(): void {
    this.providers = this.providerService.getProvidersByCategoryAsync(this.selectedCategories);
  }
}
