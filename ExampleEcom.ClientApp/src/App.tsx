import React, { useEffect, useState } from "react";
import logo from "./logo.svg";
import "./App.css";
import UserRegistration from "./components/user-registration/user-registration";
import AppHeader from "./components/app-header/app-header";

function App() {
  return (
    <div className="App">
      <AppHeader />
      <UserRegistration />
    </div>
  );
}

export default App;
