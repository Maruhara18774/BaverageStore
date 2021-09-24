import React, { Component } from 'react';
import FilterBar from '../FilterBar';
import ProductApi from '../../../Api/ProductApi';

export class ShopForm extends Component {
    constructor(props) {
        super(props)
    
        this.state = {
            currentCate: this.props.cateID,
            products: {}
        }
        this.initial();
    }
    async initial(){
        const request = {
            page: 1,
            productTypeID: 0,
            flavorsID: [],
            origin: "",
            min: 0,
            max: 0,
            sortBy: "",
            sortType: "",
            categoryID: this.props.cateID
        };
        var products = await ProductApi.getList(request);
        this.setState({products: products.data, currentCate: this.props.cateID})
        console.log(this.state.products)
    }
    render() {
        if(this.props.cateID != this.state.currentCate){
            this.initial();
        }
        return (
            <div>
                <FilterBar cateID={this.props.cateID}/>
            </div>
        )
    }
}

export default ShopForm
