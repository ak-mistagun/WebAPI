import {Component, OnInit} from '@angular/core';
import {FeedbackRequest} from "./models/request/feedback.request";
import {FormControl, FormGroup, Validators} from "@angular/forms";

import {Contact} from "./models/contact";
import {Message} from "./models/message";
import {Topic} from "./models/topic";

import {FeedbackService} from "./services/feedback.service";
import {TopicService} from "./services/topic.service";
import {ContactService} from "./services/contact.service";
import {MessageService} from "./services/message.service";

import {FeedbackResponse} from "./models/response/feedback.response";
import {TopicResponse} from "./models/response/topic.response";
import {ContactResponse} from "./models/response/contact.response";
import {MessageResponse} from "./models/response/message.response";

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [
        FeedbackService,
        ContactService,
        TopicService,
        MessageService
    ]
})
export class AppComponent implements OnInit {
    private feedbackService: FeedbackService;
    private contactService: ContactService;
    private topicService: TopicService;
    private messageService: MessageService;

    public type: string; // contacts, topics, messages, feedbacks, new.
    public form: FormGroup;
    
    public contacts: ContactResponse[] = [];
    public topics: TopicResponse[] = [];
    public messages: MessageResponse[] = [];
    public feedbackResponses: FeedbackResponse[] = [];

    public feedbackRequest: FeedbackRequest = AppComponent.emptyFeedbackRequest();
    
    private static telephone = "^((\\+7|7|8)+([0-9]){10})$";
    
    constructor(feedbackService: FeedbackService, 
                contactService: ContactService, 
                topicService: TopicService, 
                messageService: MessageService) {
        this.feedbackService = feedbackService;
        this.contactService = contactService;
        this.topicService = topicService;
        this.messageService = messageService;
        
        this.form = new FormGroup({
            "contact.name": new FormControl("", [Validators.required, Validators.minLength(1)]),
            "contact.email": new FormControl("", [Validators.required, Validators.email]),
            "contact.telephone": new FormControl("", [Validators.required, Validators.pattern(AppComponent.telephone)]),
            "topic.name": new FormControl(null, Validators.nullValidator),
            "message.text": new FormControl("", Validators.required)
        })
        this.type = "new";
    }
    
    onSendFeedbackClick() {
        this.feedbackService.sendFeedback(this.feedbackRequest)
            .subscribe(value => this.feedbackResponses.push(value));
        this.onFeedbackClick();
    }
    
    private static emptyFeedbackRequest(): FeedbackRequest {
        return  new FeedbackRequest(
            new Contact(),
            new Topic(),
            new Message());
    }

    public ngOnInit(): void {
        this.topicService.all()
            .subscribe(value => this.topics = value as TopicResponse[]);
        this.feedbackService.all()
            .subscribe(value => this.feedbackResponses = value as FeedbackResponse[]);
    }

    onSelectedChange(event: any) {
        this.feedbackRequest.topic.name = event.target.value;
    }
    
    public onContactClick() {
        this.contactService.all()
            .subscribe(value => this.contacts = value as ContactResponse[]);
        this.type = 'contacts';
    }
    
    public onTopicClick() {
        this.topicService.all()
            .subscribe(value => this.topics = value as TopicResponse[]);
        this.type = 'topics';
    }
    
    public onMessageClick() {
        this.messageService.all()
            .subscribe(value => this.messages = value as MessageResponse[]);
        this.type = 'messages';
    }
    
    public onFeedbackClick() {
        this.feedbackService.all()
            .subscribe(value => this.feedbackResponses = value as FeedbackResponse[]);
        this.type = 'feedbacks';
    }
    
    public onNewClick() {
        this.feedbackRequest = AppComponent.emptyFeedbackRequest();
        this.type = 'new';
    }
}