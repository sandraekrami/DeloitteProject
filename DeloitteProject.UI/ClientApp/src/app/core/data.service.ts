import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpErrorResponse } from '@angular/common/http';

import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { IHotel } from '../shared/interfaces';
/* 
    ##### PLEASE NOTE ######

    1. This code has been updated to use the HttpClient service that's part of Angular 4.3+
       Http and HttpModule have been deprecated
    2. RxJS has been updated to the latest version which uses pipe() rather than operator chaining
    3. The original file shown in the Pluralsight course is also available if you want it: data.service.ts.http
    
    #####
*/
@Injectable()
export class DataService {

  baseUrl: string = '/api/hotel';
  baseStatesUrl: string = '/api/states'

  constructor(private http: HttpClient) {

  }

  getHotels(): Observable<IHotel[]> {
    var hotels = [{
      id: 1,
      name: 'name',
      location: 'loc',
      description: 'desc',
      ranking: 1
    }];

    return Observable.create(hotels);
    
    //return this.http.get<IHotel[]>(this.baseUrl)
    //  .pipe(
    //    map((hotels: IHotel[]) => {
    //      return hotels;
    //    }),
    //    catchError(this.handleError)
    //  );
  }

  getRatings(): Observable<number[]> {
    return this.http.get<number[]>(this.baseStatesUrl)
      .pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    console.error('server error:', error);
    if (error.error instanceof Error) {
      let errMessage = error.error.message;
      return Observable.throw(errMessage);
      // Use the following instead if using lite-server
      //return Observable.throw(err.text() || 'backend server error');
    }

    return Observable.throw(error || 'ASP.NET Core server error');
  }
}
