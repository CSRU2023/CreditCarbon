<template>
  <Modal ref="modal" size="lg">
    <template #title>Sale</template>
    <template #body>
      <div class="card">
        <div class="card-body">
          <div class="row">
            <div class="col-5">
              <label for="dp-input-effectiveFrom" class="form-label">ชื่อโครงการ :</label>
            </div>
            <div class="col-7">
              <p>{{ dataView?.projectCarbon?.projectName }}</p>
            </div>
          </div>
          <div class="row">
            <div class="col-5">
              <label for="dp-input-effectiveFrom" class="form-label">ประเภท :</label>
            </div>
            <div class="col-7">
              <p>Land Use (Agriculture & Forestry)</p>
            </div>
          </div>
          <div class="row">
            <div class="col-5">
              <label for="dp-input-effectiveFrom" class="form-label">ปริมาณคาร์บอนเครดิต :</label>
            </div>
            <div class="col-7">
              <p>{{ dataView?.amountGreenhouseGases }}</p>
            </div>
          </div>
          <div class="row">
            <div class="col-5">
              <label for="dp-input-effectiveFrom" class="form-label">ราคา/หน่วย :</label>
            </div>
            <div class="col-7">
              <p>{{ formatUnit(dataView?.unitPrice) }} บาท</p>
            </div>
          </div>
          <div class="row">
            <div class="col-5">
              <label for="dp-input-effectiveFrom" class="form-label">ซื้อ :</label>
            </div>
            <div class="col-5">
              <Field
                type="number"
                class="form-control"
                id="buy"
                name="buy"
                :class="{ 'is-invalid': errors.buy }"
              />
              <ErrorMessage class="invalid-feedback" name="buy" />
            </div>
          </div>
        </div>
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
import { useForm, ErrorMessage } from 'vee-validate'
import * as yup from 'yup'
import Swal from 'sweetalert2'
import { useRoute, useRouter } from 'vue-router'


const router = useRouter()
const route = useRoute()

const validationSchema = yup.object({
  buy: yup.number().required().nullable().label('ซื้อ')
})

const { errors, values, resetForm, setValues, validate, setFieldValue } = useForm({
  validationSchema: validationSchema
})

const modal = ref(null)
const loading = ref(false)

let dataView = ref(null)

const defaultColDef = {
  resizable: true
}

function openModal(data) {
  modal.value.show()
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
  Swal.fire({
    title: 'Are you sure to Buy it?',
    icon: 'warning',
    showCancelButton: true,
    confirmButtonColor: '#3085d6',
    cancelButtonColor: '#d33',
    confirmButtonText: 'Yes',
    cancelButtonText: 'No'
  }).then(async (result) => {
    if (result.isConfirmed) {
      try {
        const data = getSubmittingData()
        const res = await http.post('api/ProjectCarbonMarkets/BuyCarbon', data)

        loading.value = true
      } finally {
        modal.value.hide()
        loading.value = false
        window.location.reload();
      }
    }
  })
}

function getSubmittingData() {
  const data = {
    buyForUserId:4,
    buyAmountGreenhouseGases: values['buy'],
    projectCarbonMarketsId: dataView?.value?.projectCarbonMarketsId,
    projectCarbonId: dataView?.value?.projectCarbonId,
    amountGreenhouseGases: dataView?.value?.amountGreenhouseGases,
    price: dataView?.value?.price,
    unitPrice: dataView?.value?.unitPrice,
    createdDate: dataView?.value?.createdDate,
    createdByUserId: dataView?.value?.createdByUserId,

  }
  return data
}

function formatUnit(number) {
  return Math.floor(number)
    .toString()
    .replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,')
}
</script>
