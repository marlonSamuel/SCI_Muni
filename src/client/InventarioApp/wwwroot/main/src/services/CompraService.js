class compraService {
    axios
    baseUrl

    constructor(axios, baseUrl) {
        this.axios = axios
        this.baseUrl = `${baseUrl}compras`
    }

    getAll(params) {
        let self = this;
        return self.axios.post(`${self.baseUrl}/listar`,params);
    }

    getDetalle(id) {
        let self = this;
        return self.axios.get(`${self.baseUrl}/listar/${id}`);
    }

    get(id) {
        let self = this;
        //return self.axios.get(`${self.baseUrl}departamento/${id}`);
    }

    save(compra){
        let self = this;
        debugger;
        return self.axios.post(`${self.baseUrl}`,compra);
    }

    remove(id) {
        let self = this;
        return self.axios.delete(`${self.baseUrl}/${id}`);
    }
}

export default compraService