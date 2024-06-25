<template>
  <table class="table table-hover table-striped table-bordered overflow-auto mt-3">
    <thead>
      <tr>
        <th>Categoria</th>
        <th>Preço médio</th>
        <th>
          <span class="d-inline-flex align-items-center">
            <span>Intervalo de preços</span>
            <span
              class="question-mark-icon px-1 ms-2"
              title="Onde encontra-se o preço médio comparado aos preços mínimos e máximos."
            >
              ?
            </span>
          </span>
        </th>
      </tr>
    </thead>
    <tbody>
      <tr v-if="costs.length === 0">
        <td class="text-center" colspan="4">
          Não há registros de custos de viagem para essa cidade.
        </td>
      </tr>
      <tr v-for="cost in costs" :key="cost.type">
        <td>{{ cost.type }}</td>
        <td>{{ formatters.currency(cost.average) }}</td>
        <td>
          <div class="progress-bar">
            <span class="progress-bar-fill" :style="getStyle(cost)"></span>
          </div>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script setup lang="ts">
import type { PropType } from 'vue';
import type { ICost } from '@/domain/costs';
import useFormatters from '@/composables/useFormatters';

defineProps({
  costs: {
    type: Array as PropType<ICost[]>,
    required: true
  }
});

const formatters = useFormatters();

function getStyle(cost: ICost) {
  return {
    width: `${(cost.average / cost.max) * 100}%`
  };
}
</script>

<style scoped>
.progress-bar {
  width: 100%;
  background-color: #e0e0e0;
  padding: 3px;
  border-radius: 3px;
  box-shadow: inset 0 1px 3px rgba(0, 0, 0, 0.2);
}

.progress-bar-fill {
  display: block;
  height: 22px;
  background-color: green;
  border-radius: 3px;

  transition: width 500ms ease-in-out;
}

.question-mark-icon {
  width: 15px;
  height: 15px;
  display: inline-block;
  border-radius: 100%;
  font-size: 10px;
  text-align: center;
  text-decoration: none;
  box-shadow: inset -1px -1px 1px 0 rgba(0, 0, 0, 0.25);
  border: 1px solid rgba(0, 0, 0, 0.25);
  cursor: help;
}
</style>
