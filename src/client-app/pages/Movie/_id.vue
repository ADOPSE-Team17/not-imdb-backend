<template>
  <div class="pa-16">
    <v-sheet>
      <v-skeleton-loader
        v-if="!movie"
        class="mx-auto"
        max-width="400"
        type="card"
      ></v-skeleton-loader>
    </v-sheet>
    <Movie
      v-if="movie"
      :movieTitle="this.movie.headline"
      :about="this.movie.about"
      :abstract="this.movie.abstractText"
      :creator="this.movie.creator"
      :producer="this.movie.producer"
      :musicBy="this.movie.musicBy"
      :familyFriendly="this.movie.isFamilyFriendly"
      :trailer="this.movie.trailerUrl"
    />
  </div>
</template>

<script>
import Movie from "@/components/Movie.vue";

export default {
  components: {
    Movie,
  },
  data() {
    return { 
      movie: undefined
    };
  },
  methods: {},
  created() {
    this.$store.subscribe((mutation) => {
      if (mutation.type === "movies/FETCH_MOVIE_BY_ID") {
        this.movie = this.$store.getters["movies/getFetchedMovieById"];
      }
    });
    this.$store.dispatch("movies/fetchMovieById", this.$route.params.id);
  },
};
</script>
