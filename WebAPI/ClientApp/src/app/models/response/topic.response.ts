import { Topic } from '../topic'

export class TopicResponse extends Topic {
    public id?: number;
    
    constructor(
        id?: number,
        name?: string) {
        super(name);
        this.id = id;
    }
}