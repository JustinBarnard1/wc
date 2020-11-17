<template>
  <div class="leaderboard container-fluid">
    <div class="row d-flex flex-coloumn">
      <h1 class="col mt-3 text-center">Rankings!</h1>
    </div>
    <div class="row my-3 d-flex flex-column justify-content-center">
      <participant-comp
        v-for="participant in participants"
        :key="participant.id"
        :participantProp="participant"
      />
    </div>
  </div>
</template>

<script>
import participantComp from "../components/participantComp";
export default {
  name: "leaderboard",
  data() {
    return {
      participantData: {},
    };
  },
  computed: {
    participants() {
      return this.$store.state.participants;
    },
    profile() {
      return this.$store.state.profile;
    },
  },
  components: {
    participantComp,
  },
  // mounted(){
  //     this.$store.dispatch("getParticipants");
  // }
};
</script>

<style>
/* .leaderboard{
    flex-grow: 1;
} */
</style>