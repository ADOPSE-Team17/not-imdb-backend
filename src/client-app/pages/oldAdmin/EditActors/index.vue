<template>
  <div>
    <AppBarAdmin/>
    <div class="pa-16">
      <SearchAdmin :placeholder="this.placeholder"/>
    </div>
    <div class="pa-8">
      <ActorEdit/>
    </div>
    <div class="pa-8">
      <ActorEdit/>
    </div>
    <div class="pa-8">
      <ActorEdit/>
    </div>
  </div>
</template>

<script>
import AppBarAdmin from '@/components/AppBarAdmin'
import SearchAdmin from '@/components/SearchAdmin'
import ActorEdit from '@/components/ActorEdit'

export default {
  components: {
    AppBarAdmin,
    SearchAdmin,
    ActorEdit
  },
  data(){
    return{
      placeholder:'search for an actor to modify'
    }
  }
}
</script>
