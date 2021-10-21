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
        <div className="cart-card-wrapper">
          {this.props.checkout ? (
            <div className="cart-card-checkout">
              <div className="img-wrapper-checkout">
                <img
                  src={`https://localhost:44330${this.props?.item.imageURL}`}
                  alt="img"
                  className="cart-img-checkout"
                />
                <div className="cart-item-quantity">
                  <span>{this.props?.item.quantity}</span>
                </div>
              </div>
              <div className="cart-info-checkout">
                <h3 className="cart-item-name">
                  {this.props?.item.productName}
                </h3>
              </div>
              <span className="cart-item-price-checkout">
                {this.props?.item.soldPrice}$
              </span>
            </div>
          ) : (
            <div className="cart-card">
              <img
                src={`https://localhost:44330${this.props?.item.imageURL}`}
                alt="img"
                className="cart-img"
              />
              <div className="cart-info">
                <h3 className="cart-item-name">
                  {this.props?.item.productName}
                </h3>
                <span className="cart-item-price">
                  {this.props?.item.soldPrice}$
                </span>
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
                {this.props.checkout ? null : (
                  <span className="remove" onClick={this.RemoveProduct}>
                    REMOVE
                  </span>
                )}
              </div>
            </div>
          )}
        </div>
      </div>
    );
  }
}

export default CartContent;
