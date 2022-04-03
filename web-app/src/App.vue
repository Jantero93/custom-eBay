<template>
  <div id="app">
    <NavBar />
    <b-container fluid="lg">
      <router-view />
    </b-container>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';

import NavBar from '@/components/NavBar.vue';

export default Vue.extend({
  components: { NavBar }
});
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 1.5em;
}

nav a {
  font-weight: bold;
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color: #42b983;
}
</style>
