import React, { Component } from 'react'
import "./style.css";
import AccountApi from '../../Api/AccountApi';
import SubNavbar from '../../Components/Profie/SubNavbar';
import {Button} from 'antd';

export class Profie extends Component {
    constructor(props){
        super(props);
        this.state = {
            user: {},
            position: "detail"
        }
    }
    async componentDidMount(){
        var result = await AccountApi.profie();
        this.setState({user: result.data})
    }
    changePosition(position){
        this.setState({position: position})
    }
    getContent(){
        switch(this.state.position){
            case "detail":
                return (
                    <div className="profie-content">
                            <table style={{width:"100%", marginBottom:"10px"}}>
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
                            style={{marginRight:"20px"}} 
                            onClick={this.setState({position:"changePassword"})}>
                                Change Password</Button>
                            <Button shape="round" 
                            onClick={this.setState({position:"edit"})}>
                                Edit Details</Button>
                        </div>
                )
            case "history":
                return(<div className="profie-content">
                History
                </div>)
            case "changePassword":
                return(<div className="profie-content">
                    Change Password
                </div>)
            case "edit":
                return(<div className="profie-content">
                Edit profie
                </div>)
            default:
                break;
        }
    }
    render() {
        return(
            <div className="wrap">
                <SubNavbar name={this.state.user.lastName} changePosition={(val)=>this.changePosition(val)}/>
                {this.getContent()}
            </div>
        )
    }
}

export default Profie