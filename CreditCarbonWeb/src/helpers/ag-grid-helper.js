import { Tooltip } from "bootstrap";
import moment from "moment";

const blankFilterOption = {
  displayKey: "blank",
  displayName: "Blank",
  predicate: function (filterValues, cellValue) {
    return (
      cellValue === null || cellValue === "" || typeof cellValue === "undefined"
    );
  },
  numberOfInputs: 0,
};

const notBlankFilterOption = {
  displayKey: "notBlank",
  displayName: "Not blank",
  predicate: function (filterValues, cellValue) {
    return (
      cellValue !== null && cellValue !== "" && typeof cellValue !== "undefined"
    );
  },
  numberOfInputs: 0,
};

export const activeFilterParams = {
  values: ["true", "false"],
  suppressSorting: true,
  valueFormatter: (params) => {
    return params.value === "true" ? "Active" : "Inactive";
  },
  buttons: ["apply", "reset"],
};

export function createCellButton(text, iconId, tooltip) {
  const button = document.createElement("button");
  button.type = "button";
  button.classList.add("btn", "btn-sm");
  if (iconId) {
    const icon = document.getElementById(iconId).cloneNode(true);
    icon.removeAttribute("id");
    icon.classList.remove("d-none");

    if (text) {
      icon.classList.add("me-1");
    }

    button.appendChild(icon);
  }

  if (text) {
    const textNode = document.createTextNode(text);
    button.appendChild(textNode);
  }

  if (tooltip) {
    button.setAttribute("data-bs-toggle", "tooltip");
    button.setAttribute("data-bs-placement", "top");
    button.setAttribute("data-bs-delay", '{ "show": 1000, "hide": 0 }');
    button.setAttribute("data-bs-title", tooltip);
    const bsTooltip = new Tooltip(button);
    button.addEventListener("click", () => {
      bsTooltip.hide();
    });
  }

  button.style.padding = "8px";
  // button.style.marginBottom = "5px";

  return button;
};

export const textFilterParams = {
  filterOptions: [
    "equals",
    "notEqual",
    "contains",
    "notContains",
    "startsWith",
    {
      displayKey: "notStartsWith",
      displayName: "Not starts with",
      predicate: function ([filterValue], cellValue) {
        return cellValue != null && cellValue.indexOf(filterValue) !== 0;
      },
    },
    "endsWith",
    blankFilterOption,
    notBlankFilterOption,
  ],
  buttons: ["apply", "reset"],
  closeOnApply: true,
};

export function dateValueFormatter(x) {
  if (x.value) {
    return moment(x.value)
      .format("DD/MM/YYYY")
      .replace(/\s00:00:00$/, "");
  }
  return "";
};

export function getCurrentAgGridState(gridApi, gridColumnApi) {
  return {
    columnState: gridColumnApi.getColumnState(),
    filterModel: gridApi.getFilterModel(),
    currentPage: gridApi.paginationGetCurrentPage(),
  };
}

export function loadAgGridState(agGridState, gridApi, gridColumnApi) {
  gridColumnApi.applyColumnState({ state: agGridState.columnState });
  gridApi.setFilterModel(agGridState.filterModel);
}

export function getAllRows(gridApi) {
  const rowData = [];

  gridApi.forEachNode((node) => {
    rowData.push(node.data);
  });

  return rowData;
}



