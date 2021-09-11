import axios from "axios";
import queryString from "query-string";

const userEndpoint = "./api/Users";

const API = axios.create({
  timeout: 300000,
  headers: {
    "Content-Type": "application/json",
  },
  paramsSerializer: (params) => queryString.stringify(params),
});

API.interceptors.request.use(async (config) => {
  return config;
});
API.interceptors.response.use(
  (response) => {
    if (response && response.data) {
      return response.data;
    }
  },
  (error) => {
    if (401 === error.response.status) {
      window.location.href = "/login";
    } else if (404 === error.response.status) {
      window.location.href = "/NotFound";
    } else if (403 === error.response.status) {
      window.location.href = "/forbidden";
    } else if (500 === error.response.status) {
      console.error("Server error: " + error);
      return Promise.reject(error);
    } else {
      console.error(error);
      return Promise.reject(error);
    }
  },
);

export default API;

export function get(body) {
  return axios.get(userEndpoint, body);
}
