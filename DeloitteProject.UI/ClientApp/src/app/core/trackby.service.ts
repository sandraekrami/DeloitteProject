import { Injectable } from '@angular/core';
import { IHotel } from '../shared/interfaces';

@Injectable()
export class TrackByService {

  hotel(index: number, hotel: IHotel) {
    return hotel.ranking;
  }
}
