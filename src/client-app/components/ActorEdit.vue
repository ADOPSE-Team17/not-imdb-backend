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
                    <v-list-item-subtitle>First Name ' Last Name</v-list-item-subtitle>
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
            <v-toolbar-title >Actor Name</v-toolbar-title>
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
                {{action.title}}
                
              </v-tab>
              <v-tab-item
               v-for="action in actions"
                        :key="action.id">
                    <v-card
                       
                    >
                        <v-card-text
                            v-for="(par,i) in action.par"
                            :key="i"
                        >
                            {{par}}
                            
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
import Avatar from '@/components/Avatar'

export default {
    components:{
        Avatar
    },
   data(){
        return {
            dialog:false,
            notifications:false,
            sound:true,
            widgets:true,
            actions:[
                {
                    id:1,
                    title:'BIO',
                    name:'Name Name',
                    par:[`Lorem ipsum dolor sit amet consectetur adipisicing elit. Non dolorem, quam consequuntur eum voluptatibus doloribus
                    Lorem ipsum dolor sit amet consectetur adipisicing elit. Non dolorem, quam consequuntur eum voluptatibus doloribus
                    Lorem ipsum dolor sit amet consectetur adipisicing elit. Non dolorem, quam consequuntur eum voluptatibus doloribus`],
                    Awards:[]
                },
                {
                    id:2,
                    title:'Movies',
                    par:['Title1','Title2','Title3','Title4']
                },
                {
                    id:3,
                    title:'Fun Facts',
                    par:['fact 1','fact 5','fact 4','fact 3','fact 2']
                }   
            ]
        }
    }
}
</script>

<style>
</style>