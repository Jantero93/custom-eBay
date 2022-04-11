<template>
  <div>
    <p>test</p>
    <b-img
      v-for="image in articleImages"
      :key="image.id"
      :src="`data:${image.type};base64,${image.data}`"
    ></b-img>
  </div>
</template>

<script lang="ts">
import Vue, { PropType } from 'vue';

import { Image, SalesArticle } from '@/types/salesArticle';

export default Vue.extend({
  name: 'SalesArticle',
  props: {
    item: {
      type: Object as PropType<SalesArticle>,
      required: true
    }
  },
  computed: {
    articleImages(): Image[] {
      console.log(`this.salesArticle.images`, this.item.images);
      return this.item.images;
    }
  }
});
</script>
