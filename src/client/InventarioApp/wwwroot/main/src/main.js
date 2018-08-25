// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'

// Element Ui
import Element from 'element-ui'
import locale from 'element-ui/lib/locale/lang/es'
import 'element-ui/lib/theme-chalk/index.css'
import VueCurrencyFilter from 'vue-currency-filter'

//import boostrap
import BootstrapVue from 'bootstrap-vue'

//import boostrap style
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

import VModal from 'vue-js-modal'
 
// App
import App from './App'

// Vue Router
import router from './router'

// Vuex: for services, shared components, etc
import store from './store/index'

// Our Style
import '../static/style.css'

// MomentJs for Vue
const moment = require('moment')
require('moment/locale/es')

Vue.use(require('vue-moment'), {
    moment
})

Vue.use(BootstrapVue);

Vue.config.productionTip = false

Vue.use(VModal,{ dynamic: true, injectModalsContainer: true })


Vue.use(Element, {
  locale
})

Vue.use(VueCurrencyFilter,
  {
    symbol : 'Q',
    thousandsSeparator: ',',
    fractionCount: 2,
    fractionSeparator: '.',
    symbolPosition: 'front',
    symbolSpacing: true
  })

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  store,
  template: '<App/>',
  components: {
    App
  }
})
