import "./style.css";
import React, { useState, useEffect, useContext, useRef } from "react";
import {
  Layout,
  Menu,
  Table,
  Input,
  Button,
  Popconfirm,
  Form,
  Modal,
  Select,
} from "antd";
import {
  UserOutlined,
  VideoCameraOutlined,
  UploadOutlined,
} from "@ant-design/icons";
import { Link, Route, Router } from "react-router-dom";
import AdminApi from "../../Api/AdminApi";
import ProductApi from "../../Api/ProductApi";
import HomeApi from "../../Api/HomeApi";
const { Header, Sider, Content } = Layout;

function ManageHome(props) {
  const [isModalVisible, setIsModalVisible] = useState(false);
  const [productList, setProductList] = useState([]);
  const [categoryList, setCategoryList] = useState([]);
  const [typename, setTypename] = useState("");
  const [categoryID, setCategoryID] = useState(0);
  const EditableContext = React.createContext(null);
  const EditableRow = ({ index, ...props }) => {
    const [form] = Form.useForm();
    return (
      <Form form={form} component={false}>
        <EditableContext.Provider value={form}>
          <tr {...props} />
        </EditableContext.Provider>
      </Form>
    );
  };
  const EditableCell = ({
    title,
    editable,
    children,
    dataIndex,
    record,
    handleSave,
    ...restProps
  }) => {
    const [editing, setEditing] = useState(false);
    const inputRef = useRef(null);
    const form = useContext(EditableContext);
    useEffect(() => {
      if (editing) {
        inputRef.current.focus();
      }
    }, [editing]);

    const toggleEdit = () => {
      setEditing(!editing);
      form.setFieldsValue({
        [dataIndex]: record[dataIndex],
      });
    };

    const save = async () => {
      try {
        const values = await form.validateFields();
        toggleEdit();
        handleSave({ ...record, ...values });
      } catch (errInfo) {
        console.log("Save failed:", errInfo);
      }
    };

    let childNode = children;

    if (editable) {
      childNode = editing ? (
        <Form.Item
          style={{
            margin: 0,
          }}
          name={dataIndex}
          rules={[
            {
              required: true,
              message: `${title} is required.`,
            },
          ]}
        >
          <Input ref={inputRef} onPressEnter={save} onBlur={save} />
        </Form.Item>
      ) : (
        <div
          className="editable-cell-value-wrap"
          style={{
            paddingRight: 24,
          }}
          onClick={toggleEdit}
        >
          {children}
        </div>
      );
    }

    return <td {...restProps}>{childNode}</td>;
  };
  const columns = [
    {
      title: "ID",
      key: "categoryID",
      dataIndex: "categoryID",
    },
    {
      title: "Product Type",
      dataIndex: "productTypes",
      key: "categoryID",
    },
    {
      title: "Category",
      dataIndex: "categoryName",
      key: "categoryID",
    },
    {
      title: "Action",
      dataIndex: "operation",
      render: (_, record) =>
        productList.length >= 1 ? (
          <Popconfirm
            title="Sure to delete?"
            onConfirm={() => handleDelete(record)}
          >
            <a>Delete</a>
          </Popconfirm>
        ) : null,
    },
  ];
  //Xu ly Delete
  const handleDelete = (item) => {
    AdminApi.removeProductType(item.productID).then((res) => {
      // ProductAdminApi.getListAdmin(1).then((res) => {
      //   setProductList(res.items);
      // });
    });
  };
  //Xu ly Add
  const [getCategories, setGetCategories] = useState([]);
  useEffect(() => {
    HomeApi.getCategories().then((res) => {
      setGetCategories(res.data);
    });
  }, []);
  const onChangeTypeName = (e) => {
    setTypename(e.target.value);
  };

  const { Option } = Select;
  const onChangeCategoryID = (e) => {
    setCategoryID(e);
  };
  const handleAdd = () => {
    AdminApi.addProductType({
      categoryID: categoryID,
      typeName: typename,
      // }).then((res) => {
      //   ProductAdminApi.getListAdmin(1).then((res) => {
      //     setProductList(res.items);
      //   });
    });
    setIsModalVisible(false);
  };

  //Xu ly Save
  const handleSave = (row) => {
    const newData = [...productList];
    const index = newData.findIndex((item) => row.key === item.key);
    const item = newData[index];
    newData.splice(index, 1, { ...item, ...row });
    setProductList(newData);
  };

  const components = {
    body: {
      row: EditableRow,
      cell: EditableCell,
    },
  };
  columns.map((col) => {
    if (!col.editable) {
      return col;
    }

    return {
      ...col,
      onCell: (record) => ({
        record,
        editable: col.editable,
        dataIndex: col.productList,
        title: col.title,
        handleSave: handleSave,
      }),
    };
  });
  useEffect(() => {
    AdminApi.getListProduct(1).then((res) => {
      setProductList(res.items);
    });
  }, []);
  // Xử lý Modal Form
  const layout = {
    labelCol: {
      span: 8,
    },
    wrapperCol: {
      span: 16,
    },
  };
  const validateMessages = {
    required: "${label} is required!",
    types: {
      email: "${label} is not a valid email!",
      number: "${label} is not a valid number!",
    },
    number: {
      range: "${label} must be between ${min} and ${max}",
    },
  };
  const onFinish = (values) => {
    console.log(values);
  };

  // Xử lý Modal
  const showModal = () => {
    setIsModalVisible(true);
  };

  const handleCancel = () => {
    setIsModalVisible(false);
  };
  return (
    <div>
      <Button
        onClick={showModal}
        type="primary"
        style={{
          marginBottom: 16,
        }}
      >
        Add a product
      </Button>
      <Modal
        title="Add a Product"
        visible={isModalVisible}
        onOk={handleAdd}
        onCancel={handleCancel}
      >
        <Form
          {...layout}
          name="nest-messages"
          onFinish={onFinish}
          validateMessages={validateMessages}
        >
          <Form.Item
            name={["add", "name"]}
            label="Category"
            rules={[
              {
                required: true,
              },
            ]}
          >
            <Select
              style={{ width: 120 }}
              onChange={onChangeCategoryID}
              value={categoryID}
            >
              {getCategories
                ? getCategories.map((item, index) => (
                    <Option key={index} value={item.categoryID}>
                      {item.categoryName}
                    </Option>
                  ))
                : null}
            </Select>
          </Form.Item>
          <Form.Item
            name={["add", "flavor"]}
            label="Type Name"
            rules={[
              {
                required: true,
              },
            ]}
          >
            <Input
              placeholder="Type Name"
              type="text"
              value={typename}
              onChange={onChangeTypeName}
            />
          </Form.Item>
        </Form>
      </Modal>
      <Table
        components={components}
        rowClassName={() => "editable-row"}
        bordered
        dataSource={getCategories}
        columns={columns}
      />
    </div>
  );
}

export default ManageHome;
