<template>
  <v-card max-width="25vw" shaped>
    <v-img
      max-height="30vh"
      src="https://cdn.vuetifyjs.com/images/cards/cooking.png"
      @click="openMovie"
    ></v-img>

    <v-card-title class="justify-left">{{ title }}</v-card-title>

    <v-card-text class="text-center">
      <v-row>
        <v-col
          ><div>{{ year }}</div></v-col
        >
        <v-col
          ><div>{{ runtime }}</div></v-col
        >
        <v-col>
          <v-rating
            :value="4.5"
            color="amber"
            dense
            readonly
            size="25"
          ></v-rating>
        </v-col>
      </v-row>
      <v-row>
        <v-col>
          <v-btn fab small color="primary" @click="addRating"
            ><v-icon dark>mdi-star</v-icon></v-btn
          >
        </v-col>
        <v-col>
          <v-btn fab small color="primary" @click="addToWatchlist"
            ><v-icon dark>mdi-plus</v-icon></v-btn
          >
        </v-col>
        <v-col>
          <v-btn fab small color="primary" @click="showInfo"
            ><v-icon dark>mdi-information</v-icon></v-btn
          >
        </v-col>
      </v-row>
    </v-card-text>
  </v-card>
</template>

<script>
export default {
  name: "MovieCard",
  props: {
    title: {
      type: String,
      required: true
    },
    year: {
      type: String,
      required: true
    },
    runtime: {
      type: String,
      required: true
    }
  },
  methods: {
    addToWatchlist() {
      alert("add me to watchlist");
    },
    addRating() {
      alert("Let me rate this movie");
    },
    showInfo() {
      alert("show more information!");
    },
    openMovie() {
      alert("Show me this Movie!!!!!");
    }
  }
};
</script>

<style></style>
