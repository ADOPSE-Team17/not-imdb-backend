<template>
  <v-app class="grey darken-4">
    <AppBar :user="user"></AppBar>
    <!-- The nuxt element is where the whole app takes place -->
    <v-main>
      <Nuxt />
    </v-main>
    <v-footer app>
      <span>&copy; {{ new Date().getFullYear() }}</span>
    </v-footer>
  </v-app>
</template>

<script>
import AppBar from "@/components/AppBar";

export default {
  components: {
    AppBar,
  },
  mounted() {
    try {
      this.$store.dispatch("auth/verifyUser");
    } catch (err) {
      console.warn(err);
    }
  },
  data() {
    this.$store.subscribe((mutation) => {
      if (mutation.type === "auth/LOGIN_USER") {
        this.user = mutation.payload.user;
      } else if (mutation.type === "auth/LOGOUT_USER") {
        this.user = undefined;
      }
    });
    return {
      user: undefined,
    };
  },
};
</script>
