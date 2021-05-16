<template>
  <div class="container">
    <v-navigation-drawer
      v-model="drawer"
      :mini-variant="miniVariant"
      :clipped="clipped"
      fixed
      app
    >
      <v-list v-if="loading">
        <v-skeleton-loader type="list-item"></v-skeleton-loader>
        <v-skeleton-loader type="list-item"></v-skeleton-loader>
        <v-skeleton-loader type="list-item"></v-skeleton-loader>
        <v-skeleton-loader type="list-item"></v-skeleton-loader>
        <v-skeleton-loader type="list-item"></v-skeleton-loader>
        <v-skeleton-loader type="list-item"></v-skeleton-loader>
        <v-skeleton-loader type="list-item"></v-skeleton-loader>
        <v-skeleton-loader type="list-item"></v-skeleton-loader>
      </v-list>
      <v-list v-if="!loading">
        <v-list-item
          v-for="(item, i) in generateList(modelData)"
          :key="i"
          :to="item.to"
          router
          exact
        >
          <v-list-item-action>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title v-text="item.title" />
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-app-bar :clipped-left="clipped" fixed app class="amber lighten-2">
      <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
      <div class="ml-16">
        <Title />
      </div>

      <v-spacer />
      <div>
        <Avatar v-show="loggedIn" />
      </div>
    </v-app-bar>
  </div>
</template>

<script>
import Title from "@/components/Title.vue";
import Avatar from "@/components/Avatar.vue";

export default {
  name: "ModelsNavBar",
  components: {
    Title,
    Avatar,
  },
  methods: {
    generateList(modelData) {
      if (!modelData) {
        return [];
      }
      const items = modelData.map((item) => ({
        icon: item.icon,
        title: item.label,
        to: `/Admin/${item.title}`,
      }));

      return items;
    },
  },
  data() {
    return {
      clipped: false,
      drawer: true,
      fixed: false,
      miniVariant: false,
      loggedIn: true,
    };
  },
  props: {
    modelData: {
      type: Array,
    },
    loading: {
      type: Boolean,
    },
  },
};
</script>
