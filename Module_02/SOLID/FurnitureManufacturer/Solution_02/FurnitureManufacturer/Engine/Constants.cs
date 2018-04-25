namespace FurnitureManufacturer.Engine
{
    public class Constants
    {
        public virtual string InvalidCommandErrorMessage => "Invalid command name: {0}";
        public virtual string CompanyExistsErrorMessage => "Company {0} already exists";
        public virtual string CompanyNotFoundErrorMessage => "Company {0} not found";
        public virtual string FurnitureNotFoundErrorMessage => "Furniture {0} not found";
        public virtual string FurnitureExistsErrorMessage => "Furniture {0} already exists";
        public virtual string InvalidChairTypeErrorMessage => "Invalid chair type: {0}";
        public virtual string FurnitureIsNotAdjustableChairErrorMessage => "{0} is not adjustable chair";
        public virtual string FurnitureIsNotConvertibleChairErrorMessage => "{0} is not convertible chair";

        public virtual string CompanyCreatedSuccessMessage => "Company {0} created";
        public virtual string FurnitureAddedSuccessMessage => "Furniture {0} added to company {1}";
        public virtual string FurnitureRemovedSuccessMessage => "Furniture {0} removed from company {1}";
        public virtual string TableCreatedSuccessMessage => "Table {0} created";
        public virtual string ChairCreatedSuccessMessage => "Chair {0} created";
        public virtual string ChairHeightAdjustedSuccessMessage => "Chair {0} adjusted to height {1}";
        public virtual string ChairStateConvertedSuccessMessage => "Chair {0} converted";
    }
}
