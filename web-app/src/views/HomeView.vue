<template>
  <div class="d-flex flex-column align-items-center">
    <SearchForm class="mt-5" />
    <span class="mt-4 border-top align-self-stretch" />
  </div>
</template>

<script lang="ts">
import Vue from 'vue';

import SearchForm from '@/components/homeview/SearchForm.vue';

export default Vue.extend({
  name: 'HomeView',
  components: { SearchForm }
});
</script>
