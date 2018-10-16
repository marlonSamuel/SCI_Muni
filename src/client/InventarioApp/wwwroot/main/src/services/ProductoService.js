class productoService {
    axios
    baseUrl

    constructor(axios, baseUrl) {
        this.axios = axios
        this.baseUrl = `${baseUrl}productos`
    }

    getAll(params, id) {
        let self = this;
        return self.axios.post(`${self.baseUrl}/listar/${id}`,params);
    }

    get(id) {
        let self = this;
        return self.axios.get(`${self.baseUrl}/${id}`);
    }

    save(producto){
        let self = this;
        debugger;
        return self.axios.post(`${self.baseUrl}/guardar`,producto);
    }

    remove(id,almacenId) {
        debugger;
        let self = this;
        return self.axios.delete(`${self.baseUrl}/${id}/${almacenId}`);
    }
}

export default productoService