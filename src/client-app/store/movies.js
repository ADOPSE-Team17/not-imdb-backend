import axios from 'axios'

export default{
    namespaced:true,
    state(){
        return{

        }
    },
    mutations:{

    },
    actions:{
        async fetchMovies(){
            try {
                const res = await axios.get('http://localhost:5000/Movies')
                console.log(res)
            } catch (error) {
                console.log(error)   
            }
            
        }
    },
    getters:{

    }
}