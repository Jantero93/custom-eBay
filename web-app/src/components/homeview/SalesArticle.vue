<template>
  <b-card
    class="item-card"
    :img-src="
      imageAvailable ? articleImageSrc : require('@/assets/no-image.png')
    "
    img-left
    :title="item.name"
    @click="cardClicked"
  >
    <div class="d-flex flex-row justify-content-between">
      <p class="price-text font-weight-bold">{{ item.price }} €</p>
      <div class="text-right text-muted secondary-text">
        <p>{{ itemListedDate }}</p>
        <p>{{ itemProvince }}</p>
      </div>
    </div>
  </b-card>
</template>

<script lang="ts">
import Vue, { PropType } from 'vue';

import { formatDate } from '@/utilities/dateHelpers';

import { SalesArticle } from '@/types/salesArticle';

export default Vue.extend({
  name: 'SalesArticle',
  props: {
    item: {
      type: Object as PropType<SalesArticle>,
      required: true
    }
  },
  computed: {
    articleImageSrc(): string {
      return `data:${this.item.images[0].type};base64,${this.item.images[0].data}`;
    },
    imageAvailable(): boolean {
      return this.item.images[0] !== undefined;
    },
    itemListedDate(): string {
      return formatDate('DD MMM HH:mm', this.item.created);
    },
    itemProvince(): string {
      return this.item.location.admin_Name;
    }
  },
  methods: {
    cardClicked() {
      this.$router.replace({ path: `/articles/${this.item.id}` });
    }
  }
});
</script>

<style scoped>
.item-card:hover {
  cursor: pointer;
  background-color: rgb(242, 242, 242);
}

img {
  object-fit: contain;
  width: 260px;
  height: 200px;
  margin-right: 0.5em;
}

.card-title {
  font-size: 2.75em;
}

.price-text {
  font-size: 2em;
}

.secondary-text > p {
  margin: 0;
  font-size: 1.2em;
}

@media screen and (max-width: 575px) {
  img {
    object-fit: contain;
    width: 130px;
    height: 100px;
    margin-right: 0em;
  }

  .price-text {
    font-size: 1em;
  }

  .card-title {
    font-size: 1.5em;
  }

  .secondary-text > p {
    margin: 0;
    font-size: 0.8em;
  }
}
</style>
