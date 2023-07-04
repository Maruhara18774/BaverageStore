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
  },
  getCategory: async(id)=>{
    try {
      const url = baseURL + "/Category/"+id;
      var result = await API.get(url);
      return result;
    } catch (error) {
      //alert(error);
      console.error(error);
    }
  },
  getProductType: async(id)=>{
    try {
      const url = baseURL + "/ProductTypes/"+id;
      var result = await API.get(url);
      return result;
    } catch (error) {
      //alert(error);
      console.error(error);
    }
  },
  getFlavors: async() =>{
    try{
      const url = baseURL + "/Flavors";
      var result = await API.get(url);
      return result;
    }
    catch(err){console.log(err);}
  },
  getOrigins: async()=>{
    try{
      const url = baseURL +"/Origins";
      var result = await API.get(url);
      return result;
    }
    catch(err){console.log(err);}
  }
};
export default HomeApi;
