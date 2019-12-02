export class PageBase {
    errorMessage = '';
    sucessMessage = '';
    cleanMessages() {
        this.errorMessage = '';
        this.sucessMessage = '';
    }
}