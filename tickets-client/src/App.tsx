import React, { useEffect } from "react";
import "./App.css";
import { TicketsClient } from "./protoc/TicketsServiceClientPb";
import { TicketRequestId } from "./protoc/tickets_pb";

var client = new TicketsClient("https://localhost:5000");

function App() {
  useEffect(() => {
    var request = new TicketRequestId();
    request.setId("000000000");
    client.getTicket(request, {}, (err, response) => {
      console.log(err);
      console.log(response.getId());
    });
  }, []);

  return (
    <div className="App">
      <header className="App-header">
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
