<template>
  <v-card elevation="5">
    <v-tabs dark>
      <v-tab href="#movie-details">
        Details
      </v-tab>
      <v-tab-item value="movie-details">
        <MovieDetails />
      </v-tab-item>

      <v-tab href="#movie-cast">
        Cast
      </v-tab>
      <v-tab-item value="movie-cast">
        <MovieCast />
      </v-tab-item>

      <v-tab href="#movie-reviews">
        Reviews
      </v-tab>
      <v-tab-item value="movie-reviews">
        <MovieReviews />
      </v-tab-item>

      <v-tab href="#movie-events">
        Events
      </v-tab>
      <v-tab-item value="movie-events">
        <MovieEvents />
      </v-tab-item>

      <v-tab href="#movie-merchandise">
        Merchandise
      </v-tab>
      <v-tab-item value="movie-merchandise">
        <MovieMerchandise />
      </v-tab-item>
    </v-tabs>
    <SignInUpPrompt />
  </v-card>
</template>

<script>
export default {};
</script>

<style>
h1 {
  color: black;
}
p {
  color: black;
}
</style>
