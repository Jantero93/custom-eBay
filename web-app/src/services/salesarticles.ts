import axios from 'axios';

import { ApiSalesArticle, Pager } from '@/types/api';
import { SalesArticle } from '@/types/salesArticle';

const BASE_URL = '/api/salesarticles';

export const getSalesArticlesByPage = async (
  pageNum: number
): Promise<Pager<ApiSalesArticle>> => {
  const request = await axios.get(BASE_URL, { params: { page: pageNum } });
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
