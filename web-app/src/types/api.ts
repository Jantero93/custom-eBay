import { Location } from '@/types/location';
import { Image } from '@/types/salesArticle';
export interface Pager<T> {
  currentPage: number;
  hasNextPage: boolean;
  hasPreviousPage: boolean;
  items: T[];
  pageSize: number;
  totalPages: number;
  totalCount: number;
}

export type ApiSalesArticle = {
  id: string;
  name: string;
  description: string;
  price: number;
  image: Image;
  imageCount: number;
  location: Location;
  created: string;
};
