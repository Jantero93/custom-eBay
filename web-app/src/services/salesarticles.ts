import axios from 'axios';

import { SalesArticle } from '@/types/salesArticle';

const BASE_URL = '/api/salesarticles';

export const getAllSalesArticle = async (): Promise<SalesArticle[]> => {
  const params = new URLSearchParams([
    ['test', 'one'],
    ['time', 'testTime']
  ]);

  const request = await axios.get(BASE_URL, { params });
  return request.data;
};

export const getSaleArticle = async (id: number): Promise<SalesArticle> => {
  const request = await axios.get(`${BASE_URL}/${id}`);
  return request.data;
};

export const postSalesArticle = async (
  saleArticle: FormData
): Promise<void> => {
  const request = await axios.post(BASE_URL, saleArticle);
  return request.data;
};
