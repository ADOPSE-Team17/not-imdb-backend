<template>
  <div>
    <AppBarAdmin/>
    <div class="pa-16">
      <SearchAdmin :placeholder="this.placeholder"/>
    </div>
    <div class="pa-16" v-for="(userEd,i) in userEdit" :key="i">
      <UserEdit :user="userEd.user" :comments="userEd.comments" :listsPolls="userEd.listsPolls"/>
    </div>
  </div>
</template>

<script>
import AppBarAdmin from '@/components/AppBarAdmin'
import SearchAdmin from '@/components/SearchAdmin'
import UserEdit from '@/components/UserEdit'

export default {
  components: {
    AppBarAdmin,
    SearchAdmin,
    UserEdit
  },
  data(){
    return{
      placeholder : 'search for specific users',
      userEdit:[
        {
          user:'user1',
          comments:['https://www.example.com/arch/boot','https://example.com/apparel/book.php','http://www.example.com/'],
          listsPolls:['https://www.example.com/arch/boot','https://example.com/apparel/book.php','http://www.example.com/']
        },
        {
          user:'user2',
          comments:['https://www.example.com/arch/boot','https://example.com/apparel/book.php','http://www.example.com/'],
          listsPolls:['https://www.example.com/arch/boot','https://example.com/apparel/book.php','http://www.example.com/']
        },
        {
          user:'user3',
          comments:['https://www.example.com/arch/boot','https://example.com/apparel/book.php','http://www.example.com/'],
          listsPolls:['https://www.example.com/arch/boot','https://example.com/apparel/book.php','http://www.example.com/']
        },
        {
          user:'user4',
          comments:['https://www.example.com/arch/boot','https://example.com/apparel/book.php','http://www.example.com/'],
          listsPolls:['https://www.example.com/arch/boot','https://example.com/apparel/book.php','http://www.example.com/']
        },
        {
          user:'user5',
          comments:['https://www.example.com/arch/boot','https://example.com/apparel/book.php','http://www.example.com/'],
          listsPolls:['https://www.example.com/arch/boot','https://example.com/apparel/book.php','http://www.example.com/']
        },
      ]
    }
  }
}
</script>
