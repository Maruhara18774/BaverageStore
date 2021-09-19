import React from "react";
import ReactDOM from "react-dom";
import App from "./App";
import reportWebVitals from "./reportWebVitals";
import { Redirect, Route, Switch, BrowserRouter } from "react-router-dom";
import Nav from "./Components/Nav";
import Footer from "./Components/Footer";
import "@fortawesome/fontawesome-free/css/all.min.css";

ReactDOM.render(
  <BrowserRouter>
    <div className="wrapper" style={{ position: "relative" }}>
      <Nav></Nav>
      <Switch>
        <Route path="/" render={(props) => <App {...props} />} />
        <Redirect from="/" to="/home/index" />
      </Switch>
      <Footer></Footer>
    </div>
  </BrowserRouter>,
  document.getElementById("root")
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
