<template>
<div class="custom-container">
 <div v-show="gridMode">
<h2>Empleados</h2>

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
        <p><b>Nombres:</b> {{ props.row.primer_nombre + " " + props.row.segundo_nombre }}</p>
        <p><b>Apellidos:</b> {{ props.row.primer_apellido + " " + props.row.segundo_apellido }}</p>
        <p><b>Departamento:</b> {{ props.row.departamento}}</p>
        <p><b>Cargo:</b> {{ props.row.cargo}}</p>
    </template>
    </el-table-column>
    <el-table-column prop="primer_nombre" label="Nombres" sortable width="200px">
        <template slot-scope="scope">
            {{scope.row.primer_nombre + " " + scope.row.segundo_nombre}}
         </template>
    </el-table-column>
     <el-table-column prop="primer_apellido" label="Apellidos" sortable width="200px">
    </el-table-column>
    <el-table-column prop="telefono" label="Telefono" sortable width="200px">
    </el-table-column>
    <el-table-column prop="direccion" label="Direccion" sortable width="200px">
    </el-table-column>
    <el-table-column align="right" label="opciones">
         <template slot-scope="scope">
            <el-button type="danger" icon="el-icon-delete" size="small" @click="remove(scope.row)"></el-button>
            <el-button type="warning" icon="el-icon-edit" size="small" @click="editar(scope.row)"></el-button>
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
    <el-form :label-position="labelPosition" v-loading ="loading" :model="form" :rules="rules" ref="ruleForm">
    
        <el-col :span="11">
          <el-form-item label="Primer Nombre" prop="primer_nombre">
            <el-input v-model="form.primer_nombre"></el-input>
          </el-form-item>
       </el-col>
       <el-col :span="2">&nbsp;</el-col>
        <el-col :span="11">
          <el-form-item label="Segundo Nombre">
            <el-input v-model="form.segundo_nombre"></el-input>
          </el-form-item>
       </el-col>

        <el-col :span="11">
          <el-form-item label="Primer Apellido" prop="primer_apellido">
            <el-input v-model="form.primer_apellido"></el-input>
          </el-form-item>
       </el-col>
       <el-col :span="2">&nbsp;</el-col>
        <el-col :span="11">
          <el-form-item label="Segundo Apellido">
            <el-input v-model="form.segundo_apellido"></el-input>
          </el-form-item>
       </el-col>

        <el-col :span="7">
          <el-form-item label="Departamento" prop="departamentoId">
             <el-select filterable clearable v-model="form.departamentoId" placeholder="Departamento">
                <el-option
                  v-for="item in itemsDeptos"
                  :key="item.id"
                  :label="item.nombre"
                   :value="item.id">
              </el-option>
             </el-select>
        </el-form-item>
        </el-col>
            <el-col :span="7">
              <el-form-item label="Cargo" prop="cargoId">
                  <el-select filterable clearable v-model="form.cargoId" placeholder="Departamento">
                    <el-option
                       v-for="item in itemsCargos"
                       :key="item.id"
                       :label="item.nombre"
                       :value="item.id">
                   </el-option>
                 </el-select>
              </el-form-item>
           </el-col>
             <el-col :span="10">
              <el-form-item label="Telefono" prop="telefono">
                 <el-input v-model="form.telefono"></el-input> 
              </el-form-item>
           </el-col>
          
          <el-col>
            <el-form-item label="Direccion" prop="direccion">
                 <el-input v-model="form.direccion"></el-input> 
          </el-form-item>
          </el-col>


   <el-col>
      <el-form-item>
        <el-button type="primary" @click="save"><i class="fa fa-save"></i> Guardar</el-button>
        <el-button type="danger" @click="cancelar"><i class="fa fa-undo"></i> Cancelar</el-button>
      </el-form-item>
   </el-col>

    </el-form>
</div>

</div>
</template>

<script>
export default {
  name: "empleado",
  created() {
    let self = this;
    self.getAll();
    self.getDeptos();
    self.getCargo();
  },
  props: {
    Url: {
      type: String,
      default: null
    }
  },
  data() {
    return {
     labelPosition: 'top',
      titulo: "Nuevo Registro",
      itemsDeptos: [],
      itemsCargos: [],
      gridMode: true,
      insertMode: false,
      loading: false,
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
        empleadoId: 0,
        primer_apellido: null,
        primer_nombre: null,
        segundo_nombre: null,
        segundo_apellido: null,
        departamentoId: 0,
        cargoId: 0,
        telefono: null,
        direccion: null
      },
      rules: {
        primer_nombre: [{ required: true, message: "Debe ingresar un nombre" }],
        telefono: [{ required: true, message: "Debe ingresar un numero de telefono" }],
        departamentoId: [{ required: true, message: "Debe ingresar un departamento" }],
        cargoId: [{ required: true, message: "Debe ingresar un cargo" }],
        direccion: [{ required: true, message: "Debe ingresar una direccion" }],
        primer_apellido: [{ required: true, message: "Debe ingresar un apellido" }],
      }
    };
  },
  methods: {
    Nuevo() {
      let self = this;
      self.titulo = "Nuevo Registro";
      self.gridMode = false;
      self.insertMode = true;
      let newForm = {
        id: 0,
        primer_apellido: null,
        primer_nombre: null,
        segundo_nombre: null,
        segundo_apellido: null,
        departamentoId: 0,
        cargoId: 0,
        telefono: null,
        direccion: null
      };

      self.mapData(newForm);
    },

    mapData(model) {
      let self = this;
      self.form.empleadoId = model.empleadoId,
      self.form.primer_nombre = model.primer_nombre,
      self.form.segundo_nombre = model.segundo_nombre,
      self.form.primer_apellido = model.primer_apellido,
      self.form.segundo_apellido = model.segundo_nombre,
      self.form.telefono = model.telefono,
      self.form.direccion = model.direccion,
      self.form.departamentoId = model.departamentoId,
      self.form.cargoId = model.cargoId
    },

    editar(model) {
      let self = this;
      debugger;
      self.titulo = model.primer_nombre + " " + model.primer_apellido;
      self.mapData(model);
      self.gridMode = false;
      self.insertMode = true;
    },

    cancelar() {
      let self = this;
      self.gridMode = true;
      self.insertMode = false;
    },

    getAll() {
      let self = this;
      self.loading = true;

      self.$store.state.services.empleadoService
        .getAll(self.grid.pagination)
        .then(r => {
          self.grid.items = r.data.data || [];
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
        let empleado = self.form;
        debugger;
        self.loading = true;
        self.$store.state.services.empleadoService
          .save(empleado)
          .then(r => {
            self.getAll();
            self.loading = false;
            self.gridMode = true;
            self.insertMode = false;

            if (empleado.empleadoId > 0) {
              self.message("Empleado Actualizado correctamente", "success");
            } else {
              self.message("Empleado insertado correctamente", "success");
            }
          })
          .catch(r => {});
      });
    },

    remove(model) {
      let self = this;
      this.$confirm("Esta seguro de eliminar a " + model.primer_nombre + "?", {
        confirmButtonText: "Si",
        cancelButtonText: "Cancelar",
        type: "warning"
      })
        .then(() => {
          _remove();
          self.message(
            "Empleado" + model.primer_nombre + "Eliminado correctamente",
            "success"
          );
        })
        .catch(() => {});

      function _remove() {
        let id = model.empleadoId;
        self.loading = true;
        self.$store.state.services.empleadoService
          .remove(id)
          .then(r => {
            self.loading = false;
            self.getAll();
          })
          .catch(r => {});
      }
    },

    getDeptos(){
      let self = this;
      self.loading = true;

      self.$store.state.services.departamentoService
        .getAll()
        .then(r => {
          self.loading = false;
          self.itemsDeptos = r.data;
        })
        .catch(r => {});
    },

    getCargo(){
       let self = this;
       self.loading = true;

        self.$store.state.services.cargoService
        .getAll(self.grid.pagination)
        .then(r => {
          self.itemsCargos = r.data.data || [];

          self.loading = false;
        })
        .catch(r => {
          self.grid.items = [];
          self.grid.total = 0;

          self.loading = false;
        });
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