import {ExternalProviderData} from "./external-login-provider";

export class LoginData {
  rememberMe: boolean;
  enableLocalLogin: boolean;
  externalProviders: ExternalProviderData [];
  externalLoginOnly: boolean;
  userName : string;
  password : string;
  returnUrl : string;
}
