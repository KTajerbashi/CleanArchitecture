var AppSelectCommentComponent_1;
import { __decorate } from "tslib";
import { CommonModule } from "@angular/common";
import { Component, Input } from "@angular/core";
import { FormsModule, ReactiveFormsModule, NG_VALUE_ACCESSOR } from "@angular/forms";
import { of } from "rxjs";
import { map, mergeMap, toArray } from "rxjs/operators";
import AppSelectComponent from "./select.component";
import AppOption from "./option";
let AppSelectCommentComponent = AppSelectCommentComponent_1 = class AppSelectCommentComponent extends AppSelectComponent {
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
    get(postId) {
        if (!postId)
            return of();
        return this.http
            .get(`https://jsonplaceholder.cypress.io/comments?postId=${postId}`)
            .pipe(mergeMap((option) => option), map((option) => new AppOption(option.id, option.name)), toArray());
    }
};
__decorate([
    Input()
], AppSelectCommentComponent.prototype, "autofocus", void 0);
__decorate([
    Input()
], AppSelectCommentComponent.prototype, "child", void 0);
__decorate([
    Input()
], AppSelectCommentComponent.prototype, "class", void 0);
__decorate([
    Input()
], AppSelectCommentComponent.prototype, "disabled", void 0);
__decorate([
    Input()
], AppSelectCommentComponent.prototype, "formControlName", void 0);
__decorate([
    Input()
], AppSelectCommentComponent.prototype, "text", void 0);
AppSelectCommentComponent = AppSelectCommentComponent_1 = __decorate([
    Component({
        selector: "app-select-comment",
        templateUrl: "./select.component.html",
        standalone: true,
        providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: AppSelectCommentComponent_1, multi: true }],
        imports: [CommonModule, FormsModule, ReactiveFormsModule]
    })
], AppSelectCommentComponent);
export default AppSelectCommentComponent;
//# sourceMappingURL=comment.select.component.js.map