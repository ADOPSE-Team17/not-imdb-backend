<template>
 <div>
   <v-row class="pa-8">
      <SearchMovies class="mx-auto"/>
    </v-row>
    <v-row class="pa-8">
      <h2>|Headline 1</h2>
      <CarouselList/>
    </v-row>
    <v-row class="pa-8">
      <h2>|Headline 1</h2>
      <CarouselList/>
    </v-row>
    <v-row class="pa-8">
      <h2>|Headline 1</h2>
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
  }
}
</script>

<style>
h2{
  color: #fff;
  
}
</style>
