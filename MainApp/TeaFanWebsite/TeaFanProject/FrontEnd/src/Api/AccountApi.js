import API from "./API.js";
const baseURL = "/api/Account";

const AccountApi = {
  profie: async () => {
    try {
      const url = baseURL + "/Profie";
      var result = await API.get(url);
      return result;
    } catch (error) {
      //alert(error);
      console.error(error);
    }
  },
  logout: async () =>{
    try {
      const url = baseURL + "/Logout";
      var result = await API.get(url);
      return result;
    } catch (error) {
      //alert(error);
      console.error(error);
    }
  }
};
export default AccountApi;