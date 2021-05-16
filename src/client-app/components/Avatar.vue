<template>
  <div class="d-relative">
    <v-menu :offset-y="true" top>
      <template v-slot:activator="{ on, attrs }">
        <div v-bind="attrs" v-on="on">
          <v-avatar>
            <img src="https://cdn.vuetifyjs.com/images/john.jpg" />
          </v-avatar>
          <span>{{ accountName }}</span>
        </div>
      </template>
      <v-list>
        <v-list-item v-if="isAdmin">
          <v-list-item-title>
            <nuxt-link to="Admin"> Dashboard </nuxt-link>
          </v-list-item-title>
        </v-list-item>
        <v-list-item>
          <v-list-item-title>
            <nuxt-link to="ProfileEdit"> Profile </nuxt-link>
          </v-list-item-title>
        </v-list-item>
        <v-list-item
          v-on:click="
            () => {
              this.logout(this.$store);
            }
          "
        >
          <v-list-item-title> Logout </v-list-item-title>
        </v-list-item>
      </v-list>
    </v-menu>
  </div>
</template>

<script>
export default {
  name: "Avatar",
  props: ['accountName', 'isAdmin'],
  data: () => ({
    showMenu: false,
  }),
  methods: {
    logout: (store) => {
      store.dispatch("auth/logoutUser");
    },
  },
};
</script>
