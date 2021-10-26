import React, { Component } from "react";
import CartApi from "../../../Api/CartApi";
import AccountApi from "../../../Api/AccountApi";
import CartContent from "../../../Components/Cart/CartContent";
import Paypal from "../../../Components/Paypal";
import { Button, Input } from "antd";
import "./style.css";
export class CheckoutForm extends Component {
  constructor(props) {
    super(props);

    this.state = {
      cart: [],
      user: {},
      total: 0,
      inputs: [
        { name: "First name", error: "" },
        { name: "Last name", error: "" },
        { name: "Email", error: "" },
        { name: "Phone number", error: "" },
        { name: "Address", error: "" },
      ],
    };
  }
  handelValidate() {}
  async componentDidMount() {
    var cart = await CartApi.getCheckoutInforAsync();
    var user = await AccountApi.profile();
    var subtotal = 0;
    cart.data.details.map((item) => {
      subtotal += item.soldPrice * item.quantity;
    });
    this.setState({
      cart: cart.data.details,
      firstName: user.data.firstName,
      lastName: user.data.lastName,
      email: user.data.email,
      phoneNumber: user.data.phoneNumber,
      address: user.data.address,
      subtotal,
      shippingPrice: cart.data.shippingPrice,
      total: subtotal + cart.data.shippingPrice,
    });
  }
  async checkOut() {
    await CartApi.confirmCheckoutAsync();
  }
  checkValue(){
    if(this.state.firstName==""
    || this.state.lastName == ""
    || this.state.email != ""
    || this.state.phoneNumber != ""
    || this.state.address!= "") return false;
    return true;
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
            <p>{this.state.total}$</p>
          </div>
        </div>
        <div style={{ width: "40%" }}>
          <h2>Contact Information</h2>
          <div className="input-wrapper">
            <span className="input-label">First name:</span>
            <Input
              className="input-info"
              onChange={(e) => {
                this.setState({ firstName: e.target.value });
              }}
              value={this.state.firstName}
            />
            <span></span>
          </div>
          <div className="input-wrapper">
            <span className="input-label">Last name:</span>
            <Input
              className="input-info"
              onChange={(e) => {
                this.setState({ lastName: e.target.value });
              }}
              value={this.state.lastName}
            />
          </div>
          <div className="input-wrapper">
            <span className="input-label">Email:</span>
            <Input
              className="input-info"
              onChange={(e) => {
                this.setState({ email: e.target.value });
              }}
              value={this.state.email}
            />
          </div>
          <div className="input-wrapper">
            <span className="input-label">Phone number:</span>
            <Input
              className="input-info"
              type="number"
              value={this.state.phoneNumber}
              onChange={(e) => {
                this.setState({ phoneNumber: e.target.value });
              }}
            />
          </div>
          <div className="input-wrapper">
            <span className="input-label">Address:</span>
            <Input
              className="input-info"
              value={this.state.address}
              onChange={(e) => {
                this.setState({ address: e.target.value });
              }}
            />
          </div>

          {/* <Button className="cancle-btn">Cancle</Button> */}
          {
            this.checkValue()?<Button disabled>Please enter contact info</Button>:
            <Paypal val={this.state.total} name={this.state.firstName} callback={()=>this.checkOut()}/>
          }
        </div>
      </div>
    );
  }
}

export default CheckoutForm;
