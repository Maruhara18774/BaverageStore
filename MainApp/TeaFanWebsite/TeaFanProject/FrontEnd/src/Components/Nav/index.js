import React from "react";
import {
  HeartOutlined,
  SearchOutlined,
  UserOutlined,
  ShoppingCartOutlined,
} from "@ant-design/icons";
import { Link } from "react-router-dom";
import "./style.css";
import HomeApi from "../../Api/HomeApi";
function Nav() {
  var category = await HomeApi.getCategories();
  function GetCateID(name){
    category.data.forEach(item => {
      if(item.categoryName === name) return item.categoryID
    });
    return 0;
  }
  return (
    <div className="navbar">
      <div className="nav-header">
        <div className="logo-content">
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
        <div className="icons-list">
          <li>
            <a href="/favorite">
              <HeartOutlined />
            </a>
          </li>
          <li>
            <a href="/search">
              <SearchOutlined />
            </a>
          </li>
          <li>
            {localStorage.getItem("user") == null ?
              <Link to="/login">
                <UserOutlined />
              </Link> :
              <Link to="/profie">
                <UserOutlined />
              </Link>
            }
          </li>
          <li>
            <a href="/cart">
              <ShoppingCartOutlined />
            </a>
          </li>
        </div>
      </div>
      <div className="nav-footer">
        <ul>
          <li>
            <Link to="/">Home</Link>
          </li>
          <li>
            <Link to={()=> "/shop/"+ GetCateID("Tea")}>Shop</Link>
          </li>
          <li>
            <Link to={()=> "/shop/" + GetCateID("Packaged")}>Collections</Link>
          </li>
          <li>
            <Link to={()=> "/shop/" + GetCateID("Teaware")}>Teaware</Link>
          </li>
          <li>
            <Link to={()=> "/shop/" + GetCateID("Gift")}>Featured</Link>
          </li>
          <li>
            <Link to="/sale">Sale</Link>
          </li>
          <li>
            <Link to="/explore">Explore</Link>
          </li>
        </ul>
      </div>
    </div>
  );
}

export default Nav;
