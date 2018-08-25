<template>
  <el-tabs v-model="selectedTab" @tab-click="tabAlmacen">
     <el-tab-pane
     v-for="(item) in itemsCaegoriasAlmacen"
      :key="item.id"
      :label="item.nombre"
      :name="item.id.toString()"
      >
         <h2>{{item.nombre}}</h2>
         <h2>Productos</h2>
            <el-col :span="5">
              <el-input size="medium" v-model="search" placeholder="buscar por nombre" suffix-icon="fa fa-search"></el-input>
            </el-col>
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
          <el-table-column prop="precio" label="Precio Unitario" sortable width="150px">
            <template slot-scope="scope">
               {{scope.row.precio|currency}}
            </template>
          </el-table-column>
          <el-table-column prop="stock" label="Existencia" sortable width="150px">
          </el-table-column>
          <el-table-column label="Estado" sortable width="150px">
            <template slot-scope="scope">
               <b v-if="scope.row.estado == 'D'"><el-tag>Disponible</el-tag></b>
               <b v-if="scope.row.estado == 'P'"><el-tag type="danger">Prestado</el-tag></b>
            </template>
          </el-table-column>
          <el-table-column align="right" label="Agregar" width="100px">
              <template slot-scope="scope">
                  <el-button type="warning" size="medium" @click="send(scope.row)"><i class="fa fa-plus-square" aria-hidden="true"></i></el-button>
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
      itemsCaegoriasAlmacen: [],
      selectedTab: "",
      categoriaId: 0,
      search: '',
      grid: {
        items: [],
        total: 0,
        pagination: {
          rowsPerPage: 6,
          page: 1,
          sortBy: "nombre",
          descending: false
        }
      }
    };
  },
  methods: {
    tabAlmacen(item, event) {
      let self = this;
      var id = parseInt(item.name);
      self.categoriaId = id;
      self.getAll();
    },

    send(producto){
       let self = this;
       var prod = new Object();

       prod.ProductoId = producto.id;
       prod.Id = 0;
       prod.nombre = producto.nombre;
       prod.stock = producto.stock;
       prod.precioCompra = producto.precio;
       prod.cantidad = 0;
       prod.subtotal = producto.precio * prod.cantidad;
       
       this.$emit('clicked', prod);

    },

    getCategorias() {
      let self = this;
      self.$store.state.services.categoriaAlmacenService
        .getAll(self.grid.pagination)
        .then(r => {
          self.itemsCaegoriasAlmacen = r.data.data || [];
          self.selectedTab = self.itemsCaegoriasAlmacen[0].id.toString();
          self.categoriaId = self.itemsCaegoriasAlmacen[0].id;
          self.getAll();
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
  },
  computed: {
    filterProducto: function() {
      let self = this;
      return self.grid.items.filter(producto => {
        return producto.nombre
          .toLowerCase()
          .includes(self.search.toLowerCase());
      });
    }
  }
};
</script>