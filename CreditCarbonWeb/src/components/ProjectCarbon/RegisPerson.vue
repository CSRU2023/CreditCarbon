<template>
  <div class="d-flex flex-column h-100">
    <form class="container" id="form1" @submit.prevent="onSubmit" autocomplete="off">
      <div class="row mb-5 pb-3 border-bottom">
        <label class="form-label h2 mb-3 align-center" v-if="typeUser == 3"
          >ลงทะเบียนบุคคลธรรมดา</label
        >
        <label class="form-label h2 mb-3 align-center" v-if="typeUser == 2"
          >ลงทะเบียนนิติบุคคล</label
        >
        <div class="col-6 mb-2">
          <label for="userName" class="form-label"
            >ชื่อผู้ใช้งาน <span class="text-danger">*</span></label
          >
          <Field
            type="text"
            class="form-control"
            id="userName"
            name="userName"
            :class="{ 'is-invalid': errors.userName }"
          />
          <ErrorMessage class="invalid-feedback" name="userName" />
        </div>
        <div class="col-3 mb-2">
          <label for="password" class="form-label"
            >รหัสผ่าน<span class="text-danger">*</span></label
          >
          <Field
            type="password"
            class="form-control"
            id="password"
            name="password"
            :class="{ 'is-invalid': errors.password }"
          />
          <ErrorMessage class="invalid-feedback" name="password" />
        </div>
        <div class="col-3 mb-2">
          <label for="password1" class="form-label"
            >ยืนยันรหัสผ่าน<span class="text-danger">*</span></label
          >
          <Field
            type="password"
            class="form-control"
            id="password1"
            name="password1"
            :class="{ 'is-invalid': errors.password1 }"
          />
          <ErrorMessage class="invalid-feedback" name="password1" />
        </div>
        <div class="col-6 mb-2">
          <label for="firstName" class="form-label">ชื่อ <span class="text-danger">*</span></label>
          <Field
            type="text"
            class="form-control"
            id="firstName"
            name="firstName"
            :class="{ 'is-invalid': errors.firstName }"
          />
          <ErrorMessage class="invalid-feedback" name="firstName" />
        </div>
        <div class="col-6 mb-2">
          <label for="lastName" class="form-label"
            >นามสกุล <span class="text-danger">*</span></label
          >
          <Field
            type="text"
            class="form-control"
            id="lastName"
            name="lastName"
            :class="{ 'is-invalid': errors.lastName }"
          />
          <ErrorMessage class="invalid-feedback" name="lastName" />
        </div>
        <div class="col-6 mb-2">
          <label for="email" class="form-label">E-mail<span class="text-danger">*</span></label>
          <Field
            type="text"
            class="form-control"
            id="email"
            name="email"
            :class="{ 'is-invalid': errors.email }"
          />
          <ErrorMessage class="invalid-feedback" name="email" />
        </div>

        <div class="col-6 mb-2">
          <label for="tel" class="form-label">โทรศัพท์ <span class="text-danger">*</span></label>
          <Field
            type="text"
            class="form-control"
            id="tel"
            name="tel"
            :class="{ 'is-invalid': errors.tel }"
          />
          <ErrorMessage class="invalid-feedback" name="tel" />
        </div>
        <div class="col-6 mb-2">
          <label for="occupation" class="form-label"
            >อาชีพ <span class="text-danger">*</span></label
          >
          <Field
            type="text"
            class="form-control"
            id="occupation"
            name="occupation"
            :class="{ 'is-invalid': errors.occupation }"
          />
          <ErrorMessage class="invalid-feedback" name="occupation" />
        </div>
        <div class="col-6 mb-2" v-if="typeUser == 2">
          <label for="business" class="form-label">บริษัท<span class="text-danger">*</span></label>
          <Field
            type="text"
            class="form-control"
            id="business"
            name="business"
            :class="{ 'is-invalid': errors.business }"
          />
          <ErrorMessage class="invalid-feedback" name="business" />
        </div>
        <div class="col-6 mb-2" v-if="typeUser == 2">
          <label for="registrationNumber" class="form-label"
            >เลขทะเบียนนิติบุคคล<span class="text-danger">*</span></label
          >
          <Field
            type="text"
            class="form-control"
            id="registrationNumber"
            name="registrationNumber"
            :class="{ 'is-invalid': errors.registrationNumber }"
          />
          <ErrorMessage class="invalid-feedback" name="registrationNumber" />
        </div>
        <div class="col-6 mb-2">
          <label for="position" class="form-label">ตำแหน่ง</label>
          <Field type="text" class="form-control" id="position" name="position" />
          <ErrorMessage class="invalid-feedback" name="position" />
        </div>

        <div class="col-12 mb-2">
          <label for="address" class="form-label">ที่อยู่ <span class="text-danger">*</span></label>
          <Field
            type="text"
            class="form-control"
            id="address"
            name="address"
            :class="{ 'is-invalid': errors.address }"
          />
          <ErrorMessage class="invalid-feedback" name="address" />
        </div>

        <div class="col-12 mb-2">
          <label for="tambolKhwaeng" class="form-label"
            >แขวง <span class="text-danger">*</span></label
          >
          <Field
            type="text"
            class="form-control"
            id="tambolKhwaeng"
            name="tambolKhwaeng"
            :class="{ 'is-invalid': errors.tambolKhwaeng }"
          />
          <ErrorMessage class="invalid-feedback" name="tambolKhwaeng" />
        </div>
        <div class="col-12 mb-2">
          <label for="amphurKhet" class="form-label">เขต <span class="text-danger">*</span></label>
          <Field
            type="text"
            class="form-control"
            id="amphurKhet"
            name="amphurKhet"
            :class="{ 'is-invalid': errors.amphurKhet }"
          />
          <ErrorMessage class="invalid-feedback" name="amphurKhet" />
        </div>
        <div class="col-12 mb-2">
          <label for="province" class="form-label"
            >จังหวัด <span class="text-danger">*</span></label
          >
          <Field
            type="text"
            class="form-control"
            id="province"
            name="province"
            :class="{ 'is-invalid': errors.province }"
          />
          <ErrorMessage class="invalid-feedback" name="province" />
        </div>
        <div class="col-12 mb-2">
          <label for="zipCode" class="form-label"
            >รหัสไปรษณีย์ <span class="text-danger">*</span></label
          >
          <Field
            type="text"
            class="form-control"
            id="zipCode"
            name="zipCode"
            :class="{ 'is-invalid': errors.zipCode }"
          />
          <ErrorMessage class="invalid-feedback" name="zipCode" />
        </div>

        <div class="col-3 mb-2">
          <input type="submit" form="form1" value="บันทึก" class="btn btn-success" />
          <input type="reset" value="ยกเลิก" class="btn btn-danger" />
        </div>
      </div>
    </form>
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

let typeUser = ref(router.currentRoute.value.params.id)

const validationSchema = yup.object({
  userName: yup.string().required().nullable().label('ชื่อผู้ใช้งาน'),
  firstName: yup.string().required().nullable().label('ชื่อ'),
  lastName: yup.string().required().nullable().label('นามสกุล'),
  tel: yup.number().required().nullable().label('เบอร์โทร'),
  email: yup.string().required().nullable().label('อีเมลล์'),
  address: yup.string().required().nullable().label('ที่อยู่'),
  business: yup.string().required().nullable().label('บริษัท'),
  occupation: yup.string().required().nullable().label('อาชีพ'),
  tambolKhwaeng: yup.string().required().nullable().label('แขวง'),
  amphurKhet: yup.string().required().nullable().label('เขต'),
  province: yup.string().required().nullable().label('จังหวัด'),
  zipCode: yup.string().required().nullable().label('รหัสไปรษณีย์'),
  registrationNumber: yup.number().required().nullable().label('เลขทะเบียนนิติบุคคล'),

  password: yup.string().required().nullable().label('รหัสผ่าน'),
  password1: yup.string().test('', 'รหัสไม่เหมือนกัน', (value) => {
    // console.log('valuePassword', values.password, values.password1)
    if (values.password !== values.password1) {
      // console.log('false')
      return false
    }
    // console.log('true')
    return true
  })
})

const { errors, values, resetForm, setValues, validate, setFieldValue } = useForm({
  validationSchema: validationSchema
})

async function onSubmit() {
  const { valid } = await validate()
  console.log('onsubmit', valid)

  if (valid) {
    console.log('heool')

    Swal.fire({
      title: 'คุณต้องการบันทึกใช่ไหม?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes',
      cancelButtonText: 'No'
    }).then(async (result) => {
      if (result.isConfirmed) {
        const data = getSubmittingData()
        console.log('data', data)

        const response = await http.post('api/User/Save', data)

        console.log('response', response)
      }
    })
  } else {
    return
  }
}

function getSubmittingData() {
  const data = {
    userName: values['userName'],
    firstName: values['firstName'],
    lastName: values['lastName'],
    position: values['position'],
    tel: values['tel'],
    password: values['password'],
    occupation: values['occupation'],
    email: values['email'],
    business: values['business'],
    address: values['address'],
    tambolKhwaeng: values['tambolKhwaeng'],
    province: values['province'],
    zipCode: values['zipCode'],
    registrationNumber: values['registrationNumber'],

    //mock data
    roleId: 1
  }

  return data
}
</script>

<!-- <style>
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
</style> -->
