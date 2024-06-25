<template>
  <div class="marker-content text-center">
    <p class="h5">{{ title }}</p>
    <p>
      <a :href="routes.details">Ver custos</a>
    </p>
    <p>- ou -</p>
    <p>
      <a :href="routes.contribute">contribuir</a>
    </p>
  </div>
</template>

<script setup lang="ts">
import { AppRoutes } from '@/router/appRoutes';
import { computed } from 'vue';

const props = defineProps({
  placeId: {
    type: String,
    required: true
  },
  title: {
    type: String,
    required: true
  }
});

const routes = computed(() => ({
  details: AppRoutes.Details(props.placeId),
  contribute: AppRoutes.Contribute(props.placeId)
}));
</script>

<style scoped>
.marker-content {
  min-width: 200px;
}
</style>
