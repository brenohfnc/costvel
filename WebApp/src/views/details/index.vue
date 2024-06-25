<template>
  <div v-if="store.loading">
    <costvel-loading-skeleton
      v-for="i in 7"
      height="100px"
      width="100%"
      class="mb-3"
      :key="`skeleton-${i}`"
    />
  </div>
  <div v-else class="row justify-content-center">
    <div class="col-12 col-xl-8 mb-3">
      <router-link :to="routes.home"> Início </router-link>
    </div>
    <div class="col-12 col-xl-8">
      <details-description :details="store.current" />
      <details-summary-card :details="store.current" />
      <details-table :costs="store.current.costs" />
      <details-charts :details="store.current" />
    </div>
  </div>
</template>

<script setup lang="ts">
import { useDetailsStore } from '@/views/details/store';
import DetailsDescription from '@/views/details/components/DetailsDescription.vue';
import DetailsSummaryCard from '@/views/details/components/DetailsSummaryCard.vue';
import DetailsTable from '@/views/details/components/DetailsTable.vue';
import DetailsCharts from '@/views/details/components/DetailsCharts.vue';
import { AppRoutes } from '@/router/appRoutes';
import { computed } from 'vue';
import CostvelLoadingSkeleton from '@/components/shared/CostvelLoadingSkeleton.vue';

const props = defineProps({
  mapId: {
    type: String,
    required: true
  }
});

const store = useDetailsStore();
store.fetch(props.mapId);

const routes = computed(() => ({ home: AppRoutes.Home }));
</script>
