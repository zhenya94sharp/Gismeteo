import { tableWeather } from "./tableWeather.js";

let vm = new Vue({
    el: "#tw",
    components: {
        "table-weather": tableWeather
    }
});