import { __decorate } from "tslib";
import { CommonModule } from "@angular/common";
import { Component, EventEmitter, Input, Output } from "@angular/core";
import AppOrder from "./order";
let AppOrderComponent = class AppOrderComponent {
    changed = new EventEmitter();
    order;
    property;
    text;
    click() {
        this.order = this.order ?? new AppOrder();
        this.order.property = this.property;
        this.order.ascending = !this.order.ascending;
        this.changed.emit();
    }
};
__decorate([
    Output()
], AppOrderComponent.prototype, "changed", void 0);
__decorate([
    Input()
], AppOrderComponent.prototype, "order", void 0);
__decorate([
    Input()
], AppOrderComponent.prototype, "property", void 0);
__decorate([
    Input()
], AppOrderComponent.prototype, "text", void 0);
AppOrderComponent = __decorate([
    Component({
        selector: "app-order",
        templateUrl: "./order.component.html",
        standalone: true,
        imports: [
            CommonModule
        ]
    })
], AppOrderComponent);
export default AppOrderComponent;
//# sourceMappingURL=order.component.js.map