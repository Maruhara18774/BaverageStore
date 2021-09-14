import React from "react";
import {
  HeartOutlined,
  SearchOutlined,
  UserOutlined,
  ShoppingCartOutlined,
} from "@ant-design/icons";
import "./style.css";
function index() {
  return (
    <div className="navbar">
      <div className="nav-header">
        <div className="logo-content">
          <h1>Logo</h1>
        </div>
        <div className="icons-list">
          <li>
            <a href="">
              <HeartOutlined />
            </a>
          </li>
          <li>
            <a href="">
              <SearchOutlined />
            </a>
          </li>
          <li>
            <a href="">
              <UserOutlined />
            </a>
          </li>
          <li>
            <a href="">
              <ShoppingCartOutlined />
            </a>
          </li>
        </div>
      </div>
      <div className="nav-footer">
        <ul>
          <li>
            <a href="">Home</a>
          </li>
          <li>
            <a href="">Featured</a>
          </li>
          <li>
            <a href="">Shop</a>
          </li>
          <li>
            <a href="">Collections</a>
          </li>
          <li>
            <a href="">Teaware</a>
          </li>
          <li>
            <a href="">Sale</a>
          </li>
          <li>
            <a href="">Explore</a>
          </li>
        </ul>
      </div>
    </div>
  );
}

export default index;
