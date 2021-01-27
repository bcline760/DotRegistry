import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { Provider } from '../models/provider.model';

@Injectable({
  providedIn: 'root'
})
export class ProviderService {

  constructor(protected httpService: HttpService) { }

  async getAsync(slug: string): Promise<Provider> {
    try {
      const url: string = `${window.location.origin}/api/provider/${slug}`;
      const provider: Provider = await this.httpService.getAsync<Provider>(url);

      return provider;
    } catch (e) {
      console.error(e);
      throw e;
    }
  }
}
