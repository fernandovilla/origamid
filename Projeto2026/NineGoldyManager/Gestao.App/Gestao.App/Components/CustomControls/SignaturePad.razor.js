const pads = new WeakMap();

function paintWhite(canvas, context) {
    context.fillStyle = "#fff";
    context.fillRect(0, 0, canvas.clientWidth, canvas.clientHeight);
}

function resize(canvas, context, state) {
    const bounds = canvas.getBoundingClientRect();
    const pixelRatio = window.devicePixelRatio || 1;
    const width = Math.max(1, Math.round(bounds.width * pixelRatio));
    const height = Math.max(1, Math.round(bounds.height * pixelRatio));

    if (canvas.width === width && canvas.height === height)
        return;

    const previous = document.createElement("canvas");
    previous.width = canvas.width;
    previous.height = canvas.height;
    if (previous.width && previous.height)
        previous.getContext("2d").drawImage(canvas, 0, 0);

    canvas.width = width;
    canvas.height = height;
    context.setTransform(pixelRatio, 0, 0, pixelRatio, 0, 0);
    paintWhite(canvas, context);

    if (previous.width && previous.height)
        context.drawImage(previous, 0, 0, bounds.width, bounds.height);

    context.lineCap = "round";
    context.lineJoin = "round";
    context.strokeStyle = "#111";
    context.fillStyle = "#111";
    context.lineWidth = 2.5;
}

export function initialize(canvas, initialImage) {
    const context = canvas.getContext("2d");
    const state = { drawing: false, hasSignature: false, lastX: 0, lastY: 0 };
    pads.set(canvas, state);

    resize(canvas, context, state);
    paintWhite(canvas, context);

    canvas.addEventListener("pointerdown", onPointerDown);
    canvas.addEventListener("pointermove", onPointerMove);
    canvas.addEventListener("pointerup", onPointerEnd);
    canvas.addEventListener("pointercancel", onPointerEnd);
    canvas.addEventListener("lostpointercapture", onPointerEnd);
    state.resizeObserver = new ResizeObserver(() => resize(canvas, context, state));
    state.resizeObserver.observe(canvas);

    if (initialImage) {
        const image = new Image();
        image.onload = () => {
            paintWhite(canvas, context);
            context.drawImage(image, 0, 0, canvas.clientWidth, canvas.clientHeight);
            state.hasSignature = true;
        };
        image.src = initialImage;
    }

    function onPointerDown(event) {
        event.preventDefault();
        canvas.setPointerCapture(event.pointerId);
        const bounds = canvas.getBoundingClientRect();
        state.drawing = true;
        state.lastX = event.clientX - bounds.left;
        state.lastY = event.clientY - bounds.top;
        context.beginPath();
        context.arc(state.lastX, state.lastY, context.lineWidth / 2, 0, Math.PI * 2);
        context.fill();
        state.hasSignature = true;
    }

    function onPointerMove(event) {
        if (!state.drawing)
            return;

        event.preventDefault();
        const bounds = canvas.getBoundingClientRect();
        const x = event.clientX - bounds.left;
        const y = event.clientY - bounds.top;
        context.beginPath();
        context.moveTo(state.lastX, state.lastY);
        context.lineTo(x, y);
        context.stroke();
        state.lastX = x;
        state.lastY = y;
    }

    function onPointerEnd() {
        state.drawing = false;
    }

    state.onPointerDown = onPointerDown;
    state.onPointerMove = onPointerMove;
    state.onPointerEnd = onPointerEnd;
}

export function clear(canvas) {
    const state = pads.get(canvas);
    if (!state)
        return;

    const context = canvas.getContext("2d");
    paintWhite(canvas, context);
    state.hasSignature = false;
}

export function exportSignature(canvas) {
    const state = pads.get(canvas);
    if (!state || !state.hasSignature)
        return null;

    const context = canvas.getContext("2d");
    const bounds = canvas.getBoundingClientRect();
    const image = context.getImageData(0, 0, canvas.width, canvas.height);
    const output = document.createElement("canvas");
    output.width = canvas.width;
    output.height = canvas.height;
    const outputContext = output.getContext("2d");
    outputContext.fillStyle = "#fff";
    outputContext.fillRect(0, 0, bounds.width, bounds.height);
    outputContext.putImageData(image, 0, 0);

    return output.toDataURL("image/png");
}

export function dispose(canvas) {
    const state = pads.get(canvas);
    if (!state)
        return;

    state.resizeObserver.disconnect();
    canvas.removeEventListener("pointerdown", state.onPointerDown);
    canvas.removeEventListener("pointermove", state.onPointerMove);
    canvas.removeEventListener("pointerup", state.onPointerEnd);
    canvas.removeEventListener("pointercancel", state.onPointerEnd);
    canvas.removeEventListener("lostpointercapture", state.onPointerEnd);
    pads.delete(canvas);
}
