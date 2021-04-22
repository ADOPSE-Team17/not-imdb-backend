<template>
  <v-app
    class="theme--dark"
    >
        <v-app-bar
        fixed
        app
        class="amber lighten-2"
      >
      <div class="ml-16">
        <Title/>
      </div>
      
      
        <Avatar
          v-show="loggedIn"
        />
      
      
        <LoginButton
          v-show="!loggedIn"
        />
        
        <RegisterButton
          v-show="!loggedIn"
        />
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
import LoginButton from '@/components/LoginButton'
import RegisterButton from '@/components/RegisterButton'
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
