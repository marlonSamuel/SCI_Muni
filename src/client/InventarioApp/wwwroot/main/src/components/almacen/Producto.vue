<template>
<div>
 <div v-show="gridMode">
  <el-tabs v-model="selectedTab" @tab-click="tabAlmacen">
     <el-tab-pane
     v-for="(item, index) in itemsCat"
      :key="item.id"
      :label="item.nombre"
      :name="item.id.toString()"
      >
         <h2>{{item.nombre}}</h2>
         <h2>Productos</h2>
           <el-col :span="5">
              <el-input size="medium" v-model="search" placeholder="buscar por nombre" suffix-icon="fa fa-search"></el-input>
            </el-col>

            <div class="pull-right">
              <el-button type="success" @click="Nuevo()"><i class="fa fa-plus"> Nuevo</i></el-button>
            </div>
          <el-table
          :data="filterProducto"
          :default-sort = "{prop: 'nombre', order: 'ascending'}"
          stripe
          style="width: 100%">
          <el-table-column type="expand">
            <template slot-scope="props">
              <p><b>Nombre:</b> {{ props.row.nombre}}</p>
              <p><b>Categoria Producto:</b> {{ props.row.categoria}}</p>
              <p><b>Precio:</b> {{ props.row.precio | currency}}</p>
          </template>
          </el-table-column>
          <el-table-column prop="nombre" label="Nombre" sortable width="200px">
          </el-table-column>
          <el-table-column prop="precio" label="Precio Unitario" sortable width="200px">
            <template slot-scope="scope">
               {{scope.row.precio|currency}}
            </template>
          </el-table-column>
          <el-table-column prop="stock" label="Existencia" sortable width="200px">
          </el-table-column>
          <el-table-column label="Estado" sortable width="200px">
            <template slot-scope="scope">
               <b v-if="scope.row.estado == 'D'"><el-tag>Disponible</el-tag></b>
               <b v-if="scope.row.estado == 'P'"><el-tag type="danger">Prestado</el-tag></b>
            </template>
          </el-table-column>
          <el-table-column align="right" label="opciones">
              <template slot-scope="scope">
                  <el-button type="danger" icon="el-icon-delete" @click="remove(scope.row)" size="small"></el-button>
                  <el-button type="warning" icon="el-icon-edit" @click="editar(scope.row)" size="small"></el-button>
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
     </el-tab-pane>
  </el-tabs>
</div>

  
 <!--Formulario de registro -->
 <div v-show="insertMode">
     <h2>{{titulo}}</h2>
    <el-form label-position="top" v-loading ="loading" :model="form" :rules="rules" ref="ruleForm">
    
        <el-col :span="11">
          <el-form-item label="Nombre" prop="nombre">
            <el-input v-model="form.nombre"></el-input>
          </el-form-item>
       </el-col>
       <el-col :span="2">&nbsp;</el-col>
        <el-col :span="11">
          <el-form-item label="Categoria Producto" prop="categoriaId">
             <el-select filterable clearable v-model="form.categoriaId" placeholder="Categoria">
                <el-option
                  v-for="item in itemsCatProd"
                  :key="item.id"
                  :label="item.nombre"
                  :value="item.id">
              </el-option>
             </el-select>
        </el-form-item>
       </el-col>

       <el-col :span="6">
          <el-form-item label="Precio" prop="precio">
            <el-input-number v-model="form.precio" :precision="2" :min="0.00"></el-input-number>
          </el-form-item>
       </el-col>
      <el-col :span="6">
          <el-form-item label="Stock Maximo" prop="stock_maximo">
            <el-input-number v-model="form.stock_maximo" :min="0"></el-input-number>
          </el-form-item>
       </el-col>
        <el-col :span="6">
          <el-form-item label="Stock Minimo" prop="stock_minimo">
            <el-input-number v-model="form.stock_minimo" :min="0"></el-input-number>
          </el-form-item>
       </el-col>
        <el-col :span="6">
          <el-form-item label="Existencia Actual" prop="stock">
           <el-input-number v-model="form.stock" :min="0"></el-input-number>
          </el-form-item>
       </el-col>

          <el-col>
            <el-form-item label="Descripcion" prop="descripcion">
                 <el-input type="textarea" :rows="2" v-model="form.descripcion" :min="0"></el-input> 
          </el-form-item>
          </el-col>

   <el-col>
      <el-form-item>
        <el-button type="primary" @click="save" ><i class="fa fa-save"></i> Guardar</el-button>
        <el-button type="danger" @click="cancelar"><i class="fa fa-undo"></i> Cancelar</el-button>
      </el-form-item>
   </el-col>

    </el-form>
</div>
  </div>

  
</template>


<script>
   
export default {
  name: "producto",
  created() {
    let self = this;
    self.getCategorias();
  },

  data() {
    return {
      titulo: "Nuevo Registro",
      selectedTab: '',
      gridMode: true,
      insertMode: false,
      search: '',
      loading: false,
      itemsCat: [],
      itemsCatProd: [],
      categoriaId: null,
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
        categoriaId: 0,
        almacenId: 0,
        nombre: null,
        stock_maximo: null,
        stock_minimo: null,
        descripcion: null,
        precio: 0,
        stock: null,
        estado: null,
      },
      rules: {
        categoriaId: [{ required: true, message: "Debe ingresar una categoria" }],
        nombre: [{ required: true, message: "Debe ingresar un nombre" }],
        stock_maximo: [{ required: true, message: "Debe ingresar un stock maximo" }],
        stock_minimo: [{ required: true, message: "Debe ingresar un stock minimo" }],
        stock: [{ required: true, message: "Debe ingresar un stock" }],
        precio: [{ required: true, message: "Debe ingresar un precio" }],
      }
    };
  },
  methods: {
      tabAlmacen(item, event){
        let self = this;
        var id = parseInt(item.name);
        self.categoriaId = id;
        self.getAll();
      },
    Nuevo() {
      let self = this;
      self.titulo = "Nuevo Registro";
      self.gridMode = false;
      self.insertMode = true;
      let newForm = {
        id: 0,
        almacenId: 0,
        categoriaId: 0,
        nombre: null,
        stock_Maximo: null,
        stock_Minimo: null,
        precio: 0,
        stock: null,
        descripcion: null,
        estado: 'A'
      };
     
      self.mapData(newForm);
    },

    mapData(model) {
      let self = this;
      self.form.id = model.id;
      self.form.categoriaId = model.categoriaId;
      self.form.nombre = model.nombre;
      self.form.descripcion = model.descripcion;
      self.form.stock_maximo = model.stock_Maximo;
      self.form.stock_minimo = model.stock_Minimo;
      self.form.stock = model.stock;
      self.form.precio = model.precio;
      self.form.almacenId = model.almacenId;
      self.form.estado = model.estado;

      self.getCategoriasProductos(self.categoriaId);
    },

    editar(model) {
      let self = this;
      debugger;
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
             self.selectedTab = self.itemsCat[0].id.toString();
             self.categoriaId = self.itemsCat[0].id;

             self.getAll();
             self.loading = false;
        })
        .catch(r => {

          self.loading = false;
        });
    },

    getCategoriasProductos(id) {
      let self = this;
      self.$store.state.services.categoriaProductoService
        .getByAlmacen(id)
        .then(r => {
            self.itemsCatProd = r.data || [];
             self.loading = false;
        })
        .catch(r => {

          self.loading = false;
        });
    },

    getAll() {
      let self = this;
      self.loading = true;
      self.$store.state.services.productoService
        .getAll(self.grid.pagination, self.categoriaId)
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
        let producto = self.form;
        self.loading = true;
        self.$store.state.services.productoService
          .save(producto)
          .then(r => {
            self.getAll();
            self.loading = false;
            self.gridMode = true;
            self.insertMode = false;

            if (producto.id > 0) {
              self.message("producto Actualizado correctamente", "success");
            } else {
              self.message("producto insertado correctamente", "success");
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
            "Producto " + model.nombre + " Eliminado correctamente",
            "success"
          );
        })
        .catch(() => {});

      function _remove() {
        let id = model.id;
        let idAlmacen = model.almacenId
        self.loading = true;
        self.$store.state.services.productoService
          .remove(id, idAlmacen)
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

  },
  computed: {
      filterProducto: function(){
        let self = this;
        return self.grid.items.filter((producto) =>{
           return producto.nombre.toLowerCase().includes(self.search.toLowerCase());
        });
      }
    }
};
</script>

