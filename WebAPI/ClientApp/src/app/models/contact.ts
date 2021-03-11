export class Contact {
    public name?: string;
    public email?: string;
    public telephone?: string;
    
    constructor(
        name?: string, 
        email?: string, 
        telephone?: string) {
        this.name = name; 
        this.email = email;
        this.telephone = telephone;
    }
}