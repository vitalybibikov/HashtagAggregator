import {
  Component,
  OnInit,
  OnDestroy,
} from '@angular/core';

import {AppState} from "../../app.service";
import {ExternalLoginService} from "../services/external-login.service";
import {LoginData} from "../models/login-data";
import {Subscription} from "rxjs";
import {ExternalProviderData} from "../models/external-login-provider";

@Component({
  selector: 'external-login-buttons',
  styleUrls: ['external-login-buttons.component.scss'],
  templateUrl: 'external-login-buttons.component.html',
  providers: [ExternalLoginService]
})
export class ExternalLoginButtonsComponent implements OnInit, OnDestroy {

  private loginData: LoginData;
  private externalProviders: ExternalProviderData [];
  private loginSubscription: Subscription;

  constructor(public appState: AppState, private externalLoginService: ExternalLoginService) {

  }

  public ngOnInit(): void {
    this.loginSubscription = this.externalLoginService.getExternalLogins()
      .subscribe(
        (loginData) => {
            this.loginData = loginData;
            this.externalProviders = loginData.externalProviders}
      );
  }

  public ngOnDestroy(): void {
    this.loginSubscription.unsubscribe();
  }
}
