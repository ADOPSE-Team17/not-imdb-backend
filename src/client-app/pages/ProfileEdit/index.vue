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
    
}
</script>

<style>

</style>