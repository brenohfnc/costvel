export class AppRoutes {
  public static readonly Home = '/';

  public static readonly Details = (mapId: string) => `/detalhes/${mapId}`;

  public static readonly Contribute = (mapId: string) => `/contribuir/${mapId}`;
}
