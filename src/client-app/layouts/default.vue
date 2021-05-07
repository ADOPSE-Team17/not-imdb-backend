<template>
  <v-app
    dark
    >
        <v-app-bar
        fixed
        app
        class="amber lighten-2"
      >
      <div class="ml-16">
        <router-link to="/">
          <Title/>
        </router-link>
      </div>
      <div class="ml-auto d-flex">
        <Avatar
          v-show="loggedIn"
        />
        <LinkButton v-show="!loggedIn" target="/Login" text="Login" ></LinkButton>
        <LinkButton v-show="!loggedIn" target="/Register" text="Register" ></LinkButton>
      </div>
    </v-app-bar>
        <!-- The nuxt element is where the whole app takes place -->
        <v-main>
         
          <Nuxt />
          
        </v-main>
        <v-footer
      app
    >
      <span>&copy; {{ new Date().getFullYear() }}</span>
    </v-footer>
  </v-app>
</template>

<script>
import Title from '@/components/Title'
import Avatar from '@/components/Avatar'
import LinkButton from '@/components/LinkButton'

export default {
  components: {
    Title,
    Avatar,
    LoginButton,
    RegisterButton
  },
  data(){
    return {
      loggedIn:false
    }
  },
}
</script>
