import { ProductionResponseService } from '../../services/production-response.service';
import { IProductionResponse } from '../../models/IProductionResponse';
import { Component, OnInit } from '@angular/core';

@Component({
  templateUrl: './production-response.component.html',
  styleUrls: ['./production-response.component.css']
})
export class ProductionResponseComponent implements OnInit {
  
  _equipmentIdFilter: string;
  _beerInProduction: string;
  prodSegResponses: IProductionResponse[];
  filteredProdSegResponse: IProductionResponse[];
  errMessage : string;
  sortAscending:boolean;
  constructor(private productionSegmentResponseService : ProductionResponseService) 
  { 
    this.sortAscending = false;
  }
  
  get equipmentIdFilter() : string{
    return this._equipmentIdFilter;
  }

  set equipmentIdFilter(value: string)
  {
    this._equipmentIdFilter = value;
    this.filteredProdSegResponse = this._equipmentIdFilter 
    ? this.performFilter(value, this.prodSegResponses, "equipmentId") 
    :  this.prodSegResponses;
  }

  set typeOfBeerFilter(value: string)
  {
    this._beerInProduction = value;
    this.filteredProdSegResponse = this._beerInProduction 
    ? this.performFilter(value, this.prodSegResponses, "beerInProduction") 
    :  this.prodSegResponses;
  }

  ngOnInit() {
    this.productionSegmentResponseService.getAll().subscribe({
      next: prodSegResponses =>
      {
        this.prodSegResponses = prodSegResponses;
        this.filteredProdSegResponse = this.prodSegResponses;
      },
      error: err => this.errMessage = err
    })
  }

  sortByStartDate<T extends object>(collection: T[], propertyToSort: string)
  {
    this.sortAscending = !this.sortAscending;

    if(this.sortAscending)
    {
      this.filteredProdSegResponse.sort((a, b) =>{return b.dateRecieved < a.dateRecieved ? 1 : -1});
    }
    else
    {
      this.filteredProdSegResponse.sort((a, b) =>{return b.dateRecieved > a.dateRecieved ? 1 : -1});
    }
  }

  performFilter<T extends object>(value: string, collection: T[], property:string): T[] {
    value = value.toLocaleLowerCase();
    return collection.filter((single: T) =>
    Reflect.get(single, property).toLocaleLowerCase().indexOf(value) !== -1);
  }
}
