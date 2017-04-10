import {InjectionToken} from "@angular/core";

/**
 * App configuration
 */
export const APP_CONFIG_TOKEN = new InjectionToken<AppConfig>("app.config");
export const VK_CONFIG_TOKEN = new InjectionToken<VkConfig>("vk.config");
export const TWI_CONFIG_TOKEN = new InjectionToken<TwiConfig>("twi.config");


export interface AppConfig {
    i18nPath: string;
    apiEndpoint: string;
    loginApiEndpoint: string;
    i18nResourceFileFormat: string;
    hashtag: string;
    idTokenName: string;
    accessTokenName: string;
    clientId: string;
    defaultAvatar: string;
}

export interface VkConfig {
    vkMessageUri : string;
}

export interface TwiConfig {
  twitterMessageUri : string;
}

export const CONFIG: AppConfig = {
    i18nPath: "/assets/i18n",
    apiEndpoint: "",
    loginApiEndpoint: "",
    i18nResourceFileFormat: ".json",
    idTokenName: "id_token",
    accessTokenName: "access_token",
    hashtag: "microsoft", //somesmallmessagefortest1
    clientId: "statisticsapiclient",
    defaultAvatar: "http://abs.twimg.com/sticky/default_profile_images/default_profile_normal.png"
};

export const VK_CONFIG: VkConfig = {
    vkMessageUri : "https://vk.com/{user}?w=wall{userId}_{networkId}%2Fall"
};

export const TWI_CONFIG: TwiConfig = {
  twitterMessageUri : "https://twitter.com/{user}/status/{networkId}"
};

if ("prod" === ENV) {
    CONFIG.apiEndpoint = 'http://hashtagaggregator.azurewebsites.net/api/';
    CONFIG.loginApiEndpoint = "http://silichyexchangeidentity.azurewebsites.net/";
} else {
    CONFIG.apiEndpoint = "http://localhost:5005/api/";
    CONFIG.loginApiEndpoint = "http://localhost:5001/";
}
