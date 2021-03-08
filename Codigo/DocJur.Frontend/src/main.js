import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import { BootstrapVue } from "bootstrap-vue";
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";
import VueSession from 'vue-session';
import Sidebar from './template/Sidebar';
import Navbar from './template/Navbar';
import CpfField from './components/CpfField';
import DateField from './components/DateField';
import TextField from './components/TextField';
import MoneyField from './components/MoneyField';
import YesNoField from './components/YesNoField';
import money from 'v-money'
import VueTheMask from 'vue-the-mask';

Vue.use(money)
Vue.use(VueTheMask);
Vue.use(BootstrapVue);
Vue.use(VueSession)
Vue.config.productionTip = false;
Vue.prototype.$apiHost = 'https://localhost:52000/';
Vue.prototype.$apiHeader = {'Content-Type': 'application/json'};

Vue.component('app-sidebar',Sidebar);
Vue.component('app-navbar',Navbar);
Vue.component('cpf-field', CpfField);
Vue.component('date-field', DateField); 
Vue.component('text-field', TextField);
Vue.component('money-field', MoneyField);
Vue.component('yesno-field', YesNoField);

new Vue({
    router,
    render: h => h(App)
}).$mount("#app");
