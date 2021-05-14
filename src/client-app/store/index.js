import Vue from 'vue'
import Vuex from 'vuex'
import authModule from './auth'

Vue.use(Vuex)

export const store = new Vuex.Store({
    state() {
        return { counter: 0 }
    },
    actions:{},
    mutations:{},
    getters:{},
    modules:{
        auth:authModule
    },
})

    

    








