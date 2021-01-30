import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { GithubProfile } from '../models/github-profile.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  constructor(protected httpService: HttpService) { }

  getProfileAsync(): Observable<GithubProfile> {
    const url: string = `${window.location.origin}/api/github/user`;
    const profile: Observable<GithubProfile> = this.httpService.getAsync(url);

    return profile;
  }
}
