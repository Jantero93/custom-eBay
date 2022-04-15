import Vue from 'vue';
import Vuex from 'vuex';

import { Location } from '@/types/location';

import { getLocations } from '@/services/locations';
export interface AppState {
  loggedIn: boolean;
  username: string;
  userId?: number;
  locations: Location[];
}

Vue.use(Vuex);

export default new Vuex.Store<AppState>({
  state: {
    loggedIn: false,
    username: '',
    userId: undefined,
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
      ),
    userId: (state): number | undefined => state.userId
  },
  mutations: {
    setLoggingInfo(state, loggedInfo: AppState): void {
      state.loggedIn = loggedInfo.loggedIn;
      state.username = loggedInfo.username;
      state.userId = loggedInfo.userId;
    },
    clearLoggingInfo(state): void {
      state.loggedIn = false;
      state.username = '';
    },
    setCities(state, locations: Location[]) {
      state.locations = locations;
    }
  },
  actions: {
    async setLocations(state): Promise<void> {
      const locations = (await getLocations()) || [];
      state.commit('setCities', locations);
    }
  },
  modules: {}
});
