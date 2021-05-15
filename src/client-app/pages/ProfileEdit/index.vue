<template>
  <ProfileEdit
    :account="this.$store.getters['auth/account']"
    :watchlist="this.$store.getters['movies/getWatchlist']"
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