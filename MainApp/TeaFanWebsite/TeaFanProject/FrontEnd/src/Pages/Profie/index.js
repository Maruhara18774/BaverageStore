import React, { Component } from "react";
import "./style.css";
import AccountApi from "../../Api/AccountApi";
import SubNavbar from "../../Components/Profie/SubNavbar";
import { Button, Form, Input } from "antd";

export class Profie extends Component {
  constructor(props) {
    super(props);
    this.state = {
      user: {},
      position: "detail",
      errorMessage: "",
    };
  }
  async componentDidMount() {
    var result = await AccountApi.profie();
    this.setState({ user: result.data });
  }
  async changePosition(position) {
    this.setState({ position: position });
    if (position === "detail") {
      var result = await AccountApi.profie();
      this.setState({ user: result.data });
    }
  }
  async changePassword(val) {
    if (val.newPass !== val.comfirmedPass) {
      this.setState({ errorMessage: "Confirm password is wrong!" });
    } else {
      const request = {
        oldPass: val.oldPass,
        newPass: val.newPass,
      };
      var result = await AccountApi.changePassword(request);
      if (result.code !== 200) {
        this.setState({ errorMessage: result.message });
      } else {
        alert("Password was changed.");
      }
    }
  }
  async editProfie(val) {
    var result = await AccountApi.editProfie(val);
    if (result.code !== 200) {
      this.setState({ errorMessage: result.message });
    } else {
      localStorage.setItem("user", JSON.stringify(result.data));
      alert("Profie was edited.");
    }
  }
  getContent() {
    switch (this.state.position) {
      case "detail":
        return (
          <div className="profie-content">
            <table style={{ width: "100%", marginBottom: "10px" }}>
              <tr>
                <td>First Name:</td>
                <td>{this.state.user.firstName}</td>
              </tr>
              <tr>
                <td>Last Name:</td>
                <td>{this.state.user.lastName}</td>
              </tr>
              <tr>
                <td>Email:</td>
                <td>{this.state.user.email}</td>
              </tr>
              <tr>
                <td>Phone Number:</td>
                <td>{this.state.user.phoneNumber}</td>
              </tr>
              <tr>
                <td>Address:</td>
                <td>{this.state.user.address}</td>
              </tr>
            </table>
            <Button
              shape="round"
              style={{ marginRight: "20px" }}
              onClick={() => this.setState({ position: "changePassword" })}
            >
              Change Password
            </Button>
            <Button
              shape="round"
              onClick={() => this.setState({ position: "edit" })}
            >
              Edit Details
            </Button>
          </div>
        );
        break;
      case "history":
        return <div className="profie-content">History</div>;
        break;
      case "changePassword":
        return (
          <div className="profie-content">
            <Form
              labelCol={{
                span: 8,
              }}
              wrapperCol={{
                span: 24,
              }}
              onFinish={this.changePassword}
            >
              <Form.Item
                name="oldPass"
                rules={[
                  {
                    required: true,
                    message: "Please input your old password!",
                  },
                ]}
              >
                <Input placeholder="Old password" type="password" />
              </Form.Item>

              <Form.Item
                name="newPass"
                rules={[
                  {
                    required: true,
                    message: "Please input your new password!",
                  },
                ]}
              >
                <Input placeholder="New password" type="password" />
              </Form.Item>

              <Form.Item
                name="confirmedPass"
                rules={[
                  {
                    required: true,
                    message: "Please input your confirm password!",
                  },
                ]}
              >
                <Input placeholder="Confirm password" type="password" />
              </Form.Item>
              <p>{this.state.errorMessage}</p>
              <Button type="primary" htmlType="submit">
                Save
              </Button>
              <Button
                type="secondary"
                onClick={() => this.changePosition("detail")}
              >
                Back
              </Button>
            </Form>
          </div>
        );
        break;
      case "edit":
        var initVal = {
          firstName: this.state.user.firstName,
          lastName: this.state.user.lastName,
          phoneNumber: this.state.user.phoneNumber,
          address: this.state.user.address,
        };
        return (
          <div className="profie-content">
            <Form
              labelCol={{
                span: 8,
              }}
              wrapperCol={{
                span: 24,
              }}
              onFinish={this.editProfie}
              initialValues={initVal}
            >
              <Form.Item name="firstName">
                <Input
                  placeholder="First name"
                  defaultValue={this.state.user.firstName}
                />
              </Form.Item>

              <Form.Item name="lastName">
                <Input
                  placeholder="Last name"
                  defaultValue={this.state.user.lastName}
                />
              </Form.Item>

              <Form.Item name="phoneNumber">
                <Input
                  placeholder="Phone number"
                  defaultValue={this.state.user.phoneNumber}
                />
              </Form.Item>

              <Form.Item name="address">
                <Input
                  placeholder="address"
                  defaultValue={this.state.user.address}
                />
              </Form.Item>
              <Button type="primary" htmlType="submit">
                Save
              </Button>
              <Button
                type="secondary"
                onClick={() => this.changePosition("detail")}
              >
                Back
              </Button>
            </Form>
          </div>
        );
        break;
      default:
        break;
    }
  }
  render() {
    return (
      <div className="wrap">
        <SubNavbar
          name={this.state.user.lastName}
          changePosition={(val) => this.changePosition(val)}
        />
        {this.getContent()}
      </div>
    );
  }
}

export default Profie;
