import React, { Component } from "react";
import HomeApi from "../../../Api/HomeApi";
import "antd/dist/antd.css";
import "./filter.css";
import {
  Checkbox,
  Radio,
  Input,
  Space,
  Button,
  Layout,
  Menu,
  Select,
} from "antd";
const { Option } = Select;
const { SubMenu } = Menu;
const { Sider } = Layout;
export class FilterBar extends Component {
  constructor(props) {
    super(props);

    this.state = {
      category: {},
      productTypes: [],
      flavors: [],
      origin: [],
    };
  }
  onChangeProDuctType = (e) => {
    var request = {
      ...this.state.request,
      productTypeID: e.target.value,
    };
    this.setState({ request: request });
    this.filter();
  };
  onChangeOrigin = (e) => {
    var request = {
      ...this.state.request,
      origin: e.target.value,
    };
    this.setState({ request: request });
    this.filter()
  };
  onChangeMin = (e) => {
    var request = {
      ...this.state.request,
      min: e.target.value,
    };
    this.setState({ request: request });
  };
  onChangeMax = (e) => {
    var request = {
      ...this.state.request,
      max: e.target.value,
    };
    this.setState({ request: request });
  };

  handleChange(value) {
  }
  async initial() {
    var cate = await HomeApi.getCategory(this.props.cateID);
    var productTypes = await HomeApi.getProductType(this.props.cateID);
    var origin = await HomeApi.getOrigins();
    if (
      cate.data.categoryName === "Tea" ||
      cate.data.categoryName === "Packaged"
    ) {
      var flavors = await HomeApi.getFlavors();
      var listFlavor = [];
      flavors.map((item) => {
        listFlavor.push({ label: item.flavorName, value: item.flavorID });
        return listFlavor;
      });
      this.setState({
        category: cate.data,
        productTypes: productTypes.data,
        flavors: listFlavor,
        origin: origin,
        currentCate: this.props.cateID,
      });
    } else {
      this.setState({
        category: cate.data,
        productTypes: productTypes.data,
        origin: origin,
        currentCate: this.props.cateID,
      });
    }
  }

  filter = () => {
    this.props.filterChange(this.state.request);
  };

  typeChange = (e) => {
    var request = {
      ...this.state.request,
      sortType: e,
    };
    this.setState({ request: request });
  };

  flavorsChange = (e) => {
    var request = {
      ...this.state.request,
      flavorsID: e,
    };
    this.setState({ request: request });
  };

  orderChange = (e) => {
    var request = {
      ...this.state.request,
      sortBy: e,
    };
    this.setState({ request: request });
  };

  componentDidMount() {
    this.initial();
    this.setState({
      request: {
        page: 1,
        productTypeID: 0,
        flavorsID: [],
        origin: "",
        min: 0,
        max: 0,
        sortBy: "ASC",
        pageCount: 1,
        sortType: "",
        categoryID: this.props.cateID,
      },
    });
  }

  clearFilter = () => {
    const request = {
      page: 1,
      productTypeID: 0,
      flavorsID: [],
      origin: "",
      min: 0,
      max: 0,
      sortBy: "ASC",
      pageCount: 1,
      sortType: "",
      categoryID: this.props.cateID,
    };
    this.props.filterChange(request);
    this.setState({
      request: request,
    });
  };

  render() {
    if (this.props.cateID !== this.state.currentCate) {
      this.initial();
    }
    return (
      <div className="layout-wrapper">
        <Sider
          width={300}
          style={{ height: "100%" }}
          className="site-layout-background"
        >
          <Menu
            mode="inline"
            defaultSelectedKeys={["1"]}
            defaultOpenKeys={["sub1"]}
            style={{ height: "100%", borderRight: 0 }}
          >
            <SubMenu key="sub1" title="PRODUCT TYPE">
              <Radio.Group
                className="sideBox"
                onChange={this.onChangeProDuctType}
                value={this.state.request?.productTypeID}
              >
                <Space direction="vertical">
                  {this.state.productTypes
                    ? this.state.productTypes.map((item) => {
                        return (
                          <Radio value={item.typeID}>{item.typeName}</Radio>
                        );
                      })
                    : null}
                </Space>
              </Radio.Group>
            </SubMenu>
            {this.state.category.categoryName === "Tea" ||
            this.state.category.categoryName === "Packaged" ? (
              <SubMenu key="sub2" title="FLAVOR">
                {this.state.flavors ? (
                  <Checkbox.Group
                    onChange={this.flavorsChange}
                    className="flavorBox"
                    value={this.state.request?.flavorsID}
                    options={this.state.flavors}
                  />
                ) : null}
              </SubMenu>
            ) : null}
            <SubMenu key="sub3" title="ORIGIN">
              <Radio.Group
                className="sideBox"
                onChange={this.onChangeOrigin}
                value={this.state.request?.origin}
              >
                <Space direction="vertical">
                  {this.state.origin
                    ? this.state.origin.map((item) => {
                        return <Radio value={item}>{item}</Radio>;
                      })
                    : null}
                </Space>
              </Radio.Group>
            </SubMenu>
            <SubMenu key="sub4" title="PRICE">
              <div className="price-boxs">
                <Input
                  className="pricebox"
                  style={{ width: 120 }}
                  type="number"
                  value={this.state.request?.min}
                  placeholder="Min"
                  onChange={this.onChangeMin}
                ></Input>
                <Input
                  className="pricebox"
                  type="number"
                  value={this.state.request?.max}
                  style={{ width: 120 }}
                  placeholder="Max"
                  onChange={this.onChangeMax}
                ></Input>
              </div>
            </SubMenu>
            <SubMenu key="sub5" title="SORT">
              <div className="price-boxs">
                <Select
                  value={this.state.request?.sortType}
                  style={{ width: 120 }}
                  onChange={this.typeChange}
                >
                  <Option value="Name">Name</Option>
                  <Option value="Price">Price</Option>
                  <Option value="">Default</Option>
                </Select>
                <Select
                  value={this.state.request?.sortBy}
                  style={{ width: 120 }}
                  onChange={this.orderChange}
                >
                  <Option value="ASC">Ascending</Option>
                  <Option value="DESC">Decrease</Option>
                </Select>
              </div>
            </SubMenu>
            <div className="pricebtnwrapper">
              <Button className="pricebtn" onClick={this.filter}>
                Filter
              </Button>
              <Button className="pricebtn" onClick={this.clearFilter}>
                Clear all
              </Button>
            </div>
          </Menu>
        </Sider>
      </div>
    );
  }
}

export default FilterBar;
