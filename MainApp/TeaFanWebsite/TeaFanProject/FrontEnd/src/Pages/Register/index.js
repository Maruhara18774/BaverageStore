import React from "react";
import Background from "./Background";
import "./Register.css";
import "antd/dist/antd.css";
import { Form, Input, Button } from "antd";
import { Link } from "react-router-dom";
function index(props) {
  const onFinish = (values) => {
    console.log("Success:", values);
  };

  const onFinishFailed = (errorInfo) => {
    console.log("Failed:", errorInfo);
  };
  return (
    <div>
      <div className="container">
        <Background></Background>
        <div className="login-form">
          <p className="login-title">
            <b>Register</b>
          </p>
          <Form
            name="basic"
            labelCol={{
              span: 8,
            }}
            wrapperCol={{
              span: 24,
            }}
            initialValues={{
              remember: true,
            }}
            onFinish={onFinish}
            onFinishFailed={onFinishFailed}
            autoComplete="off"
          >
            <div className="name-wrapper">
              <Form.Item
                style={{ width: "35%" }}
                name="name"
                rules={[
                  {
                    required: true,
                    message: "Please input your first name!",
                  },
                ]}
              >
                <Input className="aloalo" placeholder="First name" />
              </Form.Item>

              <Form.Item
                style={{ width: "60%" }}
                name="lastname"
                rules={[
                  {
                    required: true,
                    message: "Please input your last name!",
                  },
                ]}
              >
                <Input className="aloalo" placeholder="Last name" />
              </Form.Item>
            </div>
            <Form.Item
              name="username"
              rules={[
                {
                  required: true,
                  message: "Please input your username!",
                },
              ]}
            >
              <Input className="aloalo" placeholder="Username or email" />
            </Form.Item>

            <Form.Item
              name="password"
              rules={[
                {
                  required: true,
                  message: "Please input your password!",
                },
              ]}
            >
              <Input
                type="password"
                className="aloalo"
                placeholder="Password"
              />
            </Form.Item>
            <Form.Item
              name="password"
              rules={[
                {
                  required: true,
                  message: "Please confirm your password!",
                },
              ]}
            >
              <Input
                type="password"
                className="aloalo"
                placeholder="Confirm password"
              />
            </Form.Item>

            <Button className="submit-btn" type="primary" htmlType="submit">
              Sign Up
            </Button>
          </Form>
          <div className="line">
            <hr />
            Or
            <hr />
          </div>
          <div className="social-group-btn">
            <Button className="social-btn" style={{ width: "45%" }}>
              <i class="fab fa-google"></i>Login with Google
            </Button>
            <Button className="social-btn" style={{ width: "45%" }}>
              <i class="fab fa-facebook"></i> Login with Facebook
            </Button>
          </div>
          <h5 style={{ color: "#B2B1B9", fontSize: "1.1vw" }}>
            Already a member ?{" "}
            <Link style={{ color: "#FEC5BB", fontWeight: "600" }} to="/login">
              Click here
            </Link>
          </h5>
        </div>
      </div>
    </div>
  );
}

export default index;
