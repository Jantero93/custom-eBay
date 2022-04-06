import axios from 'axios';

import { User } from '@/types/user';

const BASE_URL = '/api/users';

export const registerUser = async (user: Partial<User>) => {
  const request = await axios.post(BASE_URL, user, {
    validateStatus: (status) => status < 400
  });

  return request.data;
};
