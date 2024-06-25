import { defineStore } from 'pinia';
import { useApiClient } from '@/composables/useApiClient';
import type { ICostType } from '@/domain/costs';
import { ApiRoutes } from '@/router/apiRoutes';
import { ref } from 'vue';

export const useContributeStore = defineStore('contribute', () => {
  const apiClient = useApiClient();

  const current = ref<ICostType[]>([]);
  const loading = ref(false);

  async function fetch(): Promise<void> {
    loading.value = true;

    current.value = await apiClient.get<ICostType[]>(ApiRoutes.Costs.getTypes);

    loading.value = false;
  }

  async function submit(mapId: string): Promise<void> {
    loading.value = true;

    await apiClient.post(ApiRoutes.Costs.submit(mapId), current.value);

    loading.value = false;
  }

  return { current, loading, fetch, submit };
});
