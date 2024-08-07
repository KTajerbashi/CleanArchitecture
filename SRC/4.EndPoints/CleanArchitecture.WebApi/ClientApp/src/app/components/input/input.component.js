import AppComponent from "src/app/components/component";
export default class AppInputComponent extends AppComponent {
    type;
    constructor(type) {
        super();
        this.type = type;
    }
    input($event) {
        this.value = $event.target.value;
    }
}
//# sourceMappingURL=input.component.js.map