import Vue from "vue";
import VueRouter from "vue-router";
import Home from "../views/Home.vue";
import Login from "../views/Login.vue";
import Users from "../views/Users.vue";
import Documentos from "../views/Documentos.vue";
import ModelosDocumento from "../views/ModelosDocumento.vue";
import DocumentCreate from "../views/DocumentCreate.vue";

Vue.use(VueRouter);

const routes = [
  { path: "/", name: "Home", component: Home },
  { path: "/login", name: "Login", component: Login },
  { path: "/usuarios", name: "Usuarios", component: Users },
  { path: "/modelos_documento", name: "ModelosDocumento", component: ModelosDocumento },
  { path: "/documentos", name: "Documentos", component: Documentos },
  { path: "/document_create", name: "DocumentCreate", component: DocumentCreate },
  { path: '*', redirect: '/' }
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes
});

router.beforeEach((to,from,next) => {
  console.log(to.path);
  if (to.path != '/login' && !Vue.prototype.$session.exists()) {
    return next({
      path: '/login'
    });
  }

  next()
})

export default router;
