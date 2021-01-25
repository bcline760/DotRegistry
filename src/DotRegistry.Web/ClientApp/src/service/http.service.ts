import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpRequest } from '@angular/common/http'
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(protected http: HttpClient) {
    this.isCrossOrigin = false;
  }

  /**
   * Get or set this to inform that this is a cross-origin request and set the header
   */
  public isCrossOrigin: boolean;

  /**
   * Get data from the REST API
   * @param url The absolute URL to the REST API
   */
  async getAsync<R>(url: string): Promise<R> {
    return await this._executeHttpMethod(url, "GET");
  }

  /**
   * Send a HTTP PUT to the REST API. This is typically updating data.
   * @param url The absolute URL to the REST API
   * @param body The request body to send
   */
  async putAsync<R, B>(url: string, body: B): Promise<R> {
    return await this._executeHttpMethod(url, "PUT", body);
  }

  /**
   * Send a HTTP POST to the REST API. This is typically for creating data
   * @param url The absolute URL to the REST API
   * @param body The request body to send
   */
  async postAsync<R, B>(url: string, body: B): Promise<R> {
    return await this._executeHttpMethod(url, "POST", body);
  }

  /**
   * Execute a HTTP DELETE on the REST API
   * @param url The absolute URL to the REST API
   */
  async deleteAsync<R>(url: string): Promise<R> {
    return await this._executeHttpMethod(url, "DELETE");
  }

  private async _executeHttpMethod<R, B>(url: string, method: "GET" | "PUT" | "POST" | "DELETE", body?: B): Promise<R> {
    let httpHeaders: HttpHeaders = new HttpHeaders();

    const token: string | null = localStorage.getItem("access_token");
    if (token) {
      httpHeaders = httpHeaders.append('Authorization', `Bearer ${token}`);
    }

    if (!this.isCrossOrigin) {
      httpHeaders = httpHeaders.append('Content-Type', 'application/json');
    }

    let data: R;
    switch (method) {
      case "GET":
        data = await this.http.get<R>(url, {headers: httpHeaders}).toPromise();
        break;
      case "PUT":
        data = await this.http.put<R>(url, body, { headers: httpHeaders }).toPromise();
        break;
      case "POST":
        data = await this.http.post<R>(url, body, {headers: httpHeaders}).toPromise();
        break;
      case "DELETE":
        data = await this.http.delete<R>(url, {headers: httpHeaders}).toPromise();
        break;
    }

    return data;
  }
}
