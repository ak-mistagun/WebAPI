import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {FeedbackRequest} from "../models/request/feedback.request";

@Injectable()
export class FeedbackService {
    private url = "api/feedbacks";
    
    constructor(private http: HttpClient) {
    }
    
    public all() {
        return this.http.get(this.url);
    }
    
    sendFeedback(feedback: FeedbackRequest) {
        return this.http.post(this.url, feedback);
    }
}