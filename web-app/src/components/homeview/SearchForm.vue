<template>
  <div>
    <b-form inline>
      <b-form-input
        v-model="state.searchTerms"
        size="lg"
        class="mb-2 mr-sm-2 mb-sm-0"
        placeholder="Search items"
      ></b-form-input>

      <b-form-select v-model="state.adminName" size="lg">
        <b-form-select-option value="Finland">Finland</b-form-select-option>
        <b-form-select-option
          v-for="admin in adminNames"
          :key="admin"
          :value="admin"
          >{{ admin }}</b-form-select-option
        >
      </b-form-select>

      <b-button
        class="mt-2 mt-sm-0 ml-0 ml-sm-2"
        variant="success"
        size="lg"
        @click="searchClicked"
        >Search</b-button
      >
    </b-form>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';

interface FormState {
  searchTerms: string;
  adminName: string;
}

export default Vue.extend({
  name: 'SearchForm',
  data(): { state: FormState } {
    return {
      state: {
        searchTerms: '',
        adminName: 'Finland'
      }
    };
  },
  computed: {
    adminNames(): string[] {
      return this.$store.getters.cityAdminNames;
    }
  },
  methods: {
    searchClicked() {
      this.$emit('search-submit', {
        searchTerms: this.state.searchTerms,
        location: this.state.adminName
      });
    }
  }
});
</script>
