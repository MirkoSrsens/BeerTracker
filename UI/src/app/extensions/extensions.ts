import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class Extensions
{  
  public sortByStartDate<T extends object>(collection: T[], propertyToSort: string, sortAscending)
  {
    if(sortAscending)
    {
        collection.sort((a, b) =>{return Reflect.get(b, propertyToSort) < Reflect.get(a, propertyToSort) ? 1 : -1});
    }
    else
    {
        collection.sort((a, b) =>{return Reflect.get(b, propertyToSort) > Reflect.get(a, propertyToSort) ? 1 : -1});
    }
  }

  public performFilter<T extends object>(value: string, collection: T[], property:string): T[] {
    value = value.toLocaleLowerCase();
    return collection.filter((single: T) =>
    Reflect.get(single, property).toLocaleLowerCase().indexOf(value) !== -1);
  }
}