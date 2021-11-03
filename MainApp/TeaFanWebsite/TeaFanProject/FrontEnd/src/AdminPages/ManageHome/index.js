import "./style.css";
import { React, useState, useEffect } from "react";
import { Layout, Menu, Table } from "antd";
import {
  UserOutlined,
  VideoCameraOutlined,
  UploadOutlined,
} from "@ant-design/icons";
import AdminApi from "../../Api/AdminApi";
import ProductApi from "../../Api/ProductApi";
import HomeApi from "../../Api/HomeApi";
const { Header, Sider, Content } = Layout;
const columns = [
  {
    title: "Product Name",
    dataIndex: "name",
  },
  {
    title: "Age",
    dataIndex: "age",
  },
  {
    title: "Address",
    dataIndex: "address",
  },
];

const data = [];
for (let i = 0; i < 46; i++) {
  data.push({
    key: i,
    name: `Edward King ${i}`,
    age: 32,
    address: `London, Park Lane no. ${i}`,
  });
}
function ManageHome(props) {
  const [productList, setProductList] = useState([]);
  const [rowkey, setRowkey] = useState([]);
  const onSelectChange = (rowkey) => {
    console.log("selectedRowKeys changed: ", rowkey);
    setRowkey();
  };
  const { selectedRowKeys } = rowkey;
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
    categoryID: props.cateID,
  };
  useEffect(() => {
    ProductApi.getList(request)
      .then((res) => setProductList(res.data))
      .catch((error) => {
        console.log("error");
      });
  }, []);

  const rowSelection = {
    selectedRowKeys,
    onChange: onSelectChange,
    selections: [
      Table.SELECTION_ALL,
      Table.SELECTION_INVERT,
      Table.SELECTION_NONE,
      {
        key: "odd",
        text: "Select Odd Row",
        onSelect: (changableRowKeys) => {
          let newSelectedRowKeys = [];
          newSelectedRowKeys = changableRowKeys.filter((key, index) => {
            if (index % 2 !== 0) {
              return false;
            }
            return true;
          });
          setRowkey({ selectedRowKeys: newSelectedRowKeys });
        },
      },
      {
        key: "even",
        text: "Select Even Row",
        onSelect: (changableRowKeys) => {
          let newSelectedRowKeys = [];
          newSelectedRowKeys = changableRowKeys.filter((key, index) => {
            if (index % 2 !== 0) {
              return true;
            }
            return false;
          });
          setRowkey({ selectedRowKeys: newSelectedRowKeys });
        },
      },
    ],
  };
  return (
    <Layout>
      <Sider
        breakpoint="lg"
        collapsedWidth="0"
        onBreakpoint={(broken) => {
          console.log(broken);
        }}
        onCollapse={(collapsed, type) => {
          console.log(collapsed, type);
        }}
      >
        <div className="logo" />
        <Menu theme="dark" mode="inline" defaultSelectedKeys={["4"]}>
          <Menu.Item key="1" icon={<UserOutlined />}>
            nav 1
          </Menu.Item>
          <Menu.Item key="2" icon={<VideoCameraOutlined />}>
            nav 2
          </Menu.Item>
          <Menu.Item key="3" icon={<UploadOutlined />}>
            nav 3
          </Menu.Item>
          <Menu.Item key="4" icon={<UserOutlined />}>
            nav 4
          </Menu.Item>
        </Menu>
      </Sider>
      <Layout>
        <Header
          className="site-layout-sub-header-background"
          style={{ padding: 0 }}
        />
        <Content style={{ margin: "24px 16px 0" }}>
          <div
            className="site-layout-background"
            style={{ padding: 24, minHeight: 360 }}
          >
            <Table
              rowSelection={rowSelection}
              columns={columns}
              dataSource={data}
            />
          </div>
        </Content>
      </Layout>
    </Layout>
  );
}

export default ManageHome;
