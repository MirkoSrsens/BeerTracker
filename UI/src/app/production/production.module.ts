import { RouterModule } from '@angular/router';
import { ProductionResponseComponent } from './production-response/production-response.component';
import { ProductionSegmentResponseDetailsComponent } from './production-response-details/production-response-details.component';
import { SharedModule } from '../shared/shared.module';
import { NgModule } from '@angular/core';

@NgModule({
    declarations: [
        ProductionResponseComponent,
        ProductionSegmentResponseDetailsComponent
    ],
    imports: [
      RouterModule.forChild([
        {path: 'productionSegmentResponse', component: ProductionResponseComponent},
        {path: 'productionSegmentResponse/:oid', component: ProductionSegmentResponseDetailsComponent},
      ]),
      SharedModule
    ]
  })
  export class ProductionModule { }