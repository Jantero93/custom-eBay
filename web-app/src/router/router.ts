import Vue from 'vue';
import VueRouter, { RouteConfig } from 'vue-router';

import store from '@/store/store';

import { isLoggingExpired } from '@/utilities/localStorageHelpers';

Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'home',
    component: () =>
      import(/* webpackChunkName: "home" */ '@/views/HomeView.vue'),
    alias: '/articles'
  },
  {
    path: '/login',
    name: 'login',
    component: () =>
      import(/* webpackChunkName: "login" */ '@/views/LoginView.vue')
  },
  {
    path: '/login/signup',
    name: 'signup',
    component: () =>
      import(
        /* webpackChunkName: "signup" */ '@/components/loginview/SignUpForm.vue'
      )
  },
  {
    path: '/list-item',
    name: 'list-item',
    meta: {
      requiresAuth: true
    },
    component: () =>
      import(/* webpackChunkName: "list-item" */ '@/views/ListItemView.vue')
  },
  {
    path: '/articles/:id',
    name: 'article',
    props: true,
    component: () =>
      import(/* webpackChunkName: "item" */ '@/views/SalesArticleView.vue')
  }
];

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
});

router.beforeEach((to, _from, next) => {
  // Clear local storage if user has been logged over hour
  isLoggingExpired() && store.commit('clearLoggingInfo');

  // Route requires auth; Redirect to login if not logged in
  const pathRequiresLogin = to.matched.some((route) => route.meta.requiresAuth);
  pathRequiresLogin && !store.getters.isLogged && next({ name: 'login' });

  next();
});

export default router;
