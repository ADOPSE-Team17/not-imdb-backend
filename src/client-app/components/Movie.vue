<template>
  <v-card
    class="mx-auto"
    max-width="400"
  >
    <v-img
      class="white--text align-end"
      height="200px"
      src="https://cdn.vuetifyjs.com/images/cards/docks.jpg"
    >
      <v-card-title>{{movieTitle}}</v-card-title>
    </v-img>


    <v-card-text class="text--primary">
        <v-list-item v-if="familyFriendly">
            <v-list-item-content>
                <v-list-item-title>Rated : PG</v-list-item-title>
            </v-list-item-content>
        </v-list-item>
        <v-list-item v-else>
            <v-list-item-content>
                <v-list-item-title>Rated X</v-list-item-title>
            </v-list-item-content>
        </v-list-item>
        <v-list-item v-if="abstract">
            <v-list-item-content>
                <v-list-item-title>Abstract</v-list-item-title>
                <v-list-item-subtitle>{{abstract}}</v-list-item-subtitle>
            </v-list-item-content>
        </v-list-item>
        <v-list-item v-if="about">
            <v-list-item-content>
                <v-list-item-title>Plot</v-list-item-title>
                <p>{{about}}</p>
            </v-list-item-content>
        </v-list-item>
        <v-list-item v-if="creator">
            <v-list-item-content>
                <v-list-item-title>Created by {{creator || ''}}</v-list-item-title>
            </v-list-item-content>
        </v-list-item>
        <v-list-item>
            <v-list-item-content v-if="producer">
                <v-list-item-title>Produced by {{producer}}</v-list-item-title>
            </v-list-item-content>
        </v-list-item>
        <v-list-item>
            <v-list-item-content v-if="musicBy">
                <v-list-item-title>Soundtrack made by {{musicBy}}</v-list-item-title>
            </v-list-item-content>
        </v-list-item>
        
    </v-card-text>

    <v-card-actions>
        <v-col>
            <v-chip 
                draggable class="ml-16"
            >
                See trailer
            </v-chip>
            </v-col>
            <v-icon @click="ja">mdi-star</v-icon>
            <small>Add to Watchlist</small>
    </v-card-actions>
  </v-card>
</template>

<script>
export default {
    props:{
        movieTitle:{
            type:String,
            
        },
        about:{
            type:String,
            
        },
        abstract:{
            type:String,
            
        },
        creator:{
            type:String,
            
        },
        producer:{
            type:String,
            
        },
        musicBy:{
            type:String,
            
        },
        familyFriendly:{
            type:Boolean,
            
        },
        trailer:{
            type:String,
            
        }
    },
    data(){
        return{
            movie : this.$store.getters['movies/getFetchedMovieById']
        }
    },
    methods:{
        ja(){
            this.$store.dispatch('movies/addToWatchlist',this.movie)
        }
    }

}
</script>

<style>

</style>