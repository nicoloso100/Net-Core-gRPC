import * as React from "react";
import DataTable from "react-data-table-component";
import EditTicketComponent from "../components/EditTicketComponent";
import FilterComponent from "../components/FilterComponent";
import { SectionContainer } from "./styles";

interface ITicketsTableProps {
  data: ITicket[];
  loading: boolean;
  totalRows: number;
  handlePerRowsChange: (newPerPage: number, page: number) => void;
  handlePageChange: (page: number) => void;
  onUpdated: () => void;
  onFiltered: (text: string | null) => void;
  onDelete: (id: string) => void;
}

const TicketsTable: React.FC<ITicketsTableProps> = ({
  data,
  loading,
  totalRows,
  handlePerRowsChange,
  handlePageChange,
  onUpdated,
  onFiltered,
  onDelete,
}) => {
  const ExpandableComponent = ({ data }: any) => (
    <EditTicketComponent ticket={data} onUpdated={onUpdated} />
  );

  const subHeaderComponentMemo = React.useMemo(() => {
    return <FilterComponent onSearch={onFiltered} />;
  }, [onFiltered]);

  const columns = React.useMemo(
    () => [
      {
        name: "Id",
        selector: "id",
        sortable: false,
      },
      {
        name: "User Name",
        selector: "user",
        sortable: true,
      },
      {
        name: "Creation Date",
        selector: "creationDate",
        sortable: true,
        cell: (row: ITicket) => (
          <div>{`${row.creationDate.toDateString()} ${row.creationDate.toLocaleTimeString()}`}</div>
        ),
      },
      {
        name: "Update Date",
        selector: "updateDate",
        sortable: true,
        cell: (row: ITicket) => (
          <div>{`${row.updateDate.toDateString()} ${row.updateDate.toLocaleTimeString()}`}</div>
        ),
      },
      {
        name: "Status",
        selector: "status",
        sortable: true,
        cell: (row: ITicket) => <div>{row.status ? "Open" : "Closed"}</div>,
      },
      {
        name: "Actions",
        selector: "status",
        sortable: true,
        cell: (row: ITicket) => (
          <div>
            <button onClick={() => onDelete(row.id)}>Delete</button>
          </div>
        ),
      },
    ],
    [onDelete]
  );

  return (
    <SectionContainer>
      <DataTable
        columns={columns}
        data={data}
        progressPending={loading}
        pagination
        paginationServer
        paginationTotalRows={totalRows}
        onChangeRowsPerPage={handlePerRowsChange}
        onChangePage={handlePageChange}
        expandableRows
        expandableRowsComponent={<ExpandableComponent />}
        subHeader
        subHeaderComponent={subHeaderComponentMemo}
        persistTableHead
        noHeader
      />
    </SectionContainer>
  );
};

export default TicketsTable;
