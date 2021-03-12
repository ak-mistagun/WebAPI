import { Message } from '../message'

export class MessageResponse extends Message {
    public id?: number;
    public contactId?: number;
    public topicId?: number;
    
    constructor(
        id?: number, 
        text?: string,
        topicId?: number,
        contactId?: number) {
        super(text);
        this.id = id;
        this.topicId = topicId;
        this.contactId = contactId;
    }
}