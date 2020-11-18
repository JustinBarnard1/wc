<template>
  <div class="dashboard mt-2 container">
    <div class="row">
      <div class="col-6 d-flex justify-content-center">
        <h5 class="text-center">Day's Left</h5>
      </div>
      <div class="col-6 d-flex justify-content-center">
        <h5 class="text-center">My Score</h5>
      </div>
    </div>
    <div id="row-height" class="row">
      <div
        class="col-6 m-circle d-flex justify-content-center align-items-center"
      >
        <h1 class="text-center">15</h1>
      </div>
      <div
        class="col-6 m-circle d-flex justify-content-center align-items-center"
      >
        <h1 class="text-center">36</h1>
      </div>
    </div>
    <div id="row-height" class="row my-3">
      <div
        class="col-6 m-circle d-flex justify-content-center align-items-center"
      >
        <h6 @click="toLeaderboard" class="text-center">Leaderboard</h6>
      </div>
      <div
        class="col-6 m-circle d-flex justify-content-center align-items-center"
      >
        <h6 class="text-center">Log Points</h6>
      </div>
    </div>
    <div id="row-height" class="row my-3">
      <div
        class="col-6 m-circle d-flex justify-content-center align-items-center"
      >
        <h6 class="text-center">Join Challenge</h6>
      </div>
      <div
        class="col-6 m-circle d-flex justify-content-center align-items-center"
      >
        <h6 class="text-center">Create Challenge</h6>
      </div>
    </div>
  </div>
</template>

<script>
import router from "../router";
export default {
  methods: {
    toLeaderboard() {
      router.push({ name: "Leaderboard" });
    },
  },
};
</script>

<style>
.m-circle {
  background-image: url(../assets/circle.png);
  background-position: center center;
  background-size: contain;
  background-repeat: no-repeat;
}
#row-height {
  height: 22vh;
}
</style>