<template>
  <div class="d-flex flex-column">
    <SearchForm class="mt-5" />
    <span class="mt-3 border-top align-self-stretch" />

    <div v-if="apiDataFetched" class="d-flex flex-column align-baseline mb-3">
      <SalesArticle
        v-for="article in state.articles"
        :key="article.id"
        class="w-100 mt-3"
        :item="article"
      />
    </div>

    <b-pagination-nav
      v-if="multiplePages"
      align="fill"
      class="pagination-nav"
      :link-gen="generateLink"
      :number-of-pages="state.totalPages"
      use-router
      size="md"
      @change="fetchNewPage"
    />
  </div>
</template>

<script lang="ts">
import Vue from 'vue';

import SalesArticle from '@/components/homeview/SalesArticleListItem.vue';
import SearchForm from '@/components/homeview/SearchForm.vue';

import { getSalesArticlesByPage } from '@/services/salesarticles';

import { ApiSalesArticle, Pager } from '@/types/api';

interface ComponentState {
  articles: ApiSalesArticle[];
  currentPage: number;
  totalPages: number;
  hasNextPage: boolean;
  hasPreviousPage: boolean;
}

export default Vue.extend({
  name: 'HomeView',
  components: { SearchForm, SalesArticle },
  data(): { state: ComponentState } {
    return {
      state: {
        articles: [],
        currentPage: 1,
        totalPages: 0,
        hasNextPage: false,
        hasPreviousPage: false
      }
    };
  },

  computed: {
    apiDataFetched(): boolean {
      return this.state.articles.length > 0;
    },
    multiplePages(): boolean {
      return this.state.totalPages > 1;
    }
  },
  watch: {
    // Fetch first page data if for example ebay 'home icon' is pressed
    // eslint-disable-next-line @typescript-eslint/no-unused-vars
    async $route(to, _from) {
      to.path === '/' &&
        this.setStateFromApiCall(await getSalesArticlesByPage(1));
    }
  },
  async created() {
    this.setStateFromApiCall(await getSalesArticlesByPage(1));
  },
  methods: {
    async fetchNewPage(pageNum: number) {
      this.setStateFromApiCall(await getSalesArticlesByPage(pageNum));
    },
    generateLink(pageNum: number): string {
      // Do not generate link on the first page
      return pageNum === 1 ? '/' : `/articles?page=${pageNum}`;
    },
    setStateFromApiCall(pager: Pager<ApiSalesArticle>) {
      const { items, currentPage, totalPages, hasNextPage, hasPreviousPage } =
        pager;

      this.state.articles = items;
      this.state.currentPage = currentPage;
      this.state.totalPages = totalPages;
      this.state.hasNextPage = hasNextPage;
      this.state.hasPreviousPage = hasPreviousPage;
    }
  }
});
</script>
