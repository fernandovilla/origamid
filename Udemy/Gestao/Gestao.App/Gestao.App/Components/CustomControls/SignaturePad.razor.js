// JavaScript for Signaturepad component
// ============================================================
// SignaturePad.razor.js
// Módulo JS isolado do componente SignaturePad.
// Responsável por desenhar no <canvas> usando Pointer Events
// (funciona com touch, mouse e caneta) e exportar/baixar o PNG.
//
// Suporta múltiplas instâncias do componente na mesma página:
// o estado de cada canvas fica isolado em um WeakMap.
// ============================================================

const instances = new WeakMap();

export function initialize(canvasEl, dotNetRef, penColor, penWidth, backgroundColor) {
    const state = {
        dotNetRef,
        penColor,
        penWidth,
        backgroundColor,
        drawing: false,
        hasSignature: false,
        lastX: 0,
        lastY: 0,
        resizeObserver: null
    };

    setupCanvasSize(canvasEl, state);

    const onPointerDown = (e) => startDraw(canvasEl, state, e);
    const onPointerMove = (e) => draw(canvasEl, state, e);
    const onPointerUp = (e) => endDraw(canvasEl, state, e);

    canvasEl.addEventListener('pointerdown', onPointerDown);
    canvasEl.addEventListener('pointermove', onPointerMove);
    canvasEl.addEventListener('pointerup', onPointerUp);
    canvasEl.addEventListener('pointerleave', onPointerUp);
    canvasEl.addEventListener('pointercancel', onPointerUp);

    state.resizeObserver = new ResizeObserver(() => setupCanvasSize(canvasEl, state));
    state.resizeObserver.observe(canvasEl.parentElement);

    state.handlers = { onPointerDown, onPointerMove, onPointerUp };
    instances.set(canvasEl, state);
}

function setupCanvasSize(canvasEl, state) {
    const rect = canvasEl.parentElement.getBoundingClientRect();
    const ratio = window.devicePixelRatio || 1;

    canvasEl.width = Math.max(1, Math.round(rect.width * ratio));
    canvasEl.height = Math.max(1, Math.round(rect.height * ratio));
    canvasEl.style.width = rect.width + 'px';
    canvasEl.style.height = rect.height + 'px';

    const ctx = canvasEl.getContext('2d');
    ctx.setTransform(1, 0, 0, 1, 0, 0);
    ctx.scale(ratio, ratio);
    ctx.fillStyle = state.backgroundColor;
    ctx.fillRect(0, 0, rect.width, rect.height);
    ctx.lineCap = 'round';
    ctx.lineJoin = 'round';
    ctx.strokeStyle = state.penColor;
    ctx.lineWidth = state.penWidth;

    state.ctx = ctx;
    // Redimensionar (ex.: rotação do celular) limpa o traço atual
    // — comportamento simples e previsível.
    state.hasSignature = false;
}

function getPos(canvasEl, e) {
    const rect = canvasEl.getBoundingClientRect();
    return { x: e.clientX - rect.left, y: e.clientY - rect.top };
}

function startDraw(canvasEl, state, e) {
    state.drawing = true;
    const pos = getPos(canvasEl, e);
    state.lastX = pos.x;
    state.lastY = pos.y;

    try { canvasEl.setPointerCapture(e.pointerId); } catch { /* noop */ }

    // Um toque único (sem arrastar) também deve contar como assinatura
    state.ctx.beginPath();
    state.ctx.arc(pos.x, pos.y, state.penWidth / 2, 0, Math.PI * 2);
    state.ctx.fillStyle = state.penColor;
    state.ctx.fill();

    markSignature(state);
}

function draw(canvasEl, state, e) {
    if (!state.drawing) return;

    const pos = getPos(canvasEl, e);
    state.ctx.beginPath();
    state.ctx.moveTo(state.lastX, state.lastY);
    state.ctx.lineTo(pos.x, pos.y);
    state.ctx.stroke();

    state.lastX = pos.x;
    state.lastY = pos.y;

    markSignature(state);
}

function endDraw(canvasEl, state, e) {
    state.drawing = false;
    try { canvasEl.releasePointerCapture(e.pointerId); } catch { /* noop */ }
}

function markSignature(state) {
    if (!state.hasSignature) {
        state.hasSignature = true;
        state.dotNetRef.invokeMethodAsync('OnStrokeChanged', true);
    }
}

export function clear(canvasEl) {
    const state = instances.get(canvasEl);
    if (!state) return;

    const rect = canvasEl.getBoundingClientRect();
    state.ctx.fillStyle = state.backgroundColor;
    state.ctx.fillRect(0, 0, rect.width, rect.height);
    state.hasSignature = false;
}

export function exportAsPng(canvasEl) {
    return canvasEl.toDataURL('image/png');
}

export function downloadAsPng(canvasEl, fileName) {
    const dataUrl = canvasEl.toDataURL('image/png');

    const link = document.createElement('a');
    link.href = dataUrl;
    link.download = fileName || 'assinatura.png';
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

export function dispose(canvasEl) {
    const state = instances.get(canvasEl);
    if (!state) return;

    state.resizeObserver?.disconnect();
    const { onPointerDown, onPointerMove, onPointerUp } = state.handlers;
    canvasEl.removeEventListener('pointerdown', onPointerDown);
    canvasEl.removeEventListener('pointermove', onPointerMove);
    canvasEl.removeEventListener('pointerup', onPointerUp);
    canvasEl.removeEventListener('pointerleave', onPointerUp);
    canvasEl.removeEventListener('pointercancel', onPointerUp);

    instances.delete(canvasEl);
}
