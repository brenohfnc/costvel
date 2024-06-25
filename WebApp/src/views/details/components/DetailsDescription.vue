<template>
  <h1>Custos de viagem em {{ details.city }} - {{ details.state }}</h1>
  <p class="mt-3">
    Planejar uma viagem envolve mais do que apenas decidir onde ficar e o que fazer - é crucial
    entender os custos associados para garantir uma experiência agradável e sem estresse.
  </p>
  <p>
    Por meio da nossa plataforma, você têm uma visão detalhada dos principais custos envolvidos ao
    visitar a cidade de {{ details.city }}, desde acomodações, alimentação, transportes e até
    atrações turísticas.
  </p>
  <p>
    Com informações atualizadas pelos próprios usuários, você estará pronto para aproveitar sua
    próxima viagem mantendo suas despesas sob controle.
  </p>
</template>

<script setup lang="ts">
import { type PropType } from 'vue';
import type { IDetails } from '@/domain/details';

defineProps({
  details: {
    type: Object as PropType<IDetails>,
    required: true
  }
});
</script>
