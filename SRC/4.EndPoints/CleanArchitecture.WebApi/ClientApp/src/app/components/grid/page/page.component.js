import { __decorate } from "tslib";
import { CommonModule } from "@angular/common";
import { Component, EventEmitter, Input, Output } from "@angular/core";
import AppPage from "./page";
let AppPageComponent = class AppPageComponent {
    get count() {
        return this._count;
    }
    set count(count) {
        this._count = count;
        this.setPages();
    }
    get page() {
        return this._page;
    }
    set page(page) {
        this._page = page;
        this.setPages();
    }
    changed = new EventEmitter();
    pages = 0;
    _count = 0;
    _page = new AppPage();
    change(index) {
        this.page.index = index;
        this.changed.emit();
    }
    setPages() {
        this.pages = Math.ceil(this.count / this.page.size);
    }
};
__decorate([
    Input("count")
], AppPageComponent.prototype, "count", null);
__decorate([
    Input("page")
], AppPageComponent.prototype, "page", null);
__decorate([
    Output()
], AppPageComponent.prototype, "changed", void 0);
AppPageComponent = __decorate([
    Component({
        selector: "app-page",
        templateUrl: "./page.component.html",
        standalone: true,
        imports: [
            CommonModule
        ]
    })
], AppPageComponent);
export default AppPageComponent;
//# sourceMappingURL=page.component.js.map