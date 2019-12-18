import { IProductionResponse } from '../../models/IProductionResponse';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductionResponseService } from '../../services/production-response.service';

@Component({
  selector: 'app-production-response-details',
  templateUrl: './production-response-details.component.html',
  styleUrls: ['./production-response-details.component.css']
})
export class ProductionSegmentResponseDetailsComponent implements OnInit {

  pageTitle: string = 'Production segment response detail for process with Oid: ';
  detail: IProductionResponse;
  errMessage : string;
  constructor(private route: ActivatedRoute,
    private router: Router,
    private prodSegRespService : ProductionResponseService) { }

  ngOnInit() {
    let oid = +this.route.snapshot.paramMap.get('oid');
    this.prodSegRespService.getByOid(oid).subscribe({
      next: prodSegResponses =>
      {
        this.detail = prodSegResponses;
      },
      error: err => this.errMessage = err
    })
  }

  onBack(): void{
    this.router.navigate(['/productionSegmentResponse']);
  }
}
