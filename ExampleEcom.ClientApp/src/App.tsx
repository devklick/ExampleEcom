import React, { useEffect, useState } from "react";
import logo from "./logo.svg";
import "./App.css";
import UserRegistration from "./components/user-registration/user-registration";

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
      <UserRegistration />
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
