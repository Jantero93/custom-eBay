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
    <b-container>
      <b-form>
        <b-row>
          <b-form-group>
            <label>Name</label>
            <b-form-input id="input-name"></b-form-input>
          </b-form-group>
        </b-row>

        <b-row class="d-flex align-items-baseline pt-2">
          <b-col>
            <b-form-group>
              <label>Price</label>
              <b-form-input id="input-price"></b-form-input>
            </b-form-group>
          </b-col>

          <b-col class="d-flex flex-column align-items-center">
            <b-form-group v-slot="{ ariaDescribedby }" label="Condition">
              <b-form-radio-group
                v-model="input.condition"
                :aria-describedby="ariaDescribedby"
              >
                <b-form-radio value="New">New</b-form-radio>
                <b-form-radio value="Good">Good</b-form-radio>
                <b-form-radio value="Fair">Fair</b-form-radio>
                <b-form-radio value="Poor">Poor </b-form-radio>
              </b-form-radio-group>
            </b-form-group>
          </b-col>
        </b-row>

        <b-row>
          <b-col>
            <b-form-group>
              <label>Description</label>
              <b-form-textarea
                id="input-description"
                rows="5"
              ></b-form-textarea>
            </b-form-group>
          </b-col>
        </b-row>

        <b-row class="mt-2">
          <b-form-group>
            <b-row>
              <label>Pictures</label>
            </b-row>
            <b-row>
              <b-form-file
                id="file-input"
                v-model="input.files"
                accept="image/*"
                multiple
                plain
              />
            </b-row>
          </b-form-group>
        </b-row>
      </b-form>
    </b-container>
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
