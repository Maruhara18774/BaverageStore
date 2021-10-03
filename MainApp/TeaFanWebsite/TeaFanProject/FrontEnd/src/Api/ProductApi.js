import API from "./API.js";
const baseURL = "/api/Product";
const baseURLfeedback = "/api/Feedback";

const ProductApi = {
  getList: async (request) => {
    try {
      const url = baseURL + "/List";
      var result = await API.post(url, request);
      return result;
    } catch (error) {
      //alert(error);
      console.error(error);
    }
  },
  getDetail: async (id) => {
    try {
      const url = baseURL + `/${id}`;
      var result = await API.get(url);
      return result;
    } catch (error) {
      //alert(error);
      console.error(error);
    }
  },
  getListfeedback: async (request) => {
    try {
      const url = baseURLfeedback + "/List";
      var result = await API.post(url, request);
      return result;
    } catch (error) {
      //alert(error);
      console.error(error);
    }
  },
  createComment: async (request) => {
    try {
      const url = baseURLfeedback + "/Create";
      var result = await API.post(url, request);
      return result;
    } catch (error) {
      //alert(error);
      console.error(error);
    }
  },
};
export default ProductApi;
