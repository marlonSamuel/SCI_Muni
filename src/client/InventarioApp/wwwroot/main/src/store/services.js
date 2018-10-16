import Axios from 'axios'
import departamentoService from '../services/DeptoService'
import globalService from '../services/GlobalService'
import cargoService from '../services/cargoService'
import empleadoService from '../services/EmpleadoService'
import categoriaAlmacenService from '../services/CategoriaAlmacenService'
import categoriaProductoService from '../services/CategoriaProductoservice'
import productoService from '../services/ProductoService'
import proveedorService from '../services/proveedorService'
import compraService from '../services/compraService'
import solicitudService from '../services/solicitudService'

//url api local
let baseUrl = "http://localhost:55330/";

// Axios Configuration
Axios.defaults.headers.common.Accept = 'application/json'
Axios.defaults.headers.common.Authorization = `bearer ${User.Token}`

export default {
    departamentoService: new departamentoService(Axios,baseUrl),
    globalService: new globalService(Axios,baseUrl),
    cargoService: new cargoService(Axios,baseUrl),
    empleadoService: new empleadoService(Axios,baseUrl),
    categoriaAlmacenService: new categoriaAlmacenService(Axios,baseUrl),
    categoriaProductoService: new categoriaProductoService(Axios,baseUrl),
    proveedorService: new proveedorService(Axios,baseUrl),
    productoService: new productoService(Axios,baseUrl),
    compraService: new compraService(Axios,baseUrl),
    solicitudService: new solicitudService(Axios,baseUrl)
}