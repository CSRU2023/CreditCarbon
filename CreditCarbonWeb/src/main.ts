import './assets/main.css'

import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'

//bootstrap
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap";

//datepicker
import "@vuepic/vue-datepicker/dist/main.css";
import DatePicker from "./components/DatePicker.vue";

//AgGrid
import "ag-grid-community/styles/ag-grid.css"; // Core grid CSS, always needed
import "ag-grid-community/styles/ag-theme-alpine.css"; // Optional theme CSS
import { AgGridVue } from "ag-grid-vue3";

//fortawesome
import { library } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import {
  faArrowsRotate,
  faCode,
  faUser,
  faArrowRightFromBracket,
  faBars,
  faCheck,
  faTrashCan,
  faPenToSquare,
  faEye,
  faFileLines,
  faPlus,
} from "@fortawesome/free-solid-svg-icons";

library.add(
  faArrowsRotate,
  faCode,
  faUser,
  faArrowRightFromBracket,
  faBars,
  faCheck,
  faTrashCan,
  faPenToSquare,
  faEye,
  faFileLines,
  faPlus
  );


const app = createApp(App)
app.component("ag-grid-vue", AgGridVue)
app.component("font-awesome-icon", FontAwesomeIcon)

// eslint-disable-next-line vue/multi-word-component-names
app.component("date-picker", DatePicker)
app.use(createPinia())
app.use(router)

app.mount('#app')
