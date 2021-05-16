<template>
  <v-app class="grey darken-4">
    <AppBar :user="user"></AppBar>
    <ModelsNavBar :modelData="models.resources" :loading="models.loading" />
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
      this.$store.dispatch('models/fetchModelList');
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
      } else if (mutation.type === 'models/MODELS_UPDATE') {
        this.models = this.$store.getters['models/getModels']
      }
    });

    return {
      user: undefined,
      models: this.$store.getters['models/getModels']
    };
  },
  beforeRouteUpdate(to,from, next) {
    const user = this.$store.getters['auth/state'];
    console.log('user: ', user);
    if (!user.isLoggedIn){
      next('/');
    } else if (!user.loginInfo.isAdmin) {
      next('/');
    } else {
      next();
    }
  }
};
</script>
