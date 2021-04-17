<template>
   <v-card
        class="mx-auto my-12"
        max-width="500"
      >
        <v-card-title>Login</v-card-title>
        <v-card-text>
            <v-form>
                <v-row
                align="center"
                class="mx-0"
                >
                    <v-text-field
                        class="pa-16"
                        label="username"
                    ></v-text-field> 
                </v-row>
                <v-row
                align="center"
                class="mx-0"
                >
                    <v-text-field
                        class="pa-16"
                        :append-icon="show ? 'mdi-eye' : 'mdi-eye-off'"
                        :rules="[rules.required, rules.emailMatch]"
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
                class="mt-8"
                >
                <v-col>
                    <v-btn
                    class="ma-8"
                    :loading="loading"
                    :disabled="loading"
                    color="blue"
                    @click="loader = 'loading'"
                    >
                    Log In
                    </v-btn>
                </v-col>
                <v-col>
                    <v-btn
                    class="ma-8"
                    :loading="loading"
                    :disabled="loading"
                    color="blue"
                    @click="loader = 'loading'"
                    >
                    Use SSO
                    </v-btn>
                </v-col>
                </v-row>
                <v-row
                align="center"
                class="mt-8"
                >
                    <nuxt-link to="/Register">Not Registered? Sign Up here</nuxt-link>
                </v-row>
            </v-form>
        </v-card-text>
      </v-card>
</template>

<script>
export default {
    name:'LoginCard',
    data(){
        return{
            show:false,
            rules: {
            required: value => !!value || 'Required.',
            min: v => v.length >= 8 || 'Min 8 characters',
            emailMatch: () => (`The email and password you entered don't match`),
            },
        }
    },
    watch: {
      loader () {
        const l = this.loader
        this[l] = !this[l]

        setTimeout(() => (this[l] = false), 3000)

        this.loader = null
      },
    },
}
</script>

<style>

</style>