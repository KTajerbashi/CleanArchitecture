import { CommonModule } from "@angular/common";
import AppButtonComponent from "src/app/components/button/button.component";
import { Component } from "@angular/core";

@Component({
    selector: "app-footer",
    templateUrl: "./footer.component.html",
    standalone: true,
    imports: [
        CommonModule,
        AppButtonComponent,
    ]
})
export default class AppFooterComponent {

    UserProfile() {
        console.log("User Profile Clicked...");
    }
}
