import {
  Component,
  OnInit, OnDestroy, Input,
} from '@angular/core';

import {AppState} from "../../../app.service";
import {ExternalProviderData} from "../../models/external-login-provider";
import {ExternalLoginService} from "../../services/external-login.service";

@Component({
  selector: 'external-button',
  styleUrls: ['external-button.component.scss'],
  templateUrl: 'external-button.component.html'
})
export class ExternalButtonComponent implements OnInit {

  @Input() externalProvider: ExternalProviderData;
  @Input() returnURL: string;

  constructor(public appState: AppState, private loginService : ExternalLoginService) {

  }

  public ngOnInit(): void {

  }

  public send(returnUrl: string, scheme: string) {
      this.loginService.externalLogIn(returnUrl, scheme);
  }
}
