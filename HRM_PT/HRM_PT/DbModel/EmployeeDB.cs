using SQLite;
namespace HRM_PT.DbModel;

    [Table("employee_tb")]
    public class EmployeeDB
    {
    [PrimaryKey, Unique]
    public string identificationStaffID { get; set; }

    [MaxLength(20), Unique]
    public string identificationSocialSecurity { get; set; }

    [MaxLength(20)]
    public string identificationNHIS { get; set; }

    [MaxLength(20)]
    public string identificationIntPassport { get; set; }

    [MaxLength(20)]
    public string identificationVotersID { get; set; }

    [MaxLength(20)]
    public string identificationNationalID { get; set; }

    [MaxLength(100)]
    public string identificationDriversLicense { get; set; }

    [MaxLength(100)]
    public string employeeDetialsSurname { get; set; }

    [MaxLength(100)]
    public string employeeDetialsFirstName { get; set; }

    [MaxLength(100)]
    public string employeeDetialsMiddleName { get; set; }

    [MaxLength(100)]
    public string employeeDetialsDirectorate { get; set; }

    [MaxLength(100)]
    public string employeeDetialsDepartment { get; set; }

    [MaxLength(100)]
    public string employeeDetialsUnit { get; set; }

    [MaxLength(200)]
    public string employeeDetialsImmediateSupervisor { get; set; }

    [MaxLength(100)]
    public string employeeDetialsCostCenter { get; set; }

    [MaxLength(100)]
    public string employeeDetialsJobClass { get; set; }

    [MaxLength(100)]
    public string employeeDetialsJobTitle { get; set; }

    [MaxLength(100)]
    public string employeeDetialsJobGrade { get; set; }

    [MaxLength(100)]
    public string employeeDetialsGradeLevel { get; set; }

    [MaxLength(100)]
    public string employeeDetialsGradePoint { get; set; }

    [MaxLength(100)]
    public string bankDetialsBankName { get; set; }

    [MaxLength(100)]
    public string bankDetialsBankBranchName { get; set; }

    [MaxLength(100)]
    public string bankDetialsBankAccount { get; set; }

    [MaxLength(100)]
    public string biographicalDataMaidenName { get; set; }

    [MaxLength(100)]
    public string biographicalDataPlaceOfBirth { get; set; }

    [MaxLength(100)]
    public string biographicalDataHomeTown { get; set; }

    [MaxLength(100)]
    public string biographicalDataReligion { get; set; }

    [MaxLength(100)]
    public string residentialHouseNo { get; set; }

    [MaxLength(100)]
    public string residentialStreetName { get; set;}

    [MaxLength(100)]
    public string residentialArea { get; set; }

    [MaxLength(100)]
    public string residentialTownCity { get; set; }

    [MaxLength(100)]
    public string otherPostalAddress { get; set; }

    [MaxLength(100)]
    public string otherEmailAddress { get; set; }

    [MaxLength(100)]
    public string otherPhoneNo { get; set; }

    [MaxLength(20)]
    public string otherMobileNo { get; set; }

    [MaxLength(5)]
    public string disableState { get; set; }

    [MaxLength(500)]
    public string disableReason { get; set; }

    [MaxLength(100)]
    public string nextOfKinSurname { get; set; }

    [MaxLength(100)]
    public string nextOfKinFirstName { get; set; }

    [MaxLength(100)]
    public string nextOfKinRelationship { get; set; }

    [MaxLength(100)]
    public string nextOfKinContactHouseNo { get; set; }

    [MaxLength(100)]
    public string nextOfKinContactStreetName { get; set; }

    [MaxLength(100)]
    public string nextOfKinContactArea { get; set; }

    [MaxLength(100)]
    public string nextOfKinContactCityTown { get; set; }

    [MaxLength(20)]
    public string nextOfKinContactPhoneNo { get; set; }

    [MaxLength(100)]
    public string dependant1Surname { get; set; }

    [MaxLength(100)]
    public string dependant1FirstName { get; set; }

    [MaxLength(100)]
    public string dependant1MiddleName { get; set; }

    [MaxLength(100)]
    public string dependant1Relationship { get; set; }

    [MaxLength(100)]
    public string dependant2Surname { get; set; }

    [MaxLength(100)]
    public string dependant2FirstName { get; set; }

    [MaxLength(100)]
    public string dependant2MiddleName { get; set; }

    [MaxLength(100)]
    public string dependant2Relationship { get; set; }

    [MaxLength(100)]
    public string dependant3Surname { get; set; }

    [MaxLength(100)]
    public string dependant3FirstName { get; set; }

    [MaxLength(100)]
    public string dependant3MiddleName { get; set; }

    [MaxLength(100)]
    public string dependant3Relationship { get; set; }

    [MaxLength(100)]
    public string dependant4Surname { get; set; }

    [MaxLength(100)]
    public string dependant4FirstName { get; set; }

    [MaxLength(100)]
    public string dependant4MiddleName { get; set; }

    [MaxLength(100)]
    public string dependant4Relationship { get; set; }

    [MaxLength(100)]
    public string dependant5Surname { get; set; }

    [MaxLength(100)]
    public string dependant5FirstName { get; set; }

    [MaxLength(100)]
    public string dependant5MiddleName { get; set; }

    [MaxLength(100)]
    public string dependant5Relationship { get; set; }

    [MaxLength(200)]
    public string educationInstitutionName { get; set; }

    [MaxLength(300)]
    public string educationQualificationObtained { get; set; }

    [MaxLength(300)]
    public string educationCourseStudied { get; set; }

    [MaxLength(300)]
    public string educationEntryCertificate { get; set; }

    [MaxLength(200)]
    public string skills1Type { get; set; }

    [MaxLength(200)]
    public string skills2Type { get; set; }

    [MaxLength(200)]
    public string skills3Type { get; set; }

    [MaxLength(300)]
    public string skills1InstitutionName { get; set; }

    [MaxLength(300)]
    public string skills2InstitutionName { get; set; }

    [MaxLength(300)]
    public string skills3InstitutionName { get; set; }

    [MaxLength(300)]
    public string association1Name { get; set; }

    [MaxLength(300)]
    public string association2Name { get; set; }

    [MaxLength(300)]
    public string association3Name { get; set; }

    [MaxLength(150)]
    public string language1Name { get; set; }

    [MaxLength(150)]
    public string language2Name { get; set; }

    [MaxLength(150)]
    public string language3Name { get; set; }

    [MaxLength(100)]
    public string identificationIntPassportExpiryDate { get; set; }

    [MaxLength(100)]
    public string employeeDetialsAppointmentDate { get; set; }

    [MaxLength(100)]
    public string employeeDetialsRetirementDate { get; set; }

    [MaxLength(100)]
    public string employeeDetialsLastPromotionDate { get; set; }

    [MaxLength(100)]
    public string biographicalDataDateOfBirth { get; set; }

    [MaxLength(100)]
    public string dependant1DateOfBirth { get; set; }

    [MaxLength(100)]
    public string dependant2DateOfBirth { get; set; }

    [MaxLength(100)]
    public string dependant3DateOfBirth { get; set; }

    [MaxLength(100)]
    public string dependant4DateOfBirth { get; set; }

    [MaxLength(100)]
    public string dependant5DateOfBirth { get; set; }

    [MaxLength(100)]
    public string educationTo { get; set; }

    [MaxLength(100)]
    public string educationFrom { get; set; }

    [MaxLength(100)]
    public string skills1YearObtained { get; set; }

    [MaxLength(100)]
    public string skills2YearObtained { get; set; }

    [MaxLength(100)]
    public string skills3YearObtained { get; set; }

    [MaxLength(100)]
    public string LgsSubMetro { get; set; }

    [MaxLength(100)]
    public string identificationPaymentMode { get; set; }

    [MaxLength(100)]
    public string employementDetialsTitle { get; set; }

    [MaxLength(100)]
    public string biographicalDataSex { get; set; }

    [MaxLength(100)]
    public string biographicalMaritalStatus { get; set; }

    [MaxLength(100)]
    public string biographicalRegion { get; set; }

    [MaxLength(100)]
    public string biographicalCountries { get; set; }

    [MaxLength(100)]
    public string residentialRegion { get; set; }

    [MaxLength(100)]
    public string nextOFKinRegion { get; set; }

    [MaxLength(100)]
    public string nextOfKinCountries { get; set; }

    [MaxLength(100)]
    public string dependant1Title { get; set; }

    [MaxLength(100)]
    public string dependant2Title { get; set; }

    [MaxLength(100)]
    public string dependant3Title { get; set; }

    [MaxLength(100)]
    public string dependant4Title { get; set; }

    [MaxLength(100)]
    public string dependant5Title { get; set; }

    [MaxLength(100)]
    public string languageSpoken1 { get; set; }

    [MaxLength(100)]
    public string languageSpoken2 { get; set; }

    [MaxLength(100)]
    public string languageSpoken3 { get; set; }

    [MaxLength(100)]
    public string languageReading1 { get; set; }

    [MaxLength(100)]
    public string languageReading2 { get; set; }

    [MaxLength(100)]
    public string languageReading3 { get; set; }

    [MaxLength(100)]
    public string languageWriting1 { get; set; }

    [MaxLength(100)]
    public string languageWriting2 { get; set; }

    [MaxLength(100)]
    public string languageWriting3 { get; set; }
}

