<!-- eslint-disable vue/multi-word-component-names -->
<script setup>
import { Modal } from "bootstrap";
import { computed, onMounted } from "vue";

const props = defineProps({
  // valid values are "sm", "lg", "xl" and ""
  size: { type: String, default: "lg" },
  idModal: { type: String, default: "modal" },
});

const modalSizeClass = computed(() => {
  return props.size ? `modal-${props.size}` : "";
});

let thisModal;

onMounted(() => {
  thisModal = new Modal(document.getElementById(props.idModal));
});

function show() {
  console.log("show",props)
  thisModal.show();
}

function hide() {
  thisModal.hide();
}

defineExpose({
  show,
  hide,
});
</script>

<template>
  <div class="modal fade" :id="props.idModal" tabindex="-1">
    <div class="modal-dialog modal-dialog-scrollable" :class="modalSizeClass">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" :id="props.idModal">
            <slot name="title"></slot>
          </h5>
          <button
            type="button"
            class="btn-close"
            data-bs-dismiss="modal"
            aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <slot name="body"></slot>
        </div>
        <div class="modal-footer">
          <slot name="footer">
            <button
              type="button"
              class="btn btn-secondary"
              data-bs-dismiss="modal">
              Close
            </button>
          </slot>
        </div>
      </div>
    </div>
  </div>
</template>
