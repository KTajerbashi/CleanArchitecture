import { __decorate } from "tslib";
import { Component, Input } from "@angular/core";
let AppButtonComponent = class AppButtonComponent {
    disabled = false;
    text;
};
__decorate([
    Input()
], AppButtonComponent.prototype, "disabled", void 0);
__decorate([
    Input()
], AppButtonComponent.prototype, "text", void 0);
AppButtonComponent = __decorate([
    Component({
        selector: "app-button",
        templateUrl: "./button.component.html",
        standalone: true
    })
], AppButtonComponent);
export default AppButtonComponent;
//# sourceMappingURL=button.component.js.map