import axios from 'axios'

export default{
    namespaced:true,
    state(){
        return{
            fetchedMovies:[]
        }
    },
    mutations:{
        FETCH_MOVIES(state,movies){
            state.fetchedMovies = movies
        }
    },
    actions:{
        async fetchMovies({commit}){
            try {
                const res = await axios.get('http://localhost:5000/Movies')
                // console.log(res)
                commit('FETCH_MOVIES',res.data)
            } catch (error) {
                console.log(error)   
            }
            
        },
        async fetchWatchlist({commit}){
            try {
                user = $store.getters(['auth/account'])
                    console.log(user.identifier)
                
            } catch (error) {
                console.log(error)
            }
        }
    },
    getters:{
        getFetchedMovies:(state) => {
            return state.fetchedMovies
        }
    }
}