import { createRouter, createWebHistory } from "vue-router";






const routes = [

    {
        path:'/',
        redirect:'/home'
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