<template>
  <div>
    <label>{{ fieldLabel }}</label>
    <input type="text" v-if="field === 'text'" v-model="model" />
    <input type="number" v-else-if="field === 'number'" />
    <input type="date" v-else-if="field === 'date'" />
  </div>
</template>

<script setup lang="ts">
import { onMounted } from 'vue'
interface Props {
  field: string
  fieldLabel: string
}
const props = defineProps<Props>()
const model = defineModel()
onMounted(() => {})
</script>
