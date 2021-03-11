import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {FeedbackOut} from "./models/out/feedback.out";

@Injectable()
export class FeedbackService {
    private url = "api/feedbacks";
    
    constructor(private http: HttpClient) {
    }
    
    sendFeedback(feedback: FeedbackOut) {
        return this.http.post(this.url, feedback);
    }
}