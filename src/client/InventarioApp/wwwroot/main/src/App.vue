<template>
<el-container>
  <el-header id="header">
    <topHeader></topHeader>
  </el-header>
  <el-container>
    <el-aside style="width:240px;">
      <navegationmenu></navegationmenu>
    </el-aside>
    <el-container>
      <el-main>
        <el-row>
          <el-col :span="24">
            <router-view :key="$route.fullPath"></router-view>
          </el-col>
        </el-row>
      </el-main>
      <el-footer>© <a target="_blank" href="#">{{ 'Control de Inventario Municipalidad de San juan Tecuaco ' + new Date().getFullYear() }}</a></el-footer>
    </el-container>
  </el-container>
</el-container>
</template>

<script>
import navegationmenu from "@/components/shared/NavegationMenu";
import topHeader from "@/components/shared/TopHeader";

export default {
  components: {
    navegationmenu,
    topHeader
  },
  props: {
    source: String
  }
};
</script>