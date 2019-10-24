export interface UploadModel
{
    Id? : number,
    UploadDate? : Date,
    Context : string,
    UserId : number,
    CategoryId : number,
    File: string,
    LimiteDate? : Date,
    RatingTypeId : number,
    Anonymous : boolean,
    Active : boolean,
    Deleted : boolean,
    Category : Category,
    RatingType : any,
    Result : number
}