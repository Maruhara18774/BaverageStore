import React, { Component } from "react";
import CartApi from "../../../Api/CartApi";
import { Button, InputNumber } from "antd";
import "./style.css";
export class CartContent extends Component {
  constructor(props) {
    super(props);

    this.state = {
      cart: {},
      quantity: undefined,
    };
  }

  ChangeQuantity = (val) => {
    var request = {
      cartID: this.props.cartID,
      productID: this.props.item.productID,
      quantity: val,
    };
    CartApi.changeQuantityAsync(request).then((res) => {
      this.props.updateCart();
    });
  };
  RemoveProduct = (val) => {
    var request = {
      cartID: this.props.cartID,
      productID: this.props.item.productID,
    };
    CartApi.removeProductAsync(request).then((res) => {
      this.props.updateCart();
    });
  };

  render() {
    return (
      <div ChangeQuantity className="cart-content">
        <div className="cart-card">
          <img
            src={`https://localhost:44330${this.props?.item.imageURL}`}
            alt="img"
            className="cart-img"
          />
          <div className="cart-info">
            <h3 className="cart-item-name">{this.props?.item.productName}</h3>
            <span className="cart-item-price">
              {this.props?.item.soldPrice}$
            </span>
            {/* <span className="cart-item-price">
              quantity: {this.props?.item.quantity}
            </span> */}
            <div className="cart-quantity-wrapper">
              <div className="cart-quantity">
                <Button
                  className="cart-button descrement"
                  disabled={this.props.item.quantity === 1 ? true : false}
                  onClick={() =>
                    this.ChangeQuantity(this.props.item.quantity - 1)
                  }
                >
                  -
                </Button>
                <InputNumber
                  value={this.props.item.quantity}
                  className="quantity"
                />
                <Button
                  className="cart-button increment"
                  onClick={() =>
                    this.ChangeQuantity(this.props.item.quantity + 1)
                  }
                >
                  +
                </Button>
              </div>
            </div>
            <span className="remove" onClick={this.RemoveProduct}>
              REMOVE
            </span>
          </div>
        </div>
      </div>
    );
  }
}

export default CartContent;
