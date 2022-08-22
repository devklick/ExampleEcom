import React, { useEffect, useState } from "react";
import logo from "./logo.svg";
import "./App.css";
import RegistrationForm from "./components/registration-form/registration-form";
import AppHeader from "./components/app-header/app-header";
import LoginForm from "./components/login-form/login-form";

function App() {
  return (
    <div className="App">
      <AppHeader />
      {/* <RegistrationForm /> */}
      <LoginForm></LoginForm>
    </div>
  );
}

export default App;
