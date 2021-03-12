import { Contact } from '../contact'

export class ContactResponse extends Contact {
    public id: number;
    public messageIds: number[];
    
    constructor(
        id?: number,
        name?: string,
        email?: string,
        telephone?: string,
        messageIds?: number[]) {
        super(name, email, telephone);
        this.id = id;
        this.messageIds = messageIds;
    }
}