import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'
import store from './store';
import './assets/tailwind.css'
import { library } from "@fortawesome/fontawesome-svg-core";
import { fas } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";

library.add(fas);


const app = createApp(App)

// global components




app.component("font-awesome-icon", FontAwesomeIcon);




app.use(store);


app.mount('#app')
