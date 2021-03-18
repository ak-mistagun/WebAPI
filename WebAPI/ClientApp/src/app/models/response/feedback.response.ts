import {ContactResponse} from "./contact.response";
import {TopicResponse} from "./topic.response";
import {MessageResponse} from "./message.response";

export class FeedbackResponse {
    constructor(
        public id?: number,
        public contact?: ContactResponse,
        public topic?: TopicResponse,
        public message?: MessageResponse) {
    }
}