import React, { Component } from 'react';
import LoginApi from '../../Api/LoginApi';

export class LoginPage extends Component {
    onFormSubmit = (e) => {
        e.preventDefault();
        var email = e.target.username.value;
        var password = e.target.password.value;
        LoginApi.login({
          email: email,
          password: password,
        })
          .then((data) => {
            if (data.statusCode !== 200) {  /* Wrong username or password */}
            else {
                localStorage.setItem("user", JSON.stringify(data.data));
                history.push("/home");
            }
          })
          .catch((err) => console.error(err));
      };
    render() {
        return (
            <div>
                This is login page
            </div>
        )
    }
}

export default LoginPage
