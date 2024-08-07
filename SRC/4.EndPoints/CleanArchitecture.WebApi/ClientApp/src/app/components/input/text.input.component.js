var AppInputTextComponent_1;
import { __decorate } from "tslib";
import { CommonModule } from "@angular/common";
import { Component, Input } from "@angular/core";
import { FormsModule, ReactiveFormsModule, NG_VALUE_ACCESSOR } from "@angular/forms";
import AppInputComponent from "./input.component";
let AppInputTextComponent = AppInputTextComponent_1 = class AppInputTextComponent extends AppInputComponent {
    autofocus = false;
    class;
    disabled = false;
    formControlName;
    text;
    constructor() {
        super("text");
    }
};
__decorate([
    Input()
], AppInputTextComponent.prototype, "autofocus", void 0);
__decorate([
    Input()
], AppInputTextComponent.prototype, "class", void 0);
__decorate([
    Input()
], AppInputTextComponent.prototype, "disabled", void 0);
__decorate([
    Input()
], AppInputTextComponent.prototype, "formControlName", void 0);
__decorate([
    Input()
], AppInputTextComponent.prototype, "text", void 0);
AppInputTextComponent = AppInputTextComponent_1 = __decorate([
    Component({
        selector: "app-input-text",
        templateUrl: "./input.component.html",
        standalone: true,
        providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: AppInputTextComponent_1, multi: true }],
        imports: [
            CommonModule,
            FormsModule,
            ReactiveFormsModule
        ]
    })
], AppInputTextComponent);
export default AppInputTextComponent;
//# sourceMappingURL=text.input.component.js.map