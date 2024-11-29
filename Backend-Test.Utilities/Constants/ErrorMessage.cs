namespace Backend_Test.Utilities.Constants
{
    public static class ErrorMessage
    {
        public const string IdNotMatch = "ID mismatch.";
        public const string PurchaseInvalid = "Purchase data is invalid.";
        public const string ProductInvalid = "Product data is invalid.";
        public const string InvalidYearOfBirth = "Customer cannot be born after the current year.";
        public const string NegativeYearOfBirth = "Customer cannot have a birth year below zero";
        public const string NoProductPurchase = "A purchase must contain at least one product.";
        public const string NegativePrice = "Price cannot be negative.";

        // Static methods for dynamic error messages
        public static string PersonNotFoundById(int id) => $"Person with ID {id} not found.";
        public static string ProductNotFoundById(int id) => $"Product with ID {id} not found.";
        public static string PurchaseNotFoundById(int id) => $"Purchase with ID {id} not found.";
        public static string ReportPurchaseNotFoundById(int id) => $"Report for purchase with ID {id} not found.";
        public static string CustomerNotFoundById(long id) => $"Customer with ID {id} not found.";
        
    }
}
