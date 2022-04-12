import { User } from '@/types/user';
import { Location } from '@/types/location';

export enum Condition {
  New,
  Good,
  Fair,
  Poor
}

export type Image = {
  data: string;
  name: string;
  type: string;
};

export type SalesArticle = {
  id: string;
  condition: Condition;
  created: string;
  name: string;
  description: string;
  price: number;
  images: Image[];
  user: User;
  location: Location;
};
