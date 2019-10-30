export interface UploadModel
{
    Id : number,
    UploadDate? : Date,
    Context : string,
    UserId : number,
    CategoryId : number,
    File: any,
    RatingTypeId : number,
    Anonymous : boolean,
    Active : boolean,
    Deleted : boolean,
    Result : number,
    FileString : string
}