import { createRouter, createWebHistory } from "vue-router";
import AuthPage from '../views/Auth/AuthPage.vue';
import HomePage from '../views/HomePage.vue';
import CategoryPage from '../views/Admin/CategoryPage.vue';
import BookPage from '../views/Admin/BookPage.vue';






const routes = [
{
    path:'/',
    redirect:'/home',
  },
  {
    path:'/home',
    name:'home',
    component:HomePage,
    meta:{
      title:'home'
    }
  },
  {
    path:'/Auth',
    name:'Auth',
    component:AuthPage,
    meta:{
      title:'Auth'
    }
  },
  {
    path:'/categories',
    name:'categories',
    component:CategoryPage,
    meta:{
      title:'category'
    }
  },
  {
    path:'/categories/:catId',
    name:'book',
    component:BookPage,
    meta:{
      title:'addBook'
    }
  }

];

const router = createRouter({
    history:createWebHistory(),
    routes
});

router.beforeEach((to,_,next)=>{

    document.title = to.meta.title;
    next();
});

export default router;