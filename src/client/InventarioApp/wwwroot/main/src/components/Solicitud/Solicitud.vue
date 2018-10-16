<template>
<div class="custom-container">
 <div v-show="gridMode">
<h2>Solicitudes</h2>
  <el-col :span="12">
  </el-col>
   <div class="form-group container card">
       <div class="form-group">
         <el-button @click="Nuevo()" class="pull-right" type="success"><i class="fa fa-plus"> Nuevo</i></el-button>
         <h4>Solicitadas</h4>
       </div>
        <el-table     
            :data="solicitadas"
            :default-sort = "{prop: 'nombre', order: 'ascending'}"
            stripe
            style="width: 100%">
        <el-table-column type="expand">
            <template slot-scope="props">
                <p><b>Fecha:</b> {{ props.row.fecha_solicitud | moment('llll') }}</p>
                <p><b>Departamento:</b> {{ props.row.departamento }}</p>
            </template>
            </el-table-column>
          <el-table-column prop="fecha_solicitud" label="Fecha" sortable width="200px">
              <template slot-scope="scope">
                  {{ scope.row.fecha_solicitud | moment('DD-MM-YYYY') }}
              </template>
          </el-table-column>
           <el-table-column prop="departamento" label="Departamento" sortable></el-table-column>
            <el-table-column prop="total" label="Total" sortable width="200px">
                <template slot-scope="scope">
                    {{ scope.row.total | currency}}
                </template>
            </el-table-column>
            <el-table-column align="right" label="opciones">
                <template slot-scope="scope">
                    <el-button type="success" size="small" zize="small" @click="changeStatus(scope.row,'E')" ><i class="fa fa-paper-plane"></i></el-button>
                    <el-button type="primary" icon="el-icon-view" size="small" @click="editar(scope.row)"></el-button>
                    <el-button type="danger" icon="el-icon-close" size="small" @click="remove(scope.row)"></el-button>
                </template>
            </el-table-column>
        </el-table>

        <div class="pager">
            <el-pagination
            @size-change="sizeChange"
            @current-change="currentChange"
            :current-page.sync="grid.pagination.page"
            :page-sizes="[6]"
            layout="total, sizes, prev, pager, next, jumper"
            :total="grid.total">
            </el-pagination>
        </div>

   </div>
   <proceso @clicked="entregar" ref="proc" ></proceso>
   <historial @clicked="editar" ref="hist"></historial>
 </div>

<!--Formulario de registro -->
 <div v-show="insertMode">
     <h2>{{titulo}}</h2>
    <el-form label-position="top" v-loading ="loading" :model="form" :rules="rules" ref="ruleForm">
             <el-col :span="4">
              <el-form-item label="Codigo solicitud" prop="codigo">
                <el-input :disabled="true" v-model="form.codigo"></el-input>
             </el-form-item>
          </el-col>
            <el-col :span="1">&nbsp;</el-col>
            <el-col :span="6">
          <el-form-item label="Empleado" prop="empleadoId">
             <el-select :disabled="disabledInputs" zize="large" filterable clearable v-model="form.empleadoId" placeholder="Proveedor">
                <el-option
                  v-for="item in empleados"
                  :key="item.empleadoId"
                  :label="item.primer_nombre +' ' + item.primer_apellido"
                   :value="item.empleadoId">
              </el-option>
             </el-select>
        </el-form-item>
          </el-col>
            <el-col :span="4">
              <el-form-item label="Numero de serie" prop="no_serie">
                <el-input :disabled="true" v-model="form.no_serie"></el-input>
             </el-form-item>
          </el-col>
          <el-col :span="1">&nbsp;</el-col>
            <el-col :span="4">
              <el-form-item label="No Orden" prop="no_orden">
                <el-input :disabled="true" v-model="form.no_orden"></el-input>
             </el-form-item>
          </el-col>
          
          <el-col :span="6">
          <el-form-item label="Tipo de solicitud">
            <el-select :disabled="disabledInputs" v-model="form.tipo" placeholder="Tipo de solicitud">
              <el-option
                v-for="item in tipos"
                :key="item.value"
                :label="item.label"
                :value="item.value">
              </el-option>
            </el-select>          
          </el-form-item>
          </el-col>
          <el-col :span="6">
              <el-form-item label="Fecha" prop="fecha_solicitud">
                    <el-date-picker 
                       :disabled="disabledInputs"
                        v-model="form.fecha_solicitud"
                        type="datetime"
                        placeholder="Selecione la fecha y hora">
                    </el-date-picker>
             </el-form-item>
          </el-col>

          <el-col :span="6">
              <el-form-item label="Codigo Programatico" prop="codigo_programatico">
                <el-input :disabled="true"  v-model="form.codigo_programatico"></el-input>
             </el-form-item>
          </el-col>


       <el-col :span="24" class="form-group">
          <el-button v-show="showButtons" icon="el-icon-plus" type="primary" @click="show">Agregar Articulo</el-button>
       </el-col>

       <div class="form-group">
        <el-table
            :data="detalles"
            border
            stripe
            style="width: 100%">
            <el-table-column label="opciones" width="100px">
                <template slot-scope="scope" sortable>
                    <el-button v-show="showButtons" @click="removeProducto()" type="danger" icon="el-icon-close" size="small"></el-button>
                </template>
            </el-table-column>
            <el-table-column :disabled="disabledInputs" prop="nombre" label="Producto">
            </el-table-column>
            <el-table-column prop="precio" label="Precio">
                <template slot-scope="scope">
                    <el-input-number v-model="scope.row.precio" :precision="2" :min="0.00"></el-input-number>
                </template>
            </el-table-column>
            <el-table-column prop="cantidad" label="Cantidad solicitada">
                <template slot-scope="scope">
                    <el-input-number :disabled="disabledInputs"  v-model="scope.row.cantidad_solicitada" :min="0"></el-input-number>
                </template>
            </el-table-column>
            <div v-if="showCant">
               <el-table-column prop="cantidad" label="Cantidad Entregada">
                   <template slot-scope="scope">
                     <el-input-number :disabled="!disabledInputs || disableEntrega" v-model="scope.row.cantidad_entregada" :min="0"></el-input-number>
                   </template>
                </el-table-column>
            </div>
            <el-table-column prop="subtotal" label="Subtotal Solicitado">
              <template slot-scope="scope">
                <div><h6>{{scope.row.subtotal|currency}}</h6></div>
              </template>
            </el-table-column>
            <el-table-column v-if="showCant" prop="subtotal" label="Subtotal Entregado">
              <template slot-scope="scope">
                <div><h6>{{scope.row.subtotalE|currency}}</h6></div>
              </template>
            </el-table-column>
        </el-table>
           <div class="form-group">
             <h5 v-if="showCant" class="pull-right text-success">Total Entregado: {{totalAmountE()|currency}}</h5> 
             <h5 class="pull-right text-warning" style="padding-right: 50px;" >Total Solicitado: {{totalAmount()|currency}}</h5>
           </div>
           <div></div>
       </div>

   <el-row class="space">
      <el-form-item>
        <el-button type="primary" v-show="showButtons || showSave" @click="save()"><i class="fa fa-save"></i> Guardar</el-button>
        <el-button type="danger" @click="cancelar()" ><i class="fa fa-undo"></i> Volver</el-button>
      </el-form-item>
   </el-row>

    </el-form>
</div>

   <modal
        transition="nice-modal-fade"
        :adaptive="true"
        classes="demo-modal-class"
        width="60%"
        height="auto"
        name="producto"> 
         <div  class="size-modal-content">
       <producto @clicked="addProducto"></producto>
         </div>
        <div class="pull-right">
         <el-button @click="hide">Cerrar</el-button>
       </div>
   </modal>
   <modals-container/>

</div>

     
 </template>
 

<script>
import producto from "@/components/shared/Productos";
import proceso from "@/components/solicitud/Proceso";
import historial from "@/components/solicitud/Historial";

export default {
  components: {
    producto,
    proceso,
    historial
  },
  name: "solicitud",
  created() {
    let self = this;
    self.getEmpleados();
    self.getAll();
  },
  data() {
    return {
      search: "",
      titulo: "Nuevo Registro",
      stockVacio: false,
      gridMode: true,
      insertMode: false,
      loading: false,
      disabledInputs: false,
      showCant: false,
      showSave: true,
      disableEntrega: true,
      showButtons: true,
      producto: {},
      solicitadas: [],
      enviadas: [],
      historicos: [],
      empleados: [],
      detalles: [],
      tipos: [
        { value: "B", label: "Bienes" },
        { value: "M", label: "Materiales" },
        { value: "A", label: "Suministros" },
        { value: "S", label: "Servicios" }
      ],
      grid: {
        total: 0,
        pagination: {
          rowsPerPage: 6,
          page: 1,
          sortBy: "nombre",
          descending: false
        }
      },

      form: {
        Id: 0,
        empleadoId: 0,
        fecha_solicitud: null,
        fecha_entrega: null,
        no_serie: null,
        no_orden: null,
        tipo: null,
        total: 0,
        codigo: 0,
        codigo_programatico: 0,
        estado_solicitud: "L",
        detalle: []
      },
      rules: {
        empleadoId: [{ required: true, message: "Debe ingresar un empleado" }],
        fecha: [{ required: true, message: "Debe ingresar una fecha" }],
        no_serie: [
          { required: true, message: "Debe ingresar un numero de compra" }
        ]
      },
      formDetalle: {
        precio: 0,
        cantidad_solicitada: 0,
        cantidad_entregada: 0
      }
    };
  },

  methods: {
    show() {
      this.$modal.show("producto");
    },
    hide() {
      this.$modal.hide("producto");
    },

    addProducto(producto) {
      let self = this;
      debugger;
      self.detalles.push(producto);
    },

    removeProducto(producto) {
      let self = this;
      var idx = self.detalles.indexOf(producto);
      self.detalles.splice(idx, 1);
    },

    totalAmount() {
      let self = this;
      var total = this.detalles.reduce(function(a, b, i) {
          self.detalles[i].subtotal = b.precio * b.cantidad_solicitada;
          return a + b.precio * b.cantidad_solicitada;
      }, 0);

      //self.form.total = total;
      return total;
    },

    totalAmountE() {
      let self = this;
      var total = this.detalles.reduce(function(a, b, i) {
          self.detalles[i].subtotalE = b.precio * b.cantidad_entregada;
          return a + b.precio * b.cantidad_entregada;
      }, 0);

      self.form.total = total;
      return total;
    },
    Nuevo() {
      let self = this;
      self.titulo = "Nuevo Registro";
      self.gridMode = false;
      self.insertMode = true;
      self.detalles = [];
      let newForm = {
        id: 0,
        fecha: null,
        no_serie: null,
        no_compra: null,
        totalSolicitud: 0,
        empleadoId: 0,
        estado: "L",
        tipo: null
      };
      
      self.getCorrelativos();
      self.mapData(newForm);
      self.showButtons = true;
      self.showCant = false;
      self.disabledInputs = false;
    },

    getCorrelativos(){
       let self = this;

       self.$store.state.services.solicitudService
        .getCorrelativos()
        .then(r => {
          debugger;
          self.form.codigo = r.data.codigo_solicitud;
          self.form.no_serie = r.data.no_serie;
          self.form.no_orden = r.data.no_orden;
          self.form.codigo_programatico = r.data.codigo_programatico;
        })
        .catch(e => {});

    },

    mapData(model) {
      debugger;
      let self = this;
      self.form.Id = model.id;
      self.form.empleadoId = model.empleadoId;
      self.form.fecha_solicitud = model.fecha_solicitud;
      self.form.fecha_entrega = model.fecha_entrega;
      self.form.no_serie = model.no_serie;
      self.totalSolicitud = model.totalSolicitud;
      self.form.no_orden = model.no_orden;
      self.form.tipo = model.tipo;
      self.form.estado_solicitud = model.estado;
      self.form.codigo = model.codigo;
      self.form.codigo_programatico = model.codigoProgramatico;
      self.totalAmount();
    },

    editar(model) {
      let self = this;
      debugger;
      self.titulo = "Detalle Solicitud";

      self.getDetalle(model);

      self.mapData(model);

      if (model.estado == "F") {
        self.showCant = true;
      } else {
        self.showCant = false;
      }

      self.gridMode = false;
      self.insertMode = true;
      self.showButtons = false;
      self.disabledInputs = true;
      self.disableEntrega = true;
      self.showSave = false;
    },

    entregar(model) {
      debugger;
      let self = this;
      self.titulo = "Detalle Solicitud";
      self.getDetalle(model);
      model.estado = "F";
      model.fecha_entrega = model.fecha_entrega;
      self.mapData(model);
      self.showCant = true, 
      self.gridMode = false;
      self.insertMode = true;
      self.showButtons = false;
      self.disabledInputs = true;
      self.disableEntrega = false;
      self.showSave = true;
    },

    cancelar() {
      let self = this;
      self.gridMode = true;
      self.insertMode = false;
      self.detalles = [];
    },

    getDetalle(model) {
      let self = this;
      self.$store.state.services.solicitudService
        .getDetalle(model.id)
        .then(r => {
          self.detalles = r.data;
        })
        .catch(e => {});
    },

    getAll() {
      let self = this;
      self.loading = true;
      self.$store.state.services.solicitudService
        .getAll(self.grid.pagination, "L")
        .then(r => {
          self.solicitadas = r.data.data || [];
          self.grid.total = r.data.total;

          self.loading = false;
        })
        .catch(r => {
          self.grid.items = [];
          self.grid.total = 0;

          self.loading = false;
        });
    },

    sizeChange(val) {
      this.grid.pagination.rowsPerPage = val;
      this.getAll();
    },
    currentChange(val, estado) {
      this.grid.pagination.page = val;
      this.getAll();
    },

    getEmpleados() {
      let self = this;
      self.loading = true;

      self.$store.state.services.empleadoService
        .getAll(self.grid.pagination)
        .then(r => {
          self.loading = false;
          self.empleados = r.data.data;
        })
        .catch(r => {});
    },

    save() {
      let self = this;
      self.$refs["ruleForm"].validate(valid => {
        if (!valid) {
          return;
        }
        debugger;
        self.form.detalle = self.detalles;
        let solicitud = self.form;
        
        //validamos la existencia de un producto
        for(var i= 0; i<solicitud.detalle.length; i++){
             var entregada = solicitud.detalle[i].cantidad_entregada
             var stock = solicitud.detalle[i].stock
             var nombre = solicitud.detalle[i].nombre
              if(entregada > stock){
                debugger;
                self.message('error!!existencia insuficiente del producto '+nombre+' cuenta con '+stock+' productos','error',false)
                return;
              }
        }

        self.loading = true;
        self.$store.state.services.solicitudService
          .save(solicitud)
          .then(r => {
            self.loading = false;
            self.gridMode = true;
            self.insertMode = false;
            self.getAll();
            self.$refs.proc.getAll();
            self.$refs.hist.getAll();

            if (solicitud.id > 0) {
              self.message("solicitud Actualizado correctamente", "success",false);
            } else {
              self.message("solicitud guardada correctamente", "success",false);
            }
          })
          .catch(r => {});
      });
    },

    changeStatus(model, estado) {
      let self = this;

      this.$confirm("Esta seguro de enviar esta solicitud a revision", {
        confirmButtonText: "Si",
        cancelButtonText: "Cancelar",
        type: "warning"
      })
        .then(() => {
          _enviar();
          self.message("Solicitud ha sido Enviada para revision", "success",false);
        })
        .catch(() => {});

      function _enviar() {
        self.loading = true;
        self.$store.state.services.solicitudService
          .changeStatus(model.id, estado)
          .then(r => {
            self.loading = false;
            self.getAll();
            self.$refs.proc.getAll();
          })
          .catch(e => {});
      }
    },

    remove(model) {
      let self = this;
      this.$confirm("Esta seguro de cancelar esta solicitud ", {
        confirmButtonText: "Si",
        cancelButtonText: "Cancelar",
        type: "warning"
      })
        .then(() => {
          _remove();
          self.message("Solicitud ha sido Cancelada", "success",false);
        })
        .catch(() => {});

      function _remove() {
        let id = model.id;
        self.loading = true;
        self.$store.state.services.solicitudService
          .remove(id)
          .then(r => {
            self.loading = false;
            self.getAll("L");
          })
          .catch(r => {});
      }
    },

    /*getAllSolicitudesStatus(){
      let self = this;
        self.getAll("L");
        self.getAll("E");
        self.getAll("F");
    },*/

    message(message, type,close) {
      let self = this;
      debugger;
      self.$message({
        message: message,
        type: type,
        showClose: close
      });
    }
  }
};
</script>

<style>
.size-modal-content {
  padding: 10px;
  font-style: 13px;
}

.space {
  margin: 20px 0px 20px 0px;
}

.v--modal-overlay[data-modal="size-modal"] {
  background: rgba(0, 0, 0, 0.5);
}
.demo-modal-class {
  border-radius: 5px;
  background: #f7f7f7;
  box-shadow: 5px 5px 30px 0px rgba(46, 61, 73, 0.6);
}
</style>
 