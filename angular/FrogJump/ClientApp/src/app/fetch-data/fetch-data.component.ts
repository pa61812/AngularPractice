import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public currentBMI: number = 0;
  public height: number = 0;
  public weight: number = 0;
  public url = '';
  public Http: HttpClient;


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
    this.Http = http;
  }
  
  public incrementBMI() {
    var intweight = this.weight
    var intheight = this.height
    var xhttp = new XMLHttpRequest();
    var obj = {
        height: intheight
      , weight: intweight
    };
    debugger;
    //把這段寫完讓BMI計算出來的結果取到小數第二位
    //已經在Controllers底下幫你加了BMIController，裡面有個CalBMI的方法，你只要這邊能把參數丟過去就能算出答案了...
    xhttp.open("POST", "/BMI/CalBMI", true);
    xhttp.setRequestHeader("Content-Type", "application/json");
    var intcurrentBMI = xhttp.send(JSON.stringify(obj));
     
    this.currentBMI = Math.floor(intcurrentBMI * 100) / 100;
  }
}

