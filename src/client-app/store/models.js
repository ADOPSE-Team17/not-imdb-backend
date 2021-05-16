import axios from 'axios';
const apiUrl = 'http://localhost:5000'

const defualtState = {
  models: {
    loading: true,
    error: undefined,
    resources: [],
    openForm: undefined
  }
};

const store = {
  state() {
    return {
      ...defualtState
    }
  },
  mutations: {
    MODELS_UPDATE(state, data) {
      state.models.resources = data && data.models ? data.models : [];
      state.models.loading = false;
      state.models.error = data && data.error ? data.error : undefined;
      
      return state;
    },
    MODEL_SAVE(state, data) {
      state.openForm = data;
    }
  },
  actions: {
    async fetchModelList({commit}) {
      try {
        const { data: models } = await axios.get(`${apiUrl}/assets/resources/list.json`);
        commit('MODELS_UPDATE', {
          models: models.resources,
          error: undefined
        });
      } catch(err) {
        console.warn(err);
        commit('MODELS_UPDATE', {
          models: [],
          error: err
        });
      }
    },
    async submitForm({commit}, data) {
      commit('MODEL_SAVE', data);
    }
  },
  getters: {
    getModels: (state) => state.models
  }
}


export default {
  namespaced: true,
  ...store
}