namespace CDExellentAPI.Enums
{
    public class ResponseMessage
    {
        //Success
        public const string SUCCESSFULLY = "Successfully";
        public const string CREATED_SUCCESSFULLY = "Created Successfully";
        public const string UPDATED_SUCCESSFULLY = "Updated Successfully";
        public const string DELETED_SUCCESSFULLY = "Deleted Successfully";

        //Error
        public const string EMPTY = "Empty Data";
        public const string NOT_FOUND = "Not Found";
        public const string DATA_NOT_FOUND = "Data Not Found";
        public const string DUPLICATE_KEY = "Duplicate Key";
        public const string REFERENCE_ERROR = "Reference Error";
    }
}
