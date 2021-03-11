import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { AppComponent } from './app.componet';
import { HttpClientModule } from "@angular/common/http";
import {RECAPTCHA_SETTINGS, RECAPTCHA_V3_SITE_KEY, RecaptchaSettings} from "ng-recaptcha";
import { RecaptchaModule, RecaptchaFormsModule } from "ng-recaptcha";

const globalSettings: RecaptchaSettings = { siteKey: '6LcOuyYTAAAAAHTjFuqhA52fmfJ_j5iFk5PsfXaU' };

@NgModule({
    imports: [
        BrowserModule, 
        FormsModule, 
        HttpClientModule, 
        ReactiveFormsModule,
        RecaptchaModule,
        RecaptchaFormsModule
    ],
    declarations: [ AppComponent ],
    bootstrap:    [ AppComponent ],
})
export class AppModule { }