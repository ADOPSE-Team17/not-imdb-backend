<template>
<div>
    <v-card
    class="mx-auto"
    max-width="500"
    max-height="500"
    outlined
  >
   
   
    <v-card-text>
        <v-list>
        <v-list-item>
          <v-list-item-avatar>
            <v-img src="https://cdn.vuetifyjs.com/images/john.jpg"></v-img>
          </v-list-item-avatar>
        </v-list-item>
 <v-card-title> 
        {{account.identifier}}
    </v-card-title>
       
      </v-list>
      <v-divider></v-divider>
      <v-list
        nav
        dense
      >
        <v-list-item-group
          v-model="selectedItem"
          color="primary"
        >
          <v-list-item
            v-for="(item, i) in items"
            :key="i"
            @click="showDialog(item.text)"
          >
            <v-list-item-icon>
              <v-icon v-text="item.icon"></v-icon>
            </v-list-item-icon>

            <v-list-item-content>
              <v-list-item-title  v-text="item.text">
              </v-list-item-title>
            </v-list-item-content>
          </v-list-item>
        </v-list-item-group>
      </v-list>
    </v-card-text>
  </v-card>
  <v-list-item v-if="this.showWatch">
          <v-list-item-content >
            <v-card
              class="mx-auto"
              max-width="344"
              outlined
            >
              <v-list-item three-line>
                <v-list-item-content>
                  <div class="overline mb-4">
                     {{account.identifier}}'s Watchlist
                  </div>
                  <div v-for="object in this.watchlist" :key="object.id">
                  <v-list-item-title class="headline mb-1">
                    Movie title:{{object.headline}}
                  </v-list-item-title>
                  <v-list-item-subtitle>
                    Movie ID : {{object.id}}
                  </v-list-item-subtitle>
                  </div>
                </v-list-item-content>
              </v-list-item>
            </v-card>
        </v-list-item-content>
    </v-list-item>
  <v-list-item v-if="this.showPolls">
          <v-list-item-content>
            <v-card
              class="mx-auto"
              max-width="344"
              outlined
            >
              <v-list-item three-line>
                <v-list-item-content>
                  <div class="overline mb-4">
                    {{account.identifier}}'s List
                  </div>
                  <div v-for="object in this.$store.getters['movies/getLists']" :key="object.id">
                    <v-list-item-title v-if="object.abstractText"  class="headline mb-1">
                      <nuxt-link :to="'Movie/' + object.id">{{object.headline}}</nuxt-link>
                    </v-list-item-title>
                    <v-list-item-subtitle v-if="object.abstractText">{{object.abstractText}}</v-list-item-subtitle>
                  </div>
                </v-list-item-content>
              </v-list-item>
            </v-card>
        </v-list-item-content>
    </v-list-item>
    <v-list-item v-if="this.showGames">
          <v-list-item-content>
            <v-card
              class="mx-auto"
              max-width="344"
              outlined
            >
              <v-list-item three-line>
                <v-list-item-content>
                  <div class="overline mb-4">
                    {{account.identifier}}'s Games
                  </div>
                  <div v-for="object in this.$store.getters['movies/getGames']" :key="object.id">
                    <v-list-item-title class="headline mb-1">
                      {{object.title}}
                    </v-list-item-title>
                    <v-list-item-subtitle>Answers: {{object.optionSet}}</v-list-item-subtitle>
                    <p>from {{object.startDate.substr(0,9)}} to {{object.endDate.substr(0,9)}}</p>
                  </div>
                </v-list-item-content>
              </v-list-item>
            </v-card>
        </v-list-item-content>
    </v-list-item>
  </div>
</template>
<script>

  export default {
      data(){
        return{
            showWatch : false,
            showPolls: false,
            showGames : false,
            watchlist : [],
            games:[],
            item:'Watchlist',
            selectedItem: 0,
            items: [
                { text: 'Watchlist', icon: 'mdi-view-list' },
                { text: 'Polls & Lists', icon: 'mdi-chart-box' },
                {text: 'Games',icon:'mdi-gamepad'}
            ],
        }
      },
      created(){
        this.$store.dispatch('movies/fetchWatchlist')
        this.watchlist = this.$store.getters['movies/getWatchlist']
        this.$store.dispatch('movies/fetchGames')
        // console.log(this.$store.getters['movies/getGames'])
        this.$store.dispatch('movies/fetchLists')
      },
      methods:{
        showDialog(itemText){
          switch(itemText){
            case 'Watchlist':
              this.showWatch = true
              this.showPolls = false
              this.showGames = false
              // console.log(this.watchlist)
              break
            case 'Polls & Lists':
              this.showWatch = false
              this.showPolls = true
              this.showGames = false
              // console.log(this.games)
              break
            case 'Games':
              this.showWatch = false
              this.showPolls = false
              this.showGames = true
          }
        },
      },
      props:{
        account:{
          type:Object
        },
      }
    }
</script>