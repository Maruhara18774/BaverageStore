import React, { Component } from 'react';
import CartApi from '../../../Api/CartApi';
import AccountApi from '../../../Api/AccountApi';

export class CheckoutForm extends Component {
    constructor(props) {
        super(props)
    
        this.state = {
             cart: {},
             user: {}
        }
    }
    async componentDidMount(){
        var cart = await CartApi.getCheckoutInforAsync();
        var user = await AccountApi.profie();
        this.setState({cart: cart, user:user});
    }
    async checkOut(){
        await CartApi.confirmCheckoutAsync();
    }
    render() {
        return (
            <div>
                This is checkout
            </div>
        )
    }
}

export default CheckoutForm
