import React, { useEffect, useState } from "react";
import logo from "./logo.svg";
import "./App.css";

interface WeatherForecast {
  date: Date;
  temperatureC: number;
  temperatureF: number;
  summary: string | null;
}

function App() {
  const [weather, setWeather] = useState<WeatherForecast[]>([]);
  useEffect(() => {
    const getForecast = async () => {
      await fetch("weatherForecast").then(async (response) => {
        const data = await response.json();
        console.log(data);
        setWeather(data);
      });
    };
    getForecast();
  }, []);

  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.tsx</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
      {weather.map((w) => {
        return (
          <div>
            <span>Date:</span> <span>{w.date.toString()}</span>
            <span>Temp (C):</span> <span>{w.temperatureC}</span>
            <span>Temp (F):</span> <span>{w.temperatureF}</span>
            {w.summary && (
              <>
                <span>Summary:</span> <span>{w.summary}</span>{" "}
              </>
            )}
          </div>
        );
      })}
    </div>
  );
}

export default App;
