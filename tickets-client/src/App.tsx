import React, { useCallback } from "react";
import { Toaster } from "react-hot-toast";
import "./App.css";
import CreateTicket from "./pages/CreateTicket";
import TicketsTable from "./pages/TicketsTable";
import toast from "react-hot-toast";
import { TicketsClient } from "./protoc/TicketsServiceClientPb";
import { AllTicketsRequest, TicketRequestId } from "./protoc/tickets_pb";

var client = new TicketsClient("https://localhost:5000");

function App() {
  const [data, setData] = React.useState<ITicket[]>([]);
  const [loading, setLoading] = React.useState<boolean>(false);
  const [totalRows, setTotalRows] = React.useState<number>(0);
  const [perPage, setPerPage] = React.useState<number>(10);
  const [currentPage, setCurrentPage] = React.useState<number>(1);

  const fetchUsers = React.useCallback(
    async (page: number) => {
      setLoading(true);
      var request = new AllTicketsRequest();
      request.setPage(page);
      request.setCount(perPage);
      client.getAllTickets(request, {}, (err, response) => {
        if (err) {
          toast.error(err.message);
        } else {
          const data = response.getTicketsList().map((ticket) => ({
            id: ticket.getId(),
            user: ticket.getUser(),
            creationDate: ticket.getCreationdate().toDate(),
            updateDate: ticket.getUpdatedate().toDate(),
            status: ticket.getStatus(),
          }));
          setData(data);
          setTotalRows(response.getRows());
        }
        setLoading(false);
      });
    },
    [perPage]
  );

  const handlePageChange = (page: number) => {
    setCurrentPage(page);
  };

  const handlePerRowsChange = async (newPerPage: number, page: number) => {
    setLoading(true);
    var request = new AllTicketsRequest();
    request.setPage(page);
    request.setCount(newPerPage);
    client.getAllTickets(request, {}, (err, response) => {
      if (err) {
        toast.error(err.message);
      } else {
        setData(
          response.getTicketsList().map((ticket) => ({
            id: ticket.getId(),
            user: ticket.getUser(),
            creationDate: ticket.getCreationdate(),
            updateDate: ticket.getUpdatedate(),
            status: ticket.getStatus(),
          }))
        );
        setPerPage(newPerPage);
      }
      setLoading(false);
    });
  };

  const handleOnCreatedTicket = () => {
    fetchUsers(currentPage);
  };

  const handleFilteredText = React.useCallback(
    (text: string | null) => {
      if (text !== null) {
        if (text !== "") {
          setLoading(true);
          var request = new TicketRequestId();
          request.setId(text);
          client.getTicket(request, {}, (err, response) => {
            if (err) {
              toast.error(err.message);
            } else {
              const data = [
                {
                  id: response.getId(),
                  user: response.getUser(),
                  creationDate: response.getCreationdate().toDate(),
                  updateDate: response.getUpdatedate().toDate(),
                  status: response.getStatus(),
                },
              ];
              setData(data);
              setTotalRows(1);
            }
            setLoading(false);
          });
        } else {
          fetchUsers(1);
        }
      }
    },
    [fetchUsers]
  );

  const handleDelete = useCallback(
    (id: string) => {
      var request = new TicketRequestId();
      request.setId(id);
      client.deleteTicket(request, {}, (err, response) => {
        if (err) {
          toast.error(err.message);
        } else {
          toast.success(
            `The ticket ${response.getId()} has been successfully deleted`
          );
          fetchUsers(currentPage);
        }
      });
    },
    [currentPage, fetchUsers]
  );

  React.useEffect(() => {
    fetchUsers(currentPage);
  }, [currentPage, fetchUsers]);

  return (
    <div className="App">
      <Toaster />
      <div>
        <h1>Tickets Client For Testing gRPC API</h1>
        <CreateTicket onCreated={handleOnCreatedTicket} />
        <TicketsTable
          data={data}
          loading={loading}
          totalRows={totalRows}
          handlePageChange={handlePageChange}
          handlePerRowsChange={handlePerRowsChange}
          onUpdated={handleOnCreatedTicket}
          onFiltered={handleFilteredText}
          onDelete={handleDelete}
        />
      </div>
    </div>
  );
}

export default App;
