<template>
 <div>
   <h2></h2>
   <v-row class="pa-8">
      <SearchMovies class="mx-auto" @click="fetchMovies"/>
    </v-row>
    <v-row class="pa-8">
      <CarouselList/>
    </v-row>
    <v-row class="pa-8">
      <CarouselList/>
    </v-row>
    <v-row class="pa-8">
      <CarouselList/>
    </v-row>
 </div>
</template>

<script>
import CarouselList from '@/components/CarouselList'
import SearchMovies from '@/components/SearchMovies'

export default {
  components: {
    CarouselList,
    SearchMovies
  },
  methods:{
    fetchMovies(){
      this.$store.dispatch('movies/fetchMovies')
    }
  }
}
</script>

<style>
h2{
  color: #fff;
  
}
</style>
