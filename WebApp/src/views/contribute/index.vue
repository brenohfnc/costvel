<template>
  <div v-if="store.loading">
    <costvel-loading-skeleton
      v-for="i in 5"
      height="100px"
      width="100%"
      class="mb-3"
      :key="`skeleton-${i}`"
    />
  </div>
  <div v-else class="row justify-content-center">
    <div class="col-12 col-xl-8 mb-3">
      <router-link :to="routes.home">
        <span>Início</span>
      </router-link>
      >
      <router-link :to="routes.details">
        <span>
          Custos de viagem em {{ detailsStore.current.city }} -
          {{ detailsStore.current.state }}
        </span>
      </router-link>
    </div>
    <div class="col-12 col-xl-8">
      <h1>Contribua com dados de viagem sobre {{ detailsStore.current.city }}</h1>
      <p class="mt-3">
        Insira os dados abaixo de acordo com as experiências e custos que você teve visitando a
        cidade.
      </p>
    </div>
    <div class="col-12 col-xl-8">
      <div class="row">
        <div v-for="costType in store.current" :key="costType.id" class="col-12 col-md-6 mb-3">
          <contribute-field :cost-type="costType" />
        </div>
      </div>
      <div class="row justify-content-end">
        <div class="col-auto">
          <button @click="onClick" :disabled="store.loading" class="btn btn-primary px-5">
            Enviar
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { useContributeStore } from '@/views/contribute/store';
import { useDetailsStore } from '@/views/details/store';
import ContributeField from '@/views/contribute/components/ContributeField.vue';
import { AppRoutes } from '@/router/appRoutes';
import { computed } from 'vue';
import useToast from '@/composables/useToast';
import { useRouter } from 'vue-router';
import CostvelLoadingSkeleton from '@/components/shared/CostvelLoadingSkeleton.vue';

const props = defineProps({
  mapId: {
    type: String,
    required: true
  }
});

const router = useRouter();
const routes = computed(() => ({
  home: AppRoutes.Home,
  details: AppRoutes.Details(props.mapId!)
}));
const toast = useToast();
const detailsStore = useDetailsStore();
await detailsStore.fetch(props.mapId!);
const store = useContributeStore();
store.fetch();

async function onClick(): Promise<void> {
  await store.submit(props.mapId!);

  toast.show('Sucesso!', 'Dados enviados com sucesso.');

  await router.push(routes.value.details);
}
</script>
