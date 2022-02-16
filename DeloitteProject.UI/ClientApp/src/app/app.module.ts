import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { DataService } from './core/data.service';
import { DataFilterService } from './core/data-filter.service';
import { Sorter } from './core/sorter';
import { TrackByService } from './core/trackby.service';
import { HotelsComponent } from './hotels/hotels.component';
import { HotelsGridComponent } from './hotels/hotels-grid.component';
import { FilterTextboxComponent } from './shared/filter-textbox.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    HotelsComponent,
    HotelsGridComponent,
    FilterTextboxComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'hotels', component: HotelsComponent },
    ])
  ],
  providers: [DataService, DataFilterService, Sorter, TrackByService],
  bootstrap: [AppComponent]
})
export class AppModule { }
