export function show(element, options) {
    if (!element) return;
    const toast = bootstrap.Toast.getOrCreateInstance(element, options);
    toast.show();
}

export function hide(element) {
    if (!element) return;
    const toast = bootstrap.Toast.getInstance(element);
    toast?.hide();
}

export function dispose(element) {
    if (!element) return;
    const toast = bootstrap.Toast.getInstance(element);
    toast?.dispose();
}