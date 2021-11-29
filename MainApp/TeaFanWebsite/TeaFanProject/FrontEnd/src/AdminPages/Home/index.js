import React, { useState, useEffect } from "react";
import { Layout, Menu, Breadcrumb } from "antd";
import { Link, useParams } from "react-router-dom";
import { TeamOutlined, UserOutlined } from "@ant-design/icons";
import "./style.css";
import AdminRouting from "../Route";
import HomeApi from "../../Api/HomeApi";
function AdminHome(props) {
  const { Header, Content, Footer, Sider } = Layout;
  const { SubMenu } = Menu;
  const [collapsed, setCollapsed] = useState(false);
  const [getCategories, setGetCategories] = useState([]);
  const cateID = useParams()?.id;
  const onCollapse = (collapsed) => {
    console.log(collapsed);
    setCollapsed(collapsed);
  };
  useEffect(() => {
    HomeApi.getCategories().then((res) => {
      setGetCategories(res.data);
    });
  }, []);
  return (
    <Layout style={{ minHeight: "100vh" }}>
      <Sider
        className="menu-sider"
        collapsible
        collapsed={collapsed}
        onCollapse={onCollapse}
      >
        <div className="logo" />
        <Menu className="menu-sider" mode="inline">
          <SubMenu key="sub1" icon={<UserOutlined />} title="Product Type">
            {getCategories
              ? getCategories.map((item, index) => (
                  <Menu.Item key={index}>
                    {" "}
                    <Link to={() => "/admin/producttypes/" + item.categoryID}>
                      {item.categoryName}
                    </Link>
                  </Menu.Item>
                ))
              : null}
          </SubMenu>
          <SubMenu key="sub2" icon={<TeamOutlined />} title="Team">
            <Menu.Item key="6">Team 1</Menu.Item>
            <Menu.Item key="8">Team 2</Menu.Item>
          </SubMenu>
        </Menu>
      </Sider>
      <Layout className="site-layout">
        <Header className="site-layout-header">
          <h1>TEAFAN WEBSITE MANAGER</h1>
        </Header>
        <Content style={{ margin: "0 16px" }}>
          <div
            className="admin-content"
            style={{ padding: 24, minHeight: 360 }}
          >
            <AdminRouting />
          </div>
        </Content>
        <Footer style={{ textAlign: "center" }}>
          Ant Design ©2018 Created by Ant UED
        </Footer>
      </Layout>
    </Layout>
  );
}

export default AdminHome;
