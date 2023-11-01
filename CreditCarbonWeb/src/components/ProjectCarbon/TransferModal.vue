<script setup>
import { Field, useForm, ErrorMessage } from "vee-validate";
import * as yup from "yup";
import { ref, getCurrentInstance } from "vue";
import { computed } from "vue";
import ModalTransfer from "../Modal.vue";
import moment from "moment";

const mode = ref("add");
const modalTransfer = ref(null);
const { emit } = getCurrentInstance();
const loading = ref(false);

let dataTransfer = {};
let tempId = 0;
const transactionTypes = ref([]) 
const users = ref([]) 

let titleTransfer = computed(() => {
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
  Transfer: yup
    .string()
    .required()
    .nullable()
    .label("กรุณากรอกผู้พัฒนา"),
});

const { resetForm, setValues, values, errors, validate } = useForm({
  validationSchema: validationSchema,
});

async function openModalTransfer(modalMode, data) {
  console.log("openModalTransfer",modalMode)
  loading.value = false;
  mode.value = modalMode;
  dataTransfer = data;

  //initModalTransfer();
  loadCombobox()
  modalTransfer.value.show();
}

async function loadCombobox() {
  const resType = [
   {TransactionTypeId:1,TransactionTypeCode:"TransferCredit",TransactionTypeName:"Transfer Credit",Description:"ถ่ายโอนเครดิตไปยังบัญชีอื่น"}
  ,{TransactionTypeId:2,TransactionTypeCode:"Sale",TransactionTypeName:"Sale",Description:"เสนอขายเครดิต"}
  ,{TransactionTypeId:3,TransactionTypeCode:"Buy",TransactionTypeName:"Buy",Description:"ซื้อ"}]
  const dataType = resType.map((x) => {
    return {
      transactionTypeId: x.TransactionTypeId,
      label: x.Description,
    }
  })
  transactionTypes.value = dataType;

  
}

function initModalTransfer() {
  resetForm();

  if (mode.value !== "add") {
    loadDataTransfer();
  } else {
    tempId--;
  }
}

function loadDataTransfer() {
  const data = dataTransfer;
  setValues(data);
}

async function onSubmitTransfer() {
  const { valid } = await validate();

  if (!valid) {
    return;
  }

  loading.value = true;

  if (mode.value == "add") {
    emit("insertTransfer", { ...values, id: tempId });
  } else if (mode.value == "edit") {
    emit("updateTransfer", { ...values });
  }

  modalTransfer.value.hide();
  loading.value = false;
}

function onChange() {
  if (values.Transfer !== undefined) {
    values.allInRate =
      values.margin !== undefined
        ? parseFloat(values.Transfer) + parseFloat(values.margin)
        : values.Transfer;
  } else {
    values.allInRate = values.margin;
  }
}

defineExpose({
  openModalTransfer,
});
</script>

<template>
  <ModalTransfer ref="modalTransfer" :id-modal="'modalTransfer'">
    <template #title>{{ titleTransfer }}</template>

    <template #body>
      <form
        @submit.prevent="onSubmitTransfer"
        id="formTransfer"
        autocomplete="off">
        <fieldset :disabled="loading">
          <div class="mb-3" hidden>
            <label for="id" class="form-label">ID</label>
            <Field type="text" class="form-control" id="id" name="id" />
            <ErrorMessage class="invalid-feedback" name="id" />
          </div>
            <div class="mb-3">
              <label for="transactionTypeId" class="form-label"
                >ประเภทการทำธุรกรรม </label
              >
              <combobox
                inputId="transactionTypeId"
                name="transactionTypeId"
                class="form-control"
                :options="transactionTypes"
                :reduce="(option) => option.transactionTypeId">
              </combobox>

            </div>
            <div class="mb-3">
              <label for="userId" class="form-label"
                >บัญชีผู้รับโอน </label
              >
              <combobox
                inputId="userId"
                name="userId"
                class="form-control"
                :options="users"
                :reduce="(option) => option.userId">
              </combobox>

            </div>
            <div class="mb-3">
              <label for="coordinator" class="form-label">จำนวนเครดิต </label>
              <Field type="text" class="form-control" id="coordinator" name="coordinator" />
              <ErrorMessage class="invalid-feedback" name="coordinator" />
            </div>
            <div class="mb-3">
              <label for="position" class="form-label">ราคาขาย <span class="text-danger">*</span></label>
              <Field type="text" class="form-control" id="position" name="position" />
              <ErrorMessage class="invalid-feedback" name="position" />
            </div>
        </fieldset>
      </form>
    </template>

    <template #footer>
      <button
        type="button"
        class="btn btn-secondary"
        @click="modalTransfer.hide"
        :disabled="loading">
        Close
      </button>
      <button
        type="onSubmitTransfer"
        form="formTransfer"
        class="btn btn-primary"
        :disabled="loading">
        <div v-show="loading" class="spinner-border spinner-border-sm"></div>
        Save
      </button>
    </template>
  </ModalTransfer>
</template>
