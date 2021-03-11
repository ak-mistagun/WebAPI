import {Component, OnInit} from '@angular/core';
import {FeedbackOut} from "./models/out/feedback.out";
import {FeedbackService} from "./feedback.service";
import {Contact} from "./models/contact";
import {Message} from "./models/message";
import {Topic} from "./models/topic";
import {FeedbackIn} from "./models/in/feedback.in";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {RecaptchaErrorParameters, ReCaptchaV3Service} from "ng-recaptcha";

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [
        FeedbackService
    ]
})
export class AppComponent {
    private feedbackService: FeedbackService;

    form: FormGroup;
    public feedbackIn: FeedbackIn = null; 
    public feedbackOut: FeedbackOut = AppComponent.emptyFeedback();

    private static telephone = "^((\\+7|7|8)+([0-9]){10})$";
    
    constructor(feedbackService: FeedbackService) {
        this.feedbackService = feedbackService;
        
        this.form = new FormGroup({
            "contact.name": new FormControl("", [Validators.required, Validators.minLength(1)]),
            "contact.email": new FormControl("", [Validators.required, Validators.email]),
            "contact.telephone": new FormControl("", [Validators.required, Validators.pattern(AppComponent.telephone)]),
            "topic.name": new FormControl("", Validators.required),
            "message.text": new FormControl("", Validators.required)
        })
        console.log(this.form.invalid);
    }
    
    onSendFeedbackClick() {
        this.feedbackService.sendFeedback(this.feedbackOut)
            .subscribe(value => this.feedbackIn = value);
        console.log(this.feedbackOut)
    }
    public onReset(): void {
        this.feedbackIn = null;
        this.feedbackOut = AppComponent.emptyFeedback();
    }
    
    private static emptyFeedback(): FeedbackOut {
        return  new FeedbackOut(
            new Contact(),
            new Topic(),
            new Message());
    }

    /*    public resolved(captchaResponse: string): void {
        console.log(`Resolved captcha with response: ${captchaResponse}`);
    }
    public onError(errorDetails: RecaptchaErrorParameters): void {
        console.log(`reCAPTCHA error encountered; details:`, errorDetails);
    }*/
}