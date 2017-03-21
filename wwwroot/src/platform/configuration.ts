import { OpaqueToken } from "@angular/core";

/**
 * App configuration
 */
export const APP_CONFIG_TOKEN = new OpaqueToken("app.config");

export interface AppConfig {
    i18nPath: string;
    apiEndpoint: string;
    loginApiEndpoint: string;
    i18nResourceFileFormat: string;
    vkMessageUri : string;
    twitterMessageUri: string;
    hashtag: string
}

export const CONFIG: AppConfig = {
    apiEndpoint: "",
    loginApiEndpoint: "",
    i18nPath: "/assets/i18n",
    i18nResourceFileFormat: ".json",
    vkMessageUri : "https://vk.com/{user}?w=wall{userId}_{networkId}%2Fall",
    twitterMessageUri : "https://twitter.com/{user}/status/{networkId}",
    hashtag: "somesmallmessagefortest"
};

if ("production" === ENV) {
    CONFIG.apiEndpoint = `${location.origin}/api`;
    CONFIG.loginApiEndpoint = "http://localhost:5001/api/";
} else {
    CONFIG.apiEndpoint = "http://localhost:5005/api/";
    CONFIG.loginApiEndpoint = "http://localhost:5001/api/";
}
