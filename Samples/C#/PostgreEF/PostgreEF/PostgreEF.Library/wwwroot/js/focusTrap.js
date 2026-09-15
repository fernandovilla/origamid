// Ponte entre o componente Blazor <FocusTrap> e a biblioteca focus-trap.
// https://github.com/focus-trap/focus-trap
//
// Por padrão importamos via CDN (ESM), o que dispensa qualquer build de JS.
// Se o seu projeto já usa um bundler (Vite, esbuild, webpack...), troque a
// linha abaixo por:  import { createFocusTrap } from 'focus-trap';
// e rode `npm install focus-trap`.
import { createFocusTrap } from 'https://esm.sh/focus-trap@7';

// Um Map guarda a instância de cada trap ativo, indexado pelo id do
// elemento container. Isso permite múltiplos <FocusTrap> na mesma página.
const traps = new Map();

function toFocusTargetFn(element, selector) {
    // O focus-trap aceita string, elemento ou função. Como o Blazor só nos
    // dá o seletor (string) e o container, resolvemos aqui dentro do escopo
    // do próprio elemento (evita colisão de seletor com outras partes da página).
    return () => element.querySelector(selector) ?? element;
}

export function createTrap(id, element, options, dotNetRef) {
    const opts = { ...(options ?? {}) };

    if (typeof opts.initialFocus === 'string') {
        opts.initialFocus = toFocusTargetFn(element, opts.initialFocus);
    }
    if (typeof opts.fallbackFocus === 'string') {
        opts.fallbackFocus = toFocusTargetFn(element, opts.fallbackFocus);
    }

    if (dotNetRef) {
        opts.onActivate = () => dotNetRef.invokeMethodAsync('HandleActivate');
        opts.onDeactivate = () => dotNetRef.invokeMethodAsync('HandleDeactivate');
    }

    const trap = createFocusTrap(element, opts);
    traps.set(id, trap);
}

export function activate(id) {
    traps.get(id)?.activate();
}

export function deactivate(id) {
    traps.get(id)?.deactivate();
}

export function destroy(id) {
    const trap = traps.get(id);
    if (!trap) return;
    // returnFocus:false porque o componente já pode ter sido desmontado;
    // tentar focar algo nesse ponto pode lançar erro.
    trap.deactivate({ returnFocus: false });
    traps.delete(id);
}
