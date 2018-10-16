<template>
<div class="custom-container">
 <div class="form-group container card">
<h4>Historial</h4>
  <el-table
    :data="grid.items"
    :default-sort = "{prop: 'nombre', order: 'ascending'}"
    stripe
    style="width: 100%">
    <el-table-column type="expand">
      <template slot-scope="props">
        <p><b>Fecha Solicitud:</b> {{ props.row.fecha_solicitud }}</p>
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
                    <el-button type="primary" icon="el-icon-view" size="small" @click="ver(scope.row)"></el-button>
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

</div>
</template>

<script>
export default {
  name: "historial",
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
        descripcion: null
      },
      rules: {
        nombre: [{ required: true, message: "Debe ingresar un nombre" }]
      }
    };
  },
  methods: {
    ver(model) {
      let self = this;
      self.$emit('clicked', model);
    },

    cancelar() {
      let self = this;
      self.gridMode = true;
      self.insertMode = false;
    },

    getAll() {
      let self = this;
      self.loading = true;

      self.$store.state.services.solicitudService
        .getAll(self.grid.pagination,'F')
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