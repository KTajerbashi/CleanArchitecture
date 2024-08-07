import { CommonModule } from '@angular/common';
import { Component } from "@angular/core";
import AppButtonComponent from "src/app/components/button/button.component";
@Component({
    selector: "app-home",
    templateUrl: "./home.component.html",
    standalone: true,
    imports: [
        CommonModule, // Add CommonModule to imports
        AppButtonComponent
    ],
})
export default class AppHomeComponent {

    data: string[] = ["Kaihan", "Tajerbashi", "Clean Architecture", "CQRS", "DDD"];
    counter: number = 0;

    AddCounter = () => {
        this.counter++;
    }

    SubCounter = () => {
        this.counter--;
    }
    Reset = () => {
        this.counter = 0;
    }
}
