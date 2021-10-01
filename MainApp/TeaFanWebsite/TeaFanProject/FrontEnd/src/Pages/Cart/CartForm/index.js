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
        this.setState({cart: cart.data});
    }
    getListProductPage(){}
    render() {
        return (
            <div className="my-wrap">
                {this.state.cart.details === null?
                <p>Empty cart</p>:
                this.getListProductPage()}
            </div>
        )
    }
}

export default CartForm
