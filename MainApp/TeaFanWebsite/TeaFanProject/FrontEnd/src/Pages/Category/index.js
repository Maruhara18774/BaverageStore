import React from "react";
import { useParams } from "react-router-dom";
import ShopForm from "../../Components/Category/CoreForm";

export default function CateShop() {
  const cateID = useParams()?.id;
  console.log(cateID);
  return (
    <div>
      <ShopForm cateID={cateID} />
    </div>
  );
}
