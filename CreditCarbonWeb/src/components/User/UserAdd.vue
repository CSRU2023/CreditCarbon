<template>
  <Modal ref="modal" size="xl">
    <template #title>Add User</template>

    <template #body>
      <form
        @submit.prevent="onSubmitDeveloper"
        id="formDeveloper"
        autocomplete="off">
        <fieldset :disabled="loading">
          <div class="mb-3">
            <label for="dp-input-effectiveFrom" class="form-label"
              >Test</label
            >
            <span class="text-danger"> *</span>
            <Field type="text" class="form-control" id="projectName" name="projectName"/>
          </div>
        </fieldset>
      </form>
    </template>

    <template #footer>
      <button
        type="button"
        class="btn btn-secondary"
        @click="modal.hide"
        :disabled="loading">
        Close
      </button>
      <button
        type="onSubmitDeveloper"
        class="btn btn-primary"
        :disabled="loading">
        <div v-show="loading" class="spinner-border spinner-border-sm"></div>
        Save
      </button>
    </template>
  </Modal>
</template>

<script setup>
import { ref } from 'vue'
import Modal from '../Modal.vue'
import { Field } from 'vee-validate'

const modal = ref(null)
const loading = ref(false)

function openModal() {
  loading.value = false
  modal.value.show()
}

defineExpose({
  openModal
})
</script>
