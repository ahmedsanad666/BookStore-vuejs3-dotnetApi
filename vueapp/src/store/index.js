import {createStore} from 'vuex';
import authModule from './Modules/auth/index';
const store = createStore({
modules:{
auth:authModule,
},
    state(){},

    
})


export default store;