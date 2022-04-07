<template>
  <b-container :style="{ maxWidth: '500px' }">
    <b-card class="mt-5" title="Register new account">
      <b-form class="register-form" @submit.prevent="submitClicked">
        <b-form-group class="mt-3">
          <label>First name</label>
          <b-form-input
            id="input-name"
            v-model="form.firstName"
            maxlength="50"
            required
            trim
            type="text"
          ></b-form-input>
        </b-form-group>

        <b-form-group>
          <label>Last name</label>

          <b-form-input
            id="input-lastname"
            v-model="form.lastName"
            maxlength="50"
            required
            trim
            type="text"
          ></b-form-input>
        </b-form-group>

        <b-form-group>
          <label>Phone number</label>
          <b-form-input
            id="input-phonenumber"
            v-model="form.phone"
            maxlength="20"
            required
            trim
            type="text"
          ></b-form-input>
        </b-form-group>

        <b-form-group>
          <label>Username</label>
          <b-form-input
            id="input-username"
            v-model="form.username"
            maxlength="30"
            required
            trim
            type="text"
          ></b-form-input>
        </b-form-group>

        <b-form-group>
          <label>Email</label>
          <b-form-input
            id="input-email"
            v-model="form.email"
            required
            trim
            type="email"
          ></b-form-input>
        </b-form-group>

        <b-form-group>
          <label>Password</label>
          <b-form-input
            id="input-password"
            v-model="form.password"
            required
            trim
            type="password"
          ></b-form-input>
        </b-form-group>

        <b-form-group>
          <label>Password again</label>
          <b-form-input
            id="input-password-again"
            v-model="form.passwordAgain"
            required
            trim
            type="password"
          ></b-form-input>
        </b-form-group>

        <b-button type="submit" variant="success">Sign up</b-button>

        <div v-if="form.errors.length" class="mt-2 text-center">
          <ul
            v-for="error in form.errors"
            :key="error"
            class="text-danger font-weight-bold"
          >
            <li>{{ error }}</li>
          </ul>
        </div>
      </b-form>
    </b-card>
  </b-container>
</template>

<script lang="ts">
import Vue from 'vue';

import { registerUser } from '@/services/user';

interface ComponentState {
  firstName: string;
  lastName: string;
  phone: string;
  username: string;
  email: string;
  password: string;
  passwordAgain: string;
  errors: string[];
}

export default Vue.extend({
  name: 'SignUpForm',
  data(): { form: ComponentState } {
    return {
      form: {
        firstName: '',
        lastName: '',
        phone: '',
        username: '',
        email: '',
        password: '',
        passwordAgain: '',
        errors: []
      }
    };
  },
  methods: {
    clearInput() {
      this.form.firstName = '';
      this.form.lastName = '';
      this.form.phone = '';
      this.form.username = '';
      this.form.email = '';
      this.form.password = '';
      this.form.passwordAgain = '';
    },
    async submitClicked(e: Event) {
      e.preventDefault();

      this.validateInput();
      if (this.form.errors.length) return;

      try {
        await registerUser({
          username: this.form.username,
          password: this.form.password,
          firstName: this.form.firstName,
          lastName: this.form.lastName,
          email: this.form.email,
          phoneNumber: this.form.phone
        });

        this.$router.replace({ path: '/login' });
      } catch (error) {
        // eslint-disable-next-line @typescript-eslint/no-explicit-any
        this.form.errors.push(
          (error as any).response.data.message || 'Server error'
        );
      }
    },
    validateInput() {
      this.form.errors = [];

      if (this.form.firstName.length > 50)
        this.form.errors.push('First name max 50 characters ');

      if (this.form.lastName.length > 50)
        this.form.errors.push('Last name max 50 characters');

      if (this.form.username.length > 30 || this.form.username.length < 3)
        this.form.errors.push('Username 3 - 30 characters');

      if (this.form.password !== this.form.passwordAgain)
        this.form.errors.push(`Passwords don't match`);

      if (this.form.password.length < 6)
        this.form.errors.push('Password must be at least 6 characters');
    }
  }
});
</script>

<style>
label {
  margin-bottom: 0;
}
</style>
