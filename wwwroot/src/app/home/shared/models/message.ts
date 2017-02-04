import { SocialMedia } from '../enums/social-media.enum'

export class Message {
    id : number;
    body : string;
    hashtag : string;
    socialMedia : SocialMedia;
    postDate : Date
}