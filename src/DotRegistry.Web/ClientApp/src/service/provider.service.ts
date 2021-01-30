import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { Provider } from '../models/provider.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProviderService {

  constructor(protected httpService: HttpService) { }

  getAsync(slug: string): Observable<Provider> {
    try {
      const url: string = `${window.location.origin}/api/provider/${slug}`;
      const provider: Observable<Provider> = this.httpService.getAsync<Provider>(url);

      return provider;
    } catch (e) {
      console.error(e);
      throw e;
    }
  }

  getProvidersByCategoryAsync(categories: string[]): Observable<Provider[]> {
    const params: string | null = (categories.length == 0) ? null : encodeURIComponent(categories.join(','));
    const paramStr: string | null = (params) ? `?pr=${params}` : null;
    const url: string = `${window.location.origin}/api/browse/providers${params}`;

    try {
      const providers: Observable<Provider[]> = this.httpService.getAsync<Provider[]>(url);

      return providers;
    } catch (e) {
      console.error(e);
      throw e;
    }
  }
}
