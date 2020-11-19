import myAxios from "./myAxios";

const ENDPOINT_PATH = "TipoPermiso";

export default {
    getListOfTypes() {
        return myAxios.instance.get(ENDPOINT_PATH);
    }
};
