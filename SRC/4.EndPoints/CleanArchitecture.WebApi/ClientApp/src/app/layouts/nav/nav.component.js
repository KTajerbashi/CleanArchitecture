import { __decorate } from "tslib";
import { Component } from "@angular/core";
import { RouterModule } from "@angular/router";
let AppNavComponent = class AppNavComponent {
    appAuthService;
    constructor(appAuthService) {
        this.appAuthService = appAuthService;
    }
    signout = () => this.appAuthService.signout();
};
AppNavComponent = __decorate([
    Component({
        selector: "app-nav",
        templateUrl: "./nav.component.html",
        standalone: true,
        imports: [
            RouterModule
        ]
    })
], AppNavComponent);
export default AppNavComponent;
//# sourceMappingURL=nav.component.js.map