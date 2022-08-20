import React, { useEffect, useState } from "react";
import logo from "./logo.svg";
import "./App.css";
import RegistrationForm from "./components/registration-form/registration-form";
import AppHeader from "./components/app-header/app-header";

function App() {
  return (
    <div className="App">
      <AppHeader />
      <RegistrationForm />
    </div>
  );
}

export default App;
