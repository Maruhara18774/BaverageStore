import React from "react";
import { Redirect, Route, Switch, useLocation } from "react-router-dom";
import Nav from "./Components/Nav";

// core components
import routes from "./routes.js";
import { Container, Col } from "reactstrap";
import Footer from "./Components/Footer";

function App() {
  const mainContent = React.useRef(null);
  const location = useLocation();

  // username in header
  var user = localStorage.getItem("user");

  if (user) {
    user = JSON.parse(user);
  }
  React.useEffect(() => {
    document.documentElement.scrollTop = 0;
    document.scrollingElement.scrollTop = 0;
    // mainContent.current.scrollTop = 0;
  }, [location]);
  const getRoutes = (routes) => {
    return routes.map((prop, key) => {
      return <Route path={prop.path} component={prop.component} key={key} />;
    });
  };
  return (
    <div
      className="main-content"
      ref={mainContent}
      style={{ minHeight: "100vh", position: "relative" }}
    >
      {/* <Nav></Nav> */}
      <Container fluid className="d-flex pt-md-5 flex-column flex-md-row">
        <Col className="px-2 py-3">
          <Switch>
            {getRoutes(routes)}
            <Redirect from="*" to="/home" />
          </Switch>
        </Col>
      </Container>
      {/* <Footer></Footer> */}
    </div>
  );
}

export default App;
