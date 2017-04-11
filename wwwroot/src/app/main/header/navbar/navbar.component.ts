import {
  Component,
  ViewEncapsulation
} from '@angular/core';

import {AppConfigService} from "../../shared/services/config/app-config.service";

@Component({
  selector: 'site-nav',
  styleUrls: ['navbar.component.scss'],
  encapsulation: ViewEncapsulation.None,
  templateUrl: 'navbar.component.html'
})

export class NavbarComponent{

  private isCollapsedContent: boolean = true;

  constructor(private configService: AppConfigService) {
  }

}

