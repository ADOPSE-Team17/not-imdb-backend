import axios from 'axios';

export default {
    namespaced: true,
    state() {
        return {
            registerInfo: {},
            loginInfo: {
                identifier: '',
                password: ''
            },
            loggedIn: false,
            isAdmin: false,
            loading: true,
            hasError: false
        }
    },
    mutations: {
        REGISTER_USER(state, info) {
            state.registerInfo = info
            state.loggedIn = true
            state.loading = false;
        },
        LOGIN_USER(state, info) {
            state.loginInfo = info.user
            state.loggedIn = true
            state.loading = false;

            if (window && info.token) {
                window.localStorage.setItem('token', info.token);
            }

            if (info.isAdmin) {
                state.isAdmin = true
            }
            console.log('it should log');
            return this.info;
        },
        LOGOUT_USER(state) {
            state.loading = false;
            state.isAdmin = false;
            state.hasError = false;
            state.loggedIn = false;
            state.loginInfo = undefined;
            state.registerInfo = undefined;
            if (window) {
                window.localStorage.removeItem('token');
                window.location = "/";
            }
        },
        LOGIN_FAIL(state, info) {
            state.loading =false;
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
                const res = await axios.post('http://localhost:5000/Auth/Register', data)
                commit('REGISTER_USER', info)
            } catch (error) {
                console.error(error)
            }
        },

        async loginUser({ commit }, info) {
            const data = {
                "identifier": info.identifier,
                "password": info.password
            }

            try {
                const res = await axios.post('http://localhost:5000/Auth/Login', data);
                if (window) {
                    const token = window.localStorage.setItem('token', data.token);
                    if (token) {
                        axios.defaults.headers.common['Authorization'] = `Bearer ${data.token}`;
                    }
                }
                commit('LOGIN_USER', res.data);
            } catch (error) {
                console.error(error);
                commit('LOGIN_FAIL');
            }
        },
        async verifyUser({ commit }) {
            if (window) {
                const token = window.localStorage.getItem('token');
                if (token) {
                    axios.defaults.headers.common['Authorization'] = `Bearer ${token}`;
                }
            }

            try {
                const { data: user } = await axios.get('http://localhost:5000/Auth/verify');
                commit('LOGIN_USER', {
                    user
                });
            } catch (err) {
                console.error(err);
                commit('LOGIN_FAIL');
            }
        },
        logoutUser({commit}) {
            commit('LOGOUT_USER');
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
       },
       isAdmin:(state) => {
           return state.isAdmin
       },
       state: (state) => {
           return state;
       }
    }
}