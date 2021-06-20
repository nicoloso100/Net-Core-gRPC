import * as React from "react";
import { SectionContainer } from "./styles";
import { TicketsClient } from "../protoc/TicketsServiceClientPb";
import { AddTicketRequest } from "../protoc/tickets_pb";
import toast from "react-hot-toast";
import { APIURL } from "../constants";

var client = new TicketsClient(APIURL);

interface ICreateTicketProps {
  onCreated: () => void;
}

const CreateTicket: React.FC<ICreateTicketProps> = ({ onCreated }) => {
  const [user, setUser] = React.useState("");
  const [status, setStatus] = React.useState("0");
  const [loading, setLoading] = React.useState(false);

  const handleUserChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setUser(event.target.value);
  };

  const handleStatusChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    console.log(event.target.value);
    setStatus(event.target.value);
  };

  const handleCreateButton = () => {
    setLoading(true);
    var request = new AddTicketRequest();
    request.setUser(user);
    request.setStatus(status === "0");
    client.addTicket(request, {}, (err, response) => {
      if (err) {
        toast.error(err.message);
      } else {
        toast.success(`The ticket has been created! ID: ${response.getId()}`);
        onCreated();
        setUser("");
        setStatus("0");
      }
      setLoading(false);
    });
  };

  return (
    <SectionContainer>
      <h2>Create ticket</h2>
      <label>
        User:
        <input type="text" value={user} onChange={handleUserChange} />
      </label>
      <label>
        Status:
        <select value={status} onChange={handleStatusChange}>
          <option value="0">True</option>
          <option value="1">False</option>
        </select>
      </label>
      <button disabled={loading} onClick={handleCreateButton}>
        Create
      </button>
    </SectionContainer>
  );
};

export default CreateTicket;
