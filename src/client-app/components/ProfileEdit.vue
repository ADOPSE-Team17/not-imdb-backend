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
    <v-card-actions>
        <v-list-item v-if="dialog">
          <v-list-item-content>
            <v-list-item-title>{{item}}</v-list-item-title>
          <v-list-item-subtitle>{{item}} here</v-list-item-subtitle>
        </v-list-item-content>
    </v-list-item>
    </v-card-actions>
  </v-card>
  </div>
</template>
<script>

  export default {
      data(){
        return{
            dialog : false,
            item:'Watchlist',
            selectedItem: 0,
            items: [
                { text: 'Watchlist', icon: 'mdi-view-list' },
                { text: 'Profile Picture', icon: 'mdi-image' },
                { text: 'Polls & Lists', icon: 'mdi-chart-box' },
                {text: 'Favourites',icon:'mdi-heart'}
            ],
        }
      },
      methods:{
        showDialog(itemText){
          this.dialog = true
          this.item = itemText
          // console.log(this.item)
        }
      },
      props:{
        account:{
          type:Object
        },
        watchlist:{
          type:Array
        }
      }
     
  }
</script>