import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {FeedbackRequest} from "../models/request/feedback.request";

@Injectable()
export class FeedbackService {
    private url = "api/feedbacks";
    
    constructor(private http: HttpClient) {
    }
    
    sendFeedback(feedback: FeedbackRequest) {
        return this.http.post(this.url, feedback);
    }
}