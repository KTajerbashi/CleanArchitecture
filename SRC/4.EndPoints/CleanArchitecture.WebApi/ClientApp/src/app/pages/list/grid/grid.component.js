import { __decorate } from "tslib";
import { CommonModule } from "@angular/common";
import { Component, inject } from "@angular/core";
import { FormBuilder, FormControl, ReactiveFormsModule } from "@angular/forms";
import { debounceTime } from "rxjs/operators";
import AppButtonComponent from "src/app/components/button/button.component";
import AppGrid from "src/app/components/grid/grid";
import AppGridParameters from "src/app/components/grid/grid-parameters";
import AppInputTextComponent from "src/app/components/input/text.input.component";
import AppOrderComponent from "src/app/components/grid/order/order.component";
import AppPageComponent from "src/app/components/grid/page/page.component";
let AppListGridComponent = class AppListGridComponent {
    appUserService;
    filters = inject(FormBuilder).group({
        Id: new FormControl(),
        Name: new FormControl(),
        Email: new FormControl()
    });
    grid = new AppGrid();
    constructor(appUserService) {
        this.appUserService = appUserService;
        this.init();
    }
    load() {
        this.appUserService.grid(this.grid.parameters).subscribe((grid) => this.grid = grid);
    }
    filter() {
        this.reset();
        this.grid.parameters.filters.addFromFormGroup(this.filters);
        this.load();
    }
    init() {
        this.reset();
        this.grid.parameters.order.property = "Id";
        this.filters.valueChanges.pipe(debounceTime(0)).subscribe(() => this.filter());
        this.load();
    }
    reset() {
        this.grid = new AppGrid();
        this.grid.parameters = new AppGridParameters();
    }
};
AppListGridComponent = __decorate([
    Component({
        selector: "app-list-grid",
        templateUrl: "./grid.component.html",
        standalone: true,
        imports: [
            CommonModule,
            ReactiveFormsModule,
            AppOrderComponent,
            AppPageComponent,
            AppButtonComponent,
            AppInputTextComponent
        ]
    })
], AppListGridComponent);
export default AppListGridComponent;
//# sourceMappingURL=grid.component.js.map