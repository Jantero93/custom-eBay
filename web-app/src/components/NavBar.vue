<template>
  <b-navbar class="navigation-bar" toggleable="sm" type="dark" variant="dark">
    <b-container fluid="md">
      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

      <b-collapse id="nav-collapse" is-nav>
        <b-navbar-nav class="mr-auto">
          <router-link to="/"
            ><img src="@/assets/ebay-image.png" :style="{ width: '125px' }"
          /></router-link>
        </b-navbar-nav>

        <b-navbar-nav class="ml-auto">
          <b-nav-text
            v-if="userLogged"
            class="d-none d-lg-inline mr-1 text-info"
            >Logged in</b-nav-text
          >
          <b-nav-item-dropdown id="my-ebay" text="my eBay" boundary="viewport">
            <b-dropdown-item @click="logClicked">{{
              userLogged ? 'Log out' : 'Login'
            }}</b-dropdown-item>
            <b-dropdown-item v-if="userLogged" to="/manage-items"
              >Listed items</b-dropdown-item
            >
            <b-dropdown-item v-if="userLogged" to="/list-item"
              >New Item</b-dropdown-item
            >
          </b-nav-item-dropdown>
        </b-navbar-nav>
      </b-collapse>
    </b-container>
  </b-navbar>
</template>

<script lang="ts">
import Vue from 'vue';

import { clearLoginLocalStorage } from '@/utilities/localStorageHelpers';

export default Vue.extend({
  name: 'NavBar',
  computed: {
    userLogged(): boolean {
      return this.$store.getters.isLogged;
    },
    loggedUsername(): string {
      return this.$store.getters.username;
    }
  },
  methods: {
    logClicked(): void {
      if (this.userLogged) {
        this.$store.commit('clearLoggingInfo');
        clearLoginLocalStorage();
        this.$router.replace({ path: '/' }).catch(() => null);
        return;
      }

      // Prevent NavigationDuplicated error with empty catch
      this.$router.replace({ path: '/login' }).catch(() => null);
    }
  }
});
</script>

<style scoped>
.navigation-bar {
  font-size: 1em;
  font-family: Arial, Arial, Helvetica, sans-serif;
}

a:hover {
  color: #42b983;
}

a {
  color: #42b983;
  text-decoration: none;
  font-weight: bold;
  color: #2c3e50;
}

button {
  white-space: nowrap;
  text-align: center;
}

nav a.router-link-exact-active,
.router-link-active {
  color: #42b983;
}

@media screen and (max-width: 575px) {
  a,
  #my-ebay {
    font-size: 2em;
    align-self: center;
  }
}
</style>
