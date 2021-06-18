import React, { useEffect } from "react";
import logo from "./logo.svg";
import "./App.css";
import { GreeterClient } from "./protoc/GreetServiceClientPb";
import { HelloRequest } from "./protoc/greet_pb";

var client = new GreeterClient("https://localhost:5000");

function App() {
  useEffect(() => {
    var request = new HelloRequest();
    request.setName("World");
    client.sayHello(request, {}, (err, response) => {
      console.log(response.getMessage());
    });
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
    </div>
  );
}

export default App;
