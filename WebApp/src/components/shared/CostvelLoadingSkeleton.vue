<template>
  <div class="loading-skeleton rounded" :style="styles" />
</template>

<script setup lang="ts">
import { computed } from 'vue';

const props = defineProps({
  height: {
    type: String,
    default: '100%'
  },
  width: {
    type: String,
    default: '100%'
  }
});

const styles = computed(() => {
  return {
    width: props.width,
    height: props.height
  };
});
</script>

<style scoped lang="scss">
.loading-skeleton {
  width: 100%;
  height: 100%;
  background-color: #f0f0f0;
  background-image: linear-gradient(90deg, #f0f0f0 25%, #e0e0e0 50%, #f0f0f0 75%);
  background-size: 200% 100%;
  animation: loading 1.5s infinite linear;
}

@keyframes loading {
  0% {
    background-position: 200% 0;
  }
  100% {
    background-position: -200% 0;
  }
}
</style>
