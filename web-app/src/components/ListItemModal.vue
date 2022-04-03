<template>
  <b-modal
    id="modal-lg"
    ref="mymodal"
    hide-header-close
    ok-title="List Item"
    title="List Item"
    size="lg"
    @ok="submitClicked"
  >
    <b-form>
      <b-form-group>
        <label>Name</label>
        <b-form-input id="input-name"></b-form-input>
      </b-form-group>

      <b-form-group>
        <label>Price</label>
        <b-form-input id="input-price" type="number"></b-form-input>
      </b-form-group>

      <b-form-group>
        <label>Condition</label>
        <b-form-select v-model="input.condition" class="mb-3">
          <b-form-select-option value="New">New</b-form-select-option>
          <b-form-select-option value="Good">Good</b-form-select-option>
          <b-form-select-option value="Fair">Fair</b-form-select-option>
          <b-form-select-option value="Bad">Bad</b-form-select-option>
        </b-form-select>
      </b-form-group>
      <b-form-group>
        <label>Description</label>
        <b-form-textarea id="input-description" rows="5"></b-form-textarea>
      </b-form-group>

      <b-form-group label="Photos">
        <b-form-file
          id="file-default"
          v-model="input.files"
          accept="image/jpeg, image/png, image/gif"
          multiple
        ></b-form-file>
      </b-form-group>
    </b-form>
  </b-modal>
</template>

<script lang="ts">
import Vue from 'vue';

import { Condition } from '@/types/item';

interface FormInput {
  condition: Condition;
  description: string;
  itemName: string;
  location: string;
  price: number;
  files: [];
}

export default Vue.extend({
  name: 'ListItemModal',
  data(): { input: FormInput } {
    return {
      input: {
        condition: 'New',
        description: '',
        itemName: '',
        location: '',
        price: 0,
        files: []
      }
    };
  },
  methods: {
    submitClicked(e: Event) {
      this.$nextTick(() => {
        e.preventDefault();
        // eslint-disable-next-line @typescript-eslint/no-explicit-any
        (this.$refs.mymodal as any).hide();
      });
    }
  }
});
</script>
