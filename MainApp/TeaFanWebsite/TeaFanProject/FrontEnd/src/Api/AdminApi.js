import API from "./API.js";

const baseApiUrl = "/api/ManageProductType";

const AdminApi = {
  addProduct: async (request) => {
    try {
      const url = baseApiUrl + "/Add";
      var result = await API.get(url, { params: request });
      return result;
    } catch (error) {
      //alert(error);
      console.error(error);
    }
  },
  editProduct: async (request) => {
    try {
      const url = baseApiUrl + "/Edit";
      var result = await API.get(url, { params: request });
      return result;
    } catch (error) {
      //alert(error);
      console.error(error);
    }
  },
  removeProduct: async (request) => {
    try {
      const url = baseApiUrl + "/id";
      var result = await API.get(url, { params: request });
      return result;
    } catch (error) {
      //alert(error);
      console.error(error);
    }
  },
};
export default AdminApi;
