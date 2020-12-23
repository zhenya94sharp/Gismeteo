export let tableWeather={
    data(){
        return{
            weatherList:[],
            weather:null,
            date:null
        }
    },
    template:`
        <div>
            <select v-model="weather">
            <option disabled value="">Выберите город...</option>
            <option v-for="weather in weatherList" v-bind:value="weather">{{weather.name}}</option>
            </select> 
              
            <button class="btn btn-danger" v-on:click="weatherLoad">Загрузить погоду</button>

            <select v-if="weather!==null" v-model="date">
            <option disabled value="">Выберите день...</option>
            <option v-for="weather in weather.listTenDaysWeather" v-bind:value="weather.date">{{weather.date}}</option>
            </select>

            <div >
            <table class='table table-striped table-dark'>
            <thead>
                <tr>
                <th scope='col'>День</th>
                <th scope='col'>Температура днём</th>
                <th scope='col'>Температура ночью</th>
                <th scope='col'>Погодные условия</th>
                <th scope='col'>Ветер</th>
                <th scope='col'>Давление</th>
                <th scope='col'>Осадки</th>
                </tr>
            </thead>
            
            <tbody v-if="weather!==null&&date==null">
                <tr v-model="weather" v-for="weather in weather.listTenDaysWeather">
                <td >{{weather.date}}</td>
                <td >{{weather.temperatureDay}}</td>
                <td >{{weather.temperatureNight}}</td>
                <td >{{weather.humidity}}</td>
                <td >{{weather.wind}}</td>
                <td >{{weather.pressure}}</td>
                <td >{{weather.precipitation}}</td>
                </tr>
            </tbody>

            <tbody v-if="date!==null">
                <tr v-model="date" v-for="weather in weather.listTenDaysWeather" v-if="date==weather.date">
                <td >{{weather.date}}</td>
                <td >{{weather.temperatureDay}}</td>
                <td >{{weather.temperatureNight}}</td>
                <td >{{weather.humidity}}</td>
                <td >{{weather.wind}}</td>
                <td >{{weather.pressure}}</td>
                <td >{{weather.precipitation}}</td>
                </tr>
            </tbody>
             </table>
             </div>
        </div>   
    `,
    methods:{
        weatherLoad:async function (){
            let response = await fetch("https://localhost:44389/api/Gismeteo/GetListWeather",
                {
                    method:'GET'
                }
            );
            if(response.ok==true)
            {
                this.weatherList=await response.json()
                alert("Получены данные о погоде");
            }
            else
            {
                alert("При загрузке данных произошла ошибка "+response.status)
            }
        }
    }
}


