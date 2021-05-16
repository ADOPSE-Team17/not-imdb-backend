import axios from 'axios'

export default{
    namespaced:true,
    state(){
        return{
            fetchedMovies:[],
            fetchedMovieById:{},
            watchlist:[],
            watchlistNames:[],
            games:[],
            lists:[]
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
        },
        ADD_TO_WATCHLIST(state,movie){
            state.watchlist.push(movie)
        },
        FETCH_GAMES(state,games){
            state.games = games
        },
        FETCH_LISTS(state,list){
          state.lists = list  
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
        },
        async fetchWatchlist({commit}){
            try {
                const res = await axios.get('http://localhost:5000/WatchList')
                commit('FETCH_WATCHLIST',res.data)
            } catch (error) {
                console.log(error)
            }
        },
        async addToWatchlist({commit},movie){
            try {
                // console.log(movie.id)
               
                const res = await axios.post(`http://localhost:5000/watchlist/4/addItem/${movie.id}`)
                // console.log(res.data)
                commit('ADD_TO_WATCHLIST',res.data)
            } catch (error) {
                console.log(error)
            }
        },

        async fetchGames({commit}){
            try {
                axios.get('http://localhost:5000/Games').then((result) =>{
                    // console.log(result.data)
                    commit('FETCH_GAMES',result.data)
                })
                
            } catch (error) {
                console.log(error)
            }
        },
        async fetchLists({commit}){
            try {
                axios.get('http://localhost:5000/Movies').then((result) => {
                    // console.log(result.data)
                    commit('FETCH_LISTS',result.data)
                })
            } catch (error) {
                
            }
        }
         
        
    },
    getters:{
        getFetchedMovies:(state) => {
            return state.fetchedMovies
        },
        getFetchedMovieById:(state) => {
            return state.fetchedMovieById
        },
        getWatchlist:(state) => {
            return state.watchlist
        },
        getGames:(state) => {
            return state.games
        },
        getLists:(state) => {
            return state.lists
        }
    }
}