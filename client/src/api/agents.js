import axios from 'axios';

axios.defaults.baseURL = "https://localhost:7275/api/";

const responseBody = (response) => response.data;

const requests ={
    get: (url) => axios.get(url).then(responseBody),
    post: (url, body) => axios.post(url, body).then(responseBody),
    put: (url, body) => axios.put(url, body).then(responseBody),
    del: (url) => axios.delete(url).then(responseBody),
}

const Cases = {
    get: () => requests.get('Case/Case/GetCases')
}

const agent = {
    Cases
}

export default agent