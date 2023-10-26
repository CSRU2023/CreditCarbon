<template>
  <Modal ref="modal" size="xl">
    <template #title>Project Detail</template>

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
                  <p>{{ dataView.locationCoordinates }}</p>
                </div>
              </div>
              <div class="row">
                <div class="col-5">
                  <label for="dp-input-effectiveFrom" class="form-label">เงินลงทุน :</label>
                </div>
                <div class="col-7">
                  <p>{{ dataView.locationCoordinates }}</p>
                </div>
              </div>
              <div class="row">
                <div class="col-5">
                  <label for="dp-input-effectiveFrom" class="form-label">วันเริ่มต้นโครงการ :</label
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
                  <p>{{ dataView.locationCoordinates }}</p>
                </div>
              </div>
              <div class="row">
                <div class="col-5">
                  <label for="dp-input-effectiveFrom" class="form-label"
                    >ปริมาณก๊าซเรือนกระจกที่คาดว่าจะลด :</label
                  >
                </div>
                <div class="col-7">
                  <p>{{ dataView.locationCoordinates }}</p>
                </div>
              </div>
              <div class="row">
                <div class="col-5">
                  <label for="dp-input-effectiveFrom" class="form-label">รายละเอียด :</label>
                </div>
                <div class="col-7">
                  <p>{{ dataView.locationCoordinates }}</p>
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
                  <label for="dp-input-effectiveFrom" class="form-label">Project Detail</label>
                </div>
                <div class="col-8">
                  <p>{{ dataView.locationCoordinates }}</p>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </template>

    <template #footer>
      <button type="button" class="btn btn-secondary" data-dismiss="modal" @click="onClose" :disabled="loading">
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

const modal = ref(null)
const loading = ref(false)

let dataView = ref({})

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
</script>
