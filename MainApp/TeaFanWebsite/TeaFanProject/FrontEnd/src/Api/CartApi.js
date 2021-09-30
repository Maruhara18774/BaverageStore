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
  }
};
export default CartApi;
