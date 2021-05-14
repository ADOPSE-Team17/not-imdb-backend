<template>
    <v-carousel 
        hide-delimiters
        width="350"
    >
    <h2>|Headline 1</h2>
        <v-carousel-item
        v-for="(movie,i) in this.$store.getters['movies/getFetchedMovies']"
        :key="movie.id"
        >
            <MovieCard v-show="i<19"
                :Movietitle="movie.headline"
                :year="movie.datePublished"
                :runtime="movie.duration"
            />
        </v-carousel-item>
    </v-carousel>
</template>

<script>
import MovieCard from '@/components/MovieCard.vue'


export default {
    name:'CarouselList',
    components: {
        MovieCard,
    },
    
    
    
}
</script>

<style>

</style>