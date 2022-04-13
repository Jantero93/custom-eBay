<template>
  <div v-if="itemFetched" class="d-flex flex-column pt-5">
    <div
      id="main-content"
      class="w-100 py-2 d-flex flex-column justify-content-center align-items-center position-relative bg-light"
    >
      <b-img
        class="p-3"
        height="500"
        width="auto"
        :src="imagesAvailable ? imageData : require('@/assets/no-image.png')"
      />
      <b-badge
        v-if="imagesAvailable"
        class="mt-1 expand-badge"
        :style="{ maxWidth: '100px' }"
        @click="expandImage"
        >Click to enlarge</b-badge
      >
    </div>
    <div v-if="imagesAvailable" class="d-flex mt-3 flex-wrap">
      <b-img
        v-for="(image, index) in state.salesArticle.images"
        :key="image.id"
        class="mr-1 mt-1 thumbnail-image"
        :src="getImageData(index)"
        thumbnail
        :style="{
          width: '100px',
          height: 'auto',
          objectFit: 'contain',
          aspectRatio: '1'
        }"
        @click="selectImage(index)"
      />
    </div>
    <div class="mt-3 font-weight-bold d-flex justify-content-between item-text">
      <h1 class="font-weight-bold">
        {{ state.salesArticle.name }}
      </h1>
    </div>
    <span class="mt-2 border-top align-self-stretch" />
    <div class="d-flex justify-content-between mt-3 item-text">
      <div class="item-info">
        <p :style="{ fontSize: '2em' }">{{ state.salesArticle.price }} €</p>
        <p>Seller: {{ sellerName }}</p>
        <p>Phone: {{ state.salesArticle.user.phoneNumber }}</p>
      </div>
      <div
        class="text-muted item-secondary-info"
        :style="{ minWidth: '300px' }"
      >
        <p>
          Condition:
          {{ itemCondition(state.salesArticle.itemCondition) }}
        </p>
        <p>
          Item listed:
          {{ formatDate('DD MMM HH:mm', state.salesArticle.created) }}
        </p>
      </div>
    </div>
    <div v-if="isDescription" class="d-flex flex-column mt-5">
      <h2>Description</h2>
      <span class="mt-1 border-top align-self-stretch" />

      <p class="mt-3" :style="{ fontSize: '1.5em' }">
        {{ state.salesArticle.description }}
      </p>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';

import { getSaleArticle } from '@/services/salesarticles';

import { formatDate as formatDateHelper } from '@/utilities/dateHelpers';
import { conditionIntToString as conditionIntToStringHelper } from '@/utilities/miscHelpers';

import { SalesArticle } from '@/types/salesArticle';

interface ComponentState {
  salesArticle?: SalesArticle;
  selectedImageIndex: number;
}

export default Vue.extend({
  name: 'SalesArticleView',
  props: {
    id: {
      type: String,
      required: true
    }
  },
  data(): { state: ComponentState } {
    return {
      state: {
        salesArticle: undefined,
        selectedImageIndex: 0
      }
    };
  },
  computed: {
    imageData(): string {
      return `data:${
        this.state.salesArticle?.images[this.state.selectedImageIndex].type
      };base64,${
        this.state.salesArticle?.images[this.state.selectedImageIndex].data
      }`;
    },
    imagesAvailable(): boolean {
      return this.state.salesArticle?.images?.length ? true : false;
    },
    itemFetched(): boolean {
      return this.state.salesArticle !== undefined;
    },
    isDescription(): boolean {
      return this.state.salesArticle?.description ? true : false;
    },
    sellerName(): string {
      return `${this.state.salesArticle?.user.firstName} ${this.state.salesArticle?.user.lastName}`;
    }
  },
  async created() {
    this.state.salesArticle = await getSaleArticle(Number(this.id));
  },
  methods: {
    expandImage() {
      console.log('expand');
    },
    formatDate: formatDateHelper,
    getImageData(index: number): string {
      return `data:${this.state.salesArticle?.images[index].type};base64,${this.state.salesArticle?.images[index].data}`;
    },
    itemCondition: conditionIntToStringHelper,
    selectImage(index: number) {
      this.state.selectedImageIndex = index;
    }
  }
});
</script>

<style scoped>
img {
  object-fit: contain;
  max-width: 100%;
}

.selected-image {
  width: 700px;
  height: 500px;
}

h1,
p {
  word-break: break-all;
}

.item-info > p {
  font-weight: bold;
  font-size: 1.25em;
}

.thumbnail-image:hover {
  cursor: pointer;
  background-color: rgb(220, 220, 220);
}

.expand-badge:hover {
  cursor: pointer;
}

@media screen and (max-width: 575px) {
  .item-text,
  #main-content {
    flex-direction: column;
    align-items: flex-start;
  }

  .selected-image {
    width: auto;
    height: 300px;
  }

  .item-secondary-info {
    order: 1;
    text-align: left;
  }
  .item-info {
    order: 2;
  }
}
</style>
