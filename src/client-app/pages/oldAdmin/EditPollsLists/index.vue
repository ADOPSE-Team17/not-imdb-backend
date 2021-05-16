<template>
    <div>
    <AppBarAdmin/>
    <div class="pa-16">
      <SearchAdmin :placeholder="this.placeholder"/>
    </div>
    <div class="pa-16" v-for="list in lists" :key="list.id">
      <ListsPollsEdit :title="list.title" :creators="list.creators"/>
    </div>
    
  </div>
</template>

<script>
import AppBarAdmin from '@/components/AppBarAdmin.vue'
import SearchAdmin from '@/components/SearchAdmin.vue'
import ListsPollsEdit from '@/components/ListsPollsEdit.vue'

export default {
    components:{
        AppBarAdmin,
        SearchAdmin,
        ListsPollsEdit
    },
    data(){
        return{
            placeholder:'search for any list or poll',
            lists:[
                {
                    id:1,
                    title:'title1',
                    creators:['username1','username2']
                },
                {
                    id:2,
                    title:'title2',
                    creators:['username1']
                },
                {
                    id:3,
                    title:'title3',
                    creators:['username1','username2','username3']
                },
                {
                    id:1,
                    title:'title4',
                    creators:['username1']
                },
           ]
        }
    }
}
</script>

<style>

</style>