import Vue from 'vue';
import Vuex from 'vuex';

import { UserInfo } from '@/types/vuex';

import { cities } from '@/assets/finlandCities';

Vue.use(Vuex);

export default new Vuex.Store<UserInfo>({
  state: {
    loggedIn: false,
    username: ''
  },
  getters: {
    isLogged: (state): boolean => state.loggedIn,
    username: (state): string => state.username,
    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    cities: (): string[] =>
      cities.map((city) => city.city).sort((a, b) => a.localeCompare(b, 'sv')),
    // Get unique admin names for cities
    cityAdminNames: (): string[] =>
      [...new Set(cities.map((city) => city.admin_name))].sort((a, b) =>
        a.localeCompare(b, 'sv')
      ),
    getAdminByCity:
      () =>
      (city: string): string =>
        // eslint-disable-next-line @typescript-eslint/no-non-null-assertion
        cities.find(
          (location) => location.city.toLowerCase() === city.toLowerCase()
        )!.admin_name
  },
  mutations: {
    setLoggingInfo(state, loggedInfo: UserInfo) {
      state.loggedIn = loggedInfo.loggedIn;
      state.username = loggedInfo.username;
    },
    clearLoggingInfo(state) {
      state.loggedIn = false;
      state.username = '';
    }
  },
  actions: {},
  modules: {}
});
