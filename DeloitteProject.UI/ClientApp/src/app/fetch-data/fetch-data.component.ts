import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    //http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
    //  this.forecasts = result;
    //}, error => console.error(error));
    this.forecasts = [{
      date: "01/01/2019",
      temperatureC: 1,
      temperatureF: 2,
      summary: ''
    },
      {
        date: "01/01/2020",
        temperatureC: 3,
        temperatureF: 6,
        summary: ''
      }    ]
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
