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

  nameFilterChanged(nameFilterText: string, name: string, maxLength: number) {
    if (nameFilterText && this.hotels) {
      let props = ['name'];
      
      this.filteredHotels = this.dataFilter.filter(this.hotels, props, nameFilterText);
    }
    else {
      this.filteredHotels = this.hotels;
    }
  }

  rankingFilterChanged(rankingFilter: string, name: string, maxLength: number) {
    if (rankingFilter && this.hotels) {
      let props = ['ranking'];

      this.filteredHotels = this.dataFilter.filterEqualGreaterThan(this.hotels, props, rankingFilter);
    }
    else {
      this.filteredHotels = this.hotels;
    }
  }

  filterChanged(filterText: string, name: string, maxLength: number) {
    if (filterText && this.hotels) {
      let props = ['id', 'name', 'description', 'location'];
      this.filteredHotels = this.dataFilter.filter(this.hotels, props, filterText);
    }
    else {
      this.filteredHotels = this.hotels;
    }
  }

  getHotels() {
    this.dataService.getHotels()
      .subscribe((response: IHotel[]) => {
        this.hotels = this.filteredHotels = response;
      },
        (err: any) => console.log(err),
        () => console.log('getHotels() retrieved hotels'));
  }

}
