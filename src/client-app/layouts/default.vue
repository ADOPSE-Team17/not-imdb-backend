<template>
  <v-app class="grey darken-4">
    <v-app-bar fixed app class="amber lighten-2">
      <div class="ml-16">
        <router-link to="/">
          <Title />
        </router-link>
      </div>
      <v-skeleton-loader
        class="ml-auto d-flex"
        v-if="this.$store.getters['auth/state'].loading"
        type="avatar"
      >
      </v-skeleton-loader>
      <div
        class="ml-auto d-flex"
        v-if="!this.$store.getters['auth/state'].loading"
      >
        <Avatar
          v-show="this.user"
          v-if="this.user"
          :accountName="this.user.username"
        />
        <LinkButton
          v-show="!this.user"
          target="/Login"
          text="Login"
        ></LinkButton>
        <LinkButton
          v-show="!this.user"
          target="/Register"
          text="Register"
        ></LinkButton>
      </div>
    </v-app-bar>
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
import Title from "@/components/Title";
import Avatar from "@/components/Avatar";
import LinkButton from "@/components/LinkButton";

export default {
  components: {
    Title,
    Avatar,
    LinkButton,
    Avatar,
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
      } else if (mutation.type === 'auth/LOGOUT_USER') {
        this.user = undefined;
      }
    });
    return {
      user: undefined,
    };
  },
};
</script>
