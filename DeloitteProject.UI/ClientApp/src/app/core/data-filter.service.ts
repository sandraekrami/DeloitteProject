import { Injectable } from '@angular/core';

@Injectable()
export class DataFilterService {

  isNumber(n: string) {
    return !isNaN(parseFloat(n));
  }

  filter(datasource: any[], filterProperties: string[], keyword: string) {
    if (datasource && filterProperties && keyword) {
      keyword = keyword.toUpperCase();
      const filtered = datasource.filter(item => {
        let match = false;
        for (const prop of filterProperties) {
          let propVal: any = '';

          if (item[prop]) {
            propVal = item[prop].toString().toUpperCase();
          }

          if (propVal.indexOf(keyword) > -1) {
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
  };

  filterEqualGreaterThan(datasource: any[], filterProperties: string[], keyword: string) {
    let isNumeric = this.isNumber(keyword);

    if (datasource && filterProperties && keyword && isNumeric) {
      const filtered = datasource.filter(item => {
        let match = false;
        for (const prop of filterProperties) {
          let propVal: any = '';

          if (item[prop]) {
            propVal = item[prop];
          }

          if (propVal >= keyword) {
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
