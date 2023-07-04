import React from 'react';
import "./style.css";
import { useHistory } from "react-router-dom";
import AccountApi from '../../../Api/AccountApi';

export default function ProfieNavbar(props) {
    const history = useHistory();
    async function logout(){
        await AccountApi.logout();
        localStorage.removeItem("user");
        history.push("/home")
    }
    return (
        <div className="profieMenu">
        <ul>
            <li>Hello {props.name}!</li>
            <li className="right logout" onClick={()=>logout()}>Logout</li>
            <li className="right">|</li>
            <li className="right" onClick={()=>props.changePosition("history")}>Orders history</li>
            <li className="right">|</li>
            <li className="right"  onClick={()=>props.changePosition("detail")}>Account Details</li>
        </ul>
    </div>
    )
}