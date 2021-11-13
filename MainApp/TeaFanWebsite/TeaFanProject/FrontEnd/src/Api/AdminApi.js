import API from "./API.js";

const baseApiUrl = "/api";

const AdminApi = {
  addProductType: async (request) => {
    console.log(request);
    try {
      const url = baseApiUrl + "/ManageProductType/Add";
      var result = await API.post(url, request);
      return result;
    } catch (error) {
      //alert(error);
      console.error(error);
    }
  },
  editProductType: async (request) => {
    try {
      const url = baseApiUrl + "/ManageProductType/Edit";
      var result = await API.post(url, { params: request });
      return result;
    } catch (error) {
      //alert(error);
      console.error(error);
    }
  },
  removeProductType: async (id) => {
    try {
      const url = baseApiUrl + `/ManageProductType/${id}`;
      var result = await API.delete(url);
      return result;
    } catch (error) {
      //alert(error);
      console.error(error);
    }
  },

  getListProduct: async (page) => {
    try {
      const url = baseApiUrl + `/ManageProduct/${page}`;
      var result = await API.get(url);
      return result;
    } catch (error) {
      //alert(error);
      console.error(error);
    }
  },
};
export default AdminApi;
