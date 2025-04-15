import { toast } from 'vue3-toastify';
import 'vue3-toastify/dist/index.css';

const lifeTime = 3000;

const Success = (message) => {        
    
    toast.success(message, {
        autoClose: lifeTime
    });
}

const Error = (message) => {
    toast.error(message, {
        autoClose: lifeTime
    });
}

export { Success, Error }