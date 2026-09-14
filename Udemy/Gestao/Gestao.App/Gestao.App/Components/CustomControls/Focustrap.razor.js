// JavaScript for FocusTrap2 component
const FOCUSABLE_SELECTOR = [
    'a[href]',
    'button:not([disabled])',
    'input:not([disabled]):not([type="hidden"])',
    'select:not([disabled])',
    'textarea:not([disabled])',
    '[tabindex]:not([tabindex="-1"])',
    '[contenteditable="true"]'
].join(',');

export function createFocusTrap(container, dotNetRef, options) {
    const { autoFocus, restoreFocus } = options;
    let previouslyFocused = null;
    let keydownHandler = null;

    function isVisible(el) {
        return !!(el.offsetWidth || el.offsetHeight || el.getClientRects().length);
    }

    function getFocusableElements() {
        return Array.from(container.querySelectorAll(FOCUSABLE_SELECTOR))
            .filter(el => isVisible(el) && !el.hasAttribute('data-focustrap-ignore'));
    }

    function handleKeydown(e) {
        if (e.key === 'Escape') {
            dotNetRef.invokeMethodAsync('NotifyEscapePressed');
            return;
        }

        if (e.key !== 'Tab') return;

        const focusable = getFocusableElements();
        if (focusable.length === 0) {
            e.preventDefault();
            return;
        }

        const first = focusable[0];
        const last = focusable[focusable.length - 1];
        const active = document.activeElement;
        const activeIsInside = container.contains(active);

        if (e.shiftKey) {
            // Shift+Tab: se estiver no primeiro (ou fora do trap), volta para o último
            if (!activeIsInside || active === first) {
                e.preventDefault();
                last.focus();
            }
        } else {
            // Tab: se estiver no último (ou fora do trap), volta para o primeiro
            if (!activeIsInside || active === last) {
                e.preventDefault();
                first.focus();
            }
        }
    }

    function activate() {
        previouslyFocused = document.activeElement;

        keydownHandler = handleKeydown;
        // Captura na fase de captura para interceptar antes de outros handlers
        document.addEventListener('keydown', keydownHandler, true);

        if (autoFocus) {
            const focusable = getFocusableElements();
            if (focusable.length > 0) {
                focusable[0].focus();
            } else {
                // Sem elementos focáveis: torna o container focável temporariamente
                container.setAttribute('tabindex', '-1');
                container.focus();
            }
        }
    }

    function deactivate() {
        if (keydownHandler) {
            document.removeEventListener('keydown', keydownHandler, true);
            keydownHandler = null;
        }

        if (restoreFocus && previouslyFocused && document.contains(previouslyFocused)) {
            previouslyFocused.focus();
        }
    }

    function refresh() {
        // Hook para reavaliação futura (ex: reordenar MutationObserver), mantido simples por padrão
    }

    function dispose() {
        deactivate();
    }

    return { activate, deactivate, refresh, dispose };
}