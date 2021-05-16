<template>
  <v-card
    class="mx-auto my-12"
    max-width="374"
  >
    
    <nuxt-link :to="'Movie/' + id">
        <v-img
            height="250"
            src="https://cdn.vuetifyjs.com/images/cards/road.jpg"
        
        ></v-img>
    </nuxt-link>
    <v-card-title>{{Movietitle}}</v-card-title>

    <v-card-text
    
    >
        <v-row align="center">
            <v-col><div class="my-4 subtitle-1">{{year.substr(0,9)}}</div></v-col>
            <v-col><div>{{runtime}}'</div></v-col>
            <v-col>
                <v-rating
                    :value="rating"
                    color="amber"
                    dense
                    readonly
                    size="10"
                ></v-rating>
            </v-col>
        </v-row>
    </v-card-text>
  
  </v-card>
</template>

<script>
export default {
    name:'MovieCard',
    props: {
        year:{
            type:String,
        },
        runtime:{
            type:Number,
        },
        Movietitle:{
            type:String,
        },
        id:{
            type:Number
        },
        rating:{
            type:Number
        }
    },
    methods: {
        addToWatchlist(){
            console.log('add me to watchlist')
        },
        addRating(){
            alert('Let me rate this movie')
        },
        showInfo(){
            alert('show more information!')
        },
        openMovie(){
            alert('Show me this Movie!!!!!')
        }
    }
}
</script>

<style>

</style>
