<template>
  <div class="d-flex flex-column align-items-center">
    <SearchForm class="mt-5" />
    <span class="mt-4 border-top align-self-stretch" />
    <div v-if="apiDataFetched">
      <SalesArticle
        v-for="article in state.articles"
        :key="article.id"
        :item="article"
      />
    </div>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';

import SearchForm from '@/components/homeview/SearchForm.vue';
import SalesArticle from '@/components/homeview/SalesArticle.vue';

import { getAllSalesArticle } from '@/services/salesarticles';

import { SalesArticle as ISalesArticle } from '@/types/salesArticle';

interface ComponentState {
  articles: ISalesArticle[];
}

export default Vue.extend({
  name: 'HomeView',
  components: { SearchForm, SalesArticle },
  data(): { state: ComponentState } {
    return {
      state: {
        articles: []
      }
    };
  },
  computed: {
    apiDataFetched(): boolean {
      return this.state.articles.length > 0;
    }
  },
  async created() {
    this.state.articles = await getAllSalesArticle();
  }
});
</script>
