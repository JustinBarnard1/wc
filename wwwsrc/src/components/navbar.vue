<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-primary">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center">
        <h1>WC</h1>
      </div>
    </router-link>
    <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#navbarText"
      aria-controls="navbarText"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <div class="d-flex justify-content-end">
        <router-link class="nav-link" :to="{ name: 'Profile' }">
          <span v-if="profile.name" class="text-dark">Profile</span>
        </router-link>
        <span class="navbar-text">
          <!-- Consider changing this to a profile picture -->
          <button
            class="btn btn-success"
            @click="login"
            v-if="!$auth.isAuthenticated"
          >
            Login
          </button>
          <button class="btn btn-danger" @click="logout" v-else>logout</button>
        </span>
      </div>
    </div>
  </nav>
</template>

<script>
import { getUserData } from "@bcwdev/auth0-vue";
import { setBearer, resetBearer } from "../services/AxiosService";
export default {
  name: "Navbar",
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
    async logout() {
      resetBearer();
      await this.$auth.logout({ returnTo: window.location.origin });
    },
  },
};
</script>

<style></style>
