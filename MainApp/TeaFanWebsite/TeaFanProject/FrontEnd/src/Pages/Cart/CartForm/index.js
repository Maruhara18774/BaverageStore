import React from 'react';
import './style.css';
import CartContent from '../../../Components/Cart/CartContent';
import {useHistory} from 'react-router-dom'

export default function CartForm() {
    const history = useHistory();
    function Checkout(){
        history.push("/checkout")
    }
    return (
        <div className="my-wrap">
                <CartContent/>
                <button onClick = {Checkout}>Checkout</button>
            </div>
    )
}
