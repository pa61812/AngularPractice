import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public currentBMI:number = 0;
  public height:number = 0;
  public weight: number = 0;

  public incrementBMI() {
    //debugger;
    var intweight = this.weight
    var intheight = this.height
    var intcurrentBMI = this.currentBMI
    //var intweight = 80
    //var intheight = 170
    //把這段寫完讓BMI計算出來的結果取到小數第二位
    intcurrentBMI = intweight / ((intheight / 100.00) * (intheight / 100.00))
    intcurrentBMI = Math.floor(intcurrentBMI * 100) / 100
    this.currentBMI = intcurrentBMI
  }
}
