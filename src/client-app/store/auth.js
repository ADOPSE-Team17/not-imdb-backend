import axios from 'axios'


export default{
    namespaced: true,
    state(){
        return{
            registerInfo: {},
            loginInfo:{
                identifier:'',
                password:''
            },
            loggedIn:false,
            isAdmin:false
        }
    },
    mutations: {
        REGISTER_USER(state, info) {
            state.registerInfo = info
            state.loggedIn = true
        },
        LOGIN_USER(state,info,admin){
            state.loginInfo = info 
            state.loggedIn = true
            // console.log(state.loggedIn)
            if (admin){
                state.isAdmin = true
            }
        }
    },
    actions: {
        async registerUser({ commit }, info) {
            const data = {
                "username": info.username,
                "email": info.email,
                "password": info.password,
                "passwordRepeat": info.passwordRepeat
            }
            try {
                const res = await axios.post('http://localhost:5000/Auth/Register',data)
                // console.log(res)
                commit('REGISTER_USER',info )
            } catch (error) {
                console.log(error)
            }
        },

        async loginUser({commit},info){
            const data = {
                "identifier" : info.identifier,
                "password" : info.password
            }

            try {
                const res = await axios.post('http://localhost:5000/Auth/Login',data)
                // console.log(res.data)
                commit('LOGIN_USER',info,res.data.isAdmin)
            } catch (error) {
                console.log(error)
            }
        }
    },

    getters: {
       loggedInUser:(state) => {
           return state.loggedIn
       },
       account:(state) => {
           return state.loginInfo
       },
       accountName:(state) => {
           return state.loginInfo.identifier
       }
    }
}