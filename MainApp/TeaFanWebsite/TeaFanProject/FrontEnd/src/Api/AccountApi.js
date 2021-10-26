import API from "./API.js";
const baseURL = "/api/Account";

const AccountApi = {
  profile: async () => {
    try {
      const url = baseURL + "/Profie";
      var result = await API.get(url);
      return result;
    } catch (error) {
      //alert(error);
      console.error(error);
    }
  },
  logout: async () => {
    try {
      const url = baseURL + "/Logout";
      var result = await API.get(url);
      return result;
    } catch (error) {
      //alert(error);
      console.error(error);
    }
  },
  changePassword: async (request) => {
    try {
      const url = baseURL + "/ChangePassword";
      var result = await API.post(url, request);
      return result;
    } catch (err) {
      console.log(err);
    }
  },
  editProfie: async (request) => {
    try {
      const url = baseURL + "/Edit";
      var result = await API.post(url, request);
      return result;
    } catch (err) {
      console.log(err);
    }
  },
};
export default AccountApi;
