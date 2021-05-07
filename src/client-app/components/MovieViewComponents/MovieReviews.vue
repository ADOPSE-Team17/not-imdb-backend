<template>
  <v-container fluid>
    <v-card>
      <v-card-title>
        <v-avatar>
          <img src="https://cdn.vuetifyjs.com/images/john.jpg" alt="John" />
        </v-avatar>
        Joe Dough
      </v-card-title>
      <v-card-text>
        Unicode, Dammit guesses correctly most of the time, but sometimes it
        
      </v-card-text>
      <v-card-actions>
        <v-btn icon color="deep-orange">
          <v-icon>mdi-thumb-up</v-icon>
        </v-btn>
        <v-btn icon color="deep-orange">
          <v-icon>mdi-thumb-down</v-icon>
        </v-btn>
      </v-card-actions>
    </v-card>
    <v-btn>
      Add a Review
      <v-icon right>mdi-pencil</v-icon>
    </v-btn>
  </v-container>
</template>

<script>
export default {};
</script>

<style></style>
