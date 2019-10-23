export interface LoginAnswer {
  id: number;
  nickname: string;
  birthdate: string;
  email: string;
  country?: any;
  role?: any;
  token: string;
}