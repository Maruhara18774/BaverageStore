import Home from "./Pages/Home";
import Login from "./Pages/Login";
import Register from "./Pages/Register";
import Profie from "./Pages/Profie";
import CateShop from "./Pages/Category";
import Detail from "./Pages/Detail";
import CartForm from "./Pages/Cart/CartForm";
import CheckoutForm from "./Pages/Cart/Checkout";
import ManageHome from "./AdminPages/ManageHome";
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
  {
    path: "/profie",
    name: "Profie",
    icon: "fas fa-home",
    component: Profie,
    isSideBar: true,
  },
  {
    path: "/shop/:id",
    name: "Shop",
    icon: "fas fa-home",
    component: CateShop,
    isSideBar: true,
  },
  {
    path: "/detail/:id",
    name: "Detail",
    icon: "fas fa-home",
    component: Detail,
    isSideBar: true,
  },
  {
    path: "/cart",
    name: "Shop",
    icon: "fas fa-home",
    component: CartForm,
    isSideBar: true,
  },
  {
    path: "/checkout",
    name: "Shop",
    icon: "fas fa-home",
    component: CheckoutForm,
    isSideBar: true,
  },
  {
    path: "/managehome",
    name: "Manage Home",
    icon: "fas fa-home",
    component: ManageHome,
    isSideBar: true,
  },
];
export default routes;
