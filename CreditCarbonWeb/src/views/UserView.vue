<template>
  <div class="container-fluid">
      <div class="col-lg-12 mb-lg-0 mb-4">
        <div class="row">
          <div class="col-lg-12">
            <div class="d-flex flex-column h-100 container">
              <div
                class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom"
              >
                <h5 class="font-weight-bolder">User</h5>
              </div>

              <div class="flex-grow-1 mb-1">
                <ag-grid-vue
                  class="ag-theme-alpine h-100"
                  domLayout="autoHeight"
                  :columnDefs="columnDefs"
                  :defaultColDef="defaultColDef"
                  rowModelType="serverSide"
                  serverSideStoreType="partial"
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
import { ref } from 'vue'
import { textFilterParams, activeFilterParams, createCellButton } from '../helpers/ag-grid-helper'
import http from '../helpers/http-client'
import Swal from 'sweetalert2'
let gridColumnApi
let gridApi

const defaultColDef = {
  resizable: true
}

const columnDefs = [
  {
    headerName: 'UserId',
    field: 'userId',
    filter: 'agTextColumnFilter',
    hide: true
  },
  {
    headerName: 'First Name',
    field: 'firstName',
    sortable: true,
    filter: 'agTextColumnFilter',
    filterParams: textFilterParams,
    flex: 1
  },
  {
    headerName: 'Last Name',
    field: 'lastName',
    sortable: true,
    filter: 'agTextColumnFilter',
    filterParams: textFilterParams,
    flex: 1
  },
  {
    headerName: 'Email',
    field: 'email',
    sortable: true,
    filter: 'agTextColumnFilter',
    filterParams: textFilterParams,
    flex: 1
  },
  {
    headerName: 'Active',
    field: 'isActive',
    sortable: true,
    filter: 'agSetColumnFilter',
    filterParams: activeFilterParams,
    width: 100,
    cellClassRules: {
      'text-left': 'true'
    },
    cellRenderer: (param) => {
      if (param.data.activeFlag) {
        const icon = document.getElementById('fa-check-icon').cloneNode(true)
        icon.removeAttribute('id')
        icon.classList.remove('d-none')
        return icon
      }
    }
  },
  {
    headerName: '',
    field: '',
    suppressMenu: true,
    lockPosition: true,
    width: 240,
    cellRenderer: (param) => {
      const container = document.createElement('div')
      container.classList.add('align-items-center')

      const activeButton = createCellButton()
      if (param.data.activeFlag == 1) {
        activeButton.innerText = 'Set Inactive'
        activeButton.classList.add('btn-outline-warning')
      } else {
        activeButton.innerText = 'Set active'
        activeButton.classList.add('btn-outline-success')
      }
      activeButton.style.width = '90px'
      activeButton.classList.add('me-2')
      activeButton.addEventListener('click', () => {
        openSetInactive(param.data)
      })

      const deleteButton = createCellButton('', 'fa-trash-icon', 'Delete')
      deleteButton.classList.add('btn-outline-danger')
      deleteButton.style.marginBottom = '5px'
      deleteButton.addEventListener('click', () => {
        onDelete(param.data.userId)
      })

      container.appendChild(activeButton)
      container.appendChild(deleteButton)

      return container
    },
    pinned: 'right',
    cellClass: ['d-flex', 'justify-content-center']
  }
]

function onGridReady(params) {
  gridApi = params.api
  gridColumnApi = params.columnApi

  // gridColumnApi.getColumn('username').setSort('asc')

  let dataSource = serverSideDatasource()
  params.api.setServerSideDatasource(dataSource)
}

function serverSideDatasource() {
  return {
    getRows: async function (params) {
      const response = await http.get('api/user')
      params.success({
        rowData: response.data,
        rowCount: 1
      })
    }
  }
}

function refreshData() {
  gridApi.refreshServerSideStore({ purge: true })
}

function onDelete(userId) {
  Swal.fire({
    title: 'Deleting User',
    text: 'Are you sure you want to delete this User?',
    icon: 'warning',
    showCancelButton: true,
    confirmButtonColor: '#3085d6',
    cancelButtonColor: '#d33',
    confirmButtonText: 'Confirm'
  }).then(async (result) => {
    if (result.isConfirmed) {
      await http.delete('/users/delete/' + userId)
      refreshData()
    }
  })
}

function openSetInactive(data) {
  Swal.fire({
    title: 'Are you sure?',
    text: `Please confirm to change User status to '${data.activeFlag ? 'Inactive' : 'Active'}'`,
    icon: 'warning',
    showCancelButton: true,
    confirmButtonColor: '#3085d6',
    cancelButtonColor: '#d33',
    confirmButtonText: 'Confirm'
  }).then(async (result) => {
    if (result.isConfirmed) {
      data.activeFlag = !data.activeFlag
      await http.put('/users/update/' + data.userId, data)
      refreshData()
    }
  })
}
</script>
