<template>
<div>
    <div v-show="gridMode">
    <h2>Departamentos</h2>

    <div class="pull-right">
     <el-button type="success" @click="Nuevo()"><i class="fa fa-plus"> Nuevo</i></el-button>
   </div>

   <el-table v-loading="loading" :data="items" style="width: 100%">
    <el-table-column type="expand">

      <template slot-scope="props">
        <p><b>Nombre:</b> {{ props.row.nombre }}</p>
        <p><b>Descripcion:</b> {{ props.row.descripcion }}</p>
    </template>
    
    </el-table-column>
      <el-table-column prop="nombre" label="Nombre" sortable>
         <template slot-scope="scope">
            {{scope.row.nombre}}
         </template>
      </el-table-column>
      <el-table-column prop="descripcion" label="Descripcion" width="400" sortable></el-table-column>
      <el-table-column align="right" label="opciones">
         <template slot-scope="scope">
            <el-button type="danger" icon="el-icon-delete" size="small" @click="remove(scope.row)"></el-button>
            <el-button type="warning" icon="el-icon-edit" size="small" @click="editar(scope.row)"></el-button>
         </template>
      </el-table-column>
    </el-table>
    </div>
<div v-show="insertMode">
   <h2>{{titulo}}</h2>
    <el-form v-loading ="loading" :model="form" :rules="rules" ref="ruleForm" >
      <el-form-item label="Nombre" prop="nombre">
        <el-input v-model="form.nombre"></el-input>
      </el-form-item>

      <el-form-item label="Descripcion">
        <el-input type="textarea" v-model="form.descripcion"></el-input>
      </el-form-item>

      <el-form-item>
        <el-button type="primary" @click="save"><i class="fa fa-save"></i> Guardar</el-button>
        <el-button type="danger" @click="cancelar"><i class="fa fa-undo"></i> Cancelar</el-button>
      </el-form-item>
    </el-form>
</div>

</div>
</template>

<!--Formulario registros -->

<script>
export default {
  name: "DepartamentoIndex",
  data() {
    return {
      titulo: "Nuevo Registro",
      gridMode: true,
      insertMode: false,
      filter: "",
      loading: false,
      items: [],
      form: {
        id: 0,
        nombre: null,
        descripcion: null
      },
      rules: {
        nombre: [{ required: true, message: "Debe ingresar un nombre" }]
      }
    };
  },

  created() {
    let self = this;
    self.getAll();
  },
  methods: {
    Nuevo() {
      let self = this;
      self.titulo = "Nuevo Registro";
      self.gridMode = false;
      self.insertMode = true;
      let newForm = {
        id: 0,
        nombre: null,
        descripcion: null
      };

      self.mapData(newForm);
    },

    mapData(model) {
      let self = this;
      self.form.id = model.id;
      self.form.nombre = model.nombre;
      self.form.descripcion = model.descripcion;

      console.log(self.form);
    },

    cancelar() {
      let self = this;
      self.gridMode = true;
      self.insertMode = false;
    },

    editar(model) {
      let self = this;
      self.titulo = model.nombre;
      self.mapData(model);
      self.gridMode = false;
      self.insertMode = true;
    },

    getAll() {
      let self = this;
      self.loading = true;

      self.$store.state.services.departamentoService
        .getAll()
        .then(r => {
          self.loading = false;
          self.items = r.data;
        })
        .catch(r => {});
    },

    save() {
      let self = this;
      self.$refs["ruleForm"].validate(valid => {
        if(!valid){
          return;
        }
        let depto = self.form;
        self.loading = true;
        self.$store.state.services.departamentoService
          .save(depto)
          .then(r => {

            self.getAll();
            self.loading = false;
            self.gridMode = true;
            self.insertMode = false;

            if (depto.id > 0) {
              self.message("Departamento actualizado correctamente", "success");
            } else {
              self.message("Departamento insertado correctamente", "success");
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
            "Departamento" + model.nombre + "Eliminado correctamente",
            "success"
          );
        })
        .catch(() => {});

      function _remove() {
        let id = model.id;
        self.loading = true;
        self.$store.state.services.departamentoService
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