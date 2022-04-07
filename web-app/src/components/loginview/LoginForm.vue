<template>
  <b-card>
    <b-form @submit.prevent="submitClicked">
      <b-form-group>
        <label>Username</label>
        <b-form-input
          id="input-username"
          v-model="form.username"
          maxlength="30"
          required
          type="text"
          trim
        ></b-form-input>
      </b-form-group>

      <b-form-group label="Password">
        <b-form-input
          id="input-password"
          v-model="form.password"
          required
          trim
          type="password"
        ></b-form-input>
      </b-form-group>

      <b-button type="submit" variant="success">Login</b-button>
    </b-form>

    <p class="mt-3">
      New to custom eBay?
      <router-link :to="`${$router.currentRoute.path}/signup`"
        >Create account</router-link
      >.
    </p>

    <div v-if="form.errors.length" class="mt-2 text-center">
      <ul
        v-for="error in form.errors"
        :key="error"
        class="text-danger font-weight-bold list-unstyled"
      >
        <li>{{ error }}</li>
      </ul>
    </div>
  </b-card>
</template>

<script lang="ts">
import Vue from 'vue';

import { loginUser } from '@/services/user';

import { AxiosError } from 'axios';

interface ComponentState {
  errors: string[];
  username: string;
  password: string;
}

export default Vue.extend({
  name: 'LoginForm',
  data(): { form: ComponentState } {
    return {
      form: {
        errors: [],
        username: '',
        password: ''
      }
    };
  },
  methods: {
    async submitClicked() {
      this.validateInput();
      if (this.form.errors.length) return;

      try {
        await loginUser({
          username: this.form.username,
          password: this.form.password
        });

        this.$router.replace({ path: '/' });
      } catch (error) {
        this.form.errors.push(
          (error as AxiosError).response?.data.message || 'Server error'
        );
      }
    },
    validateInput() {
      this.form.errors = [];
      if (!this.form.username.length) this.form.errors.push('Invalid username');
      if (!this.form.password.length) this.form.errors.push('Invalid password');
    }
  }
});
</script>
