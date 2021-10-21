import React, { useEffect, useState } from "react";
import "./style.css";
import CartContent from "../../../Components/Cart/CartContent";
import CartApi from "../../../Api/CartApi";
import { useHistory } from "react-router-dom";

export default function CartForm() {
  const history = useHistory();
  const [listcart, setListcart] = useState([]);
  const [cartID, setCartID] = useState();
  const [subTotal, setSubTotal] = useState();
  useEffect(() => {
    updateCurrentCart();
  }, []);
  function Checkout() {
    history.push("/checkout");
  }
  const updateCurrentCart = () => {
    CartApi.getCurrentCartAsync().then((res) => {
      setListcart(res.data.details);
      setCartID(res.data.cartID);
      var total = 0;
      res.data.details?.map((item) => {
        total += item.soldPrice * item.quantity;
      });
      setSubTotal(total);
    });
  };
  return (
    <div className="my-wrap">
      <div className="cart-wrapper">
        <h1>My Cart</h1>
        {listcart?.map((item, index) => {
          return (
            <div>
              <CartContent
                key={index}
                updateCart={updateCurrentCart}
                item={item}
                cartID={cartID}
              />
            </div>
          );
        })}
        <div className="total">
          <div className="subtotal">
            <span>SUBTOTAL</span>
            <span>{subTotal}$</span>
          </div>
          <button className="btn-checkout" onClick={Checkout}>
            Checkout
          </button>
        </div>
      </div>
    </div>
  );
}
