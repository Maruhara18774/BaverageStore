import React, { Component } from "react";
import Nav from "../../Components/Nav";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
export class Homepage extends Component {
  render() {
    return (
      <div>
        <Router>
          <Nav></Nav>
        </Router>
      </div>
    );
  }
}

export default Homepage;
