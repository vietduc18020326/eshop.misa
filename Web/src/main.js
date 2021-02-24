import Vue from "vue";
import App from "./App.vue";
import Vuelidate from "vuelidate";
import VueSimpleAlert from "vue-simple-alert";
import Dialog from "vue-dialog-loading";

Vue.use(Dialog, {
  dialogBtnColor: "#0f0",
});

Vue.use(VueSimpleAlert);

Vue.use(Vuelidate);

Vue.config.productionTip = false;

new Vue({ render: (h) => h(App) }).$mount("#app");
