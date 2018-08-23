class categoriaProductoService {
    axios
    baseUrl

    constructor(axios, baseUrl) {
        this.axios = axios
        this.baseUrl = `${baseUrl}categoriasProductos`
    }

    getAll(params) {
        let self = this;
        console.log(params);
        return self.axios.post(`${self.baseUrl}/listar`,params);
    }

    getByAlmacen(id) {
        let self = this;
        return self.axios.get(`${self.baseUrl}/listar/${id}`);
    }

    save(cargo){
        let self = this;
        return self.axios.post(`${self.baseUrl}`,cargo);
    }

    remove(id) {
        let self = this;
        return self.axios.delete(`${self.baseUrl}/${id}`);
    }
}

export default categoriaProductoService