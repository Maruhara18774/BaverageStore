import React, { Component } from 'react';
import CartApi from '../../../Api/CartApi';

export class CartContent extends Component {
    constructor(props) {
        super(props)
    
        this.state = {
             cart: {}
        }
    }
    async componentDidMount(){
        await this.updateCurrentCartAsync();
    }
    async ChangeQuantity(val){
        var request = {
            cartID: 0,
            productID: 0,
            quantity: 0
        };
        await CartApi.changeQuantityAsync(request);
        await this.updateCurrentCart();
    }
    async RemoveProduct(val){
        var request = {
            cartID: 0,
            productID: 0
        };
        await CartApi.removeProductAsync(request);
        await this.updateCurrentCart();
    }
    updateCurrentCart(){
        var result = await CartApi.getCurrentCartAsync();
        this.setState({cart: result.data});
    }
    render() {
        return (
            <div>
                
            </div>
        )
    }
}

export default CartContent
