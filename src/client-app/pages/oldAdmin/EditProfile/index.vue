<template>
  <div>
    <AppBarAdmin/>
    <div class="pa-16">
    <ProfileEdit/>
    </div>
  </div>
</template>

<script>
import AppBarAdmin from '@/components/AppBarAdmin'
import ProfileEdit from '@/components/ProfileEdit'

export default {
  components: {
    AppBarAdmin,
    ProfileEdit,
  }
}
</script>
