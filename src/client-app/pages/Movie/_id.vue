<template>
  <div class="pa-16">
      <small>ID : {{this.$route.params.id}}</small>
      <Movie
        :movieTitle="this.movie.headline"
        :about="this.movie.about"
        :abstract="this.movie.abstractText"
        :creator="this.movie.creator"
        :producer="this.movie.producer"
        :musicBy="this.movie.musicBy"
        :familyFriendly="this.movie.isFamilyFriendly"
        :trailer="this.movie.trailerUrl"
      />
  </div>
</template>

<script>
import Movie from '@/components/Movie.vue'

export default {
  components:{
      Movie
  },
  data(){
      return{
          movie : this.$store.getters['movies/getFetchedMovieById']
      }
  },
  methods:{
  
  },
  created(){
    this.$store.dispatch('movies/fetchMovieById',this.$route.params.id)
  },
  updated(){
    this.$store.dispatch('movies/fetchMovieById',this.$route.params.id).then((data) => {
  console.log(data);
}).catch((err) => {
console.error(err);
});
  },
  watch:{
    $route (to, from){
        console.log(to,from)
       this.$store.dispatch('movies/fetchMovieById',this.$route.params.id)
    }
    }

}

</script>

<style>
