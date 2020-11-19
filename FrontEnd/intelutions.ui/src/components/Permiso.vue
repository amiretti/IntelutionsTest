<template>
<div>
  <h1>{{formTitle}}</h1>
    <b-form @submit="onSubmit" @reset="onReset" v-if="show">
      <b-form-group id="input-group-1" label="Nombre del empleado:" label-for="input-1">
        <b-form-input
          id="input-1"
          v-model="form.empleadoNombre"
          type="text"
          required
          placeholder="Ingrese el nombre del empleado"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-2" label="Apellido del empleado:" label-for="input-2">
        <b-form-input id="input-2" v-model="form.empleadoApellidos" required placeholder="Ingrese el apellido del empleado"></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-3" label="Tipo de permiso:" label-for="input-3">
        <b-form-select id="input-3" value-field="id" text-field="descripcion" v-model="form.tipoPermisoId" :options="licenseTypes" required></b-form-select>
      </b-form-group>

      <b-form-group id="input-group-4" label="Fecha del permiso:" label-for="datepicker-1">
        <b-form-datepicker id="datepicker-1" v-model="form.fechaPermiso" class="mb-2"></b-form-datepicker>
      </b-form-group>

      <b-button type="submit" variant="primary">Guardar Permiso</b-button>
      <b-button type="reset" variant="danger">Limpiar formulario</b-button>
    </b-form>
  </div>
</template>

<script>
import { bus } from '../main'
import types from "@/logic/tiposPermisos";
import license from "@/logic/permisos";
  export default {
    data() {
      return {
        formTitle: "Nuevo permiso",
        form: {
          id: 0,
          empleadoNombre: '',
          empleadoApellidos: '',
          tipoPermisoId: 0,
          fechaPermiso: new Date()
        },
        licenseTypes: [],
        show: true
      }
    },
    methods: {
      onSubmit(evt) {
        evt.preventDefault()
        license.SaveLicense(JSON.stringify(this.form)).then((resp) => {
          this.$router.push('/')
        });
      },
      onReset(evt) {
        evt.preventDefault()
        // Reset our form values
        this.form.id = 0;
        this.form.empleadoNombre = '';
        this.form.empleadoApellidos = '';
        this.form.tipoPermisoId = 0;
        this.form.fechaPermiso = new Date();
        this.formTitle = "Nuevo permiso";
        // Trick to reset/clear native browser form validation state
        this.show = false
        this.$nextTick(() => {
          this.show = true
        })
      },
     getLicensesTypesList(){
       this.isBusy = true;
        types.getListOfTypes().then((resp) => {
              this.licenseTypes = resp.data;
              this.licenseTypes.push({id: 0, descripcion: "<< Seleccione un tipo >>"})
              this.isBusy = false;


          }, error => {
            this.isBusy = false;
            console.log(error);
          });
      }
  },
  mounted(){
    this.getLicensesTypesList();
    if(this.$route.query.id){
      this.formTitle = "Editar permiso";
      license.GetLicenseById(this.$route.query.id).then((resp) => {
       this.form.id =  resp.data.id;
       this.form.empleadoNombre = resp.data.empleadoNombre;
       this.form.empleadoApellidos = resp.data.empleadoApellidos;
       this.form.tipoPermisoId = resp.data.tipoPermisoId;
       this.form.fechaPermiso = resp.data.fechaPermiso;
      });
    }
    else
    {
      this.formTitle = "Nuevo permiso";
      // Reset our form values
      this.form.id = 0;
      this.form.empleadoNombre = '';
      this.form.empleadoApellidos = '';
      this.form.tipoPermisoId = 0;
      this.form.fechaPermiso = new Date();
      // Trick to reset/clear native browser form validation state
      this.show = false
      this.$nextTick(() => {
        this.show = true
      })
    }
  }
  }
</script>
