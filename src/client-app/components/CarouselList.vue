<template>
    <v-carousel 
        hide-delimiters
        cycle
        width="350"
    >
        <v-carousel-item
        v-for="(movie,i) in movies"
        :key="i"
        >
            <MovieCard
                :year="movie.year"
                :runtime="movie.runtime"
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
    data() {
        return{
            movies:[
                {
                    year:'1999',
                    runtime:'121 min'
                },
                {
                    year:'1998',
                    runtime:'121 min'
                },
                {
                    year:'1992',
                    runtime:'156 min'
                },
                {
                    year:'1919',
                    runtime:'129 min'
                },
                {
                    year:'1986',
                    runtime:'97 min'
                },
                {
                    year:'2000',
                    runtime:'179 min'
                },
                {
                    year:'2010',
                    runtime:'193 min'
                },
                {
                    year:'2020',
                    runtime:'110 min'
                },
            ],
        }
    },
    methods: {
        
    }
}
</script>

<style>

</style>