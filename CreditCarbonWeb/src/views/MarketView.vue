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
                    :paginationPageSize="10"
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
      <!-- <BuyCrabonMarket ref="buyCrabonMarket" v-if="test.value"/>
      <MarketDetail ref="marketDetail" v-if="!test.value"/> -->
      <BuyCrabonMarket ref="buyCrabonMarket" />
      <MarketDetail ref="marketDetail" />
    </template>
  
  <script setup>
  import { ref } from 'vue'
  import { textFilterParams, activeFilterParams, createCellButton } from '../helpers/ag-grid-helper'
  import http from '../helpers/http-client'
  import Swal from 'sweetalert2'
  import MarketDetail from "../components/Market/MarketDetail.vue";
  import BuyCrabonMarket from "../components/Market/BuyCrabonMarket.vue";
  import { formatUnit, currencyFormatter } from "../helpers/ag-grid-helper";
  
  let gridColumnApi;
  let gridApi;

  const marketDetail = ref(null);
  const buyCrabonMarket = ref(null);
  let test = ref(false)

  
  const defaultColDef = {
    resizable: true
  }


  const columnDefs = [
    {
      headerName: 'ชื่อโครงการ',
      field: 'projectCarbon.projectName',
      filter: 'agTextColumnFilter',
      flex: 2
    },
    {
      headerName: 'ประเภท',
      field: '',
      sortable: true,
      filter: 'agTextColumnFilter',
      flex: 2
    },
    {
      headerName: 'ปริมารคาร์บอนเครดิต',
      field: 'unitPrice',
      sortable: true,
      valueFormatter: formatUnit,
      filter: 'agTextColumnFilter',
      flex: 1
    },
    {
      headerName: 'ราคา/หน่วย',
      field: 'price',
      sortable: true,
      valueFormatter: currencyFormatter,
      filter: 'agTextColumnFilter',
      flex: 1
    },
    {
      headerName: 'รายละเอียด',
      flex: 0.5,
      cellRenderer: (params) => {
        const container = document.createElement("div");
        container.classList.add("d-flex", "justify-content-center");

        const buyButton = createCellButton("", "fa-cart-shopping-icon", "Sale");
        buyButton.classList.add("btn-outline-secondary", "me-1");
        buyButton.addEventListener("click", () => {
          ShowItemsForSale(params.data);
        });
        // buyButton.addEventListener("mouseup", () => {
        //   mouseUp(true)
        // });
        container.appendChild(buyButton);

        const viewButton = createCellButton("", "fa-file-icon", "View");
        viewButton.classList.add("btn-outline-secondary", "me-1");
        viewButton.addEventListener("click", () => {
          ShowDetail(params.data.projectCarbonId);
        });
        // viewButton.addEventListener("mouseup", () => {
        //   mouseUp(false)
        // });
        
        
        container.appendChild(viewButton);


        return container;
      },
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
    gridApi.setRowData(response.data)
  }

  // function onRowClicked() {
  //   console.log('22')
  //   window.localStorage.setItem('userId', '1234')
  //   console.log(window.localStorage.getItem('userId'))
  //   window.localStorage.removeItem('CART')
  // }
  
  function ShowDetail(data) {
    marketDetail.value.openModal(data);
  }

  function ShowItemsForSale(data) {
    buyCrabonMarket.value.openModal(data);
  }

  // function mouseUp(data) {
  //   test.value = data
  // }
  
  </script>
  