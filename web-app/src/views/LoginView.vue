<template>
  <div class="d-flex flex-column align-items-center">
    <b-img class="w-25 mt-2" :src="require('@/assets/ebay-image.png')" />
    <h1>Sign in to custom eBay</h1>
    <LoginForm class="mt-2" @submit-clicked="postLogin" />
  </div>
</template>

<script lang="ts">
import Vue from 'vue';

import LoginForm from '@/components/loginview/LoginForm.vue';

type UserData = {
  email: string;
  password: string;
};

export default Vue.extend({
  name: 'LoginView',
  components: { LoginForm },
  methods: {
    createAccountClicked() {
      // TODO: Open modal for creating new user
      console.log('create account clicked');
    },
    postLogin(userData: UserData) {
      // TODO: Make api call post login
      console.log(`userData`, userData);
    }
  }
});
</script>
