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
    get: () => requests.get('Case/Case/cases'),
    getById: (id) => requests.get(`Case/Case/get-case-by-id/${id}`),
    create: (values) => requests.post(`Case/Case/add-case`, values)
}

const Provat = {
    get: () => requests.get('Data/Prova/te-gjitha-provat'),
    getById: (id) => requests.get(`Data/Prova/proven/${id}`)
}

const ProvatBiologjike = {
    get: () => requests.get('Data/ProvaBiologjike/provat-biologjike'),
    getById: (id) => requests.get(`Data/ProvaBiologjike/proven-biologjike/${id}`),
    create: (values) => requests.post(`Data/ProvaBiologjike/proven-biologjike`, values)
}

const ProvatFizike = {
    get: () => requests.get('Data/ProvaFizike/provat-fizike'),
    getById: (id) => requests.get(`Data/ProvaFizike/proven-fizike/${id}`),
    create: (values) => requests.post(`Data/ProvaFizike/proven-fizike`, values)
}

const agent = {
    Cases,
    Provat,
    ProvatBiologjike,
    ProvatFizike
}

export default agent