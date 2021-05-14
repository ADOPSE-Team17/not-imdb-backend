import axios from 'axios'

export default{
    namespaced:true,
    state(){
        return{
            fetchedMovies:[],
            fetchedMovieById:{}
        }
    },
    mutations:{
        FETCH_MOVIES(state,movies){
            state.fetchedMovies = movies
        },
        FETCH_WATCHLIST(state,Watchlist){
            state.watchlist = Watchlist
        },
        FETCH_MOVIE_BY_ID(state,movie){
            state.fetchedMovieById = movie
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

        async fetchMovieById({commit},id){
            try {
                const res = await axios.get(`http://localhost:5000/Movies/${id}`)
                // console.log(res.data)
                commit('FETCH_MOVIE_BY_ID',res.data)

            } catch (error) {
                console.log(error)
            }
        }
         
        
    },
    getters:{
        getFetchedMovies:(state) => {
            return state.fetchedMovies
        },
        getFetchedMovieById:(state) => {
            return state.fetchedMovieById
        }
    }
}