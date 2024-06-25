import { ref } from 'vue';
import { defineStore } from 'pinia';
import { useApiClient } from '@/composables/useApiClient';
import { ApiRoutes } from '@/router/apiRoutes';

interface ILocation {
  readonly mapId: string;
  readonly city: string;
  readonly coordinates: string;
}

interface ISummaryResponse {
  readonly costsCount: number;
  readonly contributorsCount: number;
  readonly locations: ILocation[];
}

export const useSummaryStore = defineStore('summary', () => {
  const apiClient = useApiClient();

  const current = ref<ISummaryResponse>({
    contributorsCount: 0,
    costsCount: 0,
    locations: []
  });
  const loading = ref(true);

  async function fetch(): Promise<void> {
    loading.value = true;

    current.value = await apiClient.get<ISummaryResponse>(ApiRoutes.Locations.summary);

    loading.value = false;
  }

  async function createPlace(place: google.maps.places.PlaceResult): Promise<void> {
    await apiClient.post(ApiRoutes.Locations.create, {
      mapId: place.place_id,
      city: place.name,
      state: place.address_components?.find((component) =>
        component.types.includes('administrative_area_level_1')
      )?.short_name,
      country: place.address_components?.find((component) => component.types.includes('country'))
        ?.short_name,
      coordinates: JSON.stringify(place.geometry?.location)
    });
  }

  return { current, loading, fetch, createPlace };
});
