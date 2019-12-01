import { IProduct } from './../models/product';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class ProductService {

    getProducts() : IProduct[]{
        return [
            {
              "productId": 2,
              "productName": "Test product",
              "productCode": "1234-fffgd",
              "releaseData": "14-03-1996",
              "description": "This is just for testing dont consdier it",
              "price": 123.32,
              "starRating": 4.2,
              "imageUrl": "assets/images/lmao.png"
            },
            {
              "productId": 12,
              "productName": "Something new product",
              "productCode": "fe4g5-6b56yb",
              "releaseData": "11-03-2007",
              "description": "Neverming this thing",
              "price": 321434.32,
              "starRating": 2.2,
              "imageUrl": "assets/images/lmao.png"
            }]
    }
}