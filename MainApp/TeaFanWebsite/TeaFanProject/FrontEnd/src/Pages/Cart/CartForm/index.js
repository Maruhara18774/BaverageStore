import React, { Component } from 'react';
import './style.css';
import CartApi from '../../../Api/CartApi';

export class CartForm extends Component {
    constructor(props) {
        super(props)
    
        this.state = {
             cart: {}
        };
    }
    async componentDidMount(){
        var cart = await CartApi.getCurrentCartAsync();
        this.setState({cart: cart});
    }
    render() {
        return (
            <div className="my-wrap">
                This is your cart
            </div>
        )
    }
}

export default CartForm
