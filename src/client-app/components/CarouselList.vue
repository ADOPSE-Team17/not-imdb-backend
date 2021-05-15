<template>
  <v-carousel hide-delimiters width="350" v-if="moviesList">
    <h2>|Headline 1</h2>
    <v-carousel-item v-for="(sublist, i) in moviesList" :key="'movieList_' + i">
      <div class="d-flex">
        <MovieCard
          v-for="movie in sublist"
          :key="movie.id"
          :id="movie.id"
          :Movietitle="movie.headline"
          :year="movie.datePublished"
          :runtime="movie.duration"
        />
      </div>
    </v-carousel-item>
  </v-carousel>
</template>

<script>
import MovieCard from "@/components/MovieCard.vue";

export default {
  name: "CarouselList",
  components: {
    MovieCard,
  },
  methods: {
    formatData: (moviesList, maxItems) => {
      const groupedMovies = [];
      let chunk = [];
      if (moviesList && moviesList.length > 1) {
        for (let i = 0; i < moviesList.length; i++) {
          if (i !== 0 && i % maxItems === 0) {
            // when a set of 3 is completed
            groupedMovies.push(chunk);
            chunk = [];
          }
          chunk.push(moviesList[i]);
        }
        groupedMovies.push(chunk);
      }

      return groupedMovies;
    },
  },
  data() {
    const moviesList = this.$store.getters["movies/getFetchedMovies"];
    const maxItems = this.perSlide ? this.perSlide : 3;
    const groupedMovies = this.formatData(moviesList, maxItems);

    return {
      perSlide: maxItems,
      moviesList: groupedMovies,
    };
  },
  created() {
    this.$store.subscribe((mutation) => {
      if (mutation.type === "movies/getFetchedMovies" || mutation.type === 'movies/FETCH_MOVIES') {
        const moviesList = this.$store.getters["movies/getFetchedMovies"];
        const maxItems = this.perSlide ? this.perSlide : 3;
        const groupedMovies = this.formatData(moviesList, maxItems);
        this.moviesList = groupedMovies;
      }
    });
    this.$store.dispatch("movies/FETCH_MOVIES");
  },
};
</script>
