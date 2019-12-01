import { ProductService } from './../services/product.service';
import { IProduct } from './../models/product';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'pm-products',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit{
  
  constructor(private productService : ProductService)
  {
  }

  pageTitle : string = 'Product list';
  imageWidth: number = 50;
  imageMargin: number = 2;
  showImage: boolean = false;
  _listFilter: string;

  get listFilter() : string{
    return this._listFilter;
  }

  set listFilter(value: string)
  {
    this._listFilter = value;
    this.filteredProducts = this._listFilter ? this.performFilter(value) :  this.products;
  }

  filteredProducts: IProduct[];
  products: IProduct[];

  toggleImage() : void
  {
    this.showImage = !this.showImage;
  }

  ngOnInit(): void {
    console.log("On init");
    this.products = this.productService.getProducts();
    this.filteredProducts = this.products;
  }

  performFilter(value: string): IProduct[] {
    value = value.toLocaleLowerCase();
    return this.products.filter((products: IProduct) =>
    products.productName.toLocaleLowerCase().indexOf(value) !== -1);
  }

  onRatingClicked(massage: string) : void {
    this.pageTitle = 'Product List: '+ massage;
  }
}
