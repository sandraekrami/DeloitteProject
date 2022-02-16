import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpErrorResponse } from '@angular/common/http';

import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { IHotel } from '../shared/interfaces';

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
      rating: 1
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
    }

    return Observable.throw(error || 'API Error');
  }
}
