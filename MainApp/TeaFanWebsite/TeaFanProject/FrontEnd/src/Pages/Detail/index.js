import React, { useState, useEffect } from "react";
import "./Detail.css";
import {
  Image,
  InputNumber,
  Button,
  Comment,
  List,
  Rate,
  Row,
  Col,
  Form,
  Input,
  Modal,
} from "antd";
import { HeartTwoTone } from "@ant-design/icons";
import moment from "moment";
import ProductApi from "../../Api/ProductApi";
import { useHistory } from "react-router";
import CartApi from "../../Api/CartApi";
export default function Detail(props) {
  const [comment, setComment] = useState("");
  const [titleComment, setTitleComment] = useState("");
  const [rateComment, setRateComment] = useState(3);
  const [feedback, setFeedback] = useState();
  const [totalfeedback, setTotalfeedback] = useState();
  const [detail, setDetail] = useState();
  const [quantity, setQuantity] = useState(1);
  const [isModalVisible, setIsModalVisible] = useState(false);
  const history = useHistory();
  useEffect(() => {
    ProductApi.getDetail(props.match.params.id)
      .then((res) => setDetail(res.data))
      .catch((error) => {
        history.push("/home");
      });
    ProductApi.getListfeedback({
      page: 1,
      productID: props.match.params.id,
    }).then((res) => {
      setFeedback(res.data.items);
      setTotalfeedback(res.data.totalRecords);
    });
  }, []);
  const { TextArea } = Input;

  const onChangeComment = (e) => {
    setComment(e.target.value);
  };
  const onChangeTitle = (e) => {
    setTitleComment(e.target.value);
  };
  const onChangeRate = (e) => {
    setRateComment(e);
  };
  const onSubmitComment = () => {
    ProductApi.createComment({
      productID: props.match.params.id,
      starCount: rateComment,
      title: titleComment,
      content: comment,
    }).then((res) => {
      ProductApi.getListfeedback({
        page: 1,
        productID: props.match.params.id,
      }).then((res) => {
        setFeedback(res.data.items);
        setTotalfeedback(res.data.totalRecords);
      });
      setTitleComment("");
      setRateComment(3);
      setComment("");
    });
  };
  const addToCart = () => {
    CartApi.addProductAsync({
      productID: props.match.params.id,
      quantity,
    });
  };
  const showModal = () => {
    setIsModalVisible(true);
  };

  const handleOk = () => {
    setIsModalVisible(false);
  };

  const handleCancel = () => {
    setIsModalVisible(false);
  };
  console.log(localStorage.user);

  // const CommentList = ({ comments }) => (
  //   <List
  //     dataSource={comments}
  //     header={`${comments.length} ${comments.length > 1 ? "replies" : "reply"}`}
  //     itemLayout="horizontal"
  //     renderItem={(props) => <Comment {...props} />}
  //   />
  // );

  return (
    <div>
      <div className="detail-container">
        <div className="img-group">
          <div className="img-small">
            {detail
              ? detail.images.map((item, index) => {
                  return (
                    <Image
                      key={index}
                      className="small-img"
                      width={132}
                      height={147}
                      src={`https://localhost:44330${item}`}
                    />
                  );
                })
              : null}
          </div>
          <Image
            className="img-large"
            width={589}
            height={662}
            src={`https://localhost:44330${detail?.images[0]}`}
          />
        </div>
        <div className="detail-content">
          <p className="content-type">{detail?.typeName}</p>
          <h1 className="content-name">{detail?.productName}</h1>
          <p className="content-description">{detail?.description}</p>
          <Rate value="4" />
          <div className="buy">
            <InputNumber
              min={1}
              max={100}
              value={quantity}
              onChange={(e) => {
                setQuantity(e);
              }}
            />
            <Button
              className="add-btn"
              onClick={() => {
                addToCart();
                showModal();
              }}
            >
              ADD TO CART - ${detail?.price}
            </Button>
            <Modal
              title="Art of Tea"
              visible={isModalVisible}
              onOk={handleOk}
              onCancel={handleCancel}
            >
              <p>
                Your product has been successfully added to the cart{" "}
                <HeartTwoTone twoToneColor="#eb2f96" />
              </p>
            </Modal>
          </div>
        </div>
      </div>

      {detail?.tea ? (
        <div className="product-intruction">
          <div className="instruction-wrapper">
            <div className="info1">
              <h1 className="info-title">Steeping Instructions</h1>
              <div className="info-content">
                <p>Water temperature: {detail?.tea.waterTemperature} F</p>
                <p>Steep time: {detail?.tea.steepTime}</p>
                <p>Serving size: {detail?.tea.servingSize}</p>
              </div>
              <div className="brand">
                <h1 className="info-title">Brand</h1>
                <p className="info-content">{detail?.brand}</p>
              </div>
            </div>
            <div className="info2">
              <h1 className="info-title">Ingredients</h1>
              <div className="info-content">
                <p>{detail?.tea.ingredients}</p>
              </div>
              <div className="origin">
                <h1 className="info-title">Origin</h1>
                <p className="info-content">{detail?.origin}</p>
              </div>
            </div>
          </div>
        </div>
      ) : (
        <div className="product-intruction">
          <div className="instruction-wrapper">
            <div className="info1">
              <h1 className="info-title">Product Details</h1>
              <div className="info-content">
                <p>Material: {detail?.other.material}</p>
                <p>Color: {detail?.other.color}</p>
              </div>
              <div className="brand">
                <h1 className="info-title">Brand</h1>
                <p className="info-content">{detail?.brand}</p>
              </div>
            </div>
            <div className="info2">
              <h1 className="info-title">Dimensions</h1>
              <div className="info-content">
                <p>
                  {detail?.other.demensions[0].demensionName}:&nbsp;
                  {detail?.other.demensions[0].value}
                  {detail?.other.demensions[0].unit}
                </p>
              </div>
              <div className="origin">
                <h1 className="info-title">Origin</h1>
                <p className="info-content">{detail?.origin}</p>
              </div>
            </div>
          </div>
        </div>
      )}

      <div className="review-rating">
        <div className="review-rating-wrapper">
          <div className="review-header">
            <h1>Ratings & Reviews</h1>
            <Button>Write a review</Button>
          </div>
          <List
            className="comment-list"
            header={`${totalfeedback} replies`}
            itemLayout="horizontal"
            dataSource={feedback}
            pagination={{
              onChange: (page) => {
                ProductApi.getListfeedback({
                  page: page,
                  productID: props.match.params.id,
                }).then((res) => {
                  setFeedback(res.data.items);
                  setTotalfeedback(res.data.totalRecords);
                });
              },
              pageSize: 5,
              totalItem: totalfeedback,
            }}
            renderItem={(item) => (
              <li>
                <Comment className="comment">
                  <Row>
                    <Col span={4}>
                      <span className="comment-date">
                        {moment(item.createDate).format("DD/MM/YYYY")}
                      </span>
                      <h4 className="comment-name">{item.fullName}</h4>
                      <Rate value={item.starCount} />
                    </Col>
                    <Col span={16}>
                      <h4 className="comment-title">{item.title}</h4>
                      <p className="comment-content">{item.content}</p>
                    </Col>
                  </Row>
                </Comment>
              </li>
            )}
          />
          {localStorage.user === undefined ? null : (
            <div className="add-cmt" style={{ marginTop: "20px" }}>
              <Form.Item>
                <div className="cmt-title">
                  <Input
                    className="title-input"
                    placeholder="Title"
                    type="text"
                    value={titleComment}
                    onChange={onChangeTitle}
                  ></Input>
                  <Rate value={rateComment} onChange={onChangeRate} />
                </div>
                <div style={{ display: "flex", marginTop: "20px" }}>
                  <TextArea
                    rows={4}
                    value={comment}
                    onChange={onChangeComment}
                    placeholder="Your review..."
                  />
                </div>
              </Form.Item>
              <Form.Item>
                <Button
                  htmlType="submit"
                  onClick={onSubmitComment}
                  type="primary"
                >
                  Add Review
                </Button>
              </Form.Item>
            </div>
          )}
        </div>
      </div>
    </div>
  );
}
