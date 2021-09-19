import Home from "./Pages/Home";
import Login from "./Pages/Login";
import Register from "./Pages/Register";

var routes = [
  {
    path: "/home",
    name: "Home",
    icon: "fas fa-home",
    component: Home,
    isSideBar: true,
  },
  {
    path: "/login",
    name: "Login",
    icon: "fas fa-home",
    component: Login,
    isSideBar: true,
  },
  {
    path: "/register",
    name: "Register",
    icon: "fas fa-home",
    component: Register,
    isSideBar: true,
  },
];
export default routes;
