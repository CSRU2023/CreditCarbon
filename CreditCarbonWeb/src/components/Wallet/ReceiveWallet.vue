<template>
    <Modal ref="modal">
      <template #title>เติมเงิน</template>
  
      <template #body>
        <div class="row">
          <div class="col-6">
            <div class="card">
              <h6 class="card-header">รายละเอียดโครงการ</h6>
              <div class="card-body">
                <div class="row">
                  <div class="col-5">
                    <label for="dp-input-effectiveFrom" class="form-label">ชื่อโครงการ :</label>
                  </div>
                  <div class="col-7">
                    <p>{{ dataView.projectName }}</p>
                  </div>
                </div>
                <div class="row">
                  <div class="col-5">
                    <label for="dp-input-effectiveFrom" class="form-label">ประเภท :</label>
                  </div>
                  <div class="col-7">
                    <p>{{ dataView.technologyTypeName }}</p>
                  </div>
                </div>
                <div class="row">
                  <div class="col-5">
                    <label for="dp-input-effectiveFrom" class="form-label">มาตรฐาน :</label>
                  </div>
                  <div class="col-7">
                    <p>Standard T-VER</p>
                  </div>
                </div>
                <div class="row">
                  <div class="col-5">
                    <label for="dp-input-effectiveFrom" class="form-label">เงินลงทุน :</label>
                  </div>
                  <div class="col-7">
                    <p>{{ formatUnit(dataView.investment) }} บาท</p>
                  </div>
                </div>
                <div class="row">
                  <div class="col-5">
                    <label for="dp-input-effectiveFrom" class="form-label"
                      >วันเริ่มต้นโครงการ :</label
                    >
                  </div>
                  <div class="col-7">
                    <p>{{ moment(dataView.startDate).format('DD MMMM YYYY') }}</p>
                  </div>
                </div>
                <div class="row">
                  <div class="col-5">
                    <label for="dp-input-effectiveFrom" class="form-label">วันสิ้นสุดโครงการ :</label>
                  </div>
                  <div class="col-7">
                    <p>{{ moment(dataView.endDate).format('DD MMMM YYYY') }}</p>
                  </div>
                </div>
                <div class="row">
                  <div class="col-5">
                    <label for="dp-input-effectiveFrom" class="form-label">ที่ตั้งโครงการ :</label>
                  </div>
                  <div class="col-7">
                    <p>{{ dataView.location }}</p>
                  </div>
                </div>
                <div class="row">
                  <div class="col-5">
                    <label for="dp-input-effectiveFrom" class="form-label"
                      >ปริมาณก๊าซเรือนกระจกที่คาดว่าจะลด :</label
                    >
                  </div>
                  <div class="col-7">
                    <p>{{ dataView.amountGreenhouseGases }} kWh/year</p>
                  </div>
                </div>
                <div class="row">
                  <div class="col-5">
                    <label for="dp-input-effectiveFrom" class="form-label">รายละเอียด :</label>
                  </div>
                  <div class="col-7">
                    <p>{{ dataView.projectDescription }}</p>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="col-6">
            <div class="card">
              <h6 class="card-header">รายละเอียดเจ้าของโครงการ</h6>
              <div class="card-body">
                <div class="row">
                  <div class="col-4">
                    <label for="dp-input-effectiveFrom" class="form-label">ผู้พัฒนาโครงการ :</label>
                  </div>
                  <div class="col-8">
                    <p>{{ dataView.projectOwner }}</p>
                  </div>
                </div>
                <div class="row">
                  <div class="col-4">
                    <label for="dp-input-effectiveFrom" class="form-label">ผู้ประสานงาน :</label>
                  </div>
                  <div class="col-8">
                    <p>{{ dataView.coordinator }}</p>
                  </div>
                </div>
                <div class="row">
                  <div class="col-4">
                    <label for="dp-input-effectiveFrom" class="form-label">ตำแหน่ง :</label>
                  </div>
                  <div class="col-8">
                    <p>{{ dataView.position }}</p>
                  </div>
                </div>
                <div class="row">
                  <div class="col-4">
                    <label for="dp-input-effectiveFrom" class="form-label">ที่อยู่ :</label>
                  </div>
                  <div class="col-8">
                    <p>{{ dataView.address }}</p>
                  </div>
                </div>
                <div class="row">
                  <div class="col-4">
                    <label for="dp-input-effectiveFrom" class="form-label">โทรศัพท์ :</label>
                  </div>
                  <div class="col-8">
                    <p>{{ dataView.tel }}</p>
                  </div>
                </div>
                <div class="row">
                  <div class="col-4">
                    <label for="dp-input-effectiveFrom" class="form-label">E-mail :</label>
                  </div>
                  <div class="col-8">
                    <p>{{ dataView.email }}</p>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
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
            :rowData="dataView.projectCarbonDevelopers"
            :defaultColDef="defaultColDef"
          >
          </ag-grid-vue>
        </div>
      </template>
  
      <template #footer>
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
  
  let dataView = ref({})
  
  const defaultColDef = {
    resizable: true
  }
  
  const developerColumnDefs = [
    {
      headerName: 'ผู้พัฒนาโครงการ',
      field: 'developer',
      flex: 1,
      sortable: true,
      filter: 'agTextColumnFilter',
      filterParams: textFilterParams
    },
    {
      headerName: 'ผู้ประสานงาน',
      field: 'coordinator',
      flex: 1,
      sortable: true,
      filter: 'agTextColumnFilter',
      filterParams: textFilterParams
    },
    {
      headerName: 'ตำแหน่ง',
      field: 'position',
      flex: 1,
      sortable: true,
      filter: 'agTextColumnFilter',
      filterParams: textFilterParams
    },
    {
      headerName: 'เบอร์โทร',
      field: 'tel',
      flex: 1,
      sortable: true,
      filter: 'agTextColumnFilter',
      filterParams: textFilterParams
    },
    {
      headerName: 'E-mail',
      field: 'email',
      flex: 1,
      sortable: true,
      filter: 'agTextColumnFilter',
      filterParams: textFilterParams
    }
  ]
  
  async function openModal(data) {
    modal.value.show()
    const response = await http.get('api/ProjectCarbon/GetById', { params: { id: data } })
    console.log('dataShow', response.data)
    dataView.value = response.data
  }
  
  defineExpose({
    openModal
  })
  
  function onClose() {
    modal.value.hide()
    console.log('save', dataView)
  }
  
  function formatUnit(number) {
    return Math.floor(number)
      .toString()
      .replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,')
  }
  </script>
  