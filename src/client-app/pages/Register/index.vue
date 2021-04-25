<template>
  <div class="container">
      <RegisterCard :registerForm="register"/>
  </div>
</template>

<script>
import RegisterCard from '@/components/RegisterCard'
import { mapActions, mapMutations } from 'vuex'

export default {
    components: {
        RegisterCard
    },
    // computed:{
    //     info(){
    //         return this$store.state.auth.registerInfo
    //     }
    // },
    methods:{
        register(info){
            this.$store.dispatch('auth/registerUser',info)
        },
    }  
}
</script>

<style>

</style>