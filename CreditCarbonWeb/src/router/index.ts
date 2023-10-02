import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import LoginView from '../views/LoginView.vue'
import ContactView from '../views/ContactView.vue'
import EventView from '../views/EventView.vue'
// import MemView from '../views/MemView.vue'

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
   {  path: '/login',
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
  // {
  //   path: '/mem',
  //   name:'mem',
  //   component: MemView
  // },


  ]
})

export default router