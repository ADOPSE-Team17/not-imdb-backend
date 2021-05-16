import axios from 'axios';
const apiUrl = 'http://localhost:5000'

const defualtState = {
  models: {
    loading: true,
    error: undefined,
    resources: []
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