import React, { Component } from 'react';
import HomeApi from '../../../Api/HomeApi';

export class FilterBar extends Component {
    constructor(props) {
        super(props)
    
        this.state = {
            category: {},
            productTypes:[],
            flavors:[],
            origin:[],
        }
    }
    async initial(){
        var cate = await HomeApi.getCategory(this.props.cateID);
        var productTypes = await HomeApi.getProductType(this.props.cateID);
        var origin = await HomeApi.getOrigins();
        if(cate.data.isTypeOfTea){
            var flavors = await HomeApi.getFlavors();
            this.setState({
                category: cate.data,
                productTypes: productTypes.data,
                flavors: flavors.data,
                origin: origin.data
            });
        }
        else {
            this.setState({
                category: cate.data,
                productTypes: productTypes.data,
                origin : origin.data
            });
        }
    }
    
    render() {
        return (
            <div>
                
            </div>
        )
    }
}

export default FilterBar
