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
    getById: (id) => requests.get(`Case/Case/case/${id}`),
    create: (values) => requests.post(`Case/Case/case`, values)
}

const Files = {
    getCaseImages: (id) => requests.get(`/File/get-case-png/${id}`),
    uploadfile: (id, values) => requests.post(`/File/upload/${id}`, values)
}

const deshmitaret = {
    get: () => requests.get('Data/Deshmitari/deshmitaret'),
    create: (values) => requests.post(`Data/Deshmitari/deshmitar`, values)
}

const teDyshuarit = {
    get: () => requests.get('Data/IDyshuari/te-dyshuarit'),
    create: (values) => requests.post(`Data/IDyshuari/i-dyshuari`, values)
}

const viktimat = {
    get: () => requests.get('Data/Viktima/viktimat'),
    create: (values) => requests.post(`Data/Viktima/viktime`, values)
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

const Tasks = {
    get: () => requests.get('Task/tasks'),
    getById: (id) => requests.get(`Task/get-task-by-id/${id}`),
    create: (values) => requests.post(`Task/add-task`, values),
    update: (values,id) => requests.put(`Task/put-task/${id}`, values),
    delete: (id) => requests.del(`Task/delete-task/${id}`)
}

const agent = {
    Cases,
    Files,
    deshmitaret,
    teDyshuarit,
    viktimat,
    Provat,
    ProvatBiologjike,
    ProvatFizike,
    Tasks
}

export default agent