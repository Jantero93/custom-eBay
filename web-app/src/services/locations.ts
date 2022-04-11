import axios from 'axios';

import { Location } from '@/types/location';

const BASE_URL = '/api/locations';

export const getLocations = async (): Promise<Location> => {
  const request = await axios.get(BASE_URL);
  return request.data;
};
