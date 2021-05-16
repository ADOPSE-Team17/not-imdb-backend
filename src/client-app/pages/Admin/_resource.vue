<template>
  <div>
    <v-data-table
      :items="data"
      :loading="loading"
      :headers="headers"
      loading-text="Loading data"
      sort-by="id"
      class="elevation-1"
    >
      <template v-slot:top>
        <v-toolbar flat>
          <v-toolbar-title>{{ resource.title }}</v-toolbar-title>
          <v-divider class="mx-4" inset vertical></v-divider>
          <v-spacer></v-spacer>
          <v-dialog v-model="dialog" max-width="500px">
            <template v-slot:activator="{ on, attrs }">
              <v-btn color="primary" dark class="mb-2" v-bind="attrs" v-on="on">
                New Item
              </v-btn>
            </template>
            <v-card>
              <v-card-title>
                <span class="headline">{{ resource.title }}</span>
              </v-card-title>

              <v-card-text>
                <v-container>
                  <v-row> </v-row>
                </v-container>
              </v-card-text>

              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="blue darken-1" text @click="close">
                  Cancel
                </v-btn>
                <v-btn color="blue darken-1" text @click="save"> Save </v-btn>
              </v-card-actions>
            </v-card>
          </v-dialog>
          <v-dialog v-model="dialogDelete" max-width="500px">
            <v-card>
              <v-card-title class="headline"
                >Are you sure you want to delete this item?</v-card-title
              >
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="blue darken-1" text @click="closeDelete"
                  >Cancel</v-btn
                >
                <v-btn color="blue darken-1" text @click="deleteItemConfirm"
                  >OK</v-btn
                >
                <v-spacer></v-spacer>
              </v-card-actions>
            </v-card>
          </v-dialog>
        </v-toolbar>
      </template>
      <!-- <template v-slot:item.actions="{ item }">
        <v-icon small class="mr-2" @click="editItem(item)"> mdi-pencil </v-icon>
        <v-icon small @click="deleteItem(item)"> mdi-delete </v-icon>
      </template> -->
      <template v-slot:no-data>
        <v-btn color="primary" @click="initialize"> Reset </v-btn>
      </template>
    </v-data-table>
  </div>
</template>

<script>
import axios from "axios";

export default {
  layout: "admin",
  data() {
    return {
      resource: {
        title: undefined,
        model: undefined,
      },
      loading: true,
      error: false,
      data: [],
      headers: [],
      metadata: this.$store.getters["models/getModels"],
      dialogDelete: false,
      dialog: false
    };
  },
  methods: {
    async readModel(model) {
      this.loading = true;
      this.error = undefined;
      let headers;
      let data; 
      try {
        const rawData = (await axios.get(model)).data;
        let currentModel;
        
        this.metadata.resources.forEach((element) => {
          if (element.title === model) {
            currentModel = element;
          }
        });

        if (rawData.length > 0) {
          headers = currentModel.fields.map((field) => {
            return {
              text: field.label,
              value: Array.isArray(field.key) ? field.key.join("_") : field.key,
            };
          });

          data = rawData.map((entry) => {
            const currenctObject = {};
            currentModel.fields.forEach((field) => {
              if (Array.isArray(field.key) && field.key.length > 0) {
                let cValue = entry;
                let hasError = false;
                for (let i=0; i<field.key.length; i++) {
                  let cKey = field.key[i];
                  if (cValue.hasOwnProperty([cKey]) && cValue[cKey] !== undefined && cValue[cKey] !== null ) {
                      cValue = cValue[cKey];
                  } else {
                    hasError = true;
                    break;
                  }
                }

                Object.defineProperty(currenctObject, field.key.join('_'), {
                  value: hasError ? '' : cValue,
                  writable: true,
                });
              } else {
                Object.defineProperty(currenctObject, field.key, {
                  value: entry[field.key],
                  writable: true,
                });
              }
            });
            return currenctObject;
          });
        } else {
          this.data = [];
          this.headers = [];
        }

        this.resource.model = currentModel;
      } catch (err) {
        data = [];
        this.error = err;
        console.error(err);
      } finally {
        this.loading = false;
        this.data = data;
        this.headers = headers;
        this.resource.title = model;
      }
    },
    async save() {},
    async close() {},
    async deleteItemConfirm() {},
    async closeDelete() {},
    async initialize() {},
  },
  created() {
    this.readModel(this.$route.params.resource);
  },
};
</script>
