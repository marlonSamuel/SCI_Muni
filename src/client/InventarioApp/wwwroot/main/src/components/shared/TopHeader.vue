<template>
  <el-row>
    <el-col :span="10">
      <h1 @click="goTo('/')"><a href="#"><i class="fa fa-home"></i>SCI-MuniTecuaco</a></h1>
    </el-col>
    <el-col :span="10" class="text-right user-options">
      <a href="#" class="item">
        <i class="fa fa-user">  {{ user.Primer_Nombre + " " + user.Primer_apellido  }} 
          <el-dropdown>
     <span class="el-dropdown-link">
         <i class="el-icon-arrow-down el-icon--right"></i>
      </span>
         <el-dropdown-menu slot="dropdown">
            <el-dropdown-item>Perfil</el-dropdown-item>
            <el-dropdown-item>     
               <a class="item" href="/auth/logout">
                  <i class="fa fa-sign-out-alt">Salir</i>
               </a></el-dropdown-item>
          </el-dropdown-menu>
       </el-dropdown></i>
      </a>
    </el-col>
  </el-row>
</template>

<style>
#header {
  height: 60px;
  line-height: 60px;
  background: black;
  border-bottom: 1px solid #ccc;
  box-shadow: 0px 0px 15px 0px #eee;
}

#header h1 {
  margin: 0;
}

#header h1 a {
  text-decoration: none;
  color: #fff;
}

#header .user-options a {
  color: #fff;
  text-decoration: none;
}

#header .user-options .item {
  font-size: 1.5em;
  padding: 5px 15px;
  border-radius: 10px;
  margin-right: 5px;
  margin-left: 500px;
}

#header .user-options .item:hover {
  background: black;
}

#header .el-header .user-options .item:last-child {
  margin-right: 0;
}

  .el-dropdown-link {
    color: white;
  }
  .el-icon-arrow-down {
    margin-left: 20px;
    font-size: 25px;
  }

</style>

<script>
export default {
  name: "TopHeader",
  data: () => ({
    user: window.User
  }),
  methods: {
    goTo(path) {
      debugger;
      if (path === undefined) return;
      this.$router.push(path);
    }
  }
};
</script>