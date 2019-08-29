import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import keeps from './Components/Keeps.vue'
// @ts-ignore
import vaults from './Components/Vaults.vue'
// @ts-ignore
import createKeep from './Components/CreateKeepComponent.vue'
// @ts-ignore
import createVault from './Components/CreateVaultComponent.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/keeps',
      name: 'keeps',
      component: keeps
    },
    {
      path: '/vaults',
      name: 'vaults',
      component: vaults
    },
    {
      path: '/createfindr',
      name: 'createKeep',
      component: createKeep
    },
    {
      path: '/createKeepr',
      name: 'createVault',
      component: createVault
    },
    {
      path: "*",
      redirect: '/'
    }
  ]
})
