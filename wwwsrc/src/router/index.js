import Vue from "vue";
import VueRouter from "vue-router";
// @ts-ignore
import Home from "../pages/Home.vue";
import Dashboard from "../pages/Dashboard.vue"
import Leaderboard from "../pages/Leaderboard.vue"

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/dashboard",
    name: "Dashboard",
    component: Dashboard,
  },
  {
    path: "/leaderboard",
    name: "Leaderboard",
    component: Leaderboard,
  }
];

const router = new VueRouter({
  routes,
});

export default router;
