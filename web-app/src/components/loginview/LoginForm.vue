<template>
  <b-card>
    <b-form @submit.prevent="submitClicked">
      <b-form-group
        description="We'll never share your email with anyone else."
      >
        <label>Email</label>
        <b-form-input
          id="input-email"
          v-model="form.email"
          type="email"
          required
        ></b-form-input>
      </b-form-group>

      <b-form-group label="Password">
        <b-form-input
          id="input-password"
          v-model="form.password"
          type="password"
          required
        ></b-form-input>
      </b-form-group>
      <b-button type="submit" variant="success">Submit</b-button>
    </b-form>
    <p class="mt-3">
      New to custom eBay?
      <router-link :to="`${$router.currentRoute.path}/signup`"
        >Create account</router-link
      >.
    </p>
  </b-card>
</template>

<script lang="ts">
import Vue from 'vue';

interface ComponentState {
  email: string;
  password: string;
}

export default Vue.extend({
  name: 'LoginForm',
  data(): { form: ComponentState } {
    return {
      form: {
        email: '',
        password: ''
      }
    };
  },
  methods: {
    submitClicked() {
      this.$emit('submit-clicked', {
        email: this.form.email,
        password: this.form.password
      });
    }
  }
});
</script>
