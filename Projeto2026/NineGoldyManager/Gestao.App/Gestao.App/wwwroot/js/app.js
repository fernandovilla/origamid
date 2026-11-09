function FocusElement(element) {
    console.log("Focus2: ", element);
    if (element instanceof HTMLElement) {
        element.focus();
        console.log("Focus2: OK");
    }
}
