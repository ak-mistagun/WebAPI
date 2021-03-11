import { Contact } from '../contact'

export class ContactIn extends Contact {
    public id: number;
    
    constructor(
        id?: number,
        name?: string,
        email?: string,
        telephone?: string) {
        super(name, email, telephone);
        this.id = id;
    }
}