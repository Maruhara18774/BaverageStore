import React from "react";
import "antd/dist/antd.css";
import "./Home.css";
import { Carousel, Button } from "antd";
function index() {
  function onChange(a, b, c) {
    console.log(a, b, c);
  }

  return (
    <div className="home-container">
      <Carousel
        afterChange={onChange}
        className="main-carousel"
        autoplay="true"
      >
        <div className="carousel-item">
          <img
            src="https://cdn.shopify.com/s/files/1/0311/4398/5197/files/AOT-Website-App-05-11-21-LLSK-Website-Home-Banner_1600x.jpg?v=1621010590"
            alt="carousel1"
          />
          <div className="carousel-title">
            <h1>Introducing Blue Pineapple Iced Tea</h1>
            <p>Your new favorite summer sip</p>
            <Button className="shopbtn">Shop now</Button>
          </div>
        </div>
        <div className="carousel-item">
          <img
            src="https://cdn.shopify.com/s/files/1/0311/4398/5197/files/AOT-Website-App-Banners-Travel-Bundle-081721-Website-Home-Banner_1600x.png?v=1629238088"
            alt="carousel2"
          />
          <div className="carousel-title">
            <h1>Introducing Blue Pineapple Iced Tea</h1>
            <p>Your new favorite summer sip</p>
            <Button className="shopbtn">Shop now</Button>
          </div>
        </div>
        <div className="carousel-item">
          <img
            src="https://cdn.shopify.com/s/files/1/0311/4398/5197/files/AOT-Home-Banner-090820_1600x.jpg?v=1599580962"
            alt="carousel3"
          />
          <div className="carousel-title">
            <h1>Introducing Blue Pineapple Iced Tea</h1>
            <p>Your new favorite summer sip</p>
            <Button className="shopbtn">Shop now</Button>
          </div>
        </div>
        <div className="carousel-item">
          <img
            src="https://cdn.shopify.com/s/files/1/0311/4398/5197/files/AOT-Home-Banner-Teachable-041320_HH_1600x.jpg?v=1587056156"
            alt="carousel4"
          />
          <div className="carousel-title">
            <h1>Introducing Blue Pineapple Iced Tea</h1>
            <p>Your new favorite summer sip</p>
            <Button className="shopbtn">Shop now</Button>
          </div>
        </div>
      </Carousel>
      <h2
        style={{
          textAlign: "center",
          color: "#FEC5BB",
          letterSpacing: "1px",
          marginTop: "10px",
        }}
      >
        Shop Tea Favorite
      </h2>
      <div className="favorite">
        <div className="shopfavorite">
          <div className="card-wrapper">
            <img
              src="https://cdn.shopify.com/s/files/1/0311/4398/5197/files/20190220_ArtofTea__AudreyMa-0298_5_540x.jpg?v=1584376823"
              alt="shoptea"
            />
          </div>
          <h4>SHOP TEAS</h4>
        </div>
        <div className="shopfavorite">
          <div className="card-wrapper">
            <img
              src="https://cdn.shopify.com/s/files/1/0311/4398/5197/files/20200206_ArtofTea__AudreyMa-0294_Web_2_540x.jpg?v=1584140292"
              alt="shopcollection"
            />
          </div>
          <h4>SHOP COLLECTIONS</h4>
        </div>
        <div className="shopfavorite">
          <div className="card-wrapper">
            <img
              src="https://cdn.shopify.com/s/files/1/0311/4398/5197/files/20180828_ArtofTea__AudreyMa-0422_5_540x.jpg?v=1584376937"
              alt="shopteaware"
            />
          </div>
          <h4>SHOP TEAWARE</h4>
        </div>
      </div>
      <div className="trending">
        <h2>Trending</h2>
      </div>
      <div className="custom">
        <div className="imgBox">
          <img
            src="https://cdn.shopify.com/s/files/1/0311/4398/5197/files/homepage_crop_1_700x.jpg?v=1584140666"
            alt="custom"
          />
        </div>
        <div className="custom-content">
          <div className="contentBox">
            <p style={{ width: "85%", fontSize: "3.3vw" }}>
              Hand blended and custom crafted fine organic teas <br /> and
              botanicals
            </p>
            <Button className="custombtn">View all</Button>
          </div>
        </div>
      </div>
    </div>
  );
}

export default index;
