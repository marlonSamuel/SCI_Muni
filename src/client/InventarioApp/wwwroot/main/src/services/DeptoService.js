class departamentoService {
    axios
    baseUrl

    constructor(axios, baseUrl) {
        this.axios = axios
        this.baseUrl = `${baseUrl}departamentos`
    }

    getAll(params) {
        let self = this;
        console.log(self.baseUrl)
        return self.axios.get(`${self.baseUrl}`);
    }

    get(id) {
        let self = this;
        //return self.axios.get(`${self.baseUrl}departamento/${id}`);
    }

    save(depto){
        console.log(depto);
        let self = this;
        return self.axios.post(`${self.baseUrl}`, depto);
    }

    remove(id) {
        let self = this;
        return self.axios.delete(`${self.baseUrl}/${id}`);
    }
}

export default departamentoService