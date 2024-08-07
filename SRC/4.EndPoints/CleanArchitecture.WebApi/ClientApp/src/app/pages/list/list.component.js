import { __decorate } from "tslib";
import { Component } from "@angular/core";
import AppListGridComponent from "./grid/grid.component";
let AppListComponent = class AppListComponent {
};
AppListComponent = __decorate([
    Component({
        selector: "app-list",
        templateUrl: "./list.component.html",
        standalone: true,
        imports: [
            AppListGridComponent
        ]
    })
], AppListComponent);
export default AppListComponent;
//# sourceMappingURL=list.component.js.map