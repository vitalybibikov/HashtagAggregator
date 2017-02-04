import { OpaqueToken } from "@angular/core";

/**
 * App configuration
 */
export const APP_CONFIG_TOKEN = new OpaqueToken("app.config");

export interface AppConfig {
    i18nPath: string;
    apiEndpoint: string;
    i18nResourceFileFormat: string;
}

export const CONFIG: AppConfig = {
    apiEndpoint: "",
    i18nPath: "/assets/i18n",
    i18nResourceFileFormat: ".json"
};

if ("production" === ENV) {
    CONFIG.apiEndpoint = `${location.origin}/api`;
} else {
    CONFIG.apiEndpoint = "http://localhost:5000/api/";
}

