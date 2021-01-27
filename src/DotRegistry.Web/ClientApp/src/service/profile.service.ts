import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { GithubProfile } from '../models/github-profile.model';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  constructor(protected httpService: HttpService) { }

  async getProfileAsync(): Promise<GithubProfile> | null {
    const url: string = `${window.location.origin}/api/github/user`;

    try {
      const profile: GithubProfile = await this.httpService.getAsync(url);

      return profile;
    } catch (e) {
      return null;
    }
  }
}
