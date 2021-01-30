import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-provider-categories',
  templateUrl: './provider-categories.component.html',
  styleUrls: ['./provider-categories.component.scss']
})
export class ProviderCategoriesComponent implements OnInit {
  @Output() categoriesChanged = new EventEmitter<string[] | null>();
  public selectedCategoriesList: string[] | null;
  constructor() {
    this.selectedCategoriesList = [];
  }

  ngOnInit() {
  }

  onSelectedCategory(): void {
    this.categoriesChanged.emit(this.selectedCategoriesList);
  }
}
