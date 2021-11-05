import API from "./API.js";

const baseApiUrl = "/api/ManageProduct";

const ProductAdminApi = {
  getListAdmin: async (page) => {
    try {
      const url = baseApiUrl + `/${page}`;
      var result = await API.get(url);
      return result;
    } catch (error) {
      //alert(error);
      console.error(error);
    }
  },
};
export default ProductAdminApi;
