import { MediaType } from '../enums/social-media.enum'

export class Message {
    id : number;
    body : string;
    hashTag : string;
    mediaType : number;
    postDate : Date
}