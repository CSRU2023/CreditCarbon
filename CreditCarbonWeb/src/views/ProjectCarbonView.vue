<template>
  <div class="container-fluid">
    <div class="col-lg-12 mb-lg-0 mb-4">
      <div class="row">
        <div class="col-lg-12">
          <div class="d-flex flex-column h-100">
            <div
              class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
              <h1 class="h2">Project Carbon</h1>
              <div class="btn-toolbar mb-2 mb-md-0">
                <button type="button" class="btn btn-outline-primary" @click="addProjectCarbon">
                  <font-awesome-icon icon="fa-solid fa-plus" /> Add
                </button>
              </div>
            </div>
            <div class="flex-grow-1 mb-1">
              <ag-grid-vue
                  class="ag-theme-alpine h-100"
                  domLayout="autoHeight"
                  :columnDefs="columnDefs"
                  :defaultColDef="defaultColDef"
                  :rowData="rowData"
                  :pagination="true"
                  :paginationPageSize="50"
                  :cacheBlockSize="50"
                  @grid-ready="onGridReady"
                >
                </ag-grid-vue>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { useRouter, useRoute } from "vue-router";
import {
  textFilterParams,
  createCellButton,
  dateValueFormatter,
  getCurrentAgGridState
} from "../helpers/ag-grid-helper";
import { usePageStateStore } from "../stores/pageState";
import http from "../helpers/http-client";
import { onBeforeUnmount } from "vue";

const router = useRouter();
const route = useRoute();
const stateStore = usePageStateStore();

const routePath = route.path;
const agGridState = stateStore.getState(routePath, "agGrid");

let gridApi;
let gridColumnApi = null;

const defaultColDef = {
  resizable: true,
};

const columnDefs = [
  {
    headerName: "Id",
    field: "ProjectCarbonId",
    filter: "agTextColumnFilter",
    hide: true,
    suppressFiltersToolPanel: true,
  },
  {
    headerName: "Project Name",
    field: "projectName",
    sortable: true,
    filter: "agTextColumnFilter",
    filterParams: textFilterParams,
  },
  {
    headerName: "Location",
    field: "location",
    sortable: true,
    filter: "agTextColumnFilter",
    filterParams: textFilterParams,
  },
  {
    headerName: "วันที่ขึ้นทะเบียน",
    field: "createdDate",
    sortable: true,
    filter: "agDateColumnFilter",
    flex: 1,
    valueFormatter: dateValueFormatter,
  },
  {
    headerName: "Start Date",
    field: "startDate",
    sortable: true,
    filter: "agDateColumnFilter",
    flex: 1,
    valueFormatter: dateValueFormatter,
  },
  {
    headerName: "End Date",
    field: "endDate",
    sortable: true,
    filter: "agDateColumnFilter",
    flex: 1,
    valueFormatter: dateValueFormatter,
  },
  {
    headerName: "AmountGreenhouseGases",
    field: "amountGreenhouseGases",
    sortable: true,
    filter: "agTextColumnFilter",
    filterParams: textFilterParams,
    flex: 1,
  },
  {
    headerName: "สถานะ",
    field: "isApprove",
    sortable: true,
    filter: "agTextColumnFilter",
    filterParams: textFilterParams,
    flex: 1,
    cellRenderer: (param) => {
          const a = document.createElement('button');
          const b = document.createElement('span')
          
          switch(param.data.isApprove){
            case 1 : 
              a.className = "btn btn-outline-success btn-sm"
              a.innerText = 'Passed ';
              a.style.border = '1px solid #28a745';
              a.style.position = 'absolute';
              a.style.top = '4px';
              b.className = 'fa fa-check-circle'
              break;
            case 0 : 
              a.className = "btn btn-outline-danger btn-sm"
              a.innerText = 'Failed ';
              a.style.border = '1px solid #dc3545';
              a.style.position = 'absolute';
              a.style.top = '4px';
              b.className = 'fa fa-times-circle'
              break;
          }
          a.appendChild(b);
          
          return a;
        }

  },
  {
    headerName: "ขั้นตอน",
    field: "status",
    sortable: true,
    filter: "agTextColumnFilter",
    filterParams: textFilterParams,
    flex: 1,
  },
  {
    headerName: "",
    field: "",
    suppressMenu: true,
    lockPosition: true,
    width: 120,
    cellRenderer: (params) => {
      const container = document.createElement("div");
      container.classList.add("d-flex", "align-items-center");

      const viewButton = createCellButton("", "fa-eye-icon", "View");
      viewButton.classList.add("btn-outline-secondary", "me-1");
      viewButton.addEventListener("click", () => {
        viewProjectCarbon(params.data.projectCarbonId);
      });

      const editButton = createCellButton("", "fa-pen-to-square-icon", "Edit");
      editButton.classList.add("btn-outline-primary", "me-1");
      editButton.addEventListener("click", () => {
        editProjectCarbon(params.data.projectCarbonId);
      });

      const deleteButton = createCellButton("", "fa-trash-icon", "Delete");
      deleteButton.classList.add("btn-outline-danger");
      deleteButton.addEventListener("click", () => { });

      container.appendChild(viewButton);
      container.appendChild(editButton);
      //container.appendChild(deleteButton);

      return container;
    },
    pinned: "right",
    cellClass: ["d-flex", "justify-content-center"],
  },
];
const rowData = []


function addProjectCarbon() {
  router.push(`/add-project-carbon`);
}

function editProjectCarbon(projectCarbonId) {
  router.push(`/edit-project-carbon/${projectCarbonId}`);
}

function viewProjectCarbon(projectCarbonId) {
  router.push(`/view-project-carbon/${projectCarbonId}`);
}

function onGridReady(params) {
  gridApi = params.api;
  gridColumnApi = params.columnApi;

  getProCarbon()
}

async function getProCarbon() {
  const response = await http.get('api/projectCarbon')
  gridApi.setRowData(response.data)
}

function onFirstDataRendered() {
  if (agGridState && agGridState.currentPage) {
    gridApi.paginationGoToPage(agGridState.currentPage);
  }
}

function saveState() {
  stateStore.setState(
    routePath,
    "agGrid",
    getCurrentAgGridState(gridApi, gridColumnApi)
  );
}

onBeforeUnmount(() => {
  saveState();
});
</script>

