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
    cities: (): any[] =>
      cities.sort((a, b) => a.city.localeCompare(b.city, 'sv'))
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
