import { Loader } from '@googlemaps/js-api-loader';
import MarkerContent from '@/components/MarkerContent.vue';
import { h, render } from 'vue';
import { MarkerClusterer } from '@googlemaps/markerclusterer';
import AdvancedMarkerElement = google.maps.marker.AdvancedMarkerElement;

export type SlimPlace = Pick<google.maps.places.PlaceResult, 'place_id' | 'name' | 'geometry'>;

class MapHandler {
  private readonly mapsLibrary: google.maps.MapsLibrary;
  private readonly markerLibrary: google.maps.MarkerLibrary;
  private readonly placesLibrary: google.maps.PlacesLibrary;

  private readonly current: {
    map: google.maps.Map;
    markers: google.maps.marker.AdvancedMarkerElement[];
    markerClusterer: MarkerClusterer;
    infoWindow?: google.maps.InfoWindow;
  };

  constructor(
    mapsLibrary: google.maps.MapsLibrary,
    markerLibrary: google.maps.MarkerLibrary,
    placesLibrary: google.maps.PlacesLibrary
  ) {
    this.mapsLibrary = mapsLibrary;
    this.markerLibrary = markerLibrary;
    this.placesLibrary = placesLibrary;

    this.current = {
      map: {} as google.maps.Map,
      markers: [],
      markerClusterer: {} as MarkerClusterer
    };
  }

  public setupMap(mapElement: HTMLElement): void {
    this.current.map = new this.mapsLibrary.Map(mapElement, {
      zoom: 4,
      center: { lat: -14.235004, lng: -51.92528 },
      mapId: 'DEMO_MAP_ID'
    });

    this.current.markerClusterer = new MarkerClusterer({
      markers: this.current.markers,
      map: this.current.map
    });
  }

  public setupSearch(
    searchElement: HTMLInputElement,
    onSelectCallback: (result: google.maps.places.PlaceResult) => any
  ): void {
    const autocomplete = new this.placesLibrary.Autocomplete(searchElement);
    autocomplete.setTypes(['(cities)']);
    autocomplete.addListener.bind(this);
    autocomplete.addListener('place_changed', async () => {
      const place = autocomplete.getPlace();

      if (!place.geometry?.location) {
        return;
      }

      this.current.map.setCenter(place.geometry.location);

      const existingMarker = this.current.markers.find((marker) => marker.title === place.name);

      if (existingMarker) {
        return this.openInfoWindow(place, existingMarker);
      }

      const marker = await this.setupMarker(place);

      this.openInfoWindow(place, marker);

      onSelectCallback(place);
    });
  }

  public async setupMarker(place: SlimPlace): Promise<AdvancedMarkerElement> {
    const marker = new this.markerLibrary.AdvancedMarkerElement({
      map: this.current.map,
      title: place.name ?? '',
      position: place.geometry?.location
    });

    marker.addListener.bind(this);
    marker.addListener('click', () => {
      this.openInfoWindow(place, marker);
    });

    this.current.markers.push(marker);
    this.current.markerClusterer.addMarker(marker, true);

    return marker;
  }

  private setupInfoWindow(place: SlimPlace): google.maps.InfoWindow {
    const content = h(MarkerContent, {
      placeId: place.place_id ?? '',
      title: place.name ?? ''
    });
    const contentWrapper = document.createElement('div');

    render(content, contentWrapper);

    return new google.maps.InfoWindow({
      content: contentWrapper,
      disableAutoPan: false
    });
  }

  private openInfoWindow(place: SlimPlace, marker: AdvancedMarkerElement): void {
    if (this.current.infoWindow) {
      this.current.infoWindow.close();
    }

    this.current.infoWindow = this.setupInfoWindow(place);
    this.current.infoWindow.open(this.current.map, marker);
  }
}

let handler: MapHandler;

export default async function useMap(): Promise<MapHandler> {
  if (handler) {
    return handler;
  }

  const loader = new Loader({
    apiKey: '',
    version: 'weekly'
  });

  const mapsLibrary = await loader.importLibrary('maps');
  const markerLibrary = await loader.importLibrary('marker');
  const placesLibrary = await loader.importLibrary('places');

  handler = new MapHandler(mapsLibrary, markerLibrary, placesLibrary);

  return handler;
}
