import axios from 'axios';

import { User } from '@/types/user';

const BASE_URL = '/api/users';

export const loginUser = async (user: Partial<User>) => {
  const request = await axios.post(`${BASE_URL}/login`, user);
  return request.data;
};

export const registerUser = async (user: Partial<User>) => {
  const request = await axios.post(BASE_URL, user);
  return request.data;
};
