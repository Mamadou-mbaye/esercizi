<script setup lang="ts">
import { ref, onMounted } from 'vue'
const test = ref('test')
onMounted(() => {
  test.value = 'Lorem ipsuim dindcnskncsk'
})
</script>
<template>
  <div>
    {{ test }}
  </div>
</template>

<style scoped></style>
