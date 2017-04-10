import {
  Component,
  ViewEncapsulation
} from '@angular/core';

import { TranslateService } from '@ngx-translate/core';
import {AuthHttp} from "angular2-jwt";
import {AppConfigService} from "./shared/services/config/app-config.service";


@Component({
  selector: 'main-page',
  encapsulation: ViewEncapsulation.None,
  styleUrls: ['main.component.scss'],
  templateUrl: 'main.component.html',
  providers: [TranslateService]
})

export class MainComponent{
  constructor(
    private authHttp: AuthHttp,
    private configService: AppConfigService) {
  }

  public makeAuthCall(){
    let apiUri: string = this.configService.getApp<string>("apiEndpoint");
    this.authHttp.get(`${apiUri}auth`).subscribe(
      data => console.log(data),
      err => console.log(err),
      () => console.log('Request Complete')
    );
  }
}

