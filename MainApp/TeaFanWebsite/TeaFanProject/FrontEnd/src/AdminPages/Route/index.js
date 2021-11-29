import React from "react";
import { Route, useParams } from "react-router-dom";
import ProductTypes from "../ProductTypes";

function AdminRouting(props) {
  return (
    <div classname="admin-routing" style={{ width: "100%" }}>
      <Route path="/admin/producttypes/:id">
        <div>
          <ProductTypes />
        </div>
      </Route>
    </div>
  );
}

export default AdminRouting;
