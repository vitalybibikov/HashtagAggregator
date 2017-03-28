import {
  Component, OnInit, OnDestroy
} from '@angular/core';
import {ActivatedRoute, Params, Router} from "@angular/router";
import {AppConfigService} from "../../shared/services/config/app-config.service";
import {Subscription} from "rxjs";
import {AuthService} from "../../shared/services/auth.service";

@Component({
  selector: 'login-callback',
  styleUrls: ['./login-callback.component.scss'],
  templateUrl: './login-callback.component.html',
  providers: [
    AuthService
  ],
})

export class LoginCallbackComponent implements  OnInit, OnDestroy{

  private loginSubscription: Subscription;

  constructor(
    private router : Router,
    private route: ActivatedRoute,
    private configService: AppConfigService,
    private authService : AuthService) {
  }

  ngOnInit(): void {
    this.loginSubscription = this.route.queryParams.subscribe(params => this.saveToken(params));
  }

  ngOnDestroy(): void {
    this.loginSubscription.unsubscribe();
  }

  private saveToken(params : Params): void {

    let idToken = params[this.configService.getApp<string>("tokenName")];
    let expirationTime = params["expires_in"];
    let tokenType = params["token_type"];

    this.authService.saveToken(idToken);
    this.router.navigate(["home"])
  }
}
