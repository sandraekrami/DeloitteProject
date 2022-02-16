import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { DataFilterService } from '../core/data-filter.service';
import { DataService } from '../core/data.service';
import { IHotel } from '../shared/interfaces';

@Component({
  selector: 'hotels',
  templateUrl: './hotels.component.html'
})
export class HotelsComponent implements OnInit {

  title: string | undefined;
  hotels: IHotel[] = [];
  filteredHotels: IHotel[] = [];

  constructor(private router: Router,
    private dataService: DataService,
    private dataFilter: DataFilterService) { }

  ngOnInit() {
    this.title = 'Hotels';
    this.getHotels();
  }

  nameFilterChanged(nameFilterText: string, name: string) {
    if (nameFilterText && this.hotels) {
      let props = ['name'];
      
      this.filteredHotels = this.dataFilter.filter(this.hotels, props, nameFilterText);
    }
    else {
      this.filteredHotels = this.hotels;
    }
  }

  ratingFilterChanged(ratingFilter: string, name: string) {
    if (ratingFilter && this.hotels) {
      let props = ['rating'];

      this.filteredHotels = this.dataFilter.filterEqualGreaterThan(this.hotels, props, ratingFilter);
    }
    else {
      this.filteredHotels = this.hotels;
    }
  }

  filterChanged(filterText: string, name: string) {
    if (filterText && this.hotels) {
      let props = ['id', 'name', 'description', 'location'];
      this.filteredHotels = this.dataFilter.filter(this.hotels, props, filterText);
    }
    else {
      this.filteredHotels = this.hotels;
    }
  }

  getHotels() {
    this.hotels = this.filteredHotels = [{
      id: 1,
      name: 'Belgrave House',
      location: 'Greater London',
      description: 'London',
      rating: 1
    },
      {
        id: 2,
        name: 'The Breakers',
        location: 'Hampstead',
        description: 'London',
        rating: 2
      },
      {
        id: 3,
        name: 'Mandarin Oriental',
        location: 'Leeds',
        description: 'great place to rlax',
        rating: 5
      },
      {
        id: 4,
        name: 'Downtowner Hotel & Spa',
        location: 'Toronto',
        description: 'The best',
        rating: 5
      }
    ];
    //this.dataService.getHotels()
    //  .subscribe((response: IHotel[]) => {
    //    this.hotels = this.filteredHotels = response;
    //  },
    //    (err: any) => console.log(err),
    //    () => console.log('getHotels() retrieved hotels'));
  }

}
