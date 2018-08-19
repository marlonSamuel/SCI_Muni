class globalService {

    message(message, type){
        let self = this;
       return self.$message({
              message: message,
              type: type
          });
      }
   
}

export default globalService