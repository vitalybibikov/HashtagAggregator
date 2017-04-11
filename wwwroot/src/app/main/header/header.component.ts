import {
  Component,
  ViewEncapsulation
} from '@angular/core';

import {AppConfigService} from "../shared/services/config/app-config.service";

@Component({
  selector: 'site-header',
  encapsulation: ViewEncapsulation.None,
  styleUrls: ['header.component.scss'],
  templateUrl: 'header.component.html'
})

export class HeaderComponent{

  constructor(private configService: AppConfigService) {
  }

}

