<template>
  <div id="app">
    <navbar />
    <router-view />
  </div>
</template>


<script>
import Navbar from "@/components/navbar";
import { onAuth } from "@bcwdev/auth0-vue";
import { setBearer } from "./services/AxiosService";
export default {
  name: "App",
  async beforeCreate() {
    await onAuth();
    if (this.$auth.isAuthenticated) {
      setBearer(this.$auth.bearer);
      this.$store.dispatch("getProfile");
      //NOTE if you want to do something everytime the user logs in, do so here
      //ANCHOR Add timestamp to Profile on Login for Last Login/Last Online
    }
  },
  components: {
    Navbar,
  },
};
</script>
<style lang="scss">
@import "./assets/_variables.scss";
@import "bootstrap";
@import "./assets/_overrides.scss";
#app {
  display: flex;
  flex-direction: column;
  flex-grow: 1;
}
</style>
