export interface UploadModel
{
    id? : number,
    uploadDate? : Date,
    context : string,
    userId? : number,
    categoryId : number,
    ratingTypeId : number,
    anonymous? : boolean,
    active? : boolean,
    deleted? : boolean,
    result : number,
    fileString : string,
    limitDate? : Date
}