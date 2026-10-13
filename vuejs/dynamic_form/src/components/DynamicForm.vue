<template>
  <div>
    <!--
    <div v-for="field in schema.fields" :key="field.name">
      <label>{{ field.Label }}</label>
      <input
        type="text"
        v-if="field.ControlType === 'text'"
        v-model="prospectStore.prospect[field.FieldKey]"
      />
      <input type="number" v-else-if="field.ControlType === 'number'" />
      <input type="date" v-else-if="field.ControlType === 'date'" />
    </div>
    -->
    <!-- <div v-for="field in ProspectFields" :key="field.FieldKey"></div> -->
    <DynamicField
      v-for="field in schema.fields"
      :key="field.FieldKey"
      v-model="prospectStore.prospect[field.FieldKey]"
      :field="field.ControlType"
      :fieldLabel="field.Label"
    />
    <button @click="saveProspect()">Save</button>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { useProspectStore } from '@/stores/prospect.ts'
import DynamicField from './DynamicField.vue'

const prospectStore = useProspectStore()

const schema = ref([])
const loadSchema = async () => {
  try {
    const res = await fetch('./objSchema.json')
    if (!res.ok) throw new Exception(res.error)
    schema.value = await res.json()
  } catch (e) {
    console.error(e)
  }
}

const saveProspect = () => {
  console.log(prospectStore.prospect)
}
onMounted(async () => {
  await loadSchema()
  await prospectStore.Prospect_Load()
  // Prospect.value = { nome: 'Mario', dataNascita: null, codiceFiscale: 'SWEEEGFEFEFE' }
})
</script>
