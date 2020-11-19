<template>
  <div id="app">
    <div>
      <b-navbar toggleable="lg" type="dark" variant="info">
        <b-navbar-brand href="#">Intelutions Test</b-navbar-brand>

        <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

        <b-collapse id="nav-collapse" is-nav>
          <b-navbar-nav>
            <b-nav-item-dropdown text="Permisos">
              <b-dropdown-item href="#/">Ver todos</b-dropdown-item>
              <b-dropdown-item href="#/Permiso">Nuevo</b-dropdown-item>
            </b-nav-item-dropdown>
            <b-nav-item href="#/tipos">Tipos de permisos</b-nav-item>
          </b-navbar-nav>
        </b-collapse>
      </b-navbar>
    </div>
    <b-container >
      <router-view/>
    </b-container>
  </div>
</template>

<script>
export default {
  name: 'App'
}
</script>

<style>
</style>
