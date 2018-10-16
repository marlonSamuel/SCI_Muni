<template>
<div>
<div>
  <el-radio-group v-model="isCollapse" style="margin-bottom: 20px;">
  <el-radio-button :label="false">expand</el-radio-button>
  <el-radio-button :label="true">collapse</el-radio-button>
</el-radio-group>
</div>
<div>
  <el-menu default-active="0" :collapse="isCollapse">
    <template v-for="item, i in items">
        <el-submenu :index="i.toString()" v-if="item.children !== undefined">
            <template slot="title">
                <i :class="'fa fa-' + item.icon"></i>
                <span>{{ item.text }}</span>
            </template>
            <el-menu-item-group title="Opciones">
                <el-menu-item v-for="child, c in item.children" :index="(i.toString() + c)" @click="redirect(child.path)">
                    <i :class="'fa fa-' + child.icon"></i> <span>{{ child.text }}</span>
                </el-menu-item>
            </el-menu-item-group>    
        </el-submenu>
        <el-menu-item index="2" v-if="item.children === undefined" @click="redirect(item.path)">
            <i :class="'fa fa-' + item.icon"></i>
            <span>{{ item.text }}</span>
        </el-menu-item>
    </template>
</el-menu>
</div>
</div>


</template>

<script>
export default {
  name: "NavegationMenu",
  data: () => ({
    isCollapse: false,
    items: [
      { icon: "dashboard", text: "Dashboard", path: "/" },
      {
        icon: "address-book",
        text: "Recursos Humanos",
        children: [
          { icon: "list", text: "Departamentos", path: "/departamento" },
          { icon: "black-tie", text: "Cargos", path: "/cargo" },
          { icon: "user", text: "Empleados", path: "/empleado" }
        ]
      },

      {
        icon: "product-hunt",
        text: "Almacen",
        children: [
          { icon: "star", text: "Categoria Almacen", path: "/categoriaAlmacen" },
          { icon: "star", text: "Categoria Producto", path: "/categoriaProducto" },
          { icon: "product-hunt", text: "Productos", path: "/producto" }
        ]
      },
      {
        icon: "star",
        text: "Solicitudes",
        children: [
          { icon: "star", text: "Solicitud", path: "Solicitud" }
        ]
      },
      {
        icon: "shopping-cart",
        text: "Pedidos",
        children: [
          { icon: "building", text: "Proveedores", path: "/proveedor" },
          { icon: "shopping-cart", text: "Compras", path: "compra" }
        ]
      },

      {
        icon: "industry",
        text: "Reportes",
        children: [
          { icon: "industry", text: "Reportes", path: "/reporte" }
        ]
      }
    ]
  }),
  methods: {
    redirect(path) {
      if(path === undefined) return;
      this.$router.push(path);
    }
  }
};
</script>