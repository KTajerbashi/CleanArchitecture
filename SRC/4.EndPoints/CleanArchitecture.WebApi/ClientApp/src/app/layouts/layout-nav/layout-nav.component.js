import { __decorate } from "tslib";
import { Component } from "@angular/core";
import { RouterModule } from "@angular/router";
import AppFooterComponent from "src/app/layouts/footer/footer.component";
import AppHeaderComponent from "src/app/layouts/header/header.component";
import AppNavComponent from "src/app/layouts/nav/nav.component";
let AppLayoutNavComponent = class AppLayoutNavComponent {
};
AppLayoutNavComponent = __decorate([
    Component({
        selector: "app-layout-nav",
        templateUrl: "./layout-nav.component.html",
        standalone: true,
        imports: [
            RouterModule,
            AppFooterComponent,
            AppHeaderComponent,
            AppNavComponent
        ]
    })
], AppLayoutNavComponent);
export default AppLayoutNavComponent;
//# sourceMappingURL=layout-nav.component.js.map