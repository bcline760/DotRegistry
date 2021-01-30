import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../../service/http.service';
import { Provider } from '../../../models/provider.model';

@Component({
  selector: 'app-providers',
  templateUrl: './providers.component.html',
  styleUrls: ['./providers.component.scss']
})
export class ProvidersComponent implements OnInit {

  public selectedCategories$: string[];

  constructor() {
    this.selectedCategories$ = [];
  }

  ngOnInit() {
  }

  onCategoryChange($event: Event): void {
  }
}
