import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'filter-textbox',
  template: `
    <form>
        <table>
          <tr>
            <td>{{this.name}} Search:</td>
            <td>
              <input type="text" name="filter" maxlength="{{this.maxLength}}"
                  [(ngModel)]="model.filter" 
                  (keyup)="filterChanged($event, this.name)"  />
            </td>
          </tr>        
        </table>            
    </form>
  `
})
export class FilterTextboxComponent {
  model: { filter: string } = { filter: '' };
  @Input() name: string = ''; maxLength: number = 1;
  
  @Output()
  changed: EventEmitter<string> = new EventEmitter<string>();

  filterChanged(event: any, name: string, maxLength: number) {
    this.name = name;
    this.maxLength = maxLength;
    event.preventDefault();
    this.changed.emit(this.model.filter); //Raise changed event
  }
}
