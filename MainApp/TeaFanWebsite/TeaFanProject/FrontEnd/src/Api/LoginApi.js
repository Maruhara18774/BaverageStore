import API from "./API.js";
import axios from "axios";
import { API_URL } from "../ConfigApi.js";
import { message } from "antd";

const LoginApi = {
  login: async (request) => {
    try {
      const url = API_URL + "/api/Login/Login";
      var result = await API.Post(url, { params: request });
      return result;
    } catch (error) {
      //alert(error);
      console.error(error);
    }
  },
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
