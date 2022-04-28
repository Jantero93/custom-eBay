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
    <div>
      <div class="d-flex flex-row justify-content-between">
        <div class="d-flex flex-column align-items-start">
          <p class="price-text font-weight-bold">{{ item.price }} €</p>
          <b-badge v-if="imageCount" class="item-badge" variant="success">
            {{ imageCount }}<b-icon class="ml-1" icon="camera-fill"
          /></b-badge>
        </div>
        <div class="text-right text-muted secondary-text">
          <p>{{ itemListedDate }}</p>
          <p>{{ itemProvince }}</p>
        </div>
      </div>
    </div>
  </b-card>
</template>

<script lang="ts">
import Vue, { PropType } from 'vue';

import { formatDate } from '@/utilities/dateHelpers';

import { ApiSalesArticle } from '@/types/api';

export default Vue.extend({
  name: 'SalesArticle',
  props: {
    item: {
      type: Object as PropType<ApiSalesArticle>,
      required: true
    }
  },
  computed: {
    articleImageSrc(): string {
      return `data:${this.item.image.type};base64,${this.item.image.data}`;
    },
    imageAvailable(): boolean {
      return this.item.image !== undefined;
    },
    imageCount(): number {
      return this.item.imageCount;
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
      this.$router.push({ path: `/articles/${this.item.id}` });
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

.card-body {
  overflow: hidden;
}

.card-title {
  font-size: 2.25em;
  overflow: hidden;
  text-overflow: ellipsis;
}

.price-text {
  font-size: 1.75em;
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

  .card-body {
    padding: 0.5em;
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

  .item-badge {
    display: none;
  }
}
</style>
