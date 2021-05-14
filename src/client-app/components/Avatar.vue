<template>
<div>
    <v-avatar>
      <img
        src="https://cdn.vuetifyjs.com/images/john.jpg"
        alt="John"
      >
      
    </v-avatar>
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
    }
}
</script>

<style>

</style>