<!-- eslint-disable vue/multi-word-component-names -->
<script setup>
import { useAttrs } from "vue";
import { useField } from "vee-validate";
import vSelect from "vue-select";

const attrs = useAttrs();
const { value } = useField(attrs.name);
</script>

<template>
  <vSelect v-model="value"> </vSelect>
</template>
