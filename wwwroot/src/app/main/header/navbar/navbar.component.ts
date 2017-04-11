import {
  Component
} from '@angular/core';

import {AppConfigService} from "../../shared/services/config/app-config.service";

@Component({
  selector: 'site-nav',
  styleUrls: ['navbar.component.scss'],
  templateUrl: 'navbar.component.html'
})

export class NavbarComponent {

  public isCollapsedContent: boolean = true;

  constructor(private configService: AppConfigService) {

  }
}

