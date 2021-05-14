<template>
  <ProfileEdit
    :account="this.$store.getters['auth/account']"
  />
</template>

<script>
import ProfileEdit from '@/components/ProfileEdit'

export default {
    components:{
        ProfileEdit
    },
    created(){
        console.log(this.$store.getters['auth/account'])
    }
}
</script>

<style>

</style>