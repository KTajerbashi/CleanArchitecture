var AppInputPasswordComponent_1;
import { __decorate } from "tslib";
import { CommonModule } from "@angular/common";
import { Component, Input } from "@angular/core";
import { FormsModule, ReactiveFormsModule, NG_VALUE_ACCESSOR } from "@angular/forms";
import AppInputComponent from "./input.component";
let AppInputPasswordComponent = AppInputPasswordComponent_1 = class AppInputPasswordComponent extends AppInputComponent {
    autofocus = false;
    class;
    disabled = false;
    formControlName;
    text;
    constructor() {
        super("password");
    }
};
__decorate([
    Input()
], AppInputPasswordComponent.prototype, "autofocus", void 0);
__decorate([
    Input()
], AppInputPasswordComponent.prototype, "class", void 0);
__decorate([
    Input()
], AppInputPasswordComponent.prototype, "disabled", void 0);
__decorate([
    Input()
], AppInputPasswordComponent.prototype, "formControlName", void 0);
__decorate([
    Input()
], AppInputPasswordComponent.prototype, "text", void 0);
AppInputPasswordComponent = AppInputPasswordComponent_1 = __decorate([
    Component({
        selector: "app-input-password",
        templateUrl: "./input.component.html",
        standalone: true,
        providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: AppInputPasswordComponent_1, multi: true }],
        imports: [
            CommonModule,
            FormsModule,
            ReactiveFormsModule
        ]
    })
], AppInputPasswordComponent);
export default AppInputPasswordComponent;
//# sourceMappingURL=password.input.component.js.map