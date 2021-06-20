import * as React from "react";
import toast from "react-hot-toast";
import { APIURL } from "../constants";
import { TicketsClient } from "../protoc/TicketsServiceClientPb";
import { EditTicketRequest } from "../protoc/tickets_pb";
import { EditTicketComponentCont } from "./styles";

var client = new TicketsClient(APIURL);

interface EditTicketComponentProps {
  ticket: ITicket;
  onUpdated: () => void;
}

const EditTicketComponent: React.FC<EditTicketComponentProps> = ({
  ticket,
  onUpdated,
}) => {
  const [user, setUser] = React.useState(ticket.user);
  const [status, setStatus] = React.useState(ticket.status ? "0" : "1");
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
    var request = new EditTicketRequest();
    request.setId(ticket.id);
    request.setUser(user);
    request.setStatus(status === "0");
    client.editTicket(request, {}, (err, response) => {
      if (err) {
        toast.error(err.message);
      } else {
        toast.success(`The ticket has been updated! ID: ${response.getId()}`);
        onUpdated();
        setUser("");
        setStatus("0");
      }
      setLoading(false);
    });
  };

  return (
    <EditTicketComponentCont>
      <h2>Modify ticket</h2>
      <label>
        User:
        <input type="text" value={user} onChange={handleUserChange} />
      </label>
      <label>
        Status:
        <select value={status} onChange={handleStatusChange}>
          <option value="0">Open</option>
          <option value="1">Closed</option>
        </select>
      </label>
      <button disabled={loading} onClick={handleCreateButton}>
        Update
      </button>
    </EditTicketComponentCont>
  );
};

export default EditTicketComponent;
