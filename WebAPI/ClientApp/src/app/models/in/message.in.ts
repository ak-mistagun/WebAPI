import { Message } from '../message'

export class MessageIn extends Message {
    public id?: number;
    
    constructor(
        id?: number, 
        text?: string) {
        super(text);
        this.id = id;
    }
}