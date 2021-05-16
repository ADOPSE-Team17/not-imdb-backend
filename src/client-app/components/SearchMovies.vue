<template>
<div>
    
    <v-text-field
        placeholder="Search anything"
        prepend-icon="mdi-magnify"
        prepend-inner-icon="mdi-view-headline"
        rounded
        filled
        dense
        v-model="movieTitle"
        @click:prepend="search"
        @click:prepend-inner="filters"
        
    >
    
    </v-text-field>
     

</div>
</template>

<script>
export default {
    name:'SearchMovies',
    data(){
        return{
            movieTitle:'',
        }
    },
    props:{
        title:{
            type:String
        }
    },
    methods:{
        search(){
            this.$router.push({path: 'Movies', query:{search:encodeURI(`${this.movieTitle}`)}})
        },
        filters(){
            alert('show me the filters')
        }
    }
}
</script>

<style>

</style>