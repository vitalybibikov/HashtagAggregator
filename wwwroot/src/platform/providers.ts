import {
    CONFIG,
    APP_CONFIG_TOKEN,
} from './configuration';
import {AppConfigService} from '../app/shared/services/config/app-config.service';

export const APP_ROUTER_PROVIDERS = [
];

export const CONFIGURATION_PROVIDERS = [
    { provide: APP_CONFIG_TOKEN, useValue: CONFIG },
    { provide: AppConfigService, useClass: AppConfigService }
];

export const APPLICATION_PROVIDERS = [
    { provide: APP_CONFIG_TOKEN, useValue: CONFIG },
    { provide: AppConfigService, useClass: AppConfigService }
];

export const PROVIDERS = [
    ...APPLICATION_PROVIDERS,
    ...CONFIGURATION_PROVIDERS,
    ...APP_ROUTER_PROVIDERS
];

