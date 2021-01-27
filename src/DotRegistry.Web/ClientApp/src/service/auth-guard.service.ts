import { UrlTree, Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from "rxjs";
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {

  constructor(protected httpService: HttpService) { }
    async canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<boolean | UrlTree> {
        throw new Error("Method not implemented.");
    }
}
