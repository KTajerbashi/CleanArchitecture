import { __decorate } from "tslib";
import { Component } from "@angular/core";
import { RouterModule } from "@angular/router";
import AppFooterComponent from "src/app/layouts/footer/footer.component";
import AppHeaderComponent from "src/app/layouts/header/header.component";
let AppLayoutComponent = class AppLayoutComponent {
};
AppLayoutComponent = __decorate([
    Component({
        selector: "app-layout",
        templateUrl: "./layout.component.html",
        standalone: true,
        imports: [
            RouterModule,
            AppFooterComponent,
            AppHeaderComponent
        ]
    })
], AppLayoutComponent);
export default AppLayoutComponent;
//# sourceMappingURL=layout.component.js.map