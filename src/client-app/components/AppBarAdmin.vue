<template>
<div class="container">
  <v-navigation-drawer
      v-model="drawer"
      :mini-variant="miniVariant"
      :clipped="clipped"
      fixed
      app
      
    >
      <v-list>
        <v-list-item
          v-for="(item, i) in items"
          :key="i"
          :to="item.to"
          router
          exact
        >
          <v-list-item-action>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title v-text="item.title" />
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-app-bar
        :clipped-left="clipped"
        fixed
        app
        class="amber lighten-2"
    >
      <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
      <div class="ml-16">
        <Title/>
      </div>
      
      <v-spacer />
      <div>
        <Avatar
          v-show="loggedIn"
        />
      </div>
    </v-app-bar>
</div>
</template>

<script>
import Title from '@/components/Title.vue'
import  Avatar  from '@/components/Avatar.vue';


export default {
    title:'AppBarAdmin',
    components: { 
      Title,
      Avatar,
      },
    data(){
        return {
            clipped: false,
            drawer: false,
            fixed: false,
            miniVariant: false,
            items: [
                {
                    icon: 'mdi-account-circle',
                    title: 'Profile',
                    to: '/Admin/EditProfile'
                },
                {
                    icon: 'mdi-video-vintage',
                    title: 'Movies',
                    to: '/Admin/EditMovies'
                },
                {
                    icon: 'mdi-folder-account',
                    title: 'Users',
                    to: '/Admin/EditUsers'
                },
                {
                    icon: 'mdi-comment',
                    title: 'Comments',
                    to: '/Admin/EditComments'
                },
                {
                    icon: 'mdi-chart-box',
                    title: 'Polls and Lists',
                    to: '/Admin/EditPollsLists'
                },
                {
                    icon: 'mdi-human-male-height',
                    title: 'Actors',
                    to: '/Admin/EditActors'
                },
            ],
            loggedIn:true
        }
    }

}
</script>

<style>

</style>