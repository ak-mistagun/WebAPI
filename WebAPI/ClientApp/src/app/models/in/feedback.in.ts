import {ContactIn} from "./contact.in";
import {TopicIn} from "./topic.in";
import {MessageIn} from "./message.in";

export class FeedbackIn {
    constructor(
        public contact?: ContactIn,
        public topic?: TopicIn,
        public message?: MessageIn) {
    }
}