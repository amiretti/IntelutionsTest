<template>
  <div>
    <h1>Permisos</h1>
    <b-table striped hover :items="items" :fields="fields" :busy="isBusy" caption-top show-empty small>
      <template #table-caption>
        <b-link variant="primary" href="#/permiso"><b-icon icon="clipboard-plus" aria-hidden="true" ></b-icon> Nuevo Permiso</b-link>
        <!--<b-button variant="outline-primary" @click="VerPermisos">{{btnText}}</b-button>-->
      </template>
      <template #cell(actions)="row" text-center>
        <b-button variant="primary" size="sm" @click="editLicense(row.item)" class="mr-1">
          <b-icon icon="pencil-square" aria-hidden="true"></b-icon>
        </b-button>
        <b-button variant="danger" size="sm" @click="deleteLicenseModal(row.item)" class="mr-1">
          <b-icon icon="trash" aria-hidden="true"></b-icon>
        </b-button>
      </template>
    </b-table>
    <b-modal ref="delete-modal" id="modal-sm" size="sm" title="Eliminar permiso" @ok="deleteLicense">
      <div class="d-block">Está seguro de querer eliminar el permiso de {{ apellidoSeleccionado }}?</div>
    </b-modal>
  </div>
</template>

<script>
import { bus } from '../main'
import license from "@/logic/permisos";
export default {
  name: 'Permisos',
  data () {
    return {
      verSoloVigentes: true,
      apellidoSeleccionado: "",
      idSeleccionado: 0,
      btnText: "Ver todos los permisos",
      fields: [
          {
            key: 'empleadoNombre',
            sortable: true
          },
          {
            key: 'empleadoApellidos',
            sortable: true
          },
          {
            key: 'tipoPermiso',
            label: 'Tipo de permiso',
            sortable: true
          },
          {
            key: 'fechaPermiso',
            label: 'Fecha del permiso',
            sortable: false
          },
          {
            key: 'actions',
            label: 'Acciones',
            class: 'text-center'
          }
        ],
        items: [ ],
        isBusy: false
      }
  },
    methods:{
      VerPermisos(){
        this.verSoloVigentes = !this.verSoloVigentes;
        if(this.verSoloVigentes){
          this.btnText = "Ver todos los permisos";
        }
        else{
          this.btnText = "Ver sólo vigentes";
        }
      },
      editLicense(item) {
        this.$router.push('/permiso?id=' + item.id);
        //bus.$emit('edit-license', item);
      },
      deleteLicenseModal(item) {
        this.idSeleccionado = item.id;
        this.apellidoSeleccionado = item.empleadoApellidos;
        this.$refs['delete-modal'].show();
      },
      deleteLicense(bvModalEvt) {
        bvModalEvt.preventDefault()
        license.DeleteLicense(this.idSeleccionado).then((resp) => {
          this.getLicensesList();
          this.$refs['delete-modal'].hide();
        });
      },
      getLicensesList(){
       this.isBusy = true;
        license.getListOfLicenses().then((resp) => {
              this.items = resp.data;
              this.isBusy = false;
          }, error => {
            this.isBusy = false;
            console.log(error);
          });
      }
    },
    mounted(){
      this.getLicensesList();
    }
}
</script>
