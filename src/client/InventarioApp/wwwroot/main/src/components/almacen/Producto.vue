<template>
<div>
  <el-tabs v-model="selectedTab" @tab-click="tabAlmacen">
     <el-tab-pane
     v-for="(item, index) in itemsCat"
      :key="item.id"
      :label="item.nombre"
      :name="item.id.toString()"
      >
         <h2>{{item.nombre}}</h2>
     </el-tab-pane>
  </el-tabs>
  </div>
</template>


<script>
   
export default {
  name: "producto",
  created() {
    let self = this;
    //self.getAll();
    self.getCategorias();
  },

  data() {
    return {
      titulo: "Nuevo Registro",
      selectedTab: '',
      gridMode: true,
      insertMode: false,
      loading: false,
      itemsCat: [],
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
        descripcion: null
      },
      rules: {
        nombre: [{ required: true, message: "Debe ingresar un nombre" }]
      }
    };
  },
  methods: {

      tabAlmacen(item, event){
          debugger;
        console.log(item.name);
        var id = parseInt(item.name);
        console.log(item.name);
      },
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

    getCategorias() {
      let self = this;
      self.$store.state.services.categoriaAlmacenService
        .getAll(self.grid.pagination)
        .then(r => {
             self.itemsCat = r.data.data || [];
             self.selectedTab = self.itemsCat[0].id.toString()
             self.loading = false;
        })
        .catch(r => {

          self.loading = false;
        });
    }

    /*getAll() {
      let self = this;
      self.loading = true;

      self.$store.state.services.categoriaProductoService
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
        let categoria = self.form;
        self.loading = true;
        self.$store.state.services.categoriaProductoService
          .save(categoria)
          .then(r => {

            self.getAll();
            self.loading = false;
            self.gridMode = true;
            self.insertMode = false;

            if (categoria.id > 0) {
              self.message("Categoria Producto actualizado correctamente", "success");
            } else {
              self.message("Categoria Producto insertado correctamente", "success");
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
            "Categoria " + model.nombre + " Eliminado correctamente",
            "success"
          );
        })
        .catch(() => {});

      function _remove() {
        let id = model.id;
        self.loading = true;
        self.$store.state.services.categoriaProductoService
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
    }*/

  }
};
</script>

