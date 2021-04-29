<template>
  <v-card>
    <v-form>
      <v-row align="center">
        <v-text-field class="pa-16 white--text" label="username"></v-text-field>
      </v-row>
      <v-row align="center">
        <v-text-field
          class="pa-16 input-group--focused white--text"
          label="Password"
          hint="At least 8 characters"
          :append-icon="show ? 'mdi-eye' : 'mdi-eye-off'"
          :type="show ? 'text' : 'password'"
          error
          @click:append="show = !show"
        ></v-text-field>
      </v-row>
      <v-row align="center" class="mt-8">
        <v-col>
          <v-btn class="ma-8" color="black white--text">
            Log In
          </v-btn>
        </v-col>
        <v-col>
          <v-btn class="ma-8" color="black white--text">
            Use SSO
          </v-btn>
        </v-col>
      </v-row>
      <v-row align="center" class="mt-8"> </v-row>
    </v-form>
  </v-card>
</template>

<script>
export default {
  data() {
    return {
      show: false
    };
  }
};
</script>

<style></style>
