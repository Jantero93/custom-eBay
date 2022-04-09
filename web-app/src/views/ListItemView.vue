<template>
  <b-card class="mt-5" title="List new item">
    <b-form class="register-form" @submit.prevent="submitClicked">
      <b-form-group>
        <label>Name*</label>
        <b-form-input
          id="form-input"
          v-model="form.name"
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
          <b-form-select-option :value="0">New</b-form-select-option>
          <b-form-select-option :value="1">Good</b-form-select-option>
          <b-form-select-option :value="2">Fair</b-form-select-option>
          <b-form-select-option :value="3">Bad</b-form-select-option>
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
          class="text-danger text-center font-weight-bold list-unstyled"
        >
          <li>{{ error }}</li>
        </ul>
      </div>
    </b-form>
  </b-card>
</template>

<script lang="ts">
import Vue from 'vue';
import { AxiosError } from 'axios';

import { Condition } from '@/types/salesArticle';

import { postSalesArticle } from '@/services/salesarticles';

interface ComponentState {
  condition: Condition;
  description: string;
  name: string;
  price: number;
  files: File[];
  errors: string[];
}

export default Vue.extend({
  name: 'ListItemModal',
  data(): { form: ComponentState } {
    return {
      form: {
        condition: Condition.New,
        description: '',
        name: '',
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

      try {
        const salesArticle: FormData = new FormData();

        salesArticle.append('username', this.$store.getters.username);
        salesArticle.append('itemcondition', this.form.condition.toString());
        salesArticle.append('name', this.form.name);
        salesArticle.append('price', this.form.price.toString());
        salesArticle.append('description', this.form.description);
        this.form.files.forEach((file) => salesArticle.append(`images`, file));

        await postSalesArticle(salesArticle);

        this.$router.replace({ path: '/' });
      } catch (error) {
        this.form.errors.push(
          (error as AxiosError).response?.data.message || 'Server error'
        );
      }
    },
    validateInput() {
      this.form.errors = [];

      const allFilesAreImage = this.form.files.every((file) =>
        file.name.match(/.(jpg|jpeg|png|gif)$/i)
      );

      if (!allFilesAreImage)
        this.form.errors.push(
          'Allowed file extensions are jpg, jpeg, png, gif'
        );
      if (!this.form.name.length) this.form.errors.push('Name required');
      if (this.form.price < 0) this.form.errors.push('Price required');
      if (this.form.files.length > 10) this.form.errors.push('Max 10 photos');
    }
  }
});
</script>
