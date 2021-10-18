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
    this.setState({ cart: cart.data.details, user: user });
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
        <div style={{ width: "50%" }}>
          {this.state.cart?.map((item, index) => {
            return <CartContent key={index} item={item} />;
          })}
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
              <Button type="danger">Cancle</Button>
            </Form.Item>
          </Form>
        </div>
      </div>
    );
  }
}

export default CheckoutForm;
