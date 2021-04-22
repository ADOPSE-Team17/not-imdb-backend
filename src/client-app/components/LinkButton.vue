<template>
  <v-col justify="center" align="center">
    <router-link :to="target" class="black white--text">
      <v-btn> {{ text }} </v-btn>
    </router-link>
  </v-col>
</template>

<script>
export default {
  name: "LinkButton",
  props: {
    text: {
      type: String,
    },
    target: {
      text: {
        type: String,
      },
    },
  },
};
</script>
