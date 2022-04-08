<template>
  <b-card class="mt-5" title="List new item">
    <b-form class="register-form" @submit.prevent="submitClicked">
      <b-form-group>
        <label>Name*</label>
        <b-form-input
          id="form-input"
          v-model="form.itemName"
          trim
          type="text"
        ></b-form-input>
      </b-form-group>

      <b-form-group>
        <label>Price*</label>
        <b-form-input
          id="form-input"
          v-model="form.price"
          type="number"
          trim
        ></b-form-input>
      </b-form-group>

      <b-form-group>
        <label>Condition*</label>
        <b-form-select v-model="form.condition" class="mb-3">
          <b-form-select-option value="New">New</b-form-select-option>
          <b-form-select-option value="Good">Good</b-form-select-option>
          <b-form-select-option value="Fair">Fair</b-form-select-option>
          <b-form-select-option value="Bad">Bad</b-form-select-option>
        </b-form-select>
      </b-form-group>

      <b-form-group>
        <label>Description</label>
        <b-form-textarea
          id="form-description"
          v-model="form.description"
          rows="2"
        ></b-form-textarea>
      </b-form-group>

      <b-form-group label="Photos">
        <b-form-file
          id="file-default"
          v-model="form.files"
          accept="image/jpeg, image/png, image/gif"
          multiple
        ></b-form-file>
      </b-form-group>

      <div v-if="form.files.length" class="d-flex flex-wrap mb-3">
        <b-img
          v-for="image in filesToImages"
          :key="image"
          class="m-1"
          thumbnail
          :src="image"
          :style="{ maxWidth: '100px' }"
        ></b-img>
      </div>

      <b-button type="submit" variant="success">List item</b-button>

      <div v-if="form.errors.length">
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
</template>

<script lang="ts">
import Vue from 'vue';

import { Condition } from '@/types/item';

interface ComponentState {
  condition: Condition;
  description: string;
  itemName: string;
  price: number;
  files: File[];
  errors: string[];
}

export default Vue.extend({
  name: 'ListItemModal',
  data(): { form: ComponentState } {
    return {
      form: {
        condition: 'New',
        description: '',
        itemName: '',
        price: 0,
        files: [],
        errors: []
      }
    };
  },
  computed: {
    filesToImages(): string[] {
      return this.form.files.map((file) => URL.createObjectURL(file));
    }
  },
  methods: {
    async submitClicked(e: Event) {
      e.preventDefault();
      this.validateInput();

      if (this.form.errors.length) return;

      this.$router.replace({ path: '/' });
    },
    validateInput() {
      this.form.errors = [];
      if (!this.form.itemName.length) this.form.errors.push('Name required');
      if (this.form.price < 0) this.form.errors.push('Price required');
      if (this.form.files.length > 10) this.form.errors.push('Max 10 photos');
    }
  }
});
</script>
