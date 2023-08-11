export default {
    userId(state) {
      return state.userId;
    },
    token(state){
      return state.token;
    },
    isAuthenticated(state){
      return !!state.token;
    },
    isAdmin(state){
      return state.role == 1 ;
    },
    test(state){
      console.log(state.userId);
      
    }

  };
   