import React, { Component } from "react";
import CartApi from "../../../Api/CartApi";
import AccountApi from "../../../Api/AccountApi";
import CartContent from "../../../Components/Cart/CartContent";
import { Button, Form, Input } from "antd";
import "./style.css";
export class CheckoutForm extends Component {
  constructor(props) {
    super(props);

    this.state = {
      cart: [],
      user: {},
    };
  }

  async componentDidMount() {
    var cart = await CartApi.getCheckoutInforAsync();
    var user = await AccountApi.profie();
    var subtotal = 0;
    cart.data.details.map((item) => {
      subtotal += item.soldPrice * item.quantity;
    });
    this.setState({
      cart: cart.data.details,
      user: user,
      subtotal,
      shippingPrice: cart.data.shippingPrice,
    });
  }
  async checkOut() {
    await CartApi.confirmCheckoutAsync();
  }
  render() {
    return (
      <div
        style={{
          marginTop: "10%",
          width: "100%",
          display: "flex",
          justifyContent: "space-around",
          alignItems: "flex-start",
        }}
      >
        <div style={{ width: "40%" }}>
          {this.state.cart?.map((item, index) => {
            return <CartContent key={index} item={item} checkout={true} />;
          })}
          <hr style={{ width: "100%" }} />
          <div className="sub-wrapper">
            <div className="subtotal-shipping">
              <p>Subtotal</p>
              <p>{this.state.subtotal}$</p>
            </div>
            <div className="subtotal-shipping">
              <p>Shipping</p>
              <p>{this.state.shippingPrice}$</p>
            </div>
          </div>
          <hr style={{ width: "100%" }} />
          <div className="subtotal-shipping total">
            <p>Total</p>
            <p>{this.state.shippingPrice + this.state.subtotal}$</p>
          </div>
        </div>
        <div style={{ width: "40%" }}>
          <h2>Contact Information</h2>
          <Form
            className="contact-info"
            name="basic"
            labelCol={{ span: 7 }}
            wrapperCol={{ span: 17 }}
            autoComplete="off"
          >
            <Form.Item
              label="First Name"
              name="firstname"
              rules={[
                { required: true, message: "Please input your firstname!" },
              ]}
            >
              <Input className="input-info" />
            </Form.Item>
            <Form.Item
              label="Last Name"
              name="lastname"
              rules={[
                { required: true, message: "Please input your lastname!" },
              ]}
            >
              <Input className="input-info" />
            </Form.Item>
            <Form.Item label="Your email" name="email">
              <Input className="input-info" />
            </Form.Item>
            <Form.Item
              label="Phone number"
              name="phonenumber"
              rules={[
                { required: true, message: "Please input your phone number!" },
              ]}
            >
              <Input className="input-info" />
            </Form.Item>
            <Form.Item
              label="Your Address"
              name="address"
              rules={[
                { required: true, message: "Please input your address!" },
              ]}
            >
              <Input className="input-info" />
            </Form.Item>

            <Form.Item wrapperCol={{ offset: 7, span: 17 }}>
              <Button className="cancle-btn">Cancle</Button>
              {/* Paypal button here */}
              <img
                src="https://www.paypalobjects.com/webstatic/en_US/i/buttons/checkout-logo-medium.png"
                alt="Check out with PayPal"
                className="paypal-btn"
              />
            </Form.Item>
          </Form>
        </div>
      </div>
    );
  }
}

export default CheckoutForm;
