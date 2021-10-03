import API from "./API.js";

const baseApiUrl = "/api/Cart";

const CartApi = {
  getCurrentCartAsync: async () => {
    try {
      const url = baseApiUrl+"/Current";
      var result = await API.get(url);
      return result;
    } catch (error) {
      //alert(error);
      console.error(error);
    }
  },
  getCheckoutInforAsync: async() =>{
    try {
        const url = baseApiUrl+"/Checkout";
        var result = await API.get(url);
        return result;
      } catch (error) {
        //alert(error);
        console.error(error);
      }
  },
  confirmCheckoutAsync: async () =>{
    try {
        const url = baseApiUrl+"/Confirmation";
        var result = await API.get(url);
        return result;
      } catch (error) {
        //alert(error);
        console.error(error);
      }
  },
  changeQuantityAsync: async (request) =>{
    try {
      const url = baseApiUrl+"/Edit";
      var result = await API.post(url,request);
      return result;
    } catch (error) {
      //alert(error);
      console.error(error);
    }
  },
  removeProductAsync: async (request) =>{
    try {
      const url = baseApiUrl+"/Remove";
      var result = await API.post(request);
      return result;
    } catch (error) {
      //alert(error);
      console.error(error);
    }
  }
};
export default CartApi;
