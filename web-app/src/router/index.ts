import Vue from 'vue';
import VueRouter, { RouteConfig } from 'vue-router';

import HomeView from '../views/HomeView.vue';

Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/about',
    name: 'about',
    component: () =>
      import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
  },
  {
    path: '/login',
    name: 'login',
    component: () =>
      import(/* webpackChunkName: "login" */ '../views/LoginView.vue')
  },
  {
    path: '/login/signup',
    name: 'signup',
    component: () =>
      import(
        /* webpackChunkName: "signup" */ '../components/loginview/SignUpForm.vue'
      )
  },
  {
    path: '/list-item',
    name: 'list-item',
    component: () =>
      import(/* webpackChunkName: "list-item" */ '../views/ListItemView.vue')
  }
];

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
});

export default router;
