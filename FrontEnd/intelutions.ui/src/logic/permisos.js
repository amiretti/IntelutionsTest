import myAxios from "./myAxios";

const ENDPOINT_PATH = "permiso";

export default {
    getListOfLicenses() {
        return myAxios.instance.get(ENDPOINT_PATH);
    },
    async SaveLicense(license){
        return await myAxios.instance.post(ENDPOINT_PATH, license);
    },
    async DeleteLicense(Id){
      return await myAxios.instance.delete(ENDPOINT_PATH + "?id=" + Id);
  },
    async GetLicenseById(Id){
        return await myAxios.instance.get(ENDPOINT_PATH + "/" + Id);
    }
};
