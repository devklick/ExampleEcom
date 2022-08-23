import React, { useEffect, useState } from "react";
import logo from "./logo.svg";
import "./App.css";
import RegistrationForm from "./components/registration-form/registration-form";
import AppHeader from "./components/app-header/app-header";

interface AppProps {
  children: React.ReactNode;
}
const App: React.FC<AppProps> = ({ children }) => {
  return (
    <div className="App">
      <AppHeader />
      {children}
    </div>
  );
};

export default App;
