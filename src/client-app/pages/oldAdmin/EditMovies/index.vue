<template>
  <div>
    <AppBarAdmin />
    <div class="pa-16">
      <SearchAdmin :placeholder="this.placeholder" />
    </div>
    <div class="pa-8">
      <MovieEdit />
    </div>
    <div class="pa-8">
      <MovieEdit />
    </div>
    <div class="pa-8">
      <MovieEdit />
    </div>
  </div>
</template>

<script>
import AppBarAdmin from "@/components/AppBarAdmin";
import SearchAdmin from "@/components/SearchAdmin";
import MovieEdit from "@/components/MovieEdit";

export default {
  components: {
    AppBarAdmin,
    MovieEdit,
    SearchAdmin,
  },
  data() {
    return {
      placeholder: "search for a movie to modify",
    };
  },
};
</script>
