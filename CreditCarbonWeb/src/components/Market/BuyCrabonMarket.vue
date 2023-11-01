<template>
  <Modal ref="modal">
    <template #title>DDDDD Detail</template>

    <template #body>
      <div class="row mt-4">
        <div
          class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center mb-2"
        >
          <label class="form-label h6 mb-3 mx-2">รายละเอียดผู้พัฒนาโครงการ</label>
        </div>
        <ag-grid-vue
          class="ag-theme-alpine"
          domLayout="autoHeight"
          :columnDefs="developerColumnDefs"
          :rowData="[dataView]"
          :defaultColDef="defaultColDef"
        >
        </ag-grid-vue>
      </div>
    </template>

    <template #footer>
      <button
        type="button"
        class="btn btn-primary"
        data-dismiss="modal"
        @click="onSubmit"
        :disabled="loading"
      >
        Buy
      </button>
      <button
        type="button"
        class="btn btn-secondary"
        data-dismiss="modal"
        @click="onClose"
        :disabled="loading"
      >
        Close
      </button>
    </template>
  </Modal>
</template>

<script setup>
import { ref } from 'vue'
import Modal from '../Modal.vue'
import { Field } from 'vee-validate'
import http from '/src/helpers/http-client'
import DatePicker from '../DatePicker.vue'
import moment from 'moment'
import { textFilterParams } from '../../helpers/ag-grid-helper'

const modal = ref(null)
const loading = ref(false)

let dataView = ref([])

const defaultColDef = {
  resizable: true
}

let gridApi;

const developerColumnDefs = [
  {
    headerName: 'ชื่อโครงการ',
    field: 'projectCarbon.projectName',
    flex: 1,
    editable: true,
    cellEditor: 'agNumberCellEditor',
  },
  {
    headerName: 'ประเภท',
    field: '',
    flex: 1
  },
  {
    headerName: 'คาร์บอนเครดิต',
    field: 'amountGreenhouseGases',
    flex: 1
  },
  {
    headerName: 'ราคา/หน่วย',
    field: 'unitPrice',
    flex: 1
  },
  {
    headerName: 'จำนวน',
    field: 'buy',
    flex: 1,
    editable: true,
    cellEditor: 'agNumberCellEditor',
  },
  {
    field: 'projectCarbonMarketsId',
    hide: true
  },
  {
    field: 'projectCarbonId',
    hide: true
  },
  {
    field: 'price',
    hide: true
  },
  {
    field: 'unitPrice',
    hide: true
  },
  {
    field: 'createdDate',
    hide: true
  },
  {
    field: 'createdByUserId',
    hide: true
  },
  {
    field: 'buyForUserId',
    hide: true
  },
  {
    field: 'buyAmountGreenhouseGases',
    hide: true
  },
]

function openModal(data) {
  modal.value.show()
  // const response = await http.get('api/ProjectCarbon/GetById', { params: { id: data } })
  console.log('dataShow', data)
  dataView.value = data
  console.log('dataView', dataView)
}

defineExpose({
  openModal
})

function onClose() {
  modal.value.hide()
  console.log('save', dataView)
}

function onSubmit() {

  let rowData = [];
  this.gridApi.forEachNode(node => rowData.push(node.data));

  console.log('onSubmit', rowData)
  // modal.value.hide()
}

function formatUnit(number) {
  return Math.floor(number)
    .toString()
    .replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,')
}
</script>
