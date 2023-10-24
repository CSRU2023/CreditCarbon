import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import LoginView from '../views/LoginView.vue'
import ContactView from '../views/ContactView.vue'
import EventView from '../views/EventView.vue'
import MemberView from '../views/MemberView.vue'
import UserView from '../views/UserView.vue'
import ProjectCarbonView from '../views/ProjectCarbonView.vue'
import ProjectCarbonDetail from '../components/ProjectCarbon/ProjectCarbonDetail.vue'
import MarketViewVue from '@/views/MarketView.vue'

import RegisPerson from '../components/ProjectCarbon/RegisPerson.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/home',
      name: 'home',
      component: HomeView
    },
    {
      path: '/about',
      name: 'about',
      component: () => import('../views/AboutView.vue')
    },
    { path: '/login', 
      name: 'login', 
      component: LoginView 
  },
    {
      path: '/contact',
      name: 'contact',
      component: ContactView
    },
    {
      path: '/event',
      name: 'event',
      component: EventView
    },
    {
      path: '/member',
      name: 'member',
      component: MemberView
    },
    {
      path: '/user',
      name: 'user',
      component: UserView
    },
    {
      path: '/project-carbon',
      name: 'project-carbon',
      component: ProjectCarbonView
    },
    {
      path: "/add-project-carbon",
      name: "add-project-carbon",
      component: () =>
      ProjectCarbonDetail,
      meta: { roles: [] },
    },
    {
      path: "/view-project-carbon/:projectCarbonId",
      name: "view-project-carbon",
      component: () =>
      ProjectCarbonDetail,
      meta: { roles: [] },
    },
    {
      path: "/edit-project-carbon/:projectCarbonId",
      name: "edit-project-carbon",
      component: () =>
      ProjectCarbonDetail,
      meta: { roles: [] },
    },
    {
      path: '/market',
      name: 'market',
      component: MarketViewVue
    },
    {
      path: "/regis",
      name: "resis",
      component: () =>
      RegisPerson,
      meta: { roles: [] },
    },
  ]
})

export default router
