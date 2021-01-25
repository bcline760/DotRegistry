import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpService } from '../../../service/http.service';
import { TokenService } from '../../../service/token.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit, OnDestroy {

  public hasError: boolean;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    protected httpService: HttpService,
    protected tokenService: TokenService
  ) {
    this.hasError = false;
  }

  ngOnDestroy(): void {
  }

  async ngOnInit() {
  }
}
