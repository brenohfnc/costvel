export class ApiRoutes {
  public static readonly Locations = {
    summary: '/locations/summary',
    create: '/locations',
    get: (mapId: string): string => `/locations/${mapId}`
  };

  public static readonly Costs = {
    getTypes: '/costs/types',
    submit: (mapId: string): string => `/costs/${mapId}`
  };
}
