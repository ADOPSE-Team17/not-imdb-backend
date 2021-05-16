<template>
  <FormulateForm v-model="values" :schema="schema" @submit="handleSubmit" />
</template>

<script>
import axios from "axios";

export default {
  name: "ModelForm",
  data() {
    axios
      .get(`/assets/forms/${this.model}/${this.action}.json`)
      .then(({ data }) => {
        const values = {};

        if (this.openModel) {
          this.schema.forEach((item) => {
            if (!Array.isArray(item.key)) {
              values[item.key] = this.openModel[item.key];
            }
          });
        }

        this.values = values;
        this.schema = data.schema;
        this.loading = false;
      })
      .catch((err) => {
        console.log("err: ", err);
      });

    // console.log("openModel: ", openModel);
    return {
      values: {},
      schema: [],
      loading: true,
    };
  },
  methods: {
    async handleSubmit(data) {
      if (this.action === "new") {
        await this.saveNew(this.model, data);
      } else if (this.action === "edit") {
        await this.saveUpdated(this.model, data);
      } else {
        console.error("Could not recognize action", this.action);
      }
    },
    async saveNew(model, data) {
      try {
        const response = await axios.post(`/${model}`, data);
        this.$store.dispatch("models/submitForm", response);
      } catch (err) {
        console.error(err);
      }
    },
    async saveUpdated(model, data) {
      try {
        const response = await axios.put(`/${model}`, data);
        this.$store.dispatch("models/submitForm", response);
      } catch (err) {
        console.error(err);
      }
    },
  },
  props: ["model", "action", "openModel"],
};
</script>