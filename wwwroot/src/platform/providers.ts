import {
  CONFIG,
  APP_CONFIG_TOKEN, VK_CONFIG, VK_CONFIG_TOKEN, TWI_CONFIG_TOKEN, TWI_CONFIG
} from './configuration';
import {AppConfigService} from '../app/main/shared/services/config/app-config.service';

export const APP_ROUTER_PROVIDERS = [
];

export const CONFIGURATION_PROVIDERS = [
    { provide: APP_CONFIG_TOKEN, useValue: CONFIG },
    { provide: AppConfigService, useClass: AppConfigService }
];

export const APPLICATION_PROVIDERS = [
    { provide: APP_CONFIG_TOKEN, useValue: CONFIG },
    { provide: VK_CONFIG_TOKEN, useValue: VK_CONFIG },
    { provide: TWI_CONFIG_TOKEN, useValue: TWI_CONFIG },
    { provide: AppConfigService, useClass: AppConfigService }
];

export const PROVIDERS = [
    ...APPLICATION_PROVIDERS,
    ...CONFIGURATION_PROVIDERS,
    ...APP_ROUTER_PROVIDERS
];

