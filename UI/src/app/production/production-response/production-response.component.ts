import { ProductionResponseService } from '../../services/production-response.service';
import { IProductionResponse } from '../../models/IProductionResponse';
import { Component, OnInit } from '@angular/core';
import { Extensions } from 'src/app/extensions/extensions';

@Component({
  templateUrl: './production-response.component.html',
  styleUrls: ['./production-response.component.css']
})
export class ProductionResponseComponent implements OnInit {
  
  _equipmentIdFilter: string;
  _beerInProductionFilter: string;
  prodSegResponses: IProductionResponse[];
  filteredProdSegResponse: IProductionResponse[];
  errMessage : string;
  sortAscending:boolean;
  constructor(private extensions : Extensions, private productionSegmentResponseService : ProductionResponseService) 
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
    ? this.extensions.performFilter(value, this.prodSegResponses, "equipmentId") 
    :  this.prodSegResponses;
  }

  set typeOfBeerFilter(value: string)
  {
    this._beerInProductionFilter = value;
    this.filteredProdSegResponse = this._beerInProductionFilter 
    ? this.extensions.performFilter(value, this.prodSegResponses, "beerInProduction") 
    :  this.prodSegResponses;
  }

  sort<T extends object>(collection: T[], propertyToSort: string, sortAscending)
  {
    this.sortAscending = !sortAscending;
    this.extensions.sortByStartDate(collection, propertyToSort, sortAscending);
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
}
