<template>
  <div>
    <h1>Tipos de permisos</h1>
    <b-table striped hover :items="items" :busy="isBusy"></b-table>
  </div>
</template>

<script>
import types from "@/logic/tiposPermisos";
export default {
  name: 'TiposPermisos',
  data () {
    return {
        items: [],
        isBusy: false
      }
  },
  methods:{
     getLicensesTypesList(){
       this.isBusy = true;
        types.getListOfTypes().then((resp) => {
              this.items = resp.data;
              this.isBusy = false;
          }, error => {
            this.isBusy = false;
            console.log(error);
          });
      }
  },
  mounted(){
    this.getLicensesTypesList();
  }
}
</script>
