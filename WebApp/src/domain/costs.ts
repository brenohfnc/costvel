export interface ICost {
  readonly type: string;
  readonly average: number;
  readonly min: number;
  readonly max: number;
}

export interface ICountryCost {
  readonly city: string;
  readonly average: number;
}

export interface ICostType {
  readonly id: number;
  readonly name: string;
  readonly description: string;
  readonly order: number;
  value: number;
}
