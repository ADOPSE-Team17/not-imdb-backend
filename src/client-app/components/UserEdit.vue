<template>
   <div >
      <v-row>
          <v-card
                class="mx-auto"
                max-width="344"
                outlined
            >
                <v-list-item two-line>
                <v-list-item-content>
                    
                    <v-list-item-title class="headline mb-1">
                    <Avatar/>
                    </v-list-item-title>
                    <v-list-item-subtitle>{{user}}</v-list-item-subtitle>
                </v-list-item-content>

                <v-card-actions>
                <v-btn
                    outlined
                    rounded
                    text
                    @click="dialog = true"
                    class="red accent-3"
                >
                    Modify
                </v-btn>
                </v-card-actions>
                </v-list-item>

               
            </v-card>
      </v-row>
      <v-dialog
        v-model="dialog"
        fullscreen
        hide-overlay
        transition="dialog-bottom-transition"
        scrollable
      >
        <v-card tile>
          <v-toolbar
            flat
            dark
            class="amber lighten-2"
          >
            <v-btn
              icon
              dark
              @click="dialog = false"
            >
              <v-icon>mdi-close</v-icon>
            </v-btn>
            <v-toolbar-title >{{user}}</v-toolbar-title>
            <v-spacer></v-spacer>
            <v-toolbar-items>
              <v-btn
                dark
                text
                @click="dialog = false"
              >
                Save
              </v-btn>
            </v-toolbar-items>
          </v-toolbar>
          <v-tabs>
              <v-tab
                v-for="(action,i) in actions"
                :key="i"
              >
                <v-icon>{{action.icon}}</v-icon>
                {{action.type}}
                
              </v-tab>
              <v-tab-item 
                v-for="(action,i) in actions"
                :key="i"
              >
                    <v-list
                        v-if="action.type === 'Comment'"
                    >
                        <v-list-item>
                            <v-list-item-title >
                              <p v-for="(comment,j) in comments" :key="j">
                                Comment {{j+1}} : <nuxt-link to="./EditUsers">{{comment}}</nuxt-link>  <v-btn class="red accent-3">DELETE</v-btn>
                              </p>
                            </v-list-item-title>
                        </v-list-item>
                    </v-list>
                    <v-list v-else>
                        <v-list-item >
                            <v-list-item-title>
                              <p v-for="(list,j) in listsPolls" :key="j">
                                Lists/Polls {{j+1}} : <nuxt-link to="./EditUsers">{{list}}</nuxt-link> <v-btn class="red accent-3">DELETE</v-btn>
                              </p>
                            </v-list-item-title>
                        </v-list-item>
                    </v-list>
                </v-tab-item>
                <v-tab>
                    <v-icon>mdi-delete</v-icon>
                    DELETE USER
                </v-tab>
                <v-tab-item>
                        
                    
                    <v-btn
                        depressed
                        color="red accent-3"
                        class="deleteUserButton"
                    >
                        DELETE USER
                    </v-btn>
                    
                </v-tab-item>
                
          </v-tabs>
            <v-card-text>
            </v-card-text>
          <div style="flex: 1 1 auto;"></div>
        </v-card>
      </v-dialog>
  </div>
</template>

<script>
import Avatar from './Avatar'

export default {
  components:{
    Avatar
  },
  name:'UserEdit',
  props:{
    comments:{
      type:Array,
      required:true
    },
    listsPolls:{
      type:Array,
      required:true
    },
    user:{
      type:String,
      required:true
    }
  },
    data(){
        return {
            dialog:false,
            notifications:false,
            sound:true,
            widgets:true,
            actions:[
              {
                type:'Comment',
                icon:'mdi-comment'
              },
              {
                type:'List/Poll',
                icon:'mdi-list'
              }
            ]
        }
    },
      
}
</script>

<style>

</style>