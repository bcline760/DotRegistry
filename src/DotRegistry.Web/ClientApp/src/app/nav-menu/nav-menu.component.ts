import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../../service/profile.service';
import { GithubProfile } from '../../models/github-profile.model';
import { take } from 'rxjs/operators';

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
    this.profile = null;
  }

  ngOnInit() {
    this.profileSvc.getProfileAsync()
      .pipe(take(1)).subscribe(s => {
        this.profile = s;
      }, error => {
        console.log(error);
        this.profile = null;
      });
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
