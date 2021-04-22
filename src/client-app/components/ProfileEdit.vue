<template>
<div>
    <v-card
    class="mx-auto"
    max-width="500"
    max-height="500"
    outlined
  >
   
    <v-card-title> 
        USERNAME
    </v-card-title>
    <v-card-text>
        <v-list>
        <v-list-item>
          <v-list-item-avatar>
            <v-img src="https://cdn.vuetifyjs.com/images/john.png"></v-img>
          </v-list-item-avatar>
        </v-list-item>

        <v-list-item link>
          <v-list-item-content>
            <v-list-item-title class="title">
              John Leider
            </v-list-item-title>
            <v-list-item-subtitle>john@vuetifyjs.com</v-list-item-subtitle>
          </v-list-item-content>
        </v-list-item>
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
          >
            <v-list-item-icon>
              <v-icon v-text="item.icon"></v-icon>
            </v-list-item-icon>

            <v-list-item-content>
              <v-list-item-title v-text="item.text"></v-list-item-title>
            </v-list-item-content>
          </v-list-item>
        </v-list-item-group>
      </v-list>
    </v-card-text>
    <v-card-actions>
               
    </v-card-actions>
  </v-card>
  </div>
</template>
<script>

  export default {
      data(){
        return{
            selectedItem: 0,
            items: [
                { text: 'Watchlist', icon: 'mdi-view-list' },
                { text: 'Profile Picture', icon: 'mdi-image' },
                { text: 'Polls & Lists', icon: 'mdi-chart-box' },
                { text: 'Username', icon: 'mdi-human-male' },
                { text: 'Password', icon: 'mdi-lock' },
            ],
        }
      }
  }
</script>