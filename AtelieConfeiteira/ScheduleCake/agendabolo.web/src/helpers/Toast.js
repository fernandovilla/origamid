import { useToast } from "primevue/usetoast";
const toast = useToast();
const defaultLife = 3000;

const success = (summary, detail) => {
    toast.add({ severity: 'success', summary: summary, detail: detail, life: defaultLife });
}

const error = (summary, detail) => {
    toast.add({ severity: 'error', summary: summary, detail: detail, life: defaultLife    });
}

const information = (summary, detail) => {
    toast.add({ severity: 'info', summary: summary, detail: detail, life: defaultLife });
}

export { success, error, information };