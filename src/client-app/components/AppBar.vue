<template>
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
        :isAdmin="user.isAdmin"
      />
      <LinkButton v-show="!this.user" target="/Login" text="Login"></LinkButton>
      <LinkButton
        v-show="!this.user"
        target="/Register"
        text="Register"
      ></LinkButton>
    </div>
  </v-app-bar>
</template>
<script>
import Title from "@/components/Title";
import Avatar from "@/components/Avatar";
import LinkButton from "@/components/LinkButton";
export default {
  name: "AppBar",
  components: {
    Title,
    Avatar,
    LinkButton,
    Avatar,
  },
  props: [ 'user' ]
};
</script>