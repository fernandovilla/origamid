/*
    https://www.npmjs.com/package/vue3-toastify
    https://vue3-toastify.js-bridge.com/get-started/introduction.html
    https://vue3-toastify.js-bridge.com/
*/


import { toast } from 'vue3-toastify';
import 'vue3-toastify/dist/index.css';

const lifeTime = 3000;
const transition = "slide";
const position = toast.POSITION.TOP_RIGHT;

const Success = (message) => {        
    
    return toast.success(message, {
        autoClose: lifeTime,
        position: position,
        transition: transition
    });
}

const Error = (message) => {
    return toast.error(message, {
        autoClose: lifeTime,
        position: position,
        transition: transition
    });
}

const Info = (message) => {
    return toast.info(message, {
        autoClose: lifeTime,
        position: position,
        transition: transition
    });
}

const Warming = (message) => {
    return toast.warning(message, {
        autoClose: lifeTime,
        position: position,
        transition: transition
    });
}

const Loading = (message) => {
    return toast.loading(message, {
        autoClose: 10000,        
        position: position,
    });
}

const Done = (id) => {
    return toast.done(id);
}

const Update = (id, message, type, autoClose) => {

    if (type === '' || type === undefined) {
        type = toast.TYPE.SUCCESS;
    }

    return toast.update(id, {
        render: message,
        autoClose: autoClose,
        closeOnClick: true,
        closeButton: true,
        type: type,
        isLoading: false,
      });
}

export { Success, Error, Info, Warming, Loading, Done, Update }