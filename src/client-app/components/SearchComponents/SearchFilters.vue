<template>
  <v-container fluid>
    <v-card dark>
      <v-card-title>
        Select filters
      </v-card-title>
      <v-autocomplete
        label="Genres"
        v-model="values"
        :items="items"
        chips
        clearable
        deletable-chips
        multiple
        solo
      ></v-autocomplete>
      <v-combobox 
        label="Rating"
        v-model="select"
        :items="items"
        clearable 
        filled 
        hide-selected 
        solo></v-combobox>
        <v-range-slider
        label="Time period"
            thumb-label="true"
            thumb-color="black"
            step="5"
            max="2021"
            min="1900"
        ></v-range-slider>

      <v-card-actions>
          <v-btn>
              Confirm
          </v-btn>
          <v-btn>
              Search
          </v-btn>
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script>
export default {
  data: () => ({
    items: ["foo", "bar", "fizz", "buzz"],
    value: null
  })
};
</script>

<style></style>
