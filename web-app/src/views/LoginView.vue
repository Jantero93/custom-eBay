<template>
  <div class="d-flex flex-column align-items-center">
    <div>first</div>
    <EbayLogo :size="1" />
    <div>third</div>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';

import EbayLogo from '@/icons/EbayLogo.vue';

export default Vue.extend({
  name: 'LoginView',
  components: { EbayLogo }
});
</script>

<style scoped></style>
