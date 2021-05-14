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
                    Title
                    </v-list-item-title>
                    <v-list-item-subtitle>Runtime ' Rating</v-list-item-subtitle>
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
            <v-toolbar-title >Movie Title</v-toolbar-title>
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
                v-for="action in actions"
                :key="action.id"
              >
                <v-icon>{{action.icon}}</v-icon>
                {{action.title}}
                
              </v-tab>
              <v-tab-item
               v-for="action in actions"
                        :key="action.id">
                    <v-card
                       
                    >
                        <v-card-text
                            v-for="(item,i) in action.items"
                            :key="i" 
                        >
                            <h3>{{item.title}}</h3>
                            <v-textarea
                                
                                :value="item.text"
                                full-width
                                single-line
                            ></v-textarea>
                        </v-card-text>
                    </v-card>
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


export default {
   data(){
        return {
            dialog:false,
            notifications:false,
            sound:true,
            widgets:true,
            actions:[
                {
                    id:1,
                    title:'Details',
                    icon:'mdi-details',
                    items:[
                        {
                            title:'Plot',
                            text:'rem ipsum dolor sit amet consectetur adipisicing elit. Perferendis illum suscipit, unde distinctio temporibus nulla nemo vitae commodi est ea, excepturi cumque alias sapiente, eos itaque iste. Recusandae, fugiat velit.'
                        },
                        {
                            title:'Trivia',
                            text:'rem ipsum dolor sit amet consectetur adipisicing elit. Perferendis illum suscipit, unde distinctio temporibus nulla nemo vitae commodi est ea, excepturi cumque alias sapiente, eos itaque iste. Recusandae, fugiat velit.'
                        },
                        {
                            title:'Date or Runtime',
                            text:'rem ipsum dolor sit amet consectetur adipisicing elit. Perferendis illum suscipit, unde distinctio temporibus nulla nemo vitae commodi est ea, excepturi cumque alias sapiente, eos itaque iste. Recusandae, fugiat velit.'
                        }
                    ]
                        
                },
                {
                    id:2,
                    title:'Awards',
                    icon:'mdi-trophy-award',
                    items:[
                        {title:'Award1'},
                        {title:'Award4'},
                        {title:'Award3'},
                        {title:'Award2'}]
                },
                {
                    id:4,
                    title:'Cast',
                    icon:'mdi-human-male',                    
                    items:[
                        {title:'Actor 1'},
                        {title:'Actor 6'},
                        {title:'Actor 2'},
                        {title:'Actor 3'},
                        {title:'Actor 4'},
                        {title:'Actor 5'}
                        ]
                }
            ]
        }
    }
}
</script>

<style>
</style>