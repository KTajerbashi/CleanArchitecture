var AppSelectUserComponent_1;
import { __decorate } from "tslib";
import { CommonModule } from "@angular/common";
import { Component, Input } from "@angular/core";
import { FormsModule, ReactiveFormsModule, NG_VALUE_ACCESSOR } from "@angular/forms";
import { map, mergeMap, toArray } from "rxjs/operators";
import AppSelectComponent from "./select.component";
import AppOption from "./option";
let AppSelectUserComponent = AppSelectUserComponent_1 = class AppSelectUserComponent extends AppSelectComponent {
    http;
    autofocus = false;
    child;
    class;
    disabled = false;
    formControlName;
    text;
    constructor(http) {
        super();
        this.http = http;
        this.load();
    }
    get(_) {
        return this.http
            .get("https://jsonplaceholder.cypress.io/users")
            .pipe(mergeMap((option) => option), map((option) => new AppOption(option.id, option.name)), toArray());
    }
};
__decorate([
    Input()
], AppSelectUserComponent.prototype, "autofocus", void 0);
__decorate([
    Input()
], AppSelectUserComponent.prototype, "child", void 0);
__decorate([
    Input()
], AppSelectUserComponent.prototype, "class", void 0);
__decorate([
    Input()
], AppSelectUserComponent.prototype, "disabled", void 0);
__decorate([
    Input()
], AppSelectUserComponent.prototype, "formControlName", void 0);
__decorate([
    Input()
], AppSelectUserComponent.prototype, "text", void 0);
AppSelectUserComponent = AppSelectUserComponent_1 = __decorate([
    Component({
        selector: "app-select-user",
        templateUrl: "./select.component.html",
        standalone: true,
        providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: AppSelectUserComponent_1, multi: true }],
        imports: [CommonModule, FormsModule, ReactiveFormsModule]
    })
], AppSelectUserComponent);
export default AppSelectUserComponent;
//# sourceMappingURL=user.select.component.js.map