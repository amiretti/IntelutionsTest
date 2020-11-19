import Vue from 'vue'
import Router from 'vue-router'
import Permisos from '@/components/Permisos'
import Permiso from '@/components/Permiso'
import TipoPermiso from '@/components/TipoPermisos'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Permisos',
      component: Permisos
    },
    {
      path: '/permiso',
      name: 'Permiso',
      component: Permiso
    },
    {
      path: '/tipos',
      name: 'Tipos de Permisos',
      component: TipoPermiso
    }
  ]
})
