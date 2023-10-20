<template>
    <div class="container-fluid">
        <div class="col-lg-12 mb-lg-0 mb-4">
          <div class="row">
            <div class="col-lg-12">
              <div class="d-flex flex-column h-100 container">
                <div
                  class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom"
                >
                  <h5 class="font-weight-bolder">Carbon Credit Market</h5>
                </div>
  
                <div class="flex-grow-1 mb-1">
                  <ag-grid-vue
                    class="ag-theme-alpine h-100"
                    domLayout="autoHeight"
                    :columnDefs="columnDefs"
                    :defaultColDef="defaultColDef"
                    :rowData="rowData"
                    :pagination="true"
                    :paginationPageSize="20"
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
  import { ref } from 'vue'
  import { textFilterParams, activeFilterParams, createCellButton } from '../helpers/ag-grid-helper'
  import http from '../helpers/http-client'
  import Swal from 'sweetalert2'
  
  let gridColumnApi;
  let gridApi;
  
  const defaultColDef = {
    resizable: true
  }
  
  const columnDefs = [
    {
      headerName: 'ProjectName',
      field: 'projectCarbon.projectName',
      filter: 'agTextColumnFilter',
      flex: 2
    },
    {
      headerName: 'Type',
      field: '',
      sortable: true,
      filter: 'agTextColumnFilter',
      flex: 2
    },
    {
      headerName: 'Unit',
      field: 'unitPrice',
      sortable: true,
      valueFormatter: formatUnit,
      filter: 'agTextColumnFilter',
      flex: 1
    },
    {
      headerName: 'Price',
      field: 'price',
      sortable: true,
      valueFormatter: currencyFormatter,
      filter: 'agTextColumnFilter',
      flex: 1
    },
    {
      headerName: 'Detail',
      // field: 'price',
      flex: 1,
      cellRenderer: function(params) {
        return '<span><i class="bi bi-search"></i></span>'
     }
    },
  ]
  
  const rowData = []
  
  function onGridReady(params) {
    gridApi = params.api
    gridColumnApi = params.columnApi
  
    getMarketList();
  }
  
  async function getMarketList() {
    const response = await http.get('api/ProjectCarbonMarkets')
    console.log('data', response.data)
    gridApi.setRowData(response.data)
  }

  function currencyFormatter(params) {
    return '฿' + formatNumber(params.value);
  };

  function formatNumber(number) {
    // this puts commas into the number eg 1000 goes to 1,000,
    // i pulled this from stack overflow, i have no idea how it works
    return Math.floor(number)
      .toString()
      .replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,');
  };

  function formatUnit(number) {
    // this puts commas into the number eg 1000 goes to 1,000,
    // i pulled this from stack overflow, i have no idea how it works
    return Math.floor(number.value)
      .toString()
      .replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,');
  };
  
  
  </script>
  