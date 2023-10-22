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
      return "New Interest Rate";
    case "edit":
      return "Edit Interest Rate";
    case "view":
      return "Interest Rate Detail";
    default:
      return "";
  }
});

const validationSchema = yup.object({
  effectiveFrom: yup
    .date()
    .required()
    .nullable()
    .label("Effective From is required."),
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

  values.effectiveFrom = moment(values.effectiveFrom).format("YYYY-MM-DD");

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
         
          <div class="mb-3">
            <label for="dp-input-effectiveFrom" class="form-label"
              >Effective From</label
            >
            <span class="text-danger"> *</span>
            <date-picker
              class="form-control"
              uid="effectiveFrom"
              name="effectiveFrom"
              :class="{ 'is-invalid': errors.effectiveFrom }" />
            <ErrorMessage class="invalid-feedback" name="effectiveFrom" />
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
