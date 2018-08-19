class empleadoService {
    axios
    baseUrl

    constructor(axios, baseUrl) {
        this.axios = axios
        this.baseUrl = `${baseUrl}empleados`
    }

    getAll(params) {
        let self = this;
        return self.axios.post(`${self.baseUrl}/listar`,params);
    }

    get(id) {
        let self = this;
        //return self.axios.get(`${self.baseUrl}departamento/${id}`);
    }

    save(empleado){
        let self = this;
        return self.axios.post(`${self.baseUrl}`,empleado);
    }

    remove(id) {
        let self = this;
        return self.axios.delete(`${self.baseUrl}/${id}`);
    }
}

export default empleadoService