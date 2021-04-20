<template>
  <div>
    <AppBarAdmin/>
    <div class="pa-16">
      <SearchAdmin :placeholder="this.placeholder"/>
    </div>
    <div class="pa-16" v-for="comment in comments" :key="comment.id">
      <CommentEdit :url="comment.url" :commenter="comment.commenter"/>
    </div>
  </div>
</template>

<script>
import AppBarAdmin from '@/components/AppBarAdmin'
import SearchAdmin from '@/components/SearchAdmin'
import CommentEdit from '@/components/CommentEdit'

export default {
  components: {
    AppBarAdmin,
    SearchAdmin,
    CommentEdit
  },
  data(){
    return{
      placeholder:'search for a movies comments',
      comments:[
        {
          id:1,
          url:'https://example.com/battle/ants.php',
          commenter:'user1' 
        },
        {
          id:2,
          url:'https://www.example.com/arch/boot',
          commenter:'user2' 
        },
        {
          id:3,
          url:'https://example.com/apparel/book.php',
          commenter:'user3' 
        },
        {
          id:4,
          url:'https://example.com/beef',
          commenter:'user4' 
        },
        {
          id:5,
          url:'https://balance.example.com',
          commenter:'user5' 
        },
      ]
     
    }
  },
  
}
</script>
