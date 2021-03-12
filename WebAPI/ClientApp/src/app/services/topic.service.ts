import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";

@Injectable()
export class TopicService {
    private api = "api/topics";
    
    constructor(private http: HttpClient) {
    }
    
    public all() {
        return this.http.get(this.api);
    }
}