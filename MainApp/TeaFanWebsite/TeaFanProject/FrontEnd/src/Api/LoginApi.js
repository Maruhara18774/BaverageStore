import API from "./API.js";
const baseURL = "/api/Login";

const LoginApi = {
  login: async (request) => {
    try {
      const url = baseURL + "/Login";
      var result = await API.post(url, request);
      return result;
    } catch (error) {
      //alert(error);
      console.error(error);
    }
  },
  regist: async (request) =>{
    try{
      const url = baseURL + "/Regist";
      var result = await API.post(url, request);
      return result;
    }catch(err){console.log(err);}
  }
};
export default LoginApi;

// export const loginApi = {
//   POST: (value, loginSuccess) => {
//     return axios({
//       method: "POST",
//       data: { ...value },
//       url: API_URL + "/api/Login/Login",
//     })
//       .then((res) => {
//         if (res.statusCode !== 200) {
//           /* Wrong username or password */
//         } else {
//           localStorage.setItem("user", JSON.stringify(res.data));
//           loginSuccess();
//         }
//       })
//       .catch((err) => {
//         message.error(err.response?.data?.message);
//       });
//   },
// };
