<template>
  <div class="container">
    <LoginCard :loginForm="loginUser" />
  </div>
</template>

<script>
import LoginCard from "@/components/LoginCard.vue";

export default {
  components: {
    LoginCard,
  },
  methods: {
    loginUser(info) {
      try {
        this.$store.dispatch("auth/loginUser", info);
      } catch (error) {
        console.log(error);
      }
    },
  }
};
</script>

<style>
.custom-loader {
  animation: loader 1s infinite;
  display: flex;
}
@-moz-keyframes loader {
  from {
    transform: rotate(0);
  }
  to {
    transform: rotate(360deg);
  }
}
@-webkit-keyframes loader {
  from {
    transform: rotate(0);
  }
  to {
    transform: rotate(360deg);
  }
}
@-o-keyframes loader {
  from {
    transform: rotate(0);
  }
  to {
    transform: rotate(360deg);
  }
}
@keyframes loader {
  from {
    transform: rotate(0);
  }
  to {
    transform: rotate(360deg);
  }
}
</style>
