<script setup>
import { Field, useForm, ErrorMessage } from "vee-validate";
import * as yup from "yup";
import { ref, getCurrentInstance } from "vue";
import { computed } from "vue";
import ModalInterestRate from "../Modal.vue";
import moment from "moment";

const mode = ref("add");
const modalInterestRate = ref(null);
const { emit } = getCurrentInstance();
const loading = ref(false);

let dataInterestRate = {};
let tempId = 0;

let titleInterestRate = computed(() => {
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
  interestRate: yup.number().nullable().required().label("Interest Rate(%)"),
  margin: yup.number().nullable().required().label("Margin(%) is required."),
  effectiveFrom: yup
    .date()
    .required()
    .nullable()
    .label("Effective From is required."),
});

const { resetForm, setValues, values, errors, validate } = useForm({
  validationSchema: validationSchema,
});

async function openModalInterestRate(modalMode, data) {
  loading.value = false;
  mode.value = modalMode;
  dataInterestRate = data;

  initModalInterestRate();

  modalInterestRate.value.show();
}

function initModalInterestRate() {
  resetForm();

  if (mode.value !== "add") {
    loadDataInterestRate();
  } else {
    tempId--;
  }
}

function loadDataInterestRate() {
  const data = dataInterestRate;
  setValues(data);
}

async function onSubmitInterestRate() {
  const { valid } = await validate();

  if (!valid) {
    return;
  }

  loading.value = true;

  values.effectiveFrom = moment(values.effectiveFrom).format("YYYY-MM-DD");

  if (mode.value == "add") {
    emit("insertInterestRate", { ...values, id: tempId });
  } else if (mode.value == "edit") {
    emit("updateInterestRate", { ...values });
  }

  modalInterestRate.value.hide();
  loading.value = false;
}

function onChange() {
  if (values.interestRate !== undefined) {
    values.allInRate =
      values.margin !== undefined
        ? parseFloat(values.interestRate) + parseFloat(values.margin)
        : values.interestRate;
  } else {
    values.allInRate = values.margin;
  }
}

defineExpose({
  openModalInterestRate,
});
</script>

<template>
  <ModalInterestRate ref="modalInterestRate" :id-modal="'modalInterest'">
    <template #title>{{ titleInterestRate }}</template>

    <template #body>
      <form
        @submit.prevent="onSubmitInterestRate"
        id="formInterestRate"
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
        @click="modalInterestRate.hide"
        :disabled="loading">
        Close
      </button>
      <button
        type="onSubmitInterestRate"
        form="formInterestRate"
        class="btn btn-primary"
        :disabled="loading">
        <div v-show="loading" class="spinner-border spinner-border-sm"></div>
        Save
      </button>
    </template>
  </ModalInterestRate>
</template>
