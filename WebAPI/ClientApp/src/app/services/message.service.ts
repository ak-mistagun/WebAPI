import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";

@Injectable()
export class MessageService {
    private api = "api/messages";
    
    constructor(private http: HttpClient) {
    }
    
    public all() {
        return this.http.get(this.api);
    }
}