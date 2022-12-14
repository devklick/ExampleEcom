import React from "react";
import "./index.css";
import App from "./App";
import reportWebVitals from "./reportWebVitals";
import ReactDOM from "react-dom/client";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import RegistrationForm from "./components/registration-form/registration-form";
import LoginForm from "./components/login-form/login-form";
import UserContextProvider from "./context/user-context-provider";
import AddProductForm from "./components/add-product-form/add-product-form";

const root = ReactDOM.createRoot(
  document.getElementById("root") as HTMLElement
);
root.render(
  <UserContextProvider>
    <App>
      <BrowserRouter>
        <Routes>
          <Route path="user">
            <Route path="register" element={<RegistrationForm />} />
            <Route path="login" element={<LoginForm />} />
          </Route>
          <Route path="products">
            <Route path="add" element={<AddProductForm />} />
          </Route>
        </Routes>
      </BrowserRouter>
    </App>
  </UserContextProvider>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
