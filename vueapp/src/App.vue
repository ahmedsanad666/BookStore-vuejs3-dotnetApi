

<template>

<div class="main min-h-screen ">
  <nav-bar v-if="navBar"/>
  <router-view/>
  <the-footer v-if="Footer" />
</div>
</template>

<script>
import { fas } from '@fortawesome/free-solid-svg-icons';


export default {
  
  data(){
    return{
      navBar:true,
     Footer :true,

    }

  },
  computed:{},
  methods:{

    hideFooter(){
     
      let currentRouter =this.$router.currentRoute.value.name;

     if(currentRouter == 'Auth'){
      this.Footer = false;
      this.navBar = false;
      
     }
    }

  },
  watch:{

    $route(to,from){
     this.hideFooter();
    }
    },
  
  created(){
    this.hideFooter();
    this.$store.dispatch('auth/tryLogin');

  }

}
</script>


<style src="./assets/tailwind.css">

</style>
