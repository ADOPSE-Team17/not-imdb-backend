<template>
  <div>
    <h3>Admin dashboard</h3>
  </div>
</template>

<script>
import AppBarAdmin from "@/components/AppBarAdmin";
import ModelsNavBar from '@/components/Models/ModelsNavBar';

export default {
  components: {
    AppBarAdmin,
    ModelsNavBar
  },
  layout: 'admin'
};
</script>
