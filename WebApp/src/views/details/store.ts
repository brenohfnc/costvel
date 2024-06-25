import { ref } from 'vue';
import { defineStore } from 'pinia';
import { useApiClient } from '@/composables/useApiClient';
import { ApiRoutes } from '@/router/apiRoutes';
import type { IDetails } from '@/domain/details';

export const useDetailsStore = defineStore('details', () => {
  const apiClient = useApiClient();

  const current = ref<IDetails>({} as IDetails);
  const loading = ref(true);

  async function fetch(mapId: string): Promise<void> {
    loading.value = true;

    current.value = await apiClient.get<IDetails>(ApiRoutes.Locations.get(mapId));

    loading.value = false;
  }

  return { current, loading, fetch };
});
