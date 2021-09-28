import React, { Component } from "react";
import FilterBar from "../FilterBar";
import ProductApi from "../../../Api/ProductApi";
import { Button, List } from "antd";
import { HeartOutlined } from "@ant-design/icons";
import "antd/dist/antd.css";
import "./CoreForm.css";
export class ShopForm extends Component {
  constructor(props) {
    super(props);

    this.state = {
      currentCate: this.props.cateID,
      products: {},
    };
    this.initial();
  }

  filterChange = async (request) => {
    var products = await ProductApi.getList(request);
    this.setState({
      products: products.data,
      totalItem: products.data.totalRecords,
      currentCate: this.props.cateID,
      request: request,
    });
  };

  async initial() {
    const request = {
      page: 1,
      productTypeID: 0,
      flavorsID: [],
      origin: "",
      min: 0,
      max: 0,
      sortBy: "ASC",
      pageCount: 1,
      sortType: "",
      categoryID: this.props.cateID,
    };
    var products = await ProductApi.getList(request);
    this.setState({
      products: products.data,
      totalItem: products.data.totalRecords,
      currentCate: this.props.cateID,
      request: request,
    });
  }
  goToDetail(id){
    alert(id);
  }
  render() {
    if (this.props.cateID !== this.state.currentCate) {
      this.initial();
    }
    return (
      <div className="cate-container">
        <FilterBar
          cateID={this.props.cateID}
          filterChange={this.filterChange}
        />
        <div className="product-container">
          <h1 style={{ color: "#939393", fontSize: "3rem" }}>Products</h1>
          <div className="product-banner-box">
            <img
              src="https://cdn.shopify.com/s/files/1/0311/4398/5197/collections/AOT-Loose-Leaf-Header-Banner_1800x.jpg?v=1586118019"
              alt="banner"
              className="product-banner"
            />
          </div>
          <div className="product-list-wrapper">
            <div className="list-header">
              <p>Total ({this.state.totalItem})</p>
            </div>
            <List
              grid={{ gutter: 16, column: 4, row: 3 }}
              dataSource={this.state.products.items}
              itemLayout="horizontal"
              pagination={{
                onChange: (page) => {
                  const request = {
                    ...this.state.request,
                    page: page,
                  };
                  var products = ProductApi.getList(request);
                  this.setState({
                    products: products.data,
                    totalItem: products.data.totalRecords,
                    currentCate: this.props.cateID,
                    request: request,
                  });
                },
                pageSize: 12,
                totalItem: this.state.totalItem,
              }}
              renderItem={(item) => (
                <List.Item key={item.productID}>
                  <div className="product-list-box">
                    <div className="product-card" onClick={()=>{this.goToDetail(item.productID)}}>
                      <div className="product-imgBox">
                        <img
                          src={`https://localhost:44330${item.images[0]}`}
                          alt="product"
                          className="product-img"
                        />
                        <HeartOutlined className="heart" />
                      </div>
                      <p className="title-product" title={item.productName}>
                        {item.productName}
                      </p>
                      <div className="product-price">
                        <h3>${item.price}</h3>
                        <h2>${item.salePrice}</h2>
                      </div>
                      <Button className="addbtn">Add to cart</Button>
                      {this.props.cateID === "2" ? null : (
                        <div className="flavor-span">
                          <span>
                            <i className="far fa-lemon"></i> Flavor:
                            {` ${item.flavors}`}
                          </span>
                        </div>
                      )}
                    </div>
                  </div>
                </List.Item>
              )}
            />
            {/* <div className="product-list-box">
              <div className="product-card">
                <img
                  src="https://cdn.shopify.com/s/files/1/0311/4398/5197/products/THROAT_THERAPY_0ec26ed5-a3e2-48f2-883e-36a5ea4f51b2_600x.jpg?v=1630533835"
                  alt="product"
                  className="product-img"
                />
                <h3>{this.state.products.max}</h3>
                <div className="product-price">
                  <h3>5.55</h3>
                  <h2>5.85 $</h2>
                </div>
                <Button className="addbtn">Add to cart</Button>
                <div className="flavor-span">
                  <span>
                    <i className="far fa-lemon"></i> Flavor:{" "}
                  </span>
                </div>
              </div>
            </div> */}
            {/* <Pagination className="pagination" defaultCurrent={1} total={50} /> */}
          </div>
        </div>
      </div>
    );
  }
}

export default ShopForm;
