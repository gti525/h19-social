// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import VueResource from 'vue-resource'

import Default from './layouts/Default.vue'
import Credentials from './layouts/Credentials.vue'
import Empty from './layouts/Empty.vue'

Vue.component('default-layout', Default);
Vue.component('credentials-layout', Credentials);
Vue.component('empty-layout', Empty)


Vue.use(VueResource);
Vue.config.productionTip = false

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  components: { App },
  template: '<App/>',
})
