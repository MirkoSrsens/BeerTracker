export interface IEquipment{
    oid: number;
    id: string;
    state: string;
    currentCapacity: number;
    maxCapacity: number;
    lastInspectionDate: string;
}