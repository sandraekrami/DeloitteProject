import { Injectable } from '@angular/core';

@Injectable()
export class DataFilterService {

  filter(datasource: any[], filterProperties: string[], filterData: string) {
    if (datasource && filterProperties && filterData) {
      filterData = filterData.toUpperCase();
      const filtered = datasource.filter(item => {
        let match = false;
        for (const prop of filterProperties) {
          let propVal: any = '';

          if (item[prop]) {
            propVal = item[prop].toString().toUpperCase();
          }
          
          if (propVal.indexOf(filterData) > -1) {
            match = true;
            break;
          }
        };
        return match;
      });
      return filtered;
    }
    else {
      return datasource;
    }
  }
}
