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
                        v-model="registerInfo.username"
                    ></v-text-field> 
                </v-row>
                <v-row
                align="center"
                class="mx-0"
                >
                    <v-text-field
                        class="pa-16 white--text"
                        label="Email"
                        v-model="registerInfo.email"
                    ></v-text-field> 
                </v-row>
                <v-row
                align="center"
                class="mx-0"
                >
                    <v-text-field
                        class="pa-16 white--text"
                        v-model="registerInfo.password"
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
                        v-model="registerInfo.passwordRepeat"
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
                    @click="registerForm(registerInfo)"
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
            registerInfo:{
                username:'aaaaaaa',
                email:'test@mail.com',
                password:'12345678',
                passwordRepeat:'12345678'
            }
        }
    },
    props:{
        registerForm:{
            type:Function,
            required:true
        }
    }
}
</script>

<style>

</style>