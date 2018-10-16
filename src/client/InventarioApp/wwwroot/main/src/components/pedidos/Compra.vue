<template>
<div class="custom-container">
  <div v-show="gridMode">
    <h2>Compras</h2>

    <div class="pull-right">
     <el-button type="success" @click="Nuevo()"><i class="fa fa-plus"> Nuevo</i></el-button>
   </div>
  <el-table
    :data="grid.items"
    :default-sort = "{prop: 'nombre', order: 'ascending'}"
    stripe
    style="width: 100%">
    <el-table-column type="expand">
      <template slot-scope="props">
        <p><b>Fecha:</b> {{ props.row.fecha | moment('llll') }}</p>
        <p><b>Proveedor:</b> {{ props.row.proveedor }}</p>
    </template>
    </el-table-column>
    <el-table-column prop="fecha" label="Fecha" sortable width="200px">
        <template slot-scope="scope">
            {{ scope.row.fecha | moment('DD-MM-YYYY') }}
        </template>
    </el-table-column>
    <el-table-column prop="proveedor" label="Proveedor" sortable></el-table-column>
    <el-table-column prop="totalCompra" label="Total Compra" sortable width="200px">
        <template slot-scope="scope">
            {{ scope.row.totalCompra | currency}}
        </template>
    </el-table-column>
      <el-table-column label="Estado" sortable width="200px">
          <template slot-scope="scope">
              <b v-if="scope.row.estado == 'A'"><el-tag type="success">Aceptada</el-tag></b>
              <b v-if="scope.row.estado == 'R'"><el-tag type="danger">Anulada</el-tag></b>
          </template>
        </el-table-column>
    <el-table-column align="right" label="opciones">
         <template slot-scope="scope">
            <el-button :disabled="scope.row.estado == 'R'"  type="danger" icon="el-icon-close" size="small" @click="remove(scope.row)"></el-button>
            <el-button type="primary" icon="el-icon-view" size="small" @click="editar(scope.row)"></el-button>
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
  
<!--Formulario de registro -->
 <div v-show="insertMode">
     <h2>{{titulo}}</h2>
    <el-form label-position="top" v-loading ="loading" :model="form" :rules="rules" ref="ruleForm">
 
            <el-col :span="8">
          <el-form-item label="Proveedor" prop="proveedorId">
             <el-select zize="large" :disabled="disabledInputs" filterable clearable v-model="form.proveedorId" placeholder="Proveedor">
                <el-option
                  v-for="item in proveedores"
                  :key="item.id"
                  :label="item.nombre"
                   :value="item.id">
              </el-option>
             </el-select>
        </el-form-item>
          </el-col>
            <el-col :span="6">
              <el-form-item label="Numero de serie" prop="no_serie">
                <el-input :disabled="disabledInputs" v-model="form.no_serie"></el-input>
             </el-form-item>
          </el-col>
          <el-col :span="2">&nbsp;</el-col>
            <el-col :span="6">
              <el-form-item label="Factura" prop="factura">
                <el-input :disabled="disabledInputs" v-model="form.factura"></el-input>
             </el-form-item>
          </el-col>
          
          <el-col :span="6">
          <el-form-item label="Tipo de compra">
            <el-select :disabled="disabledInputs" v-model="form.tipo" placeholder="Tipo de Compra">
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
              <el-form-item label="Fecha" prop="fecha">
                    <el-date-picker 
                       :disabled="disabledInputs"
                        v-model="form.fecha"
                        type="datetime"
                        placeholder="Selecione la fecha y hora">
                    </el-date-picker>
             </el-form-item>
          </el-col>


       <el-col :span="24" class="form-group">
              <el-button icon="el-icon-plus" type="primary" @click="show" v-show="showButtons">Agregar Articulo</el-button>
       </el-col>

       <div class="space">
        <el-table
            :data="detalles"
            border
            stripe
            style="width: 100%">
            <el-table-column label="opciones">
                <template slot-scope="scope" sortable width="10px">
                    <el-button v-show="showButtons"  @click="removeProducto()" type="danger" icon="el-icon-close" size="small"></el-button>
                </template>
            </el-table-column>
            <el-table-column prop="nombre" label="Producto">
            </el-table-column>
            <el-table-column prop="precio" label="Precio Compra">
                <template slot-scope="scope">
                    <el-input-number :disabled="disabledInputs" v-model="scope.row.precioCompra" :precision="2" :min="0.00"></el-input-number>
                </template>
            </el-table-column>
            <el-table-column  prop="cantidad" label="Cantidad">
                <template slot-scope="scope">
                    <el-input-number :disabled="disabledInputs" v-model="scope.row.cantidad" :min="0"></el-input-number>
                </template>
            </el-table-column>
            <el-table-column prop="subtotal" label="Subtotal">
              <template slot-scope="scope">
                <div><h6>{{scope.row.subtotal|currency}}</h6></div>
              </template>
            </el-table-column>
        </el-table>
           <div><h5 class="pull-right text-success">Total: {{totalAmount()|currency}}</h5></div>
       </div>

   <el-row class="space">
      <el-form-item>
        <el-button type="primary" v-show="showButtons" @click="save()"><i class="fa fa-save"></i> Guardar</el-button>
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
export default {
  name: "compra",

  components: {
    producto
  },

  created() {
    let self = this;
    self.getAll();
    self.getProveedores();
  },
  data() {
    return {
      search: "",
      titulo: "Nuevo Registro",
      gridMode: true,
      insertMode: false,
      disabledInputs: false,
      showButtons: true,
      proveedores: [],
      detalles: [],
      tipos: [{value: 'B',label: 'Bienes'},
              {value: 'M',label: 'Materiales'},
              {value: 'A',label: 'Suministros'},
              {value: 'S',label: 'Servicios'}
             ],
      grid: {
        items: [],
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
        proveedorId: 0,
        fecha: null,
        no_serie: null,
        tipo: null,
        factura: null,
        estado: null,
        totalCompra: 0,
        estado: 'A',

        detalle: []
      },
      rules: {
        proveedorId: [
          { required: true, message: "Debe ingresar un proveedor" }
        ],
        fecha: [{ required: true, message: "Debe ingresar una fecha" }],
        no_serie: [
          { required: true, message: "Debe ingresar un numero de compra" }
        ]
      },
      formDetalle: {
        precio: 0,
        cantidad: 0
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
        self.detalles[i].subtotal = b.precioCompra * b.cantidad;
        return a + (b.precioCompra * b.cantidad);
      }, 0);

      self.form.totalCompra = total;
      return total;
    },
    Nuevo() {
      let self = this;
      self.titulo = "Nuevo Registro";
      self.gridMode = false;
      self.insertMode = true;
      let newForm = {
        id: 0,
        fecha: null,
        no_serie: null,
        totalCompra: 0,
        proveedorId: 0,
        tipo: null,
        factura: null,
      };

      self.mapData(newForm);
      self.showButtons = true;
      self.disabledInputs = false;
    },

    mapData(model) {
      let self = this;
      self.form.id = model.id,
      self.form.proveedorId = model.proveedorId,
      self.form.fecha = model.fecha,
      self.form.no_serie = model.no_serie;
      self.totalCompra = model.totalCompra;
      self.form.factura = model.factura;
      self.form.tipo = model.tipo;
      self.totalAmount();
    },

    editar(model) {
      let self = this;
      debugger;
      self.titulo = "Detalle Compra";
      self.$store.state.services.compraService
      .getDetalle(model.id)
      .then(r=> {
         self.detalles = r.data;
      }).catch(e=>{

      });

      self.mapData(model);
      self.gridMode = false;
      self.insertMode = true;
      self.showButtons = false;
      self.disabledInputs = true;
    },

    cancelar() {
      let self = this;
      self.gridMode = true;
      self.insertMode = false;
      self.detalles = [];
    },

    getAll() {
      let self = this;
      self.loading = true;
      self.$store.state.services.compraService
        .getAll(self.grid.pagination)
        .then(r => {
          self.grid.items = r.data.data || [];
          self.itemsTemp = self.grid.items;
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
    currentChange(val) {
      this.grid.pagination.page = val;
      this.getAll();
    },

    save() {
      let self = this;
      self.$refs["ruleForm"].validate(valid => {
        if (!valid) {
          return;
        }
        self.form.detalle = self.detalles;
        let compra = self.form;
        debugger;
        self.loading = true;
        self.$store.state.services.compraService
          .save(compra)
          .then(r => {
            self.getAll();
            self.loading = false;
            self.gridMode = true;
            self.insertMode = false;

            if (compra.id > 0) {
              self.message("Compra Actualizado correctamente", "success");
            } else {
              self.message("Compra insertada correctamente", "success");
            }
          })
          .catch(r => {});
      });
    },

    getProveedores() {
      let self = this;
      self.loading = true;

      self.$store.state.services.proveedorService
        .getAll(self.grid.pagination)
        .then(r => {
          self.loading = false;
          self.proveedores = r.data.data;
        })
        .catch(r => {});
    },

    remove(model) {
      let self = this;
      this.$confirm("Esta seguro de anular esta venta ", {
        confirmButtonText: "Si",
        cancelButtonText: "Cancelar",
        type: "warning"
      })
        .then(() => {
          _remove();
          self.message(
            "Venta ha sido Anulada",
            "success"
          );
        })
        .catch(() => {});

      function _remove() {
        let id = model.id;
        self.loading = true;
        self.$store.state.services.compraService
          .remove(id)
          .then(r => {
            self.loading = false;
            self.getAll();
          })
          .catch(r => {});
      }
    },

    message(message, type) {
      let self = this;
      self.$message({
        message: message,
        type: type
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