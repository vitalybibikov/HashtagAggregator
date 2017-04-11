import {
  Component,
  ViewEncapsulation
} from '@angular/core';

import {AppConfigService} from "../../shared/services/config/app-config.service";

@Component({
  selector: 'site-nav',
  encapsulation: ViewEncapsulation.None,
  styleUrls: ['navbar.component.scss'],
  templateUrl: 'navbar.component.html'
})

export class NavbarComponent{

  constructor(private configService: AppConfigService) {
  }

}

