import { createRouter, createWebHistory, type RouteLocationNormalized } from 'vue-router';
import HomeView from '@/views/index.vue';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/detalhes/:mapId',
      name: 'details',
      props(route: RouteLocationNormalized) {
        return {
          mapId: route.params.mapId
        };
      },
      component: () => import('@/views/details/index.vue')
    },
    {
      path: '/contribuir/:mapId',
      name: 'contribute',
      props(route: RouteLocationNormalized) {
        return {
          mapId: route.params.mapId
        };
      },
      component: () => import('@/views/contribute/index.vue')
    }
  ]
});

export default router;
