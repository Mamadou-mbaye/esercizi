import { ref, computed } from 'vue'
import { defineStore } from 'pinia'

export const useProspectStore = defineStore('prospect', () => {
  const prospect = ref([])
  const Prospect_Load = async () => {
    try {
      const response = await fetch('./prospect.json')
      prospect.value = await response.json()
    } catch (e) {
      console.error(e)
    }
  }

  return { prospect, Prospect_Load }
})
