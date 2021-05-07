<template>
  <v-container
    fluid
    class="d-flex flex-row justify-space-between align-baseline flex-wrap"
  >
    <v-card
      class="d-flex flex-column align-center"
      dark
      max-width="45vh"
      min-width="12vw"
      href="https://www.imdb.com/"
    >
      <v-avatar tile size="100" class="mt-5">
        <img src="../../assets/imdb_logo.png" alt="imdb" />
      </v-avatar>
      <v-card-title>Imdb</v-card-title>
      <v-card-text class="text-center">
        8.6/10
      </v-card-text>
    </v-card>

    <v-card
      class="d-flex flex-column align-center"
      dark
      max-width="45vh"
      min-width="12vw"
      href="https://www.rottentomatoes.com/"
    >
      <v-avatar tile size="100" class="mt-5">
        <img
          src="../../assets/rotten_tomatoes_logo.png"
          alt="rotten-tomatoes"
        />
      </v-avatar>
      <v-card-title>Rotten Tomatoes</v-card-title>
      <v-card-text class="text-center">
        92%
      </v-card-text>
    </v-card>

    <v-card
      class="d-flex flex-column align-center"
      dark
      max-width="45vh"
      min-width="12vw"
      href="https://www.metacritic.com/"
    >
      <v-avatar tile size="100" class="mt-5">
        <img src="../../assets/metacritic_logo.png" alt="metacritic" />
      </v-avatar>
      <v-card-title>Metacritic</v-card-title>
      <v-card-text class="text-center">
        90/100
      </v-card-text>
    </v-card>
  </v-container>
</template>

<script>
export default {};
</script>

<style></style>
