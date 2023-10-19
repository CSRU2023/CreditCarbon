<template>
  <div class="d-flex flex-column h-100">
    <div
      class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom"
    >
      <h1 class="h2">
        {{ title }}
        <span v-if="loanPaymentNo" class="text">({{ loanPaymentNo }})</span>
      </h1>
      <div class="btn-toolbar mb-2 mb-md-0">
        <div v-show="loading" class="spinner-border spinner-border m-1 text-secondary"></div>
        <button type="button" class="btn btn-outline-secondary me-1" @click="goBackToLPList">
          <font-awesome-icon icon="fa-solid fa-arrow-left" /> Back
        </button>
        <button v-if="mode !== 'view'" type="submit" form="form1" class="btn btn-outline-primary">
          <font-awesome-icon icon="fa-regular fa-floppy-disk" /> Save
        </button>
      </div>
    </div>
    <div class="flex-grow-1 overflow-auto">
      <form class="container" id="form1" @submit.prevent="onSubmit" autocomplete="off">
        <fieldset :disabled="mode === 'view'">
          <div class="row mb-3 pb-3 border-bottom">
            <label class="form-label h5 mb-3">รายละเอียดโครงการ</label>
            <div class="col-12 mb-2">
              <label for="projectName" class="form-label">ชื่อโครงการ <span class="text-danger">*</span></label>
              <Field type="text" class="form-control" id="projectName" name="projectName" :class="{ 'is-invalid': errors.projectName }" />
              <ErrorMessage class="invalid-feedback" name="projectName" />
            </div>
            <div class="col-6 mb-2">
              <label for="location" class="form-label">ที่ตั้งโครงการ <span class="text-danger">*</span></label>
              <Field type="text" class="form-control" id="location" name="location" :class="{ 'is-invalid': errors.location }"/>
              <ErrorMessage class="invalid-feedback" name="location" />
            </div>
            <div class="col-6 mb-2">
              <label for="locationCoordinates" class="form-label">พิกัดที่ตั้งโครงการ</label>
              <Field type="text" class="form-control" id="locationCoordinates" name="locationCoordinates" :class="{ 'is-invalid': errors.locationCoordinates }"/>
              <ErrorMessage class="invalid-feedback" name="locationCoordinates" />
            </div>
            <div class="col-6 mb-2">
              <label for="investment" class="form-label">เงินลงทุนทั้งหมดของโครงการ <span class="text-danger">*</span></label>
              <Field type="text" class="form-control" id="investment" name="investment" :class="{ 'is-invalid': errors.investment }"/>
              <ErrorMessage class="invalid-feedback" name="investment" />
            </div>
            <div class="col-6 mb-2">
              <label for="amountGreenhouseGases" class="form-label">ปริมาณก๊าซเรือนกระจกที่คาดว่าจะลด/ดูดกลับได้ <span class="text-danger">*</span></label>
              <Field type="text" class="form-control" id="amountGreenhouseGases" name="amountGreenhouseGases" :class="{ 'is-invalid': errors.amountGreenhouseGases }"/>
              <ErrorMessage class="invalid-feedback" name="amountGreenhouseGases" />
            </div>
            <div class="col-6 mb-2">
              <label for="dp-input-createdDate" class="form-label">Created Date</label>
              <date-picker
                class="form-control"
                uid="createdDate"
                name="createdDate"
                :class="{ 'is-invalid': errors.createdDate }"
                :disabled="true"
              />
              <ErrorMessage class="invalid-feedback" name="createdDate" />
            </div>
            <div class="row">
              <label class="form-label">ระยะเวลาคิดคาร์บอนเครดิตของโครงการ<br></label>
              <div class="col-6 mb-2">
                <label for="dp-input-startDate" class="form-label"
                  >วันเริ่มต้นโครงการ <span class="text-danger">*</span></label
                >
                <date-picker
                  class="form-control"
                  uid="startDate"
                  name="startDate"
                  :class="{ 'is-invalid': errors.startDate }"
                  :disabled="mode === 'view'"
                />
                <ErrorMessage class="invalid-feedback" name="startDate" />
              </div>
              <div class="col-6 mb-2">
                <label for="dp-input-endDate" class="form-label"
                  >วันสิ้นสุดโครงการ <span class="text-danger">*</span></label
                >
                <date-picker
                  class="form-control"
                  uid="endDate"
                  name="endDate"
                  :disabled="endDateDisable || mode === 'view'"
                  :class="{ 'is-invalid': errors.endDate }"
                />
                <ErrorMessage class="invalid-feedback" name="endDate" />
              </div>
              <div class="col-6 mb-2" style="margin-top: 40px" :hidden="!allowendDateAtCall">
                <Field
                  v-slot="{ field }"
                  name="endDateAtCall"
                  id="endDateAtCall"
                  type="checkbox"
                  :value="false"
                >
                  <label>
                    <input
                      type="checkbox"
                      name="endDateAtCall"
                      id="endDateAtCall"
                      v-bind="field"
                      :value="false"
                      :checked="endDateAtCall"
                      @change="onChangeAtCall($event)"
                    />
                    Call
                  </label>
                </Field>
              </div>
            </div>
            <div class="col-12 mb-2">
              <label for="projectName" class="form-label">รายละเอียดโครงการ <span class="text-danger">*</span></label>
              <Field type="text" class="form-control" id="projectName" name="projectName" />
              <ErrorMessage class="invalid-feedback" name="projectName" />
            </div>
          </div>
          <div class="row mb-3 pb-3 border-bottom">
            <label class="form-label h5 mb-3">รายละเอียดเจ้าของโครงการ</label>
            <div class="col-12 mb-2">
              <label for="projectName" class="form-label">เจ้าของโครงการ <span class="text-danger">*</span></label>
              <Field type="text" class="form-control" id="projectName" name="projectName" />
              <ErrorMessage class="invalid-feedback" name="projectName" />
            </div>
            <div class="col-6 mb-2">
              <label for="location" class="form-label">ผู้ประสานงาน <span class="text-danger">*</span></label>
              <Field type="text" class="form-control" id="location" name="location" />
              <ErrorMessage class="invalid-feedback" name="location" />
            </div>
            <div class="col-6 mb-2">
              <label for="locationCoordinates" class="form-label">ตำแหน่ง</label>
              <Field type="text" class="form-control" id="locationCoordinates" name="locationCoordinates" />
              <ErrorMessage class="invalid-feedback" name="locationCoordinates" />
            </div>
            <div class="col-12 mb-2">
              <label for="investment" class="form-label">ที่อยู่ <span class="text-danger">*</span></label>
              <Field type="text" class="form-control" id="investment" name="investment" />
              <ErrorMessage class="invalid-feedback" name="investment" />
            </div>
            <div class="col-6 mb-2">
              <label for="tel" class="form-label">โทรศัพท์ <span class="text-danger">*</span></label>
              <Field type="text" class="form-control" id="tel" name="tel" />
              <ErrorMessage class="invalid-feedback" name="tel" />
            </div>
            <div class="col-6 mb-2">
              <label for="email" class="form-label">E-mail<span class="text-danger">*</span></label>
              <Field type="text" class="form-control" id="email" name="email" />
              <ErrorMessage class="invalid-feedback" name="email" />
            </div>
          </div>
          <div
            class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center mb-2"
          >
            <label class="form-label h5 mb-3">รายละเอียดผู้พัฒนาโครงการ</label>
            <div class="btn-toolbar mb-2 mb-md-0" v-if="mode !== 'view'">
              <button
                type="button"
                class="btn btn-outline-primary btn-sm"
                @click="showInterestRate('add')"
              >
                <font-awesome-icon icon="fa-solid fa-plus" /> Add
              </button>
              <InterestRateModal
                ref="interestRateModal"
                @insertInterestRate="onInsertInterestRate"
                @updateInterestRate="onUpdateInterestRate"
              />
            </div>
          </div>

          <ag-grid-vue
            class="ag-theme-alpine pb-3 mb-3 border-bottom"
            domLayout="autoHeight"
            :columnDefs="interestRateColumnDefs"
            :rowData="interestRateRowData"
            :defaultColDef="defaultColDef"
            :getRowNodeId="getRowNodeId"
            @grid-ready="onInterestRateGridReady"
          >
          </ag-grid-vue>
        </fieldset>
      </form>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { createCellButton, dateValueFormatter } from '../../helpers/ag-grid-helper'
import { Field, useForm, ErrorMessage } from 'vee-validate'
import InterestRateModal from './DeveloperModal.vue'
import http from '../../helpers/http-client'
import * as yup from 'yup'
import moment from 'moment'
import Swal from 'sweetalert2'

const router = useRouter()
const route = useRoute()

const interestRateModal = ref(null)

const loanTypes = ref([])
const currency = ref([])
const currencies = ref([])
const baseRate = ref([])

const allowendDateAtCall = ref(false)
const endDateDisable = ref(false)
const endDateAtCall = ref(false)
const allowCustomBaseRate = ref(false)
const customBaseRate = ref(null)
const customBank = ref(null)
const loanPaymentNo = ref('')
const currencyCode = ref(null)
const exchangeRateLastMonth = ref(null)

const deletedInterestIds = []

const dataLP = ref({})
const loading = ref(false)
let statusSetLoanPayment = false
let parentLoanPaymentId

const validationSchema = yup.object({
  projectName: yup.string().required().nullable().label('ชื่อโครงการ'),
  amountGreenhouseGases: yup.number().required().nullable().label('ปริมาณก๊าซเรือนกระจกที่คาดว่าจะลด/ดูดกลับได้'),
  investment: yup.number().required().label('เงินลงทุนทั้งหมดของโครงการ'),
  startDate: yup.date().required().nullable().label('วันที่เริ่มต้นโครงการ'),
  endDate: yup
    .date()
    .nullable()
    .test('Is date greater', "วันสิ้นสุดโครงการไม่สามารถอยู่ก่อนวันเริ่มโครงการได้", (value) => {
      if (allowendDateAtCall.value) return true
      return moment(value).isSameOrAfter(values.startDate)
    })
    .label('วันสิ้นสุดโครงการ'),
})

const { errors, values, resetForm, setValues, validate, setFieldValue } = useForm({
  validationSchema: validationSchema
})

resetForm()

const mode = ref('')
let title

switch (route.name) {
  case 'add-project-carbon':
    mode.value = 'add'
    title = 'เพิ่มโครงการ'
    break
  case 'edit-project-carbon':
    mode.value = 'edit'
    title = `แก้ไขโครงการ`
    break
  case 'view-project-carbon':
    mode.value = 'view'
    title = `รายละเอียดโครงการ`
    break
}

resetForm()
loadCombobox()

const defaultColDef = {
  resizable: true
}

loadDataDefault()

const interestRateColumnDefs = [
  {
    headerName: 'Interest Rate (%)',
    field: 'interestRate',
    flex: 1,
    sortable: true,
    filter: 'agNumberColumnFilter'
  },
  {
    headerName: 'Margin (%)',
    field: 'margin',
    flex: 1,
    sortable: true,
    filter: 'agNumberColumnFilter'
  },
  {
    headerName: 'All in RATE',
    field: 'allInRate',
    flex: 1,
    sortable: true,
    filter: 'agNumberColumnFilter'
  },
  {
    headerName: 'Effective from',
    field: 'effectiveFrom',
    flex: 1,
    sortable: true,
    filter: 'agDateColumnFilter',
    valueFormatter: dateValueFormatter
  }
]

if (mode.value !== 'view') {
  interestRateColumnDefs.push({
    headerName: '',
    field: '',
    suppressMenu: true,
    lockPosition: true,
    width: 139,
    cellRenderer: (params) => {
      const container = document.createElement('div')
      container.classList.add('d-flex', 'align-items-center')

      const editButton = createCellButton('Edit')
      editButton.classList.add('btn-outline-primary', 'me-1')
      editButton.addEventListener('click', () => {
        showInterestRate('edit', params.data)
      })

      const deleteButton = createCellButton('Delete')
      deleteButton.classList.add('btn-outline-danger')
      deleteButton.addEventListener('click', () => {
        onDeleteInterestRate(params.data)
      })

      container.appendChild(editButton)
      container.appendChild(deleteButton)

      return container
    },
    pinned: 'right',
    cellClass: ['d-flex', 'justify-content-center']
  })
}

const interestRateRowData = ref([])
let interestRateGridApi

function getRowNodeId(data) {
  return data.id
}

async function onSubmit() {
  const { valid } = await validate()

  if (!valid) {
    return
  }

  values.endDateAtCall = values.endDateAtCall === undefined ? false : values.endDateAtCall
  if (allowendDateAtCall.value && !values.endDateAtCall && values.endDate === undefined) {
    Swal.fire({
      title: 'Error',
      html: 'Please select Call or Due Date',
      icon: 'error'
    })
    return
  }

  if (!validateInterestRate()) {
    return
  }

  Swal.fire({
    title: 'Are you sure to save it?',
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

        loading.value = true

        if (mode.value === 'add') {
          const res = await http.post('loanPayment', data)
          router.push(`/edit-loan-payment/${res.data}`)
        } else if (mode.value === 'edit') {
          const resEdit = await http.put('loanPayment', data)
          dataLP.value = resEdit.data
          
        } else if (mode.value === 'refNew') {
          const resRefNew = await http.post('loanPayment/refNewLoanPayment', data)
          router.push(`/edit-loan-payment/${resRefNew.data}`)
        }
      } finally {
        loading.value = false
      }
    }
  })
}

function getSubmittingData() {
  const data = {
    loanTypeId: values['loanTypeId'],
    companyId: values['companyId'],
    currencyId: values['currencyId'],
    series: values['series'],
    remark: values['remark'],
    startDate: values['startDate'],
    endDate: values['endDate'],
    endDateAtCall: values['endDateAtCall'],
    exchangeRate: values['exchangeRate'],
    netAmount: values['netAmount'],
    docCurrencyAmount: values['docCurrencyAmount'],
    note: values['note'],
    parentLoanPaymentId: parentLoanPaymentId
  }

  if (typeof values['bankId'] === 'number') {
    data.bankId = values['bankId']
    data.customBank = null
  } else {
    data.bankId = null
    data.customBank = values['bankId']
  }

  if (typeof values['baseRateId'] === 'number') {
    data.baseRateId = values['baseRateId']
    data.customBaseRate = null
  } else {
    data.baseRateId = null
    data.customBaseRate = values['baseRateId']
  }

  if (mode.value !== 'add') {
    data.loanPaymentId = values['loanPaymentId']
  }

  data.modifiedInterests = []

  data.deletedInterestIds = deletedInterestIds
  return data
}

function validateInterestRate() {
  var massage = ''
  var error = false

  if (effectiveFromRows.length == 0) {
    Swal.fire({
      title: 'Error',
      html: 'Interest Rates must have at least one.',
      icon: 'error'
    })
    return false
  }

  if (moment(effectiveFromRows[0]).isAfter(values.startDate)) {
    error = true
    massage = 'The Borrow Date must occur after the Effective From in Interest Rate.'
  }

  let dup = {}

  for (const data of effectiveFromRows) {
    let d = typeof data !== 'string' ? data.toLocaleDateString('en-CA') : data
    if (dup[d]) {
      error = true
      massage =
        moment(data).format('DD/MM/YYYY') +
        ' Duplicate date, please select a new one in Interest Rate.'
      break
    } else {
      dup[d] = 1
    }

    if (values.endDate !== undefined && moment(data).isAfter(values.endDate)) {
      error = true
      massage = 'The Due date must occur after the Effective From in Interest Rate.'
      break
    }
  }

  if (error) {
    Swal.fire({
      title: 'Error',
      html: massage,
      icon: 'error'
    })
    return false
  }

  return true
}

function goBackToLPList() {
  if (mode.value !== 'view') {
    var checkChange = false

    if (mode.value === 'add') {
      const checker = [null, undefined, new Date().toJSON().slice(0, 10).toString(), 'Open']
      const checkValues = Object.values(values).every((el) => checker.includes(el))

      checkChange = !checkValues
    }

    if (mode.value === 'edit') {
      for (var k in dataLP.value) {
        if (k !== 'loanPaymentInterests' && k !== 'loanTypeBaseRates') {
          if (dataLP.value[k] !== values[k]) {
            checkChange = true
            break
          }
        }
      }
    }

    if (checkChange) {
      Swal.fire({
        title: 'You have not saved.',
        text: 'Are you sure you want to leave this page?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes',
        cancelButtonText: 'No'
      }).then(async (result) => {
        if (result.isConfirmed) {
          router.push(`/project-carbon`)
        }
      })
    } else {
      router.push(`/project-carbon`)
    }
  } else {
    router.push(`/project-carbon`)
  }
}

function onInterestRateGridReady(params) {
  interestRateGridApi = params.api
}

function showInterestRate(mode, data) {
  interestRateModal.value.openModalInterestRate(mode, data)
}

function onInsertInterestRate(data) {
  data.isModified = true
  interestRateGridApi.applyTransaction({ add: [data] })
  interestRateGridApi.redrawRows()
}

function onUpdateInterestRate(data) {
  data.isModified = true
  interestRateGridApi.applyTransaction({ update: [data] })
  interestRateGridApi.redrawRows()
}

function onDeleteInterestRate(data) {
  if (data.id > 0) {
    deletedInterestIds.push(data.id)
  }
  interestRateGridApi.applyTransaction({ remove: [data] })
  interestRateGridApi.redrawRows()
}

async function loadDataDefault() {
  if (mode.value === 'add') {
    values.createdDate = new Date().toJSON().slice(0, 10)
    values.status = 'Open'
  } else {
    statusSetLoanPayment = true

    let loanPaymentId = router.currentRoute.value.params.loanPaymentId
    const dataDetail = await http.get('loanPayment/' + loanPaymentId)

    dataLP.value = dataDetail.data

  }
}

async function loadCombobox() {
  // const resType = await http.get('comboboxs/loanTypeCombobox')
  // const dataType = resType.data.map((x) => {
  //   return {
  //     loanTypeId: x.loanTypeId,
  //     label: x.name,
  //     allowendDateAtCall: x.allowendDateAtCall,
  //     allowCustomBaseRate: x.allowCustomBaseRate,
  //     customCondition: x.customCondition,
  //     loanTypeBaseRates: x.loanTypeBaseRates.map((a) => {
  //       return {
  //         baseRateId: a.baseRateId,
  //         label: a.code
  //       }
  //     })
  //   }
  // })
  // loanTypes.value = dataType

  if (mode.value === 'edit') {
    onChangeLoanType()
  }
}

</script>
