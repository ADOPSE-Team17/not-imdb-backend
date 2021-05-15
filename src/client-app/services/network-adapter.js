import axios from 'axios';

const api = 'http://localhost:5000';

const get = (path, params, options) => {
  return axios.get(`${api}/${path}`, null, {
    headers: {

    }
  });
}

const post = (path, params, options)   =>  {
  let url = `${api}/${path}`;
  if (params) {
    url += `?${params}`;
  }
  // return axios.post(url)
}

const put = () => {

}

const remove = () => {

}
