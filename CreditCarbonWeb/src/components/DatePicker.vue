<script setup>
import { useAttrs } from "vue";
import { useField } from "vee-validate";
import Datepicker from "@vuepic/vue-datepicker";

const attrs = useAttrs();
const { value } = useField(attrs.name);
</script>

<template>
  <Datepicker
    v-model="value"
    format="dd/MM/yyyy"
    :enableTimePicker="false"
    :autoApply="true"
    :class="{ disabled: attrs.disabled }"
    modelType="yyyy-MM-dd" />
</template>
