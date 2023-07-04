import API from "./API.js";

const baseApiUrl = "/api";

const assetApi = {
  getAsync: async (request) => {
    try {
      const url = baseApiUrl;
      var result = await API.get(url, { params: request });
      return result;
    } catch (error) {
      //alert(error);
      console.error(error);
    }
  },
};
export default assetApi;
