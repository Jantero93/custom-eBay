import Vue from 'vue';
import Vuex from 'vuex';

import { UserInfo } from '@/types/vuex';

Vue.use(Vuex);

export default new Vuex.Store<UserInfo>({
  state: {
    loggedIn: false,
    username: ''
  },
  getters: {
    isLogged: (state): boolean => state.loggedIn,
    username: (state): string => state.username
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
