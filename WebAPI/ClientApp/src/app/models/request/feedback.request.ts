import { Contact } from "../contact";
import { Topic } from "../topic";
import { Message } from '../message';

export class FeedbackRequest {
    public constructor(
        public contact?: Contact,
        public topic?: Topic,
        public message?: Message) {}
}