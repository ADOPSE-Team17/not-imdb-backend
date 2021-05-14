<template>
   <v-card
        class="mx-auto grey darken-3"
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
                        class="pa-16 white--text"
                        label="username/email"
                        v-model="loginInfo.identifier"
                    ></v-text-field> 
                </v-row>
                <v-row
                align="center"
                class="mx-0"
                >
                    <v-text-field
                        class="pa-16 input-group--focused white--text"
                        label="Password"
                        hint="At least 8 characters"
                        v-model="loginInfo.password"
                        :append-icon="show ? 'mdi-eye' : 'mdi-eye-off'"
                        :type="show ? 'text' : 'password'"
                        error
                        @click:append="show = !show"
                    ></v-text-field>
                </v-row>
                <v-row
                align="center"
                class="mt-8"
                >
                <v-col>
                    <nuxt-link
                        to="/"
                    >
                        <v-btn
                        class="ma-8"
                        color="black white--text"
                        @click="loginForm(loginInfo)"
                        >
                        Log In
                        </v-btn>
                    </nuxt-link>
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
            show : false,
            loginInfo:{
                identifier:'',
                password:''
            }
        }
    },
    props:{
        loginForm:{
            type:Function,
            required:true
        }
    }
}
</script>

<style>

</style>