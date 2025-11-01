namespace RapidERP.Domain.Utilities;

public static class ResponseMessage
{
    public const string CreateSuccess = "Record Created Successfully";
    public const string CreateFailed = "Failed to Create Record";
    public const string UpdateSuccess = "Record Updated Successfully";
    public const string UpdateFailed = "Failed to Update Record";
    public const string DeleteSuccess = "Record Deleted Successfully";
    public const string DeleteFailed = "Failed to Delete Record";
    public const string NoRecordFound = "No Record Found";
    public const string RecordExists = "Record exists already. Try with a different one please";
    public const string WrongDataInput = "Wrong Data Entered";
    public const string FetchSuccess = "Fetched All Data Successfully";
    public const string FetchSuccessWithPagination = "Fetched All Paginated Data Successfully";
}
