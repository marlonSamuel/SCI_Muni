<template>
<div class="custom-container">
 <div v-show="gridMode">
<h2>Proveedores</h2>

  <el-col :span="12">
<el-autocomplete
   suffix-icon="fa fa-search"
  :fetch-suggestions="querySearchAsync"
  placeholder="Buscar por nombre"
></el-autocomplete>
  </el-col>
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
        <p><b>Nombre:</b> {{ props.row.nombre }}</p>
        <p><b>Telefono:</b> {{ props.row.telefono }}</p>
        <p><b>Direccion:</b> {{ props.row.direccion }}</p>
    </template>
    </el-table-column>
    <el-table-column prop="nombre" label="Nombre" sortable width="200px"></el-table-column>
    <el-table-column prop="telefono" label="telefono" sortable></el-table-column>
     <el-table-column prop="direccion" label="direccion" sortable></el-table-column>
    <el-table-column prop="email" label="email" sortable></el-table-column>
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
    <el-form v-loading ="loading" :model="form" :rules="rules" ref="ruleForm" >

        <el-col :span="11">
          <el-form-item label="Nombre" prop="nombre">
            <el-input v-model="form.nombre"></el-input>
          </el-form-item>
       </el-col>
       <el-col :span="2">&nbsp;</el-col>
        <el-col :span="11">
          <el-form-item label="Telefono" prop="telefono">
            <el-input v-model="form.telefono"></el-input>
          </el-form-item>
       </el-col>
        <el-col :span="11">
          <el-form-item label="Email" prop="email" >
            <el-input v-model="form.email"></el-input>
          </el-form-item>
       </el-col>
       <el-col :span="2">&nbsp;</el-col>
       <el-col :span="11">
          <el-form-item label="Nit" prop="nit" >
            <el-input v-model="form.nit"></el-input>
          </el-form-item>
       </el-col>
        <el-col :span="24">
          <el-form-item label="Direccion" prop="direccion" >
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
  name: "proveedor",
  created() {
    let self = this;
    self.getAll();
  },
  props: {
    Url: {
      type: String,
      default: null
    }
  },
  data() {
    return {
      titulo: "Nuevo Registro",
      gridMode: true,
      insertMode: false,
      loading: false,
      itemsTemp: [],
      grid: {
        items: [],
        total: 0,
        pagination: {
          rowsPerPage: 6,
          page: 1,
          sortBy: "nombre",
          descending: false
        },
      },
     form: {
        id: 0,
        nombre: null,
        telefono: null,
        direccion:null,
        email: null,
        nit: null
      },
      rules: {
        nombre: [{ required: true, message: "Debe ingresar un nombre" }],
        telefono: [{ required: true, message: "Debe ingresar un numero de telefono" }],
        direccion: [{ required: true, message: "Debe ingresar una direccion" }],
        email: [{ required: true, message: "Debe ingresar un correo electronico" }]
      }
    };
  },
  methods: {
      querySearchAsync(queryString, cb) {
        let self = this;
        var links = self.itemsTemp;
        var results = queryString ? links.filter(this.createFilter(queryString)) : links;

        clearTimeout(this.timeout);
        this.timeout = setTimeout(() => {
          self.grid.items = results;
          cb(results);
        });
      },
      createFilter(queryString) {
        return (link) => {
          return (link.nombre.toLowerCase().indexOf(queryString.toLowerCase()) === 0);
        };
      },

    Nuevo() {
      let self = this;
      self.titulo = "Nuevo Registro";
      self.gridMode = false;
      self.insertMode = true;
      let newForm = {
        id: 0,
        nombre: null,
        direccion: null,
        email: null,
        telefono: null,
        nit: null
      };

      self.mapData(newForm);
    },

    mapData(model) {
      let self = this;
      self.form.id = model.id;
      self.form.nombre = model.nombre;
      self.form.telefono = model.telefono;
      self.form.direccion = model.direccion;
      self.form.email = model.email;
      self.form.nit = model.nit
    },

    editar(model) {
      let self = this;
      self.titulo = model.nombre;
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

      self.$store.state.services.proveedorService
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
        if(!valid){
          return;
        }
        let proveedor = self.form;
        self.loading = true;
        self.$store.state.services.proveedorService
          .save(proveedor)
          .then(r => {

            self.getAll();
            self.loading = false;
            self.gridMode = true;
            self.insertMode = false;

            if (cargo.id > 0) {
              self.message("Proveedor actualizado correctamente", "success");
            } else {
              self.message("Proveedor insertado correctamente", "success");
            }
          })
          .catch(r => {});
      });
    },

     remove(model) {
      let self = this;
      this.$confirm("Esta seguro de eliminar a " + model.nombre + "?", {
        confirmButtonText: "Si",
        cancelButtonText: "Cancelar",
        type: "warning"
      })
        .then(() => {
          _remove();
          self.message(
            "Cargo" + model.nombre + "Eliminado correctamente",
            "success"
          );
        })
        .catch(() => {});

      function _remove() {
        let id = model.id;
        self.loading = true;
        self.$store.state.services.proveedorService
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