import * as React from "react";
import { FilterButtonsCont } from "./styles";

interface IFilterComponentProps {
  onSearch: (text: string) => void;
}

const FilterComponent: React.FC<IFilterComponentProps> = ({ onSearch }) => {
  const [text, setText] = React.useState<string>("");

  const handleSearch = () => {
    onSearch(text);
  };

  const handleClear = () => {
    setText("");
    onSearch("");
  };

  return (
    <>
      <input
        id="search"
        type="text"
        placeholder="Filter By Id"
        aria-label="Search Input"
        value={text}
        onChange={(event) => setText(event.target.value)}
      />
      <FilterButtonsCont>
        <button type="button" onClick={handleSearch}>
          Search
        </button>
        <button type="button" onClick={handleClear}>
          X
        </button>
      </FilterButtonsCont>
    </>
  );
};

export default FilterComponent;
