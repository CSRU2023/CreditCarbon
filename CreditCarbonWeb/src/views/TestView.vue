
<template>
  <main>
    <h1>Home</h1>
    <button @click="counter++">Add 1</button>
    <p>The button above has been clicked {{ counter }} times.</p>
    <button @click="$router.push('/about')">About</button>
  </main>
</template>

<script lang="ts">
    import { defineComponent } from 'vue'

    export default defineComponent({
        data() {
            return {
                counter: 0
            }
        }
    })
    
</script>