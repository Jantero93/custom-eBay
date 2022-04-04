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

<style scoped>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}
</style>
