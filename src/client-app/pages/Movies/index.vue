<template>
  <MovieCard :year="'1900'" :Movietitle="'Title'" :runtime="142"/>
</template>

<script>
import MovieCard from '@/components/MovieCard'
export default {
    components:{
        MovieCard
    },
    created(){
        console.log(this.$route.params.title)
    }

}
</script>

<style>

</style>