<template>
  <div>
    <!-- <AppBarAdmin /> -->
    <!-- <ModelsNavBar :modelData="models.resources" :loading="models.loading" /> -->
    <h3>New admin 2</h3>
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
  // data() {
  //   return {
  //     models: this.$store.getters['models/getModels']
  //   }
  // },
  // created() {
  //   this.$store.subscribe(mutation => {
  //     if (mutation.type === 'models/MODELS_UPDATE') {
  //       this.models = this.$store.getters['models/getModels']
  //     }
  //   });
  //   this.$store.dispatch('models/fetchModelList');
  // }
};
</script>
