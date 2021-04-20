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
                        <nuxt-link to="./"> {{title}} </nuxt-link>
                    </v-list-item-title>
                    <v-list-item-content>
                        
                        Date Created <br> 
                        
                        Created By : 
                          <nuxt-link v-for="(creator,i) in creators" :key="i" to="./EditPollsLists">{{creator}}</nuxt-link></v-list-item-content>
                        
                    </v-list-item-content>

                <v-card-actions>
                <v-btn
                    outlined
                    rounded
                    text
                    @click="dialog = true"
                    class="red accent-3"
                >
                    DELETE
                </v-btn>
                </v-card-actions>
                </v-list-item>

               
            </v-card>
      </v-row>
      
  </div>
</template>

<script>


export default {
   name:'ListsPollsEdit',
   props:{
       title:{
           type:String,
           required:true
       },
       creators:{
           type:Array,
           required:true
       }
   }
}
</script>

<style>
</style>