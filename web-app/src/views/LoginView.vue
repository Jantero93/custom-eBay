<template>
  <div class="d-flex flex-column align-items-center">
    <b-img class="w-25 mt-2" :src="require('@/assets/ebay-image.png')" />
    <h1>Sign in to custom eBay</h1>
    <LoginForm class="mt-2" />
  </div>
</template>

<script lang="ts">
import Vue from 'vue';

import LoginForm from '@/components/loginview/LoginForm.vue';

export default Vue.extend({
  name: 'LoginView',
  components: { LoginForm }
});
</script>
