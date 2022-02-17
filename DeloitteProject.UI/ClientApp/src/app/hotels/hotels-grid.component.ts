import { Component, Input, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { IHotel } from '../shared/interfaces';
import { Sorter } from '../core/sorter';
import { TrackByService } from '../core/trackby.service';

@Component({
  selector: 'hotels-grid',
  templateUrl: './hotels-grid.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HotelsGridComponent implements OnInit {

  @Input() hotels: IHotel[] = [];

  constructor(private sorter: Sorter, public trackby: TrackByService) { }

  ngOnInit() {

  }

  sort(prop: string) {
    this.sorter.sort(this.hotels, prop);
  }

}
