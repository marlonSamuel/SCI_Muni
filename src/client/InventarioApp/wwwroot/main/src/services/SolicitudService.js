class solicitudService {
    axios
    baseUrl

    constructor(axios, baseUrl) {
        this.axios = axios
        this.baseUrl = `${baseUrl}solicitudes`
    }

    getAll(params,estado) {
        let self = this;
        return self.axios.post(`${self.baseUrl}/listar/${estado}`,params);
    }

    getDetalle(id) {
        let self = this;
        return self.axios.get(`${self.baseUrl}/listar/${id}`);
    }

    changeStatus(id, estado) {
        let self = this;
        return self.axios.get(`${self.baseUrl}/${id}/${estado}`);
    }

    save(solicitud){
        let self = this;
        debugger;
        return self.axios.post(`${self.baseUrl}`,solicitud);
    }

    remove(id) {
        let self = this;
        return self.axios.delete(`${self.baseUrl}/${id}`);
    }

    getCorrelativos() {
        let self = this;
        return self.axios.get(`${self.baseUrl}/correlativos`);
    }
}

export default solicitudService