export module HotelModule {

    let hotels: Array<Hotel>;
    hotels.push({
        id: 1,
        name: 'name',
        description: 'desc',
        ranking:1
    });

    export class Hotel {
        id: number;
        name: string;
        description: string;
        ranking: number;
    }

    export interface IPagedResults<T> {
        totalRecords: number;
        results: T;
    }

    export interface IHotelResponse {
        status: boolean;
        hotels: Hotel[];
    }
}
