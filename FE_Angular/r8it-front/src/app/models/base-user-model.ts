import { Country } from './country';

export interface BaseUserModel {
  id?: number;
  nickname: string;
  birthdate: string;
  email: string;
  country: Country;
  role?: string;
  token?: string;
  password? : string;
}