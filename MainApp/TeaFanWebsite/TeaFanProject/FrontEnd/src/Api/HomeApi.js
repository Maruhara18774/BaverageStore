import API from "./API.js";
const baseURL = "/api/Home";

const HomeApi = {
  getCategories: async () => {
    try {
      const url = baseURL + "/Categories";
      var result = await API.get(url);
      return result;
    } catch (error) {
      //alert(error);
      console.error(error);
    }
  }
};
export default HomeApi;
