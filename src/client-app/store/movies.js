import axios from 'axios'

export default{
    namespaced:true,
    state(){
        return{
            fetchedMovies:[],
            watchlist:{}
        }
    },
    mutations:{
        FETCH_MOVIES(state,movies){
            state.fetchedMovies = movies
        },
        FETCH_WATCHLIST(state,Watchlist){
            state.watchlist = Watchlist
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
         
        
    },
    getters:{
        getFetchedMovies:(state) => {
            return state.fetchedMovies
        }
    }
}