<template>
  <div class="home m-4">
    <div class="row">
      <div class="col-12">
        <h3>
          Welcome To WC Where You Can Create Your Own Wellness Challenges And
          Share Them With Your Friends!
          <button type="button" class="btn btn-primary" @click="toDashboard">
            <!-- Change @click back to login -->
            Get Started
          </button>
        </h3>
      </div>
    </div>
    <img class="main-img mt-3" src="../assets/wellness.png" alt="" />
  </div>
</template>

<script>
import { getUserData } from "@bcwdev/auth0-vue";
import { setBearer, resetBearer } from "../services/AxiosService";
import router from "../router";
export default {
  name: "home",
  computed: {
    profile() {
      return this.$store.state.profile;
    },
  },
  methods: {
    async login() {
      await this.$auth.loginWithPopup();
      if (this.$auth.isAuthenticated) {
        setBearer(this.$auth.bearer);
        this.$store.dispatch("getProfile");
      }
    },
    toDashboard() {
      router.push({ name: "Dashboard" });
    },
  },
  watch: {
    profile: function (userProfile) {
      if (userProfile.name) {
        router.push({ name: "Dashboard" });
      } else {
        return;
      }
    },
  },
};
</script>
<style scoped>
.main-img {
  max-width: 90vw;
  max-height: 50vh;
}
</style>