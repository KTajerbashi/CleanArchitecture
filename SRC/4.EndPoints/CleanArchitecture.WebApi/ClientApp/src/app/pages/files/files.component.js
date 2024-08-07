import { __decorate } from "tslib";
import { CommonModule } from "@angular/common";
import { Component } from "@angular/core";
import { FormsModule } from "@angular/forms";
import AppFileComponent from "src/app/components/file/file.component";
let AppFilesComponent = class AppFilesComponent {
    files = new Array();
};
AppFilesComponent = __decorate([
    Component({
        selector: "app-files",
        templateUrl: "./files.component.html",
        standalone: true,
        imports: [
            CommonModule,
            FormsModule,
            AppFileComponent
        ]
    })
], AppFilesComponent);
export default AppFilesComponent;
//# sourceMappingURL=files.component.js.map