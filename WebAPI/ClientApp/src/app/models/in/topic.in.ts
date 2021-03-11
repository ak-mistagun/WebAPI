import { Topic } from '../topic'

export class TopicIn extends Topic {
    public id?: number;
    
    constructor(
        id?: number,
        name?: string) {
        super(name);
        this.id = id;
    }
}