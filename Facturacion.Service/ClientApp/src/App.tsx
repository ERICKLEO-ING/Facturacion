import * as React from "react";
import { Route } from "react-router";
import Layout from "./components/Layout";
import Home from "./components/Home";
import Counter from "./components/Counter";
import FetchData from "./components/FetchData";
import Login from "./components/Login";

import "./custom.css";

export default () => (
  <>
    <Route exact path="/" component={Login} />
    <Route path="/counter" component={Counter} />
    <Route path="/fetch-data/:startDateIndex?" component={FetchData} />
  </>
);