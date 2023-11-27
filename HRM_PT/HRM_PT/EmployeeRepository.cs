
using SQLite;
using HRM_PT.DbModel;


namespace HRM_PT;


public class EmployeeRepository
{

    private static SQLiteConnection conn;
    string _dbPath;
    public string statusMessage {get; set;}
    public bool done { get; set; }

    public bool testData { get; set; }

    private void Init()
    {
        if (conn != null)
            return;

        conn = new SQLiteConnection(_dbPath);
        conn.CreateTable<EmployeeDB>();
    }

    public EmployeeRepository(string dbPath)
    {
        _dbPath = dbPath;
    }

    public void AddNewEmployee(string _identificationStaffID, string _identificationSocialSecurity, string _identificationNHIS, string _identificationIntPassport, 
        string _identificationVotersID,string _identificationNationalID, string _identificationDriversLicense, string _employeeDetialsSurname, string _employeeDetialsFirstName,
        string _employeeDetialsMiddleName,string _employeeDetialsDirectorate, string _employeeDetialsDepartment, string _employeeDetialsUnit, string _employeeDetialsImmediateSupervisor,
        string _employeeDetialsCostCenter, string _employeeDetialsJobClass, string _employeeDetialsJobTitle, string _employeeDetialsJobGrade, string _employeeDetialsGradeLevel,
        string _employeeDetialsGradePoint, string _bankDetialsBankName, string _bankDetialsBankBranchName, string _bankDetialsBankAccount, string _biographicalDataMaidenName,
        string _biographicalDataPlaceOfBirth, string _biographicalDataHomeTown, string _biographicalDataReligion, string _residentialHouseNo, string _residentialStreetName,
        string _residentialArea, string _residentialTownCity, string _otherPostalAddress, string _otherEmailAddress, string _otherPhoneNo, string _otherMobileNo,
        string _disableState, string _disableReason, string _nextOfKinSurname, string _nextOfKinFirstName, string _nextOfKinRelationship, string _nextOfKinContactHouseNo,
        string _nextOfKinContactStreetName, string _nextOfKinContactArea, string _nextOfKinContactCityTown, string _nextOfKinContactPhoneNo, string _dependant1Surname,
        string _dependant1FirstName, string _dependant1MiddleName, string _dependant1Relationship, string _dependant2Surname, string _dependant2FirstName,
        string _dependant2MiddleName, string _dependant2Relationship, string _dependant3Surname, string _dependant3FirstName, string _dependant3MiddleName,
        string _dependant3Relationship, string _dependant4Surname, string _dependant4FirstName, string _dependant4MiddleName, string _dependant4Relationship,
        string _dependant5Surname, string _dependant5FirstName, string _dependant5MiddleName, string _dependant5Relationship, string _educationInstitutionName,
        string _educationQualificationObtained, string _educationCourseStudied, string _educationEntryCertificate, string _skills1Type, string _skills2Type,
        string _skills3Type, string _skills1InstitutionName, string _skills2InstitutionName, string _skills3InstitutionName, string _association1Name, string _association2Name,
        string _association3Name, string _language1Name, string _language2Name, string _language3Name, string _identificationIntPassportExpiryDate, string _employeeDetialsAppointmentDate,
        string _employeeDetialsRetirementDate, string _employeeDetialsLastPromotionDate, string _biographicalDataDateOfBirth, string _dependant1DateOfBirth, string _dependant2DateOfBirth,
        string _dependant3DateOfBirth, string _dependant4DateOfBirth, string _dependant5DateOfBirth, string _educationTo, string _educationFrom, string _skills1YearObtained,
        string _skills2YearObtained, string _skills3YearObtained, string _LgsSubMetro, string _identificationPaymentMode, string _employementDetialsTitle, string _biographicalDataSex,
        string _biographicalMaritalStatus, string _biographicalRegion, string _biographicalCountries, string _residentialRegion, string _nextOFKinRegion, string _nextOfKinCountries,
        string _dependant1Title, string _dependant2Title, string _dependant3Title, string _dependant4Title, string _dependant5Title, string _languageSpoken1, string _languageSpoken2,
        string _languageSpoken3,  string _languageReading1, string _languageReading2, string _languageReading3, string _languageWriting1, string _languageWriting2, string _languageWriting3)
    {

        try
        {
            int result = 0;

            Init();
            var employeeInformation = new EmployeeDB
            {
                identificationStaffID = _identificationStaffID,
                identificationSocialSecurity = _identificationSocialSecurity,
                identificationNHIS = _identificationNHIS,
                identificationIntPassport = _identificationIntPassport,
                identificationVotersID = _identificationVotersID,
                identificationNationalID = _identificationNationalID,
                identificationDriversLicense = _identificationDriversLicense,
                employeeDetialsSurname = _employeeDetialsSurname,
                employeeDetialsFirstName = _employeeDetialsFirstName,
                employeeDetialsMiddleName = _employeeDetialsMiddleName,
                employeeDetialsDirectorate = _employeeDetialsDirectorate,
                employeeDetialsDepartment = _employeeDetialsDepartment,
                employeeDetialsUnit = _employeeDetialsUnit,
                employeeDetialsImmediateSupervisor = _employeeDetialsImmediateSupervisor,
                employeeDetialsCostCenter = _employeeDetialsCostCenter,
                employeeDetialsJobClass = _employeeDetialsJobClass,
                employeeDetialsJobTitle = _employeeDetialsJobTitle,
                employeeDetialsJobGrade = _employeeDetialsJobGrade,
                employeeDetialsGradeLevel = _employeeDetialsGradeLevel,
                employeeDetialsGradePoint = _employeeDetialsGradePoint,
                bankDetialsBankName = _bankDetialsBankName,
                bankDetialsBankBranchName = _bankDetialsBankBranchName,
                bankDetialsBankAccount = _bankDetialsBankAccount,
                biographicalDataMaidenName = _biographicalDataMaidenName,
                biographicalDataPlaceOfBirth = _biographicalDataPlaceOfBirth,
                biographicalDataHomeTown = _biographicalDataHomeTown,
                biographicalDataReligion = _biographicalDataReligion,
                residentialHouseNo = _residentialHouseNo,
                residentialStreetName = _residentialStreetName,
                residentialArea = _residentialArea,
                residentialTownCity = _residentialTownCity,
                otherPostalAddress = _otherPostalAddress,
                otherEmailAddress = _otherEmailAddress,
                otherPhoneNo = _otherPhoneNo,
                otherMobileNo = _otherMobileNo,
                disableState = _disableState,
                disableReason = _disableReason,
                nextOfKinSurname = _nextOfKinSurname,
                nextOfKinFirstName = _nextOfKinFirstName,
                nextOfKinRelationship = _nextOfKinRelationship,
                nextOfKinContactHouseNo = _nextOfKinContactHouseNo,
                nextOfKinContactStreetName = _nextOfKinContactStreetName,
                nextOfKinContactArea = _nextOfKinContactArea,
                nextOfKinContactCityTown = _nextOfKinContactCityTown,
                nextOfKinContactPhoneNo = _nextOfKinContactPhoneNo,
                dependant1Surname = _dependant1Surname,
                dependant1FirstName = _dependant1FirstName,
                dependant1MiddleName = _dependant1MiddleName,
                dependant1Relationship = _dependant1Relationship,
                dependant2Surname = _dependant2Surname,
                dependant2FirstName = _dependant2FirstName,
                dependant2MiddleName = _dependant2MiddleName,
                dependant2Relationship = _dependant2Relationship,
                dependant3Surname = _dependant3Surname,
                dependant3FirstName = _dependant3FirstName,
                dependant3MiddleName = _dependant3MiddleName,
                dependant3Relationship = _dependant3Relationship,
                dependant4Surname = _dependant4Surname,
                dependant4FirstName = _dependant4FirstName,
                dependant4MiddleName = _dependant4MiddleName,
                dependant4Relationship = _dependant4Relationship,
                dependant5Surname = _dependant5Surname,
                dependant5FirstName = _dependant5FirstName,
                dependant5MiddleName = _dependant5MiddleName,
                dependant5Relationship = _dependant5Relationship,
                educationInstitutionName = _educationInstitutionName,
                educationQualificationObtained = _educationQualificationObtained,
                educationCourseStudied = _educationCourseStudied,
                educationEntryCertificate = _educationEntryCertificate,
                skills1Type = _skills1Type,
                skills2Type = _skills2Type,
                skills3Type = _skills3Type,
                skills1InstitutionName = _skills1InstitutionName,
                skills2InstitutionName = _skills2InstitutionName,
                skills3InstitutionName = _skills3InstitutionName,
                association1Name = _association1Name,
                association2Name = _association2Name,
                association3Name = _association3Name,
                language1Name = _language1Name,
                language2Name = _language2Name,
                language3Name = _language3Name,
                identificationIntPassportExpiryDate = _identificationIntPassportExpiryDate,
                employeeDetialsAppointmentDate = _employeeDetialsAppointmentDate,
                employeeDetialsRetirementDate = _employeeDetialsRetirementDate,
                employeeDetialsLastPromotionDate = _employeeDetialsLastPromotionDate,
                biographicalDataDateOfBirth = _biographicalDataDateOfBirth,
                dependant1DateOfBirth = _dependant1DateOfBirth,
                dependant2DateOfBirth = _dependant2DateOfBirth,
                dependant3DateOfBirth = _dependant3DateOfBirth,
                dependant4DateOfBirth = _dependant4DateOfBirth,
                dependant5DateOfBirth = _dependant5DateOfBirth,
                educationTo = _educationTo,
                educationFrom = _educationFrom,
                skills1YearObtained = _skills1YearObtained,
                skills2YearObtained = _skills2YearObtained,
                skills3YearObtained = _skills3YearObtained,
                LgsSubMetro = _LgsSubMetro,
                identificationPaymentMode = _identificationPaymentMode,
                employementDetialsTitle = _employementDetialsTitle,
                biographicalDataSex = _biographicalDataSex,
                biographicalMaritalStatus = _biographicalMaritalStatus,
                biographicalRegion = _biographicalRegion,
                biographicalCountries = _biographicalCountries,
                residentialRegion = _residentialRegion,
                nextOFKinRegion = _nextOFKinRegion,
                nextOfKinCountries = _nextOfKinCountries,
                dependant1Title = _dependant1Title,
                dependant2Title = _dependant2Title,
                dependant3Title = _dependant3Title,
                dependant4Title = _dependant4Title,
                dependant5Title = _dependant5Title,
                languageSpoken1 = _languageSpoken1,
                languageSpoken2 = _languageSpoken2,
                languageSpoken3 = _languageSpoken3,
                languageReading1 = _languageReading1,
                languageReading2 = _languageReading2,
                languageReading3 = _languageReading3,
                languageWriting1 = _languageWriting1,
                languageWriting2 = _languageWriting2,
                languageWriting3 = _languageWriting3

            };

            result = conn.Insert(employeeInformation);
            statusMessage = "Success";

        }
        catch (Exception e)
        {
            statusMessage = string.Format("Failded to add {0}{1}", e.Message, _identificationStaffID);

        }
    }

    public List<EmployeeDB> GetAllPeople()
    {
        try
        {
            Init();
            return conn.Table<EmployeeDB>().ToList();
        }catch(Exception ex)
        {
            statusMessage = string.Format("failed to retrieve data. {0}", ex.Message);
        }

        return new List<EmployeeDB>();
    }

    public List<EmployeeDB> GetPeopleByStaffID(string staffID)
    {
        try
        {
            Init();

            EmployeeDB test = conn.Table<EmployeeDB>().FirstOrDefault(e => e.identificationStaffID == staffID);
            if(test != null)
            {
                statusMessage = "success";
                return conn.Table<EmployeeDB>().Where(e => e.identificationStaffID == staffID).ToList();
                testData = true;
            }
            else
            {
                testData = false;
            }
           
        }catch (Exception e)
        {
            statusMessage = string.Format("Failed to retrieve data. {0}", e.Message);
        }

        return new List<EmployeeDB>();
    }

    public List<EmployeeDB> GetUpdatePeopleByStaffID(string staffID)
    {
        try
        {
            Init();

            EmployeeDB test = conn.Table<EmployeeDB>().FirstOrDefault(e => e.identificationStaffID == staffID);
            if(test != null){
                statusMessage = "success";
                testData = true; 
                return conn.Table<EmployeeDB>().Where(e => e.identificationStaffID == staffID).ToList();
            }
            else
            {
                testData = false;
            }
        
        }
        catch (Exception e)
        {
            statusMessage = string.Format("Failed to retrieve data. {0}", e.Message);
        }

        return new List<EmployeeDB>();
    }
    public List<EmployeeDB> GetPeopleByDepartment(string department)
    {
        try
        {

            Init();
            EmployeeDB test = conn.Table<EmployeeDB>().FirstOrDefault(e => e.employeeDetialsDepartment == department);

            if (test != null)
            {
                statusMessage = "Success";
                return conn.Table<EmployeeDB>().Where(e => e.employeeDetialsDepartment == department).ToList();
                testData = true;
            }
            else
            {
                testData = false;
            }

        }
        catch(Exception e)
        {
            statusMessage = string.Format("Failed to retrieve data. {0}", e.Message);
        }

        return new List<EmployeeDB>();
    }

    public List<EmployeeDB> GetPeopleBySubMetro(string subMetro)
    {
        try
        {
            Init();
            return conn.Table<EmployeeDB>().Where(e => e.LgsSubMetro == subMetro).ToList();
        }catch (Exception e)
        {
            statusMessage = string.Format("Failed to retrieve data. {0}", e.Message);
        }

        return new List<EmployeeDB>();
    }

    public List<EmployeeDB> GetPeopleByPaymentMode(string paymentMode)
    {
        try
        {
            Init();
            return conn.Table<EmployeeDB>().Where(e => e.identificationPaymentMode == paymentMode).ToList();
        }catch (Exception e)
        {
            statusMessage = string.Format("Failed to retrieve data. {0}", e.Message);
        }

        return new List<EmployeeDB>();
    }


    public bool UpdateEmployeeByStaffID(string staffID, string _identificationStaffID, string _identificationSocialSecurity, string _identificationNHIS, string _identificationIntPassport,
        string _identificationVotersID, string _identificationNationalID, string _identificationDriversLicense, string _employeeDetialsSurname, string _employeeDetialsFirstName,
        string _employeeDetialsMiddleName, string _employeeDetialsDirectorate, string _employeeDetialsDepartment, string _employeeDetialsUnit, string _employeeDetialsImmediateSupervisor,
        string _employeeDetialsCostCenter, string _employeeDetialsJobClass, string _employeeDetialsJobTitle, string _employeeDetialsJobGrade, string _employeeDetialsGradeLevel,
        string _employeeDetialsGradePoint, string _bankDetialsBankName, string _bankDetialsBankBranchName, string _bankDetialsBankAccount, string _biographicalDataMaidenName,
        string _biographicalDataPlaceOfBirth, string _biographicalDataHomeTown, string _biographicalDataReligion, string _residentialHouseNo, string _residentialStreetName,
        string _residentialArea, string _residentialTownCity, string _otherPostalAddress, string _otherEmailAddress, string _otherPhoneNo, string _otherMobileNo,
        string _disableState, string _disableReason, string _nextOfKinSurname, string _nextOfKinFirstName, string _nextOfKinRelationship, string _nextOfKinContactHouseNo,
        string _nextOfKinContactStreetName, string _nextOfKinContactArea, string _nextOfKinContactCityTown, string _nextOfKinContactPhoneNo, string _dependant1Surname,
        string _dependant1FirstName, string _dependant1MiddleName, string _dependant1Relationship, string _dependant2Surname, string _dependant2FirstName,
        string _dependant2MiddleName, string _dependant2Relationship, string _dependant3Surname, string _dependant3FirstName, string _dependant3MiddleName,
        string _dependant3Relationship, string _dependant4Surname, string _dependant4FirstName, string _dependant4MiddleName, string _dependant4Relationship,
        string _dependant5Surname, string _dependant5FirstName, string _dependant5MiddleName, string _dependant5Relationship, string _educationInstitutionName,
        string _educationQualificationObtained, string _educationCourseStudied, string _educationEntryCertificate, string _skills1Type, string _skills2Type,
        string _skills3Type, string _skills1InstitutionName, string _skills2InstitutionName, string _skills3InstitutionName, string _association1Name, string _association2Name,
        string _association3Name, string _language1Name, string _language2Name, string _language3Name, string _identificationIntPassportExpiryDate, string _employeeDetialsAppointmentDate,
        string _employeeDetialsRetirementDate, string _employeeDetialsLastPromotionDate, string _biographicalDataDateOfBirth, string _dependant1DateOfBirth, string _dependant2DateOfBirth,
        string _dependant3DateOfBirth, string _dependant4DateOfBirth, string _dependant5DateOfBirth, string _educationTo, string _educationFrom, string _skills1YearObtained,
        string _skills2YearObtained, string _skills3YearObtained, string _LgsSubMetro, string _identificationPaymentMode, string _employementDetialsTitle, string _biographicalDataSex,
        string _biographicalMaritalStatus, string _biographicalRegion, string _biographicalCountries, string _residentialRegion, string _nextOFKinRegion, string _nextOfKinCountries,
        string _dependant1Title, string _dependant2Title, string _dependant3Title, string _dependant4Title, string _dependant5Title, string _languageSpoken1, string _languageSpoken2,
        string _languageSpoken3, string _languageReading1, string _languageReading2, string _languageReading3, string _languageWriting1, string _languageWriting2, string _languageWriting3)
    {

        try
        {
            Init();
            EmployeeDB employeeUpdate = conn.Table<EmployeeDB>().FirstOrDefault(e => e.identificationStaffID == staffID);

            if (employeeUpdate != null)
            {
                employeeUpdate.identificationStaffID = _identificationStaffID;
                employeeUpdate.identificationSocialSecurity = _identificationSocialSecurity;
                employeeUpdate.identificationNHIS = _identificationNHIS;
                employeeUpdate.identificationIntPassport = _identificationIntPassport;
                employeeUpdate.identificationVotersID = _identificationVotersID;
                employeeUpdate.identificationNationalID = _identificationNationalID;
                employeeUpdate.identificationDriversLicense = _identificationDriversLicense;
                employeeUpdate.employeeDetialsSurname = _employeeDetialsSurname;
                employeeUpdate.employeeDetialsFirstName = _employeeDetialsFirstName;
                employeeUpdate.employeeDetialsMiddleName = _employeeDetialsMiddleName;
                employeeUpdate.employeeDetialsDirectorate = _employeeDetialsDirectorate;
                employeeUpdate.employeeDetialsDepartment = _employeeDetialsDepartment;
                employeeUpdate.employeeDetialsUnit = _employeeDetialsUnit;
                employeeUpdate.employeeDetialsImmediateSupervisor = _employeeDetialsImmediateSupervisor;
                employeeUpdate.employeeDetialsCostCenter = _employeeDetialsCostCenter;
                employeeUpdate.employeeDetialsJobClass = _employeeDetialsJobClass;
                employeeUpdate.employeeDetialsJobTitle = _employeeDetialsJobTitle;
                employeeUpdate.employeeDetialsJobGrade = _employeeDetialsJobGrade;
                employeeUpdate.employeeDetialsGradeLevel = _employeeDetialsGradeLevel;
                employeeUpdate.employeeDetialsGradePoint = _employeeDetialsGradePoint;
                employeeUpdate.bankDetialsBankName = _bankDetialsBankName;
                employeeUpdate.bankDetialsBankBranchName = _bankDetialsBankBranchName;
                employeeUpdate.bankDetialsBankAccount = _bankDetialsBankAccount;
                employeeUpdate.biographicalDataMaidenName = _biographicalDataMaidenName;
                employeeUpdate.biographicalDataPlaceOfBirth = _biographicalDataPlaceOfBirth;
                employeeUpdate.biographicalDataHomeTown = _biographicalDataHomeTown;
                employeeUpdate.biographicalDataReligion = _biographicalDataReligion;
                employeeUpdate.residentialHouseNo = _residentialHouseNo;
                employeeUpdate.residentialStreetName = _residentialStreetName;
                employeeUpdate.residentialArea = _residentialArea;
                employeeUpdate.residentialTownCity = _residentialTownCity;
                employeeUpdate.otherPostalAddress = _otherPostalAddress;
                employeeUpdate.otherEmailAddress = _otherEmailAddress;
                employeeUpdate.otherPhoneNo = _otherPhoneNo;
                employeeUpdate.otherMobileNo = _otherMobileNo;
                employeeUpdate.disableState = _disableState;
                employeeUpdate.disableReason = _disableReason;
                employeeUpdate.nextOfKinSurname = _nextOfKinSurname;
                employeeUpdate.nextOfKinFirstName = _nextOfKinFirstName;
                employeeUpdate.nextOfKinRelationship = _nextOfKinRelationship;
                employeeUpdate.nextOfKinContactHouseNo = _nextOfKinContactHouseNo;
                employeeUpdate.nextOfKinContactStreetName = _nextOfKinContactStreetName;
                employeeUpdate.nextOfKinContactArea = _nextOfKinContactArea;
                employeeUpdate.nextOfKinContactCityTown = _nextOfKinContactCityTown;
                employeeUpdate.nextOfKinContactPhoneNo = _nextOfKinContactPhoneNo;
                employeeUpdate.dependant1Surname = _dependant1Surname;
                employeeUpdate.dependant1FirstName = _dependant1FirstName;
                employeeUpdate.dependant1MiddleName = _dependant1MiddleName;
                employeeUpdate.dependant1Relationship = _dependant1Relationship;
                employeeUpdate.dependant2Surname = _dependant2Surname;
                employeeUpdate.dependant2FirstName = _dependant2FirstName;
                employeeUpdate.dependant2MiddleName = _dependant2MiddleName;
                employeeUpdate.dependant2Relationship = _dependant2Relationship;
                employeeUpdate.dependant3Surname = _dependant3Surname;
                employeeUpdate.dependant3FirstName = _dependant3FirstName;
                employeeUpdate.dependant3MiddleName = _dependant3MiddleName;
                employeeUpdate.dependant3Relationship = _dependant3Relationship;
                employeeUpdate.dependant4Surname = _dependant4Surname;
                employeeUpdate.dependant4FirstName = _dependant4FirstName;
                employeeUpdate.dependant4MiddleName = _dependant4MiddleName;
                employeeUpdate.dependant4Relationship = _dependant4Relationship;
                employeeUpdate.dependant5Surname = _dependant5Surname;
                employeeUpdate.dependant5FirstName = _dependant5FirstName;
                employeeUpdate.dependant5MiddleName = _dependant5MiddleName;
                employeeUpdate.dependant5Relationship = _dependant5Relationship;
                employeeUpdate.educationInstitutionName = _educationInstitutionName;
                employeeUpdate.educationQualificationObtained = _educationQualificationObtained;
                employeeUpdate.educationCourseStudied = _educationCourseStudied;
                employeeUpdate.educationEntryCertificate = _educationEntryCertificate;
                employeeUpdate.skills1Type = _skills1Type;
                employeeUpdate.skills2Type = _skills2Type;
                employeeUpdate.skills3Type = _skills3Type;
                employeeUpdate.skills1InstitutionName = _skills1InstitutionName;
                employeeUpdate.skills2InstitutionName = _skills2InstitutionName;
                employeeUpdate.skills3InstitutionName = _skills3InstitutionName;
                employeeUpdate.association1Name = _association1Name;
                employeeUpdate.association2Name = _association2Name;
                employeeUpdate.association3Name = _association3Name;
                employeeUpdate.language1Name = _language1Name;
                employeeUpdate.language2Name = _language2Name;
                employeeUpdate.language3Name = _language3Name;
                employeeUpdate.identificationIntPassportExpiryDate = _identificationIntPassportExpiryDate;
                employeeUpdate.employeeDetialsAppointmentDate = _employeeDetialsAppointmentDate;
                employeeUpdate.employeeDetialsRetirementDate = _employeeDetialsRetirementDate;
                employeeUpdate.employeeDetialsLastPromotionDate = _employeeDetialsLastPromotionDate;
                employeeUpdate.biographicalDataDateOfBirth = _biographicalDataDateOfBirth;
                employeeUpdate.dependant1DateOfBirth = _dependant1DateOfBirth;
                employeeUpdate.dependant2DateOfBirth = _dependant2DateOfBirth;
                employeeUpdate.dependant3DateOfBirth = _dependant3DateOfBirth;
                employeeUpdate.dependant4DateOfBirth = _dependant4DateOfBirth;
                employeeUpdate.dependant5DateOfBirth = _dependant5DateOfBirth;
                employeeUpdate.educationTo = _educationTo;
                employeeUpdate.educationFrom = _educationFrom;
                employeeUpdate.skills1YearObtained = _skills1YearObtained;
                employeeUpdate.skills2YearObtained = _skills2YearObtained;
                employeeUpdate.skills3YearObtained = _skills3YearObtained;
                employeeUpdate.LgsSubMetro = _LgsSubMetro;
                employeeUpdate.identificationPaymentMode = _identificationPaymentMode;
                employeeUpdate.employementDetialsTitle = _employementDetialsTitle;
                employeeUpdate.biographicalDataSex = _biographicalDataSex;
                employeeUpdate.biographicalMaritalStatus = _biographicalMaritalStatus;
                employeeUpdate.biographicalRegion = _biographicalRegion;
                employeeUpdate.biographicalCountries = _biographicalCountries;
                employeeUpdate.residentialRegion = _residentialRegion;
                employeeUpdate.nextOFKinRegion = _nextOFKinRegion;
                employeeUpdate.nextOfKinCountries = _nextOfKinCountries;
                employeeUpdate.dependant1Title = _dependant1Title;
                employeeUpdate.dependant2Title = _dependant2Title;
                employeeUpdate.dependant3Title = _dependant3Title;
                employeeUpdate.dependant4Title = _dependant4Title;
                employeeUpdate.dependant5Title = _dependant5Title;
                employeeUpdate.languageSpoken1 = _languageSpoken1;
                employeeUpdate.languageSpoken2 = _languageSpoken2;
                employeeUpdate.languageSpoken3 = _languageSpoken3;
                employeeUpdate.languageReading1 = _languageReading1;
                employeeUpdate.languageReading2 = _languageReading2;
                employeeUpdate.languageReading3 = _languageReading3;
                employeeUpdate.languageWriting1 = _languageWriting1;
                employeeUpdate.languageWriting2 = _languageWriting2;
                employeeUpdate.languageWriting3 = _languageWriting3;


                conn.Update(employeeUpdate);
                statusMessage = string.Format("{0} updated successfully.", staffID);

                return true;
            }
            else
            {
                statusMessage = string.Format("{0} does not exist.", staffID);
                return false;
            }
        }catch (Exception e)
        {
            statusMessage = string.Format("Failed to update data. {0}", e.Message);
            return false;
        }
   

    }


    public List<EmployeeDB> GetPeopleDeleteByStaffID(string staffID)
    {
        try
        {

            Init();
            EmployeeDB test = conn.Table<EmployeeDB>().FirstOrDefault(e => e.identificationStaffID == staffID);

            if(test != null)
            {
                statusMessage = "success";
                done = true;
                testData = true;
                return conn.Table<EmployeeDB>().Where(e => e.identificationStaffID == staffID).ToList();
            }
            else
            {
                testData = false;
            }

        }
        catch (Exception e)
        {
            done = true;
            statusMessage = string.Format("Failed to retrieve data. {0}", e.Message);
        }

        return new List<EmployeeDB>();
    }

    public bool DeleteEmployeeByStaffID(string _staffID)
    {
        try
        {
            Init();
            EmployeeDB deleteData = conn.Table<EmployeeDB>().FirstOrDefault(e => e.identificationStaffID == _staffID);
            if(deleteData != null)
            {
                conn.Delete(deleteData);
                statusMessage = string.Format("{0} deleted successfully.", _staffID);
                return true;
            }
            else
            {
                statusMessage = string.Format("{0} does not exist.", _staffID);
                return false;
            }
        }catch(Exception e)
        {
            statusMessage = string.Format("failed to delete data. {0}", e.Message);
            return false;
        }
    }
}

