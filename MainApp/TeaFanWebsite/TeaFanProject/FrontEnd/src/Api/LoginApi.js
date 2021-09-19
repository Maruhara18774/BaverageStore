import API from "./API.js";

const baseApiUrl = "/api/Login";

const LoginApi = {
  login: async (request) => {
    try {
      const url = baseApiUrl+"/Login";
      var result = await API.Post(url, { params: request });
      return result;
    } catch (error) {
      //alert(error);
      console.error(error);
    }
  },
};
export default LoginApi;
