<template>
<div>
    <v-text-field
        placeholder="Search anything"
        prepend-icon="mdi-magnify"
        prepend-inner-icon="mdi-view-headline"
        rounded
        filled
        dense
        @click:prepend="search"
        @click:prepend-inner="filters"
    >

    </v-text-field>


</div>
</template>

<script>
export default {
    name:'SearchMovies',
    methods:{
        search(){
            try {
                this.$store.dispatch('movies/fetchMovies')
                console.log(this.$store.getters['movies/getFetchedMovies'])   
            } catch (error) {
                
            }
            
        },
        filters(){
            alert('show me the filters')
        }
    }
}
</script>

<style>

</style>