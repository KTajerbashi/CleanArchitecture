import { __decorate } from "tslib";
import { CommonModule } from "@angular/common";
import { Component, inject } from "@angular/core";
import { FormBuilder, ReactiveFormsModule, Validators } from "@angular/forms";
import AppButtonComponent from "src/app/components/button/button.component";
import AppInputPasswordComponent from "src/app/components/input/password.input.component";
import AppInputTextComponent from "src/app/components/input/text.input.component";
import AppLabelComponent from "src/app/components/label/label.component";
let AppAuthComponent = class AppAuthComponent {
    appAuthService;
    form = inject(FormBuilder).group({
        login: ["admin", Validators.required],
        password: ["admin", Validators.required]
    });
    constructor(appAuthService) {
        this.appAuthService = appAuthService;
    }
    auth() {
        this.appAuthService.auth(this.form.value);
    }
};
AppAuthComponent = __decorate([
    Component({
        selector: "app-auth",
        templateUrl: "./auth.component.html",
        standalone: true,
        imports: [
            CommonModule,
            ReactiveFormsModule,
            AppButtonComponent,
            AppInputPasswordComponent,
            AppInputTextComponent,
            AppLabelComponent
        ]
    })
], AppAuthComponent);
export default AppAuthComponent;
//# sourceMappingURL=auth.component.js.map