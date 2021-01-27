import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../../service/profile.service';
import { GithubProfile } from '../../models/github-profile.model';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  isAuthenticated = false;
  profile: GithubProfile | null;

  constructor(protected profileSvc: ProfileService) {
  }

  async ngOnInit(): Promise<void> {
    try {
      const profile: GithubProfile = await this.profileSvc.getProfileAsync();
      if (profile != null) {
        this.profile = profile;
        this.isAuthenticated = true;
      }
    } catch (e) {
      this.isAuthenticated = false;
    }
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
