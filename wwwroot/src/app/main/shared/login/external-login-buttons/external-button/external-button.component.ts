import {
  Component,
  Input,
} from '@angular/core';

import {ExternalProviderData} from "../../../models/external-login-provider";
import {ExternalLoginService} from "../../services/external-login.service";

@Component({
  selector: 'external-button',
  styleUrls: ['external-button.component.scss'],
  templateUrl: 'external-button.component.html'
})
export class ExternalButtonComponent  {

  @Input() externalProvider: ExternalProviderData;
  @Input() returnURL: string;

  constructor(private loginService : ExternalLoginService) {

  }

  public send(returnUrl: string, scheme: string) {
      console.log("send");
      console.log(returnUrl);
      console.log(scheme);
      this.loginService.externalLogIn(returnUrl, scheme);
  }
}
