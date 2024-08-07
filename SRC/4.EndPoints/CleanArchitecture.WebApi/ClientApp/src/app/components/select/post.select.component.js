var AppSelectPostComponent_1;
import { __decorate } from "tslib";
import { CommonModule } from "@angular/common";
import { Component, Input } from "@angular/core";
import { FormsModule, ReactiveFormsModule, NG_VALUE_ACCESSOR } from "@angular/forms";
import { of } from "rxjs";
import { map, mergeMap, toArray } from "rxjs/operators";
import AppSelectComponent from "./select.component";
import AppOption from "./option";
let AppSelectPostComponent = AppSelectPostComponent_1 = class AppSelectPostComponent extends AppSelectComponent {
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
    get(userId) {
        if (!userId)
            return of();
        return this.http
            .get(`https://jsonplaceholder.cypress.io/posts?userId=${userId}`)
            .pipe(mergeMap((option) => option), map((option) => new AppOption(option.id, option.title)), toArray());
    }
};
__decorate([
    Input()
], AppSelectPostComponent.prototype, "autofocus", void 0);
__decorate([
    Input()
], AppSelectPostComponent.prototype, "child", void 0);
__decorate([
    Input()
], AppSelectPostComponent.prototype, "class", void 0);
__decorate([
    Input()
], AppSelectPostComponent.prototype, "disabled", void 0);
__decorate([
    Input()
], AppSelectPostComponent.prototype, "formControlName", void 0);
__decorate([
    Input()
], AppSelectPostComponent.prototype, "text", void 0);
AppSelectPostComponent = AppSelectPostComponent_1 = __decorate([
    Component({
        selector: "app-select-post",
        templateUrl: "./select.component.html",
        standalone: true,
        providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: AppSelectPostComponent_1, multi: true }],
        imports: [CommonModule, FormsModule, ReactiveFormsModule]
    })
], AppSelectPostComponent);
export default AppSelectPostComponent;
//# sourceMappingURL=post.select.component.js.map