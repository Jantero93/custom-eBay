<template>
  <b-navbar class="navigation-bar" toggleable="sm" type="dark" variant="dark">
    <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

    <b-collapse id="nav-collapse" is-nav>
      <b-navbar-nav class="mr-auto">
        <b-link to="/">Home</b-link>
      </b-navbar-nav>

      <b-navbar-nav class="mx-auto search-controls">
        <b-form-input class="ml-5" placeholder="Search" />
        <b-button class="ml-2" size="md" variant="outline-info" type="submit"
          >Search</b-button
        >
      </b-navbar-nav>

      <b-navbar-nav id="my-ebay" class="ml-auto">
        <b-nav-item-dropdown text="my eBay">
          <b-dropdown-item v-b-modal.modal-lg>List Item</b-dropdown-item>
          <b-dropdown-item href="#">Sign in</b-dropdown-item>
        </b-nav-item-dropdown>
      </b-navbar-nav>
    </b-collapse>
    <ListItemModal />
  </b-navbar>
</template>

<script lang="ts">
import Vue from 'vue';

import ListItemModal from '@/components/ListItemModal.vue';

export default Vue.extend({
  components: { ListItemModal }
});
</script>

<style scoped>
.navigation-bar {
  font-size: 1em;
  font-family: Arial, Helvetica, sans-serif;
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

nav a.router-link-exact-active {
  color: #42b983;
}

@media screen and (max-width: 575px) {
  a,
  #my-ebay {
    margin-top: 1em;
    margin-bottom: 1em;
    font-size: 2em;
  }

  .search-controls {
    display: flex;
    flex-direction: row;
  }
}
</style>
