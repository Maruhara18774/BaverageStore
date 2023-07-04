import React from "react";
import "./style.css";
import { Input } from "antd";
import "antd/dist/antd.css";
import { Row, Col } from "antd";
function index() {
  return (
    <footer>
      <div className="footer-header">
        <p style={{ marginBottom: "0" }}>
          Sign up & get 10% off your first purchase
        </p>
        <Input
          className="footer-input"
          placeholder="Enter email for newsletter signup"
        ></Input>
      </div>
      <div className="footer-footer">
        <Row>
          <Col xs={{ span: 8, offset: 1 }} lg={{ span: 6, offset: 2 }}>
            <div
              className="logo-content"
              style={{ justifyContent: "flex-start" }}
            >
              <img
                className="logo"
                src="https://cdn-icons-png.flaticon.com/512/1992/1992720.png"
                alt="logo"
              />
              <div className="logo-text">
                <h1>Tea Fan</h1>
                <p>VIETNAM</p>
              </div>
            </div>
            <div className="shop-about">
              <div className="shop">
                <h4>SHOP</h4>
                <ul>
                  <li>Home</li>
                  <li>Featured</li>
                  <li>Collections</li>
                  <li>Teaware</li>
                  <li>Safe</li>
                </ul>
              </div>
              <div className="about">
                <h4>ABOUT</h4>
                <ul>
                  <li>About us</li>
                  <li>Partner</li>
                  <li>Press</li>
                </ul>
              </div>
            </div>
          </Col>
          <Col xs={{ span: 5, offset: 1 }} lg={{ span: 6, offset: 2 }}>
            <div className="customer-service">
              <h4>CUSTOMER SERVICE</h4>
              <ul>
                <li>Help Center</li>
                <li>Contact us</li>
                <li>Where is my order ?</li>
                <li>General Policies</li>
                <li>Privacy Policy</li>
              </ul>
            </div>
          </Col>
          <Col xs={{ span: 5, offset: 1 }} lg={{ span: 6, offset: 2 }}>
            <div className="contact-info">
              <h4>CONTACT</h4>
              <ul>
                <li>US: xxx-xxx-xxx </li>
                <li>International: xxx-xxx-xxx</li>
                <li>Monday - Friday</li>
                <li>8:30am—4:30pm PST</li>
              </ul>
              <div className="footer-icons">
                <ul>
                  <i className="fab fa-facebook-square"></i>
                  <i className="fab fa-instagram"></i>
                  <i className="fab fa-twitter"></i>
                  <i className="fab fa-tiktok"></i>
                </ul>
              </div>
            </div>
          </Col>
        </Row>
        ,
      </div>
    </footer>
  );
}

export default index;
