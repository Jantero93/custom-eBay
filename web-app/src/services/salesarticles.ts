import axios from 'axios';

const BASE_URL = '/api/salesarticles';

export const postSalesArticle = async (
  saleArticle: FormData
): Promise<void> => {
  const request = await axios.post(BASE_URL, saleArticle);
  return request.data;
};
