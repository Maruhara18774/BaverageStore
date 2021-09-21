import React from 'react';
import "./style.css"

export default function ProfieNavbar(props) {
    return (
        <div className="profieMenu">
            <ul>
                <li>Hello {props.name}!</li>
                <li className="right logout">Logout</li>
                <li className="right">|</li>
                <li className="right">Orders history</li>
                <li className="right">|</li>
                <li className="right">Account Details</li>
            </ul>
        </div>
    )
}
