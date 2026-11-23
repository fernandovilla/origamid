export function show(dialog, dotNetRef, closeOnBackdropClick) {
    cleanup(dialog);

    // Esc: o navegador fecha o <dialog>, só avisamos o .NET
    const onCancel = () => dotNetRef.invokeMethodAsync("OnDismissed");

    // Clique no fundo: o alvo do clique é o próprio <dialog>, não o conteúdo
    const onClick = (e) => {
        if (closeOnBackdropClick && e.target === dialog) {
            dialog.close();
            dotNetRef.invokeMethodAsync("OnDismissed");
        }
    };

    dialog.addEventListener("cancel", onCancel);
    dialog.addEventListener("click", onClick);
    dialog._cleanup = () => {
        dialog.removeEventListener("cancel", onCancel);
        dialog.removeEventListener("click", onClick);
    };

    if (!dialog.open) dialog.showModal();
}

export function close(dialog) {
    cleanup(dialog);
    if (dialog.open) dialog.close();
}

function cleanup(dialog) {
    dialog._cleanup?.();
    dialog._cleanup = null;
}