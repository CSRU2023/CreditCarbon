<script setup>
import { Field, useForm, ErrorMessage } from "vee-validate";
import * as yup from "yup";
import { ref, getCurrentInstance } from "vue";
import { computed } from "vue";
import ModalDeveloper from "../Modal.vue";
import moment from "moment";

const mode = ref("add");
const modalDeveloper = ref(null);
const { emit } = getCurrentInstance();
const loading = ref(false);

let dataDeveloper = {};
let tempId = 0;

let titleDeveloper = computed(() => {
  switch (mode.value) {
    case "add":
      return "เพิ่มผู้พัฒนาโครงการ";
    case "edit":
      return "แก้ไขผู้พัฒนาโครงการ";
    case "view":
      return "ผู้พัฒนาโครงการ";
    default:
      return "";
  }
});

const validationSchema = yup.object({
  developer: yup
    .string()
    .required()
    .nullable()
    .label("กรุณากรอกผู้พัฒนา"),
});

const { resetForm, setValues, values, errors, validate } = useForm({
  validationSchema: validationSchema,
});

async function openModalDeveloper(modalMode, data) {
  console.log("openModalDeveloper",modalMode)
  loading.value = false;
  mode.value = modalMode;
  dataDeveloper = data;

  //initModalDeveloper();

  modalDeveloper.value.show();
}

function initModalDeveloper() {
  resetForm();

  if (mode.value !== "add") {
    loadDataDeveloper();
  } else {
    tempId--;
  }
}

function loadDataDeveloper() {
  const data = dataDeveloper;
  setValues(data);
}

async function onSubmitDeveloper() {
  const { valid } = await validate();

  if (!valid) {
    return;
  }

  loading.value = true;

  if (mode.value == "add") {
    emit("insertDeveloper", { ...values, id: tempId });
  } else if (mode.value == "edit") {
    emit("updateDeveloper", { ...values });
  }

  modalDeveloper.value.hide();
  loading.value = false;
}

function onChange() {
  if (values.developer !== undefined) {
    values.allInRate =
      values.margin !== undefined
        ? parseFloat(values.developer) + parseFloat(values.margin)
        : values.developer;
  } else {
    values.allInRate = values.margin;
  }
}

defineExpose({
  openModalDeveloper,
});
</script>

<template>
  <ModalDeveloper ref="modalDeveloper" :id-modal="'modalDeveloper'">
    <template #title>{{ titleDeveloper }}</template>

    <template #body>
      <form
        @submit.prevent="onSubmitDeveloper"
        id="formDeveloper"
        autocomplete="off">
        <fieldset :disabled="loading">
          <div class="mb-3" hidden>
            <label for="id" class="form-label">ID</label>
            <Field type="text" class="form-control" id="id" name="id" />
            <ErrorMessage class="invalid-feedback" name="id" />
          </div>
          <div class="mb-3" hidden>
            <label for="id" class="form-label">Developer ID</label>
            <Field type="text" class="form-control" id="projectCarbon_DeveloperId" name="projectCarbon_DeveloperId" />
            <ErrorMessage class="invalid-feedback" name="projectCarbon_DeveloperId" />
          </div>
         
          <div class="mb-3">
              <label for="developer" class="form-label">นักพัฒนา <span class="text-danger">*</span></label>
              <Field type="text" class="form-control" id="developer" name="developer" />
              <ErrorMessage class="invalid-feedback" name="developer" />
            </div>
            <div class="mb-3">
              <label for="coordinator" class="form-label">ผู้ประสานงาน </label>
              <Field type="text" class="form-control" id="coordinator" name="coordinator" />
              <ErrorMessage class="invalid-feedback" name="coordinator" />
            </div>
            <div class="mb-3">
              <label for="position" class="form-label">ตำแหน่ง <span class="text-danger">*</span></label>
              <Field type="text" class="form-control" id="position" name="position" />
              <ErrorMessage class="invalid-feedback" name="position" />
            </div>
            <div class="mb-3">
              <label for="address" class="form-label">ที่อยู่ <span class="text-danger">*</span></label>
              <Field type="text" class="form-control" id="address" name="address" />
              <ErrorMessage class="invalid-feedback" name="address" />
            </div>
            <div class="mb-3">
              <label for="tel" class="form-label">โทรศัพท์ <span class="text-danger">*</span></label>
              <Field type="text" class="form-control" id="tel" name="tel" />
              <ErrorMessage class="invalid-feedback" name="tel" />
            </div>
            <div class="mb-3">
              <label for="email" class="form-label">E-mail<span class="text-danger">*</span></label>
              <Field type="text" class="form-control" id="email" name="email" />
              <ErrorMessage class="invalid-feedback" name="email" />
            </div>
        </fieldset>
      </form>
    </template>

    <template #footer>
      <button
        type="button"
        class="btn btn-secondary"
        @click="modalDeveloper.hide"
        :disabled="loading">
        Close
      </button>
      <button
        type="onSubmitDeveloper"
        form="formDeveloper"
        class="btn btn-primary"
        :disabled="loading">
        <div v-show="loading" class="spinner-border spinner-border-sm"></div>
        Save
      </button>
    </template>
  </ModalDeveloper>
</template>
