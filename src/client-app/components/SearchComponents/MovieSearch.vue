<template>
  <v-row class="d-inline-flex">
    <v-btn @click.stop="dialog = true">
      <v-icon>
        mdi-tune
      </v-icon>
    </v-btn>
    <v-text-field outlined label="Search for a movie"></v-text-field>
    <v-btn>
      <v-icon>
        mdi-magnify
      </v-icon>
    </v-btn>
    <v-dialog v-model="dialog" max-width="100vh">
      <v-card>
        <search-filters />
      </v-card>
    </v-dialog>
  </v-row>
</template>

<script>
import SearchFilters from "./SearchFilters.vue";
export default {
  components: { SearchFilters },
  data() {
    return {
      dialog: false
    };
  }
};
</script>

<style></style>
