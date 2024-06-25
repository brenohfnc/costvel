import type { ICost, ICountryCost } from '@/domain/costs';

export interface IDetails {
  readonly mapId: string;
  readonly city: string;
  readonly state: string;
  readonly country: string;
  readonly costsAverage: number;
  readonly costsMin: number;
  readonly costsMax: number;
  readonly numberOfContributors: number;
  readonly costs: ICost[];
  readonly countryCosts: ICountryCost[];
}
