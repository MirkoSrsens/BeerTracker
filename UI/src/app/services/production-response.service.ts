import { prodRespGet, prodRespGetByOid } from '../../api/apiUrls';
import { IProductionResponse } from '../models/IProductionResponse';
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductionResponseService {
  constructor(private http: HttpClient) { }

  getAll() : Observable<IProductionResponse[]>{
    return this.http.get<IProductionResponse[]>(prodRespGet).pipe(
      tap(data=> console.log('All' + JSON.stringify(data))),
      catchError(this.handleError)
    )
  }

  getByOid(oid:number) : Observable<IProductionResponse>{
    return this.http.get<IProductionResponse>(prodRespGetByOid + oid.toString()).pipe(
      tap(data=> console.log('All' + JSON.stringify(data))),
      catchError(this.handleError)
    )
  }

  private handleError(err: HttpErrorResponse){
    let errorMessage = '';
    if(err.error instanceof ErrorEvent)
    {
      errorMessage = `An error occurred: ${err.error.message}`;
    }
    else
    {
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`
    }

    console.error(errorMessage);
    return throwError(errorMessage);
  }
}
