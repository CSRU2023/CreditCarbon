<template>
    <div class="d-flex flex-column h-100">
     
            <div class="row mb-5 pb-3 border-bottom">
              <label class="form-label h2 mb-3 align-center">ลงทะเบียนบุคคลธรรมดา</label>
              <div class="col-6 mb-2">
                <label for="projectName" class="form-label">ชื่อ <span class="text-danger">*</span></label>
                <Field type="text" class="form-control" id="projectName" name="projectName" :class="{ 'is-invalid': errors.projectName }" />
                <ErrorMessage class="invalid-feedback" name="projectName" />
              </div>
              <div class="col-6 mb-2">
                <label for="location" class="form-label">นามสกุล <span class="text-danger">*</span></label>
                <Field type="text" class="form-control" id="location" name="location" :class="{ 'is-invalid': errors.location }"/>
                <ErrorMessage class="invalid-feedback" name="location" />
              </div>
              <div class="col-6 mb-2">
                <label for="locationCoordinates" class="form-label">ตำแหน่ง</label>
                <Field type="text" class="form-control" id="locationCoordinates" name="locationCoordinates" />
                <ErrorMessage class="invalid-feedback" name="locationCoordinates" />
              </div>
              <div class="col-6 mb-2">
                <label for="tel" class="form-label">โทรศัพท์ <span class="text-danger">*</span></label>
                <Field type="text" class="form-control" id="tel" name="tel" />
                <ErrorMessage class="invalid-feedback" name="tel" />
              </div>
              
              <div class="col-12 mb-2">
                <label for="investment" class="form-label">ที่อยู่ <span class="text-danger">*</span></label>
                <Field type="text" class="form-control" id="investment" name="investment" />
                <ErrorMessage class="invalid-feedback" name="investment" />
              </div>
             
              <div class="col-6 mb-2">
                <label for="email" class="form-label">E-mail<span class="text-danger">*</span></label>
                <Field type="text" class="form-control" id="email" name="email" />
                <ErrorMessage class="invalid-feedback" name="email" />
              </div>

              
              
              
              <div class="col-3 mb-2">
                <label for="email" class="form-label">Password<span class="text-danger">*</span></label>
                <Field type="text" class="form-control" id="email" name="email" />
                <ErrorMessage class="invalid-feedback" name="email" />
              </div>
              <div class="col-3 mb-2">
                <label for="email" class="form-label">Password<span class="text-danger">*</span></label>
                <Field type="text" class="form-control" id="email" name="email" />
                <ErrorMessage class="invalid-feedback" name="email" />
              </div>
            
              <div>
         <button class="button">ลงทะเบียน</button>
       </div>
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
  
 
  
  </script>
  
  <style>
.button {
  background-color: #4CAF50; /* Green */
  border: none;
  color: white;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 4px 2px;
  cursor: pointer;
  -webkit-transition-duration: 0.4s; /* Safari */
  transition-duration: 0.4s;
}

.button1 {
  box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
}

.button2:hover {
  box-shadow: 0 12px 16px 0 rgba(0,0,0,0.24),0 17px 50px 0 rgba(0,0,0,0.19);
}
</style>