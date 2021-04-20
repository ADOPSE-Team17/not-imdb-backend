<template>
  <v-card
        class="mx-auto grey darken-3"
        max-width="500"
      >
        <v-card-title>Register</v-card-title>
        <v-card-text>
            <v-form>
                <v-row
                align="center"
                class="mx-0"
                >
                    <v-text-field
                        class="pa-16 white--text"
                        label="username"
                    ></v-text-field> 
                </v-row>
                <v-row
                align="center"
                class="mx-0"
                >
                    <v-text-field
                        class="pa-16 white--text"
                        label="Email"
                    ></v-text-field> 
                </v-row>
                <v-row
                align="center"
                class="mx-0"
                >
                    <v-text-field
                        class="pa-16 white--text"
                        :append-icon="show ? 'mdi-eye' : 'mdi-eye-off'"
                        :type="show ? 'text' : 'password'"
                        name="input-10-2"
                        label="Password"
                        hint="At least 8 characters"
                        error
                        @click:append="show = !show"
                    ></v-text-field>
                </v-row>
                <v-row
                align="center"
                class="mx-0">
                    <v-text-field
                        class="pa-16 white--text"
                        :append-icon="show ? 'mdi-eye' : 'mdi-eye-off'"
                        :type="show ? 'text' : 'password'"
                        name="input-10-2"
                        label="Confirm Password"
                        hint="At least 8 characters"
                        error
                        @click:append="show = !show"
                    ></v-text-field>
                </v-row>
                <v-row
                align="center"
                class="mt-8"
                >
                <v-col>
                    <v-btn
                    class="ma-8"
                    color="black white--text"
                    >
                    Sign me Up!
                    </v-btn>
                </v-col>
                <v-col>
                    <v-btn
                    class="ma-8"
                    color="black white--text"
                    >
                    Use SSO
                    </v-btn>
                </v-col>
                </v-row>
            </v-form>
        </v-card-text>
      </v-card>
</template>

<script>
export default {
    name:'RegisterCard',
  data(){
        return{
            show:false,
        }
    },
}
</script>

<style>

</style>