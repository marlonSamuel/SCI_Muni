import Vue from 'vue'
import Router from 'vue-router'

import Default from '@/components/Default'
import DepartamentoIndex from '@/components/recursos_humanos/Departamento'
import CargoIndex from '@/components/recursos_humanos/Cargo'
import EmpleadoIndex from '@/components/recursos_humanos/Empleado'

Vue.use(Router)

const routes = [
  { path: '/', name: 'Default', component: Default },
  { path: '/departamento', name: 'DepartamentoIndex', component: DepartamentoIndex },
  { path: '/cargo', name: 'CargoIndex', component: CargoIndex },
  { path: '/empleado', name: 'EmpleadoIndex', component: EmpleadoIndex }
]

export default new Router({
  routes
})
