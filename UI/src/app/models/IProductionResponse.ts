import { IProductionSegmentResponse } from './IProductionSegmentResponse';

export interface IProductionResponse{
    oid: number;
    equipmentId: string;
    dateRecieved: string;
    expectedEndTime: string;
    beerInProduction: string;
    productionSegmentResponses: IProductionSegmentResponse[]
}