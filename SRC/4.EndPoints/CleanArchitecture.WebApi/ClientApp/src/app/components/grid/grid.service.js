import { __decorate } from "tslib";
import { Injectable } from "@angular/core";
import AppFilters from "./filter/filters";
import AppOrder from "./order/order";
import AppPage from "./page/page";
let GridService = class GridService {
    http;
    constructor(http) {
        this.http = http;
    }
    get(url, parameters) {
        return this.http.get(url + this.queryString(parameters));
    }
    queryString(parameters) {
        let url = "?";
        parameters.page = parameters.page ?? new AppPage();
        url += `page.index=${parameters.page.index}&`;
        url += `page.size=${parameters.page.size}&`;
        parameters.order = parameters.order ?? new AppOrder();
        url += `order.property=${parameters.order.property ?? ""}&`;
        url += `order.ascending=${parameters.order.ascending}&`;
        parameters.filters = parameters.filters ?? new AppFilters();
        parameters.filters.forEach((filter, index) => {
            url += `filters[${index}].property=${filter.property}&`;
            url += `filters[${index}].comparison=${filter.comparison ?? ""}&`;
            url += `filters[${index}].value=${filter.value}&`;
        });
        url = url.slice(0, url.length - 1);
        return url;
    }
};
GridService = __decorate([
    Injectable({ providedIn: "root" })
], GridService);
export default GridService;
//# sourceMappingURL=grid.service.js.map