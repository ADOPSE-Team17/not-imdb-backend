<template>
<div>
  <v-container fluid>
    <div class="d-flex flex-column align-center">
      <v-avatar class="mb-5">
        <img src="https://cdn.vuetifyjs.com/images/john.jpg" alt="John" />
      </v-avatar>

      <v-card max-width="40vw">
        <v-card-text>
          <h3>Username : {{}}</h3>
          <h3>Email : {{}}</h3>
          <h3>Birthday : {{}}</h3>
          <h3>Gender : {{}}</h3>
          <Address>
            The second street
          </Address>
          <h4>
            We have an enhanced ListView in android called RecyclerView. And
            here is Android RecyclerView and CardView Tutorial. It is
            recommended not to use ListView for large data sets. If you have a
            big List with custom UI components then you should use RecyclerView.
            RecyclerView is much more customizable than ListView and in terms of
            performance it is also very far ahead. So lets see how we use
            RecyclerView in our application. Below you can see a simple
            RecyclerView and this is actually what we will be building in this
            post.
          </h4>
        </v-card-text>

        <v-card-actions>
          <v-btn @click.stop="dialog = true">
            Edit
            <v-icon right>mdi-pencil</v-icon>
          </v-btn>
        </v-card-actions>
      </v-card>
    </div>
  </v-container>
  <v-row>
  <v-dialog max-width="100vh" v-model="dialog">
        <v-card>
          <v-form ref="form" v-model="valid" lazy-validation>
            <v-text-field
              v-model="name"
              :counter="10"
              :rules="nameRules"
              label="Name"
              required
            ></v-text-field>

            <v-text-field
              v-model="email"
              :rules="emailRules"
              label="E-mail"
              required
            ></v-text-field>

            <v-select
              v-model="select"
              :items="items"
              :rules="[v => !!v || 'Item is required']"
              label="Item"
              required
            ></v-select>

            <v-checkbox
              v-model="checkbox"
              :rules="[v => !!v || 'You must agree to continue!']"
              label="Do you agree?"
              required
            ></v-checkbox>

            <v-btn
              :disabled="!valid"
              color="success"
              class="mr-4"
              @click="validate"
            >
              Validate
            </v-btn>

            <v-btn color="error" class="mr-4" @click="reset">
              Reset Form
            </v-btn>

            <v-btn color="warning" @click="resetValidation">
              Reset Validation
            </v-btn>
          </v-form>
        </v-card>
      </v-dialog>
  </v-row>
      </div>
</template>

<script>
export default {
  data() {
    return {
      dialog: false
    };
  }
};
</script>

<style></style>
