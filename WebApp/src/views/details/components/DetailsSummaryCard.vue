<template>
  <div class="card bg-light mt-3">
    <div class="card-body">
      <p>
        Resumo dos custos de viagem em <b>{{ details.city }}</b>
      </p>
      <ul class="mb-0">
        <li>
          O custo médio diário de uma viagem à {{ details.city }} é de
          <b>{{ formatters.currency(details.costsAverage) }}</b>
        </li>
        <li>
          O custo mínimo diário de uma viagem à {{ details.city }} é de
          <b>{{ formatters.currency(details.costsMin) }}</b>
        </li>
        <li>
          O custo máximo diário de uma viagem à {{ details.city }} é de
          <b>{{ formatters.currency(details.costsMax) }}</b>
        </li>
        <li>
          O número de usuários que contribuíram com dados de viagem sobre {{ details.city }} é de
          <b>{{ details.numberOfContributors }}</b>
        </li>
      </ul>
    </div>
  </div>
  <div class="mt-3">
    <router-link :to="routes.contribute">
      Quero contribuir com dados de viagem sobre
      <span class="text-nowrap">{{ details.city }}</span>
    </router-link>
  </div>
</template>

<script setup lang="ts">
import { computed, type PropType } from 'vue';
import { AppRoutes } from '@/router/appRoutes';
import type { IDetails } from '@/domain/details';
import useFormatters from '@/composables/useFormatters';

const props = defineProps({
  details: {
    type: Object as PropType<IDetails>,
    required: true
  }
});

const formatters = useFormatters();

const routes = computed(() => ({
  contribute: AppRoutes.Contribute(props.details.mapId)
}));
</script>
