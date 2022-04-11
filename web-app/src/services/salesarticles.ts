import axios from 'axios';

import { SalesArticle } from '@/types/salesArticle';

const BASE_URL = '/api/salesarticles';

export const getAllSalesArticle = async (): Promise<SalesArticle[]> => {
  const request = await axios.get(BASE_URL);
  return request.data;
};

export const postSalesArticle = async (
  saleArticle: FormData
): Promise<void> => {
  const request = await axios.post(BASE_URL, saleArticle);
  return request.data;
};
