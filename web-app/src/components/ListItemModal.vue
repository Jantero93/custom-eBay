<template>
  <b-modal
    id="modal-lg"
    ref="mymodal"
    hide-header-close
    ok-title="List Item"
    title="List new item"
    size="lg"
    @hidden="clearInput"
    @ok="submitClicked"
  >
    <b-form>
      <b-form-group>
        <label>Name*</label>
        <b-form-input id="state-input" v-model="state.itemName"></b-form-input>
      </b-form-group>

      <b-form-group>
        <label>Price*</label>
        <b-form-input
          id="state-input"
          v-model="state.price"
          type="number"
        ></b-form-input>
      </b-form-group>

      <b-form-group>
        <label>Condition</label>
        <b-form-select v-model="state.condition" class="mb-3">
          <b-form-select-option value="New">New</b-form-select-option>
          <b-form-select-option value="Good">Good</b-form-select-option>
          <b-form-select-option value="Fair">Fair</b-form-select-option>
          <b-form-select-option value="Bad">Bad</b-form-select-option>
        </b-form-select>
      </b-form-group>
      <b-form-group>
        <label>Description</label>
        <b-form-textarea
          id="state-description"
          v-model="state.description"
          rows="5"
        ></b-form-textarea>
      </b-form-group>

      <b-form-group label="Photos">
        <b-form-file
          id="file-default"
          v-model="state.files"
          accept="image/jpeg, image/png, image/gif"
          multiple
        ></b-form-file>
      </b-form-group>

      <div v-if="state.errors.length">
        <ul
          v-for="error in state.errors"
          :key="error"
          class="text-danger font-weight-bold"
        >
          <li>{{ error }}</li>
        </ul>
      </div>
    </b-form>
  </b-modal>
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
  data(): { state: ComponentState } {
    return {
      state: {
        condition: 'New',
        description: '',
        itemName: '',
        price: 0,
        files: [],
        errors: []
      }
    };
  },
  methods: {
    clearInput() {
      this.state.condition = 'New';
      this.state.description = '';
      this.state.itemName = '';
      this.state.files = [];
      this.state.errors = [];
      this.state.price = 0;
    },
    async submitClicked(e: Event) {
      e.preventDefault();
      this.validateInput();

      if (this.state.errors.length) return;

      this.$nextTick(() => this.$bvModal.hide('modal-lg'));
    },
    validateInput() {
      this.state.errors = [];
      if (!this.state.itemName.length) this.state.errors.push('Name required');
      if (this.state.price < 0) this.state.errors.push('Price required');
    }
  }
});
</script>
