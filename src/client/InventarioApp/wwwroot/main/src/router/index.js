import Vue from 'vue'
import Router from 'vue-router'

import Default from '@/components/Default'
import DepartamentoIndex from '@/components/recursos_humanos/Departamento'
import CargoIndex from '@/components/recursos_humanos/Cargo'
import EmpleadoIndex from '@/components/recursos_humanos/Empleado'
import CategoriaAlmacenIndex from '@/components/almacen/CategoriaAlmacen'
import CategoriaProductoIndex from '@/components/almacen/CategoriaProducto'
import ProductoIndex from '@/components/almacen/Producto'
import ProveedorIndex from '@/components/pedidos/Proveedor'
import CompraIndex from '@/components/pedidos/Compra'


Vue.use(Router)

const routes = [
  { path: '/', name: 'Default', component: Default },
  { path: '/departamento', name: 'DepartamentoIndex', component: DepartamentoIndex },
  { path: '/cargo', name: 'CargoIndex', component: CargoIndex },
  { path: '/empleado', name: 'EmpleadoIndex', component: EmpleadoIndex },
  { path: '/categoriaAlmacen', name: 'CategoriaAlmacenIndex', component: CategoriaAlmacenIndex },
  { path: '/categoriaProducto', name: 'CategoriaProductoIndex', component: CategoriaProductoIndex },
  { path: '/producto', name: 'ProductoIndex', component: ProductoIndex },
  { path: '/proveedor', name: 'ProveedorIndex', component: ProveedorIndex },
  { path: '/compra', name: 'CompraIndex', component: CompraIndex }
]

export default new Router({
  routes
})
