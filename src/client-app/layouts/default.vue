<template>
  <v-app
    class="grey darken-4"
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
          v-show="this.$store.getters['auth/loggedInUser']"
          :accountName="this.$store.getters['auth/accountName']"
        />
        <LinkButton v-show="!this.$store.getters['auth/loggedInUser']" target="/Login" text="Login" ></LinkButton>
        <LinkButton v-show="!this.$store.getters['auth/loggedInUser']" target="/Register" text="Register" ></LinkButton>
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
import {mapGetters} from 'vuex'

export default {
  components: {
    Title,
    Avatar,
    LinkButton,
  },
   
}
</script>
