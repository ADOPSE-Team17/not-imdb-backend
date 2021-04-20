<template>
  <v-card
    class="mx-auto my-12"
    max-width="374"
  >
  
  <v-img
      height="250"
      src="https://cdn.vuetifyjs.com/images/cards/cooking.png"
      @click="openMovie"
    ></v-img>

    <v-card-title>Title</v-card-title>

    <v-card-text
    
    >
        <v-row align="center">
            <v-col><div class="my-4 subtitle-1">{{year}}</div></v-col>
            <v-col><div>{{runtime}}</div></v-col>
            <v-col>
                <v-rating
                    :value="4.5"
                    color="amber"
                    dense
                    readonly
                    size="10"
                ></v-rating>
            </v-col>
        </v-row>
        <v-row>
            <v-col>
                <v-btn 
                    class="mx-2"
                    fab
                    small
                    color="primary"
                    @click="addRating" 
                ><v-icon dark>mdi-star</v-icon></v-btn>
            </v-col>
            <v-col>
                <v-btn 
                    class="mx-2"
                    fab
                    small
                    color="primary" 
                    @click="addToWatchlist"
                ><v-icon dark>mdi-plus</v-icon></v-btn>
            </v-col>
            <v-col>
                <v-btn 
                    class="mx-2"
                    fab
                    small
                    color="primary"
                    @click="showInfo" 
                ><v-icon dark>mdi-information</v-icon></v-btn>
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
            required:true
        },
        runtime:{
            type:String,
            required:true
        },
    },
    methods: {
        addToWatchlist(){
            alert('add me to watchlist')
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