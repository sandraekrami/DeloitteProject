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
      name: 'name',
      location: 'loc',
      description: 'desc',
      ranking: 1
    },
      {
        id: 2,
        name: 'name 2',
        location: 'loc 2',
        description: 'desc 2',
        ranking: 2
      }    ];
    //this.dataService.getHotels()
    //  .subscribe((response: IHotel[]) => {
    //    this.hotels = this.filteredHotels = response;
    //  },
    //    (err: any) => console.log(err),
    //    () => console.log('getHotels() retrieved hotels'));
  }

}
