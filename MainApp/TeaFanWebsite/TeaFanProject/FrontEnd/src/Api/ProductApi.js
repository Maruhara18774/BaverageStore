import API from "./API.js";
const baseURL = "/api/Product";

const ProductApi = {
  getList: async (request) => {
    try {
      const url = baseURL + "/List";
      var result = await API.post(url,request);
      return result;
    } catch (error) {
      //alert(error);
      console.error(error);
    }
  }
};
export default ProductApi;
