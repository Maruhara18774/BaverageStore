import React, { useState } from "react";
import Background from "./Background";
import "./Login.css";
import "antd/dist/antd.css";
import { Form, Input, Button } from "antd";
import { Link } from "react-router-dom";
import LoginApi from "../../Api/LoginApi";
import { useHistory } from "react-router-dom";
function Login(props) {
  const history = useHistory();
  const [errorMessage,setErrorMessage] = useState("");

  const onFormSubmit = async (e) => {
    e["rememberMe"] = false;
    await LoginApi.login(e)
      .then((data) => {
        if(data.code !== 200){
          setErrorMessage(data.message);
        }
        else{
          localStorage.setItem("user", JSON.stringify(data.data));
          history.push("/home");
        }
      });
  };

  return (
    <div>
      <div className="container">
        <Background></Background>
        <div className="login-form">
          <p className="login-title">
            <b>Log</b> in
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
            onFinish={onFormSubmit}
            autoComplete="off"
          >
            <Form.Item
              name="email"
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
            {errorMessage!==""?<p>{errorMessage}</p>:<></>}
            <Button className="submit-btn" type="primary" htmlType="submit">
              Login
            </Button>
          </Form>
          <div className="line">
            <hr />
            Or
            <hr />
          </div>
          <Button className="social-btn">
            <i class="fab fa-google"></i>Login with Google
          </Button>
          <Button className="social-btn">
            <i class="fab fa-facebook"></i> Login with Facebook
          </Button>
          <h5 style={{ color: "#B2B1B9", fontSize: "1.1vw" }}>
            Don't have account ?{" "}
            <Link
              style={{ color: "#FEC5BB", fontWeight: "600" }}
              to="/register"
            >
              Click here
            </Link>
          </h5>
        </div>
      </div>
    </div>
  );
}

export default Login;
