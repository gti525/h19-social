import Vue from 'vue'
import Router from 'vue-router'
import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import HelloWorld from '@/components/HelloWorld'
import Login from '@/components/Login'
import Register from '@/components/Register'
import Tickets from '@/components/Tickets'
import FriendRequests from '@/components/FriendRequests'

Vue.use(Router)
Vue.use(BootstrapVue);

export default new Router({
  routes: [
    {
      path: '/HelloWorld',
      name: 'HelloWorld',
      component: HelloWorld
    },
    {
      path: '/',
      name: 'Login',
      meta: { layout: "credentials"},
      component: Login
    },
    {
      path: '/register',
      name: 'Register',
      meta: { layout: "credentials"},
      component: Register
    },
    {
      path: '/tickets',
      name: 'Tickets',
      component: Tickets
    },
    {
      path: '/tickets/:id',
      name: 'FriendTickets',
      component: Tickets,
    },
    {
      path: '/friendRequests',
      name: 'FriendRequests',
      component: FriendRequests,
    }
  ]
})
