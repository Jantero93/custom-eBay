<template>
  <b-container :style="{ maxWidth: '500px' }">
    <b-card class="mt-5" title="Register new account">
      <b-form @submit.prevent="submitClicked">
        <b-form-group class="mt-3">
          <b-form-input
            id="input-name"
            v-model="form.firstName"
            type="text"
            placeholder="First name"
            required
          ></b-form-input>
        </b-form-group>

        <b-form-group>
          <b-form-input
            id="input-lastname"
            v-model="form.lastName"
            type="text"
            placeholder="Last name"
            required
          ></b-form-input>
        </b-form-group>

        <b-form-group>
          <b-form-input
            id="input-phonenumber"
            v-model="form.phone"
            type="text"
            placeholder="Phone number"
            required
          ></b-form-input>
        </b-form-group>

        <b-form-group>
          <b-form-input
            id="input-email"
            v-model="form.email"
            type="email"
            placeholder="Email"
            required
          ></b-form-input>
        </b-form-group>

        <b-form-group>
          <b-form-input
            id="input-password"
            v-model="form.password"
            type="password"
            placeholder="Password"
            required
          ></b-form-input>
        </b-form-group>

        <b-form-group>
          <b-form-input
            id="input-password-again"
            v-model="form.passwordAgain"
            type="password"
            placeholder="Password again"
            required
          ></b-form-input>
        </b-form-group>

        <b-button type="submit" variant="success">Sign up</b-button>
      </b-form>
    </b-card>
  </b-container>
</template>

<script lang="ts">
import Vue from 'vue';

interface ComponentState {
  firstName: string;
  lastName: string;
  phone: string;
  email: string;
  password: string;
  passwordAgain: string;
}

export default Vue.extend({
  name: 'SignUpForm',
  data(): { form: ComponentState } {
    return {
      form: {
        firstName: '',
        lastName: '',
        phone: '',
        email: '',
        password: '',
        passwordAgain: ''
      }
    };
  },
  methods: {
    submitClicked() {
      console.log(`this.$data.form`, this.$data.form);
    }
  }
});
</script>
