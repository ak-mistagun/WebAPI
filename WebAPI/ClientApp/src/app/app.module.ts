import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { AppComponent } from './app.componet';
import { HttpClientModule } from "@angular/common/http";
import { RecaptchaModule, RecaptchaFormsModule } from "ng-recaptcha";

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