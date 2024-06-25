<template>
  <div v-if="store.loading">
    <costvel-loading-skeleton height="100px" width="100%" />
    <costvel-loading-skeleton height="100px" width="100%" class="mt-3" />
    <costvel-loading-skeleton height="45vh" width="100%" class="mt-3" />
  </div>
  <div v-else class="row">
    <div class="col-12">
      <p>
        Costvel é uma aplicação focada em divulgar os custos de viagem de diversas cidades pelo
        mundo. Os dados presentes na plataforma são obtidos por meio da colaboração voluntária de
        usuários, de forma anônima.
      </p>
      <p>
        <b>
          {{ store.current.costsCount }} custos em {{ store.current.locations.length }} cidades,
          providenciados por {{ store.current.contributorsCount }} contribuidores.
        </b>
      </p>
    </div>
    <div class="col-12 mb-3">
      <div class="row">
        <div class="col-12 col-md-6 col-xl-4">
          <label class="form-label">Selecione uma cidade: </label>
          <input ref="searchRef" class="form-control" placeholder="ex.: Belo Horizonte" />
        </div>
      </div>
    </div>
    <div class="col-12">
      <div id="map" class="rounded border" ref="mapRef"></div>
    </div>
  </div>
</template>

<script setup lang="ts">
import useMap from '@/composables/useMap';
import { ref, watch } from 'vue';
import { useSummaryStore } from '@/stores/summary';
import CostvelLoadingSkeleton from '@/components/shared/CostvelLoadingSkeleton.vue';

const mapRef = ref<HTMLDivElement>();
const searchRef = ref<HTMLInputElement>();

const store = useSummaryStore();
store.fetch();

watch(
  () => [store.loading, mapRef.value, searchRef.value],
  async ([loading, mapRef, searchRef]) => {
    if (!loading && mapRef && searchRef) {
      const map = await useMap();

      map.setupMap(mapRef as HTMLDivElement);
      map.setupSearch(searchRef as HTMLInputElement, store.createPlace);

      for (const place of store.current.locations) {
        await map.setupMarker({
          name: place.city,
          place_id: place.mapId,
          geometry: { location: JSON.parse(place.coordinates) }
        });
      }
    }
  }
);
</script>

<style lang="scss" scoped>
#map {
  height: 55vh;
  max-width: 100%;
}
</style>
