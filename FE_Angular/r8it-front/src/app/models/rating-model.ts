export interface RatingType {
  id: number;
  name: string;
  definition: string;
  rateChoices: RateChoice[];
}

export interface RateChoice {
  id: number;
  text: string;
  value: number;
}