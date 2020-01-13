import { EquipmentService } from './../services/equipment.service';
import { IEquipment } from './../models/IEquipment';
import { Component, OnInit } from '@angular/core';
import { Extensions } from '../extensions/extensions';

@Component({
  selector: 'app-equipment',
  templateUrl: './equipment.component.html',
  styleUrls: ['./equipment.component.css']
})
export class EquipmentComponent implements OnInit {

  _equipmentIdFilter: string;
  equipments: IEquipment[];
  filteredEquipments: IEquipment[];
  errMessage : string;
  sortAscending:boolean;
  constructor(private extensions : Extensions, private productionSegmentResponseService : EquipmentService) 
  { 
    this.sortAscending = false;
  }
  
  get equipmentIdFilter() : string{
    return this._equipmentIdFilter;
  }

  set equipmentIdFilter(value: string)
  {
    this._equipmentIdFilter = value;
    this.filteredEquipments = this._equipmentIdFilter 
    ? this.extensions.performFilter(value, this.equipments, "id") 
    :  this.equipments;
  }

  ngOnInit() {
    this.productionSegmentResponseService.getAll().subscribe({
      next: prodSegResponses =>
      {
        this.equipments = prodSegResponses;
        this.filteredEquipments = this.equipments;
      },
      error: err => this.errMessage = err
    })
  }

  sort<T extends object>(collection: T[], propertyToSort: string, sortAscending)
  {
    this.sortAscending = !sortAscending;
    this.extensions.sortByStartDate(collection, propertyToSort, sortAscending);
  }
}
