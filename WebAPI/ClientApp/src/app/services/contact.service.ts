import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";

@Injectable()
export class ContactService {
    private api = "api/contacts";
    
    constructor(private http: HttpClient) {
    }
    
    public all() {
        return this.http.get(this.api);
    }
}