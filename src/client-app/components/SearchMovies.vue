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
    title:'SearchMovies',
    methods:{
        search(){
            alert('Find That Movie')
        },
        filters(){
            alert('show me the filters')
        }
    }
}
</script>

<style>

</style>