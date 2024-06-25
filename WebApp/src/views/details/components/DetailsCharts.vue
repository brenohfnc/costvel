<template>
  <div v-if="showPieChart || showColumnChart" class="row justify-content-center">
    <div v-if="showPieChart" class="col-12">
      <div id="pie-chart" />
    </div>
    <div v-if="showColumnChart" class="col-12">
      <div id="column-chart" />
    </div>
  </div>
</template>

<script setup lang="ts">
import { computed, type PropType } from 'vue';
import type { IDetails } from '@/domain/details';

const props = defineProps({
  details: {
    type: Object as PropType<IDetails>,
    required: true
  }
});

const showPieChart = computed(() => props.details?.costs?.length > 0);
const showColumnChart = computed(() => props.details?.countryCosts?.length > 1);

const script = document.createElement('script');
script.src = 'https://www.gstatic.com/charts/loader.js';
script.onload = function () {
  // @ts-ignore
  google.charts.load('current', { packages: ['corechart'] });
  // @ts-ignore
  google.charts.setOnLoadCallback(() => {
    setupPieChart();
    setupColumnChart();
  });

  function setupPieChart() {
    if (!showPieChart.value) {
      return;
    }

    // @ts-ignore
    const costsData = google.visualization.arrayToDataTable([
      ['Custo', '% do total'],
      // eslint-disable-next-line no-unsafe-optional-chaining
      ...props.details?.costs.map((cost) => [cost.type, cost.average])
    ]);

    // @ts-ignore
    const pieChart = new google.visualization.PieChart(document.getElementById('pie-chart'));
    pieChart.draw(costsData, {
      title: 'Distribuição de custos',
      is3D: true,
      tooltip: {
        text: 'percentage'
      }
    });
  }

  function setupColumnChart() {
    if (!showColumnChart.value) {
      return;
    }

    // @ts-ignore
    const countryData = google.visualization.arrayToDataTable([
      ['Cidade', 'Custo médio diário de uma viagem'],
      // eslint-disable-next-line no-unsafe-optional-chaining
      ...props.details?.countryCosts.map((cost) => [cost.city, cost.average])
    ]);

    // @ts-ignore
    const columnChart = new google.visualization.ColumnChart(
      document.getElementById('column-chart')
    );
    columnChart.draw(countryData, {
      title: `Comparações com outras cidades do país`,
      legend: { position: 'none' }
    });
  }
};

document.head.appendChild(script);
</script>

<style scoped>
#pie-chart,
#column-chart {
  min-height: 300px;
}
</style>
