<template>
<div>
  <nuxt-link 
    v-if="!this.$store.getters['auth/isAdmin']"
    to="ProfileEdit"
  >
    <v-avatar>
      <img
        src="https://cdn.vuetifyjs.com/images/john.jpg"
      >
      
    </v-avatar>
  </nuxt-link>
  <nuxt-link 
    v-else
    to="Admin/EditProfile"
  >
    <v-avatar>
      <img
        src="https://cdn.vuetifyjs.com/images/john.jpg"
      >
      
    </v-avatar>
  </nuxt-link>
    <p>{{accountName}}</p>
    </div>
</template>

<script>
export default {
    name:'Avatar',
    props:{
      accountName:{
        type:String,
      }
    },
    methods:{
      ja(){
        console.log('sfdf')
      }
    }
}
</script>

<style>

</style>