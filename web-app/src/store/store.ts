import Vue from 'vue';
import Vuex from 'vuex';

import { Location } from '@/types/location';

import { getLocations } from '@/services/locations';
export interface AppState {
  loggedIn: boolean;
  username: string;
  locations: Location[];
}

Vue.use(Vuex);

export default new Vuex.Store<AppState>({
  state: {
    loggedIn: false,
    username: '',
    locations: []
  },
  getters: {
    isLogged: (state): boolean => state.loggedIn,
    username: (state): string => state.username,
    cities: (state): string[] =>
      state.locations
        .map((l) => l.city)
        .sort((a, b) => a.localeCompare(b, 'sv')),
    // Get unique admin names for cities
    cityAdminNames: (state): string[] =>
      [...new Set(state.locations.map((l) => l.admin_Name))].sort((a, b) =>
        a.localeCompare(b, 'sv')
      )
  },
  mutations: {
    setLoggingInfo(state, loggedInfo: AppState) {
      state.loggedIn = loggedInfo.loggedIn;
      state.username = loggedInfo.username;
    },
    clearLoggingInfo(state) {
      state.loggedIn = false;
      state.username = '';
    },
    setCities(state, locations: Location[]) {
      state.locations = locations;
    }
  },
  actions: {
    async setLocations(state) {
      const locations = (await getLocations()) || [];
      state.commit('setCities', locations);
    }
  },
  modules: {}
});
