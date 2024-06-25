<template>
  <div class="toast-container position-absolute p-3 top-0 end-0">
    <div class="toast" :class="toastClasses">
      <div class="toast-header bg-toast-success">
        <span class="fw-bold text-success">
          {{ toast.current.title }}
        </span>
      </div>
      <div class="toast-body bg-toast-success">
        <span class="text-success">
          {{ toast.current.message }}
        </span>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import useToast from '@/composables/useToast';
import { computed } from 'vue';

const toast = useToast();

const toastClasses = computed(() => {
  return {
    show: toast.current.visible
  };
});
</script>

<style scoped lang="scss">
.bg-toast-success {
  background-color: #ddede6;
}
</style>
