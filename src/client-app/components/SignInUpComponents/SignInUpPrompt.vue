<template>
  <v-row>
    <v-btn dark @click.stop="dialog = true">
      Sign In | Register
    </v-btn>

    <v-dialog v-model="dialog" max-width="100vh">
      <v-card>
        <v-tabs dark>
          <v-tab href="#sign-in">
            Sign In
          </v-tab>
          <v-tab-item value="sign-in">
            <SignInComponent />
          </v-tab-item>
          <v-tab href="#register">
            Register
          </v-tab>
          <v-tab-item value="register">
            <register-component/>
          </v-tab-item>
        </v-tabs>
      </v-card>
    </v-dialog>
  </v-row>
</template>

<script>
import RegisterComponent from './RegisterComponent.vue';
export default {
  components: { RegisterComponent },
  data() {
    return {
      dialog: false
    };
  }
};
</script>

<style></style>
