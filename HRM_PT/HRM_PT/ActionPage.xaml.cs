using HRM_PT.NewFolder3;
using HRM_PTl;
using System.IO;
using System.Text.RegularExpressions;
using HRM_PT.DbModel;
using System.Globalization;
using System.Formats.Asn1;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;


namespace HRM_PT;

public partial class ActionPage : ContentPage
{
    private string fullPath;
    private string fullPath1;
    private string fullPath2;
    public ActionPage(List<Logins> list)
    {

        InitializeComponent();


        foreach (Logins emp in list)
        {
            OneFullname.Text = emp.firstName + " " + emp.surname;
            TwoFullname.Text = emp.firstName + " " + emp.surname;
            ThreeFullname.Text = emp.firstName + " " + emp.surname;
            FourFullname.Text = emp.firstName + " " + emp.surname;
            FiveFullname.Text = emp.firstName + " " + emp.surname;
            SixFullname.Text = emp.firstName + " " + emp.surname;
            OneStaffid.Text = emp.staffID;
            TwoStaffid.Text = emp.staffID;
            ThreeStaffid.Text = emp.staffID;
            FourStaffid.Text = emp.staffID;
            FiveStaffid.Text = emp.staffID;
            SixStaffid.Text = emp.staffID;
            user.Text = "Hi, " + emp.surname;
        }
        /*spokenCollection.ItemsSource = GetLanguages();
		readingCollection.ItemsSource = GetLanguages();
		writingCollection.ItemsSource = GetLanguages();
        associationList.ItemsSource;*/
        //dependantsList.ItemsSource = GetDependants();
        skillsList.ItemsSource = GetSkills();
        //ByDepartment.ItemsSource = GetWork();
        //BySubMetro.ItemsSource = GetWork();
        //ByPaymentMode.ItemsSource = GetWork();

        inputbiographicalDataCountries.ItemsSource = countries;
        inputNextOfKinCountries.ItemsSource = countries;
        _inputbiographicalDataCountries.ItemsSource = countries;
        _inputNextOfKinCountries.ItemsSource = countries;

        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        // Append your app's name to the path
        string folderPath = Path.Combine(desktopPath, "HRM_EXCELFILES");
        System.Diagnostics.Debug.WriteLine("Folder Path: " + folderPath);

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        // Create the file path within the app's folder
        fullPath = Path.Combine(folderPath, "EmployeeRecord.txt");
        fullPath1 = Path.Combine(folderPath, "LeaveManagement.txt");
        fullPath2 = Path.Combine(folderPath, "PerformanceManagement.txt");

        if (!File.Exists(fullPath))
        {
            // Write content to the file
            using (StreamWriter writer = File.CreateText(fullPath))
            {
                writer.WriteLine("Staff ID No.,Social Security No., Payment Mode, Sub Metro, NHIS No.,Driver's License No.,Voter's ID No.," +
                    "INT'L Passport No.,Expiry Date,Title,Surname,First Name, Middle Name, First Appointment Date, Directorate, Department," +
                    " Unit, Cost Center, Job Class, Job Title, Job Grade, Grade Level,Grade Point, Date of Last Promotion, Retirement Date," +
                    " Name of Immediate Supervisor,Name of Bank,Branch Name/Code,Account Number,Maiden name,Sex,Marital Status,Place of Birth," +
                    "Date of Birth,Home Town,Region,Nationality,Religion,House No.,Street Name,Area,Town/City,Residential Region,Postal Address," +
                    "Email Address,Office Phone No.,Mobile/Cell Phone No.,Disable?,If yes Specify,Next of kin Surname,Next of kin First Name," +
                    "Next of kin Relationship,Next of kin House No.,Next of kin Street Name,Next of kin Area,Next of kin City/Town,Next of kin State/Region," +
                    "Next of kin Country,Next of kin Contact Phone No.,Title1,Surname1,First Name1,Middle Name1,Date of Birth1,Relationship1,Title2,Surname2," +
                    "First Name2,Middle Name2,Date of Birth2,Relationship2,Title3,Surname3,First Name3,Middle Name3,Date of Birth3,Relationship3,Title4,Surname4," +
                    "First Name4,Middle Name4,Date of Birth4,Relationship4,Title5,Surname5,First Name5,Middle Name5,Date of Birth5,Relationship5,Name of Institution/School," +
                    "Period Attend From, Period Attend To,Qualification,Main Course of Study, Entry Certificate,Skill/Training1,Training Institution/Organization1,Year Obtained1," +
                    "Skill/Training2,Training Institution/Organization2,Year Obtained2,Skill/Training3,Training Institution/Organization3,Year Obtained3,Professional Societies and Affiliations1," +
                    "Professional Societies and Affiliations2,Professional Societies and Affiliations3,Language1,Spoken1,Reading1,Writing1,Language2,Spoken2,Reading2,Writing2,Language1,Spoken3,Reading3,Writing3");
            }
        }

        if (!File.Exists(fullPath1))
        {
            using (StreamWriter writer = File.CreateText(fullPath1))
            {
                writer.WriteLine("StaffID,Type of leave, Date Applied, Date of Resumption, Approval Date," +
                    " Name of HOD, Offficer Taken Over, Days Requested, Total Leave");
            }
        }

        if (!File.Exists(fullPath2))
        {
            using (StreamWriter writer = File.CreateText(fullPath2))
            {
                writer.WriteLine("Department,Planning Stage, Mid-Year Review, End of Year");
            }
        }
        /*string folderPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.Parent.FullName;
        System.Diagnostics.Debug.WriteLine(folderPath);
        string filename = @"ExcelFiles\EmployeeRecord.txt";
        string filename1 = @"ExcelFiles\LeaveManagement.txt";
        string filename2 = @"ExcelFiles\PerformanceManagement.txt";

        string filePath = Path.Combine(folderPath, filename);
        if (File.Exists(filePath))
        {
            System.Diagnostics.Debug.WriteLine("file exist");
            fullPath = filePath;
            System.Diagnostics.Debug.WriteLine(fullPath);
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("error file does not exist");
        }

        string filePath1 = Path.Combine(folderPath, filename1);

        if (File.Exists(filePath1))
        {
            System.Diagnostics.Debug.WriteLine("file1 exist");
            fullPath1 = filePath1;
            System.Diagnostics.Debug.WriteLine(fullPath1);
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("error file1 does not exist");
        }

        string filePath2 = Path.Combine(folderPath, filename2);

        if (File.Exists(filePath2))
        {
            System.Diagnostics.Debug.WriteLine("file2 exist");
            fullPath2 = filePath2;
            System.Diagnostics.Debug.WriteLine(fullPath2);
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("error fil21 does not exist");
        }*/
        hoverSearchImage.Source = "white_people_search.png";
        searchFram.IsVisible = true;
        hoverSearch.BorderColor = Colors.White;
        hoverSearchLabel.TextColor = Colors.White;
        searchByStaffID.IsVisible = true;
        openSearchByStaffIDFormLabel.TextColor = Colors.White;
        openSearchByStaffIDFormFrame.BackgroundColor = Color.Parse("#1B4242");
       
    }
    protected override bool OnBackButtonPressed()
    {

        return true;
    }
    public static void getCurrentDirectory()
    {
        string a;
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        DirectoryInfo parentDirectory = Directory.GetParent(currentDirectory);
        if (!string.IsNullOrEmpty(currentDirectory))
        {
            // Get the parent directory of the application's folder
            DirectoryInfo parentDirectoryInfo = Directory.GetParent(currentDirectory);
            a = Directory.GetParent(currentDirectory).Parent.Parent.Parent.Parent.Parent.FullName;
            // Check if parent directory exists and get its full path
            System.Diagnostics.Debug.WriteLine(parentDirectoryInfo);


            // Set the label's text to the parent directory


        }
        else
        {
            // Handle the case where current directory is null or empty
            System.Diagnostics.Debug.WriteLine("Unable to retrieve parent directory. Current directory is null or empty.");
        }



    }
    //private static string currentDirectory;

    //public static string folderPath;

    //private static string filename = @"ExcelFiles\EmployeeRecord.txt";

    //private static string filePath = Path.Combine(folderPath, filename)


    //search
    private string searchByStaffIDEntryStaffID;
    private bool testsearchByStaffIDEntryStaffID = false;
    private bool isvalidsearchByStaffIDEntryStaffID = false;
    private string searchByDepartmentName;
    private bool testsearchBuDepartmentEntry = false;
    private bool isvalidsearchByDepartmentEntry = false;
    private string searchBySub_Metro;
    private string searchByPayment_Mode;

    void OnSearchByStaffID_entryStaffID(object sender, TextChangedEventArgs e)
    {
        //statusSubmitSearchByStaffID.IsVisible = false;
        statusSubmitSearchByStaffID.IsVisible = false;
        string entryValue = searchByStaffID_entryStaffID.Text;
        errorsearchByStaffID_entryStaffID.IsVisible = false;
        byStaffID.IsVisible = false;

        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            searchByStaffIDEntryStaffID = entryValue;
            testsearchByStaffIDEntryStaffID = true;
            isvalidsearchByStaffIDEntryStaffID = true;
            errorsearchByStaffID_entryStaffID.IsVisible = false;
        }
        else
        {
            errorsearchByStaffID_entryStaffID.Text = "This field cannot be empty.";
            errorsearchByStaffID_entryStaffID.IsVisible = true;

        }

    }

    void OnSearchByDepartment_Name(object sender, TextChangedEventArgs e)
    {
        string entryValue = searchByDepartment_Name.Text;
        statusSubmitSearchDepartment.IsVisible = false;
        errorsearchByDepartment_entryStaffID.IsVisible = false;
        byDepartment.IsVisible = false;

        if (!string.IsNullOrEmpty(entryValue))
        {
            searchByDepartmentName = entryValue;
            testsearchBuDepartmentEntry = true;
            isvalidsearchByDepartmentEntry = true;
            errorsearchByDepartment_entryStaffID.IsVisible = false;
        }
        else
        {
            errorsearchByDepartment_entryStaffID.Text = "This field cannot be empty.";
            errorsearchByDepartment_entryStaffID.IsVisible = true;

        }


    }

    void OnPickerSearchBy_SubMetro(object sender, EventArgs e)
    {
        string entryValue = searchBy_SubMetro.SelectedItem as string;
        searchBySub_Metro = entryValue;
    }

    void OnPickerSearchBy_PaymentMode(object sender, EventArgs e)
    {
        string entryValue = searchBy_PaymentMode.SelectedItem as string;
        searchByPayment_Mode = entryValue;
    }

    private List<EmployeeDB> GetPeopleByStaffIDlist;
    async void submitSearchByStaffID(object sender, EventArgs e)
    {
        changeButtonSubmitSearchByStaffID.Background = Colors.Teal;
        await Task.Delay(500); // Wait for 0.5 seconds (adjust time as needed)
        changeButtonSubmitSearchByStaffID.Background = Colors.DarkSlateGray;



        byDepartment.IsVisible = false;
        byPayment.IsVisible = false;
        bySubMetro.IsVisible = false;
        act1.IsRunning = true;



        if (!testsearchByStaffIDEntryStaffID)
        {
            errorsearchByStaffID_entryStaffID.Text = "This field cannot be empty";
            errorsearchByStaffID_entryStaffID.IsVisible = true;
            act1.IsRunning = false;
        }
        else
        {
            if (isvalidsearchByStaffIDEntryStaffID)
            {
                GetPeopleByStaffIDlist = await App.EmployeeRep.GetPeopleByStaffID(searchByStaffIDEntryStaffID);
                statusSubmitSearchByStaffID.Text = App.EmployeeRep.statusMessage;
                statusSubmitSearchByStaffID.IsVisible = true;
                //byStaffID.IsVisible = true;
                string check = App.EmployeeRep.statusMessage;
                if (check == "Search Successful")
                {

                    byStaffID.IsVisible = true;

                    foreach (EmployeeDB emp in GetPeopleByStaffIDlist)
                    {


                        searchByStaffID_staffID.Text = emp.identificationStaffID;
                        searchByStaffID_socialSecurity.Text = emp.identificationSocialSecurity;
                        searchByStaffID_nhis.Text = emp.identificationNHIS;
                        searchByStaffID_driverLicense.Text = emp.identificationDriversLicense;
                        searchByStaffID_votersID.Text = emp.identificationVotersID;
                        searchByStaffID_nationalID.Text = emp.identificationNationalID;
                        searchByStaffID_intPassport.Text = emp.identificationIntPassport;
                        searchByStaffID_intPassportExpiry.Text = emp.identificationIntPassportExpiryDate;
                        searchByStaffID_bankName.Text = emp.bankDetialsBankName;
                        searchByStaffID_bankBranchName.Text = emp.bankDetialsBankBranchName;
                        searchByStaffID_bankAccount.Text = emp.bankDetialsBankAccount;
                        searchByStaffID_houseNo.Text = emp.residentialHouseNo;
                        searchByStaffID_streetName.Text = emp.residentialStreetName;
                        searchByStaffID_area.Text = emp.residentialArea;
                        searchByStaffID_townCity.Text = emp.residentialTownCity;
                        searchByStaffID_region.Text = emp.residentialRegion;
                        searchByStaffID_postalAddress.Text = emp.otherPostalAddress;
                        searchByStaffID_emailAddress.Text = emp.otherEmailAddress;
                        searchByStaffID_officePhone.Text = emp.otherPhoneNo;
                        searchByStaffID_mobilePhone.Text = emp.otherMobileNo;
                        searchByStaffID_disableState.Text = emp.disableState;
                        searchByStaffID_educationInstitutionName.Text = emp.educationInstitutionName;
                        searchByStaffID_period.Text = emp.educationFrom + " - " + emp.educationTo;
                        searchByStaffID_qualificationObtained.Text = emp.educationQualificationObtained;
                        searchByStaffID_courseStudied.Text = emp.educationCourseStudied;
                        searchByStaffID_BigSurname.Text = emp.employeeDetialsSurname;
                        searchByStaffID_BigFirstName.Text = emp.employeeDetialsFirstName;
                        searchByStaffID_BigMiddleName.Text = emp.employeeDetialsMiddleName;
                        searchByStaffID_BigStaffID.Text = emp.identificationStaffID;
                        searchByStaffID_BigPaymentMode.Text = emp.identificationPaymentMode;
                        searchByStaffID_BigDepartment.Text = emp.employeeDetialsDepartment;
                        searchByStaffID_employeeTitile.Text = emp.employementDetialsTitle;
                        searchByStaffID_employeeSurname.Text = emp.employeeDetialsSurname;
                        searchByStaffID_firstName.Text = emp.employeeDetialsFirstName;
                        searchByStaffID_middleName.Text = emp.employeeDetialsMiddleName;
                        searchByStaffID_subMetro.Text = emp.LgsSubMetro;
                        searchByStaffID_employeeDirectorate.Text = emp.employeeDetialsDirectorate;
                        searchByStaffID_employeeDepartment.Text = emp.employeeDetialsDepartment;
                        searchByStaffID_employeeUnit.Text = emp.employeeDetialsUnit;
                        searchByStaffID_employeeCostCenter.Text = emp.employeeDetialsCostCenter;
                        searchByStaffID_employeeJobClass.Text = emp.employeeDetialsJobClass;
                        searchByStaffID_employeeJobTitle.Text = emp.employeeDetialsJobTitle;
                        searchByStaffID_employeeGradeLevel.Text = emp.employeeDetialsGradeLevel;
                        searchByStaffID_employeeGradePint.Text = emp.employeeDetialsGradePoint;
                        searchByStaffID_employeeFirstAppointmentDate.Text = emp.employeeDetialsAppointmentDate;
                        searchByStaffID_employeeLastPromotionDate.Text = emp.employeeDetialsLastPromotionDate;
                        searchByStaffID_employeeRetirementDate.Text = emp.employeeDetialsRetirementDate;
                        searchByStaffID_employeeImmediateSupervisor.Text = emp.employeeDetialsImmediateSupervisor;
                        searchByStaffID_biographicalMaidenName.Text = emp.biographicalDataMaidenName;
                        searchByStaffID_biographicalSex.Text = emp.biographicalDataSex;
                        searchByStaffID_biographicalMaritalStatus.Text = emp.biographicalMaritalStatus;
                        searchByStaffID_biographicalPlaceOfBirth.Text = emp.biographicalDataPlaceOfBirth;
                        searchByStaffID_biograhicalDateOfBirth.Text = emp.biographicalDataDateOfBirth;
                        searchByStaffID_biographicalHomeTown.Text = emp.biographicalDataHomeTown;
                        searchByStaffID_biographicalRegion.Text = emp.biographicalRegion;
                        searchByStaffID_biographicalNationality.Text = emp.biographicalCountries;
                        searchByStaffID_biographicalReligon.Text = emp.biographicalDataReligion;
                        searchByStaffID_nextOfKinSurname.Text = emp.nextOfKinSurname;
                        searchByStaffID_nextOfKinFirstName.Text = emp.nextOfKinFirstName;
                        searchByStaffID_nextOfKinRelationship.Text = emp.nextOfKinRelationship;
                        searchByStaffID_nextOfKinHouseNo.Text = emp.nextOfKinContactHouseNo;
                        searchByStaffID_nextOfKinStreetName.Text = emp.nextOfKinContactStreetName;
                        searchByStaffID_nextOfKinArea.Text = emp.nextOfKinContactArea;
                        searchByStaffID_nextOfKincityTown.Text = emp.nextOfKinContactCityTown;
                        searchByStaffID_nextOfKinRegion.Text = emp.nextOFKinRegion;
                        searchByStaffID_nextOfKinCountry.Text = emp.nextOfKinCountries;
                        searchByStaffID_nextOfKinContact.Text = emp.nextOfKinContactPhoneNo;
                        firstName1 = emp.dependant1FirstName;
                        surname1 = emp.dependant1Surname;
                        othername1 = emp.dependant1MiddleName;
                        dateofBirth1 = emp.dependant1DateOfBirth;
                        relationship1 = emp.dependant1Relationship;
                        title1 = emp.dependant1Title;
                        firstName2 = emp.dependant2FirstName;
                        surname2 = emp.dependant2Surname;
                        othername2 = emp.dependant2MiddleName;
                        dateofBirth2 = emp.dependant2DateOfBirth;
                        relationship2 = emp.dependant2Relationship;
                        title2 = emp.dependant2Title;
                        firstName3 = emp.dependant3FirstName;
                        surname3 = emp.dependant3Surname;
                        othername3 = emp.dependant3MiddleName;
                        dateofBirth1 = emp.dependant3DateOfBirth;
                        relationship3 = emp.dependant3Relationship;
                        title3 = emp.dependant3Title;
                        firstName4 = emp.dependant4FirstName;
                        surname4 = emp.dependant4Surname;
                        othername4 = emp.dependant4MiddleName;
                        dateofBirth4 = emp.dependant4DateOfBirth;
                        relationship4 = emp.dependant4Relationship;
                        title4 = emp.dependant4Title;
                        firstName5 = emp.dependant5FirstName;
                        surname5 = emp.dependant5Surname;
                        othername5 = emp.dependant5MiddleName;
                        dateofBirth5 = emp.dependant5DateOfBirth;
                        relationship5 = emp.dependant5Relationship;
                        title5 = emp.dependant5Title;
                        languageA = emp.language1Name;
                        languageB = emp.language2Name;
                        languageC = emp.language3Name;
                        spokenA = emp.languageSpoken1;
                        spokenB = emp.languageSpoken2;
                        spokenC = emp.languageSpoken3;
                        writingA = emp.languageWriting1;
                        writingB = emp.languageWriting2;
                        writingC = emp.languageWriting3;
                        readingA = emp.languageReading1;
                        readingB = emp.languageReading2;
                        readingC = emp.languageReading3;
                        skillname1 = emp.skills1Type;
                        skillname2 = emp.skills2Type;
                        skillname3 = emp.skills3Type;
                        init1 = emp.skills1InstitutionName;
                        init2 = emp.skills2InstitutionName;
                        init3 = emp.skills3InstitutionName;
                        year1 = emp.skills1YearObtained;
                        year2 = emp.skills2YearObtained;
                        year3 = emp.skills3YearObtained;
                        asso1 = emp.association1Name;
                        asso2 = emp.association2Name;
                        asso3 = emp.association3Name;

                    }

                    dependantsList.ItemsSource = GetDependants5();
                    skillsList.ItemsSource = GetSkills();
                    associationList.ItemsSource = GetAssociations();
                    languageList.ItemsSource = GetLanguages();
                    /*if (!(string.IsNullOrWhiteSpace(surname1) && string.IsNullOrWhiteSpace(surname2) && string.IsNullOrWhiteSpace(surname3)
                        && string.IsNullOrWhiteSpace(surname4) && string.IsNullOrWhiteSpace(surname5)))
                    {
                        dependantsList.ItemsSource = GetDependants5();

                    }
                    else if (!(string.IsNullOrWhiteSpace(surname1) && string.IsNullOrWhiteSpace(surname2) && string.IsNullOrWhiteSpace(surname3)
                        && string.IsNullOrWhiteSpace(surname4)))
                    {
                        dependantsList.ItemsSource = GetDependants4();
                    }
                    else if (!(string.IsNullOrWhiteSpace(surname1) && string.IsNullOrWhiteSpace(surname2) && string.IsNullOrWhiteSpace(surname3)
                       ))
                    {
                        dependantsList.ItemsSource = GetDependants3();

                    }
                    else if (!(string.IsNullOrWhiteSpace(surname1) && string.IsNullOrWhiteSpace(surname2)))
                    {
                        dependantsList.ItemsSource = GetDependants2();
                    }
                    else if (!(string.IsNullOrWhiteSpace(surname1)))
                    {
                        dependantsList.ItemsSource = GetDependants1();

                    }

                    if (!(string.IsNullOrWhiteSpace(languageA) && string.IsNullOrWhiteSpace(languageB) && string.IsNullOrWhiteSpace(languageC)
                        ))
                    {

                        languageList.ItemsSource = GetLanguages3();


                    }
                    else if (!(string.IsNullOrWhiteSpace(languageA) && string.IsNullOrWhiteSpace(languageB)))

                    {
                        languageList.ItemsSource = GetLanguages2();

                    }
                    else if (!(string.IsNullOrWhiteSpace(languageA)))
                    {
                        languageList.ItemsSource = GetLanguages1();

                    }

                    act1.IsRunning = false;
                }
                else
                {
                    statusSubmitSearchByStaffID.Text = searchByStaffIDEntryStaffID + " does not exist";
                    statusSubmitSearchByStaffID.IsVisible = true;
                    act1.IsRunning = false;
                    byStaffID.IsVisible = false;
                }
                }*/

                    act1.IsRunning = false;


                }
                else
                {
                    act1.IsRunning = false;

                    byStaffID.IsVisible = false;

                }
            }

        }


    }

    private string firstImage = "fivestar_preview.png";
    private string secondImage = "threestar_preview.png";
    private string thirdImage = "twostar_preview.png";
    private List<Language> GetLanguages()
    {
        return new List<Language>
        {
            new Language {name = languageA, readimage = readingA, writeimage = writingA, spokenimage = spokenA },

            new Language {name = languageB, readimage = readingB, writeimage = writingB, spokenimage = spokenB },

            new Language {name = languageC, readimage = readingC, writeimage = writingC, spokenimage = spokenC },
        };
    }
    /* private List<Language> GetLanguages2()
     {
         return new List<Language>
         {
             new Language {number="A",name = languageA, readimage = readingA, writeimage = writingA, spokenimage = spokenA },

             new Language {number="B",name = languageB, readimage = readingB, writeimage = writingB, spokenimage = spokenB },

         };
     }

     private List<Language> GetLanguages1()
     {
         return new List<Language>
         {
             new Language {number="A",name = languageA, readimage = readingA, writeimage = writingA, spokenimage = spokenA },

         };
     }*/
    private List<Association> GetAssociations()
    {
        return new List<Association>
        {
            new Association{Name = asso1},
            new Association{Name = asso2},
            new Association{Name = asso3}
        };
    }
    private string firstName1, surname1, othername1, dateofBirth1, relationship1, title1;
    private string firstName2, surname2, othername2, dateofBirth2, relationship2, title2;
    private string firstName3, surname3, othername3, dateofBirth3, relationship3, title3;
    private string firstName4, surname4, othername4, dateofBirth4, relationship4, title4;
    private string firstName5, surname5, othername5, dateofBirth5, relationship5, title5;
    private string languageA, languageB, languageC;
    private string spokenA, spokenB, spokenC;
    private string readingA, readingB, readingC;
    private string writingA, writingB, writingC;
    private string skillname1, skillname2, skillname3;
    private string init1, init2, init3;
    private string year1, year2, year3;
    private string asso1, asso2, asso3;



    private List<Dependants> GetDependants5()
    {

        return new List<Dependants>
            {

                new Dependants{Title = title1, SurName = surname1, FirstName = firstName1, OtherName = othername1,
                    DateOfBirth = dateofBirth1, Relationship = relationship1},
                 new Dependants{Title = title2, SurName = surname2, FirstName = firstName2, OtherName = othername2,
                    DateOfBirth = dateofBirth2, Relationship = relationship2},
                  new Dependants{Title = title3, SurName = surname3, FirstName = firstName3, OtherName = othername3,
                    DateOfBirth = dateofBirth3, Relationship = relationship3},
                   new Dependants{Title = title4, SurName = surname4, FirstName = firstName4, OtherName = othername4,
                    DateOfBirth = dateofBirth4, Relationship = relationship4},
                    new Dependants{Title = title5, SurName = surname5, FirstName = firstName5, OtherName = othername5,
                    DateOfBirth = dateofBirth5, Relationship = relationship5},
            };


    }


    /*private List<Dependants> GetDependants4()
    {

        return new List<Dependants>
            {

                new Dependants{Number = "I",Title = title1, SurName = surname1, FirstName = firstName1, OtherName = othername1,
                    DateOfBirth = dateofBirth1, Relationship = relationship1},
                 new Dependants{Number = "II",Title = title2, SurName = surname2, FirstName = firstName2, OtherName = othername2,
                    DateOfBirth = dateofBirth2, Relationship = relationship2},
                  new Dependants{Number = "III",Title = title3, SurName = surname3, FirstName = firstName3, OtherName = othername3,
                    DateOfBirth = dateofBirth3, Relationship = relationship3},
                   new Dependants{Number = "IV",Title = title4, SurName = surname4, FirstName = firstName4, OtherName = othername4,
                    DateOfBirth = dateofBirth4, Relationship = relationship4},

            };


    }
    private List<Dependants> GetDependants3()
    {

        return new List<Dependants>
            {

                new Dependants{Number = "I",Title = title1, SurName = surname1, FirstName = firstName1, OtherName = othername1,
                    DateOfBirth = dateofBirth1, Relationship = relationship1},
                 new Dependants{Number = "II",Title = title2, SurName = surname2, FirstName = firstName2, OtherName = othername2,
                    DateOfBirth = dateofBirth2, Relationship = relationship2},
                  new Dependants{Number = "III",Title = title3, SurName = surname3, FirstName = firstName3, OtherName = othername3,
                    DateOfBirth = dateofBirth3, Relationship = relationship3},


            };


    }
    private List<Dependants> GetDependants2()
    {

        return new List<Dependants>
            {

                new Dependants{Number = "I",Title = title1, SurName = surname1, FirstName = firstName1, OtherName = othername1,
                    DateOfBirth = dateofBirth1, Relationship = relationship1},
                 new Dependants{Number = "II",Title = title2, SurName = surname2, FirstName = firstName2, OtherName = othername2,
                    DateOfBirth = dateofBirth2, Relationship = relationship2},

            };


    }
    private List<Dependants> GetDependants1()
    {

        return new List<Dependants>
            {

                new Dependants{Number = "I",Title = title1, SurName = surname1, FirstName = firstName1, OtherName = othername1,
                    DateOfBirth = dateofBirth1, Relationship = relationship1},

            };


    }*/

    private List<Skills> GetSkills()
    {
        return new List<Skills>
        {
            new Skills{Name = skillname1, Institution = init1, Year = year1},
        new Skills { Name = skillname2, Institution = init2, Year = year2 },
        new Skills { Name = skillname3, Institution = init3, Year = year3 },
        };
    }

    private List<Work> GetWork()
    {
        return new List<Work>
        {
            new Work { Name = "Samuel", staffID = "223444", socialSecurity="227274", subMetro="North", gradeLevel = "33"},
            new Work { Name = "Samuel", staffID = "223444", socialSecurity="227274", subMetro="North", gradeLevel = "33"},

        };
    }



    async void submitSearchByDepartment(object sender, EventArgs e)
    {
        changeButtonSubmitSearchByDepartment.Background = Colors.Teal;
        await Task.Delay(500); // Wait for 0.5 seconds (adjust time as needed)
        changeButtonSubmitSearchByDepartment.Background = Colors.DarkSlateGray;
        byPayment.IsVisible = false;
        bySubMetro.IsVisible = false;
        byStaffID.IsVisible = false;
        act2.IsRunning = true;
        if (!testsearchBuDepartmentEntry)
        {
            errorsearchByDepartment_entryStaffID.IsVisible = true;
            errorsearchByDepartment_entryStaffID.Text = "This field cannot be empty";
            act2.IsRunning = false;
        }
        else
        {
            if (isvalidsearchByDepartmentEntry)
            {
                ByDepartment.ItemsSource = await App.EmployeeRep.GetPeopleByDepartment(searchByDepartmentName);
                string check = App.EmployeeRep.statusMessage;

                act2.IsRunning = false;
                if (check != "Search Successful")
                {
                    byDepartment.IsVisible = false;
                    statusSubmitSearchDepartment.Text = "Failed to retrieve data";
                    statusSubmitSearchDepartment.IsVisible = true;
                }
                else
                {
                    byDepartment.IsVisible = true;
                }
            }
        }


    }

    async void submitSearchBySub_Metro(object sender, EventArgs e)
    {
        changeButtonSubmitSearchBySub_Metro.Background = Colors.Teal;
        await Task.Delay(500); // Wait for 0.5 seconds (adjust time as needed)
        changeButtonSubmitSearchBySub_Metro.Background = Colors.DarkSlateGray;

        byDepartment.IsVisible = false;
        byPayment.IsVisible = false;
        byStaffID.IsVisible = false;
        System.Diagnostics.Debug.WriteLine(searchBySub_Metro);
        act3.IsRunning = true;
        BySubMetro.ItemsSource = await App.EmployeeRep.GetPeopleBySubMetro(searchBySub_Metro);
        string check = App.EmployeeRep.statusMessage;

        if (check == "Success")
        {
            bySubMetro.IsVisible = true;
        }
        else
        {
            bySubMetro.IsVisible = false;

        }
        act3.IsRunning = false;
    }

    async void submitSearchBy_Payment(object sender, EventArgs e)
    {
        changeButtonSubmitSearchBy_Payment.Background = Colors.Teal;
        await Task.Delay(500); // Wait for 0.5 seconds (adjust time as needed)
        changeButtonSubmitSearchBy_Payment.Background = Colors.DarkSlateGray;

        byDepartment.IsVisible = false;
        bySubMetro.IsVisible = false;
        byStaffID.IsVisible = false;
        System.Diagnostics.Debug.WriteLine(searchByPayment_Mode);
        ByPaymentMode.ItemsSource = await App.EmployeeRep.GetPeopleByPaymentMode(searchByPayment_Mode);
        string check = App.EmployeeRep.statusMessage;

        if (check == "Success")
        {
            byPayment.IsVisible = true;
        }
        else
        {
            byPayment.IsVisible = false;

        }
        System.Diagnostics.Debug.WriteLine(App.EmployeeRep.statusMessage);
    }





















    //add
    //entries

    private bool isvalidStaffID = false;
    private bool isvalidPaymentMode = false;
    private bool isvalidSubMetro = false;
    private bool isvalidEmployeeTitle = false;
    private bool isvalidEmployeeSurname = false;
    private bool isvalidEmployeeFirstName = false;
    private bool isvalidEmployeeMiddleName = true;
    private bool isvalidFirstAppointmentDate = false;
    private bool isvalidDirectorate = false;
    private bool isvalidDepartment = false;
    private bool isvalidUnit = false;
    private bool isvalidSupervisor = true;
    private bool isvalidJobClass = false;
    private bool isvalidJobTitle = false;
    private bool isvalidJobGrade = false;
    private bool isvalidMaidenName = true;
    private bool isvalidNextOfKinSurname = true;
    private bool isvalidNextOfKinFirstName = true;
    private bool isvalidDependant1Surname = true;
    private bool isvalidDependant1FirstName = true;
    private bool isvalidDependant1MiddleName = true;
    private bool isvalidDependant2Surname = true;
    private bool isvalidDependant2FirstName = true;
    private bool isvalidDependant2MiddleName = true;
    private bool isvalidDependant3Surname = true;
    private bool isvalidDependant3FirstName = true;
    private bool isvalidDependant3MiddleName = true;
    private bool isvalidDependant4Surname = true;
    private bool isvalidDependant4FirstName = true;
    private bool isvalidDependant4MiddleName = true;
    private bool isvalidDependant5Surname = true;
    private bool isvalidDependant5FirstName = true;
    private bool isvalidDependant5MiddleName = true;
    private bool language1 = true;
    private bool language2 = true;
    private bool language3 = true;









    private string identificationStaffID;
    private string identificationSocialSecurity;
    private string identificationNHIS = "";
    private string identificationIntPassport = "";
    private string identificationVotersID = "";
    private string identificationNationalID = "";
    private string identificationDriversLicense = "";
    private string employeeDetialsSurname = "";
    private string employeeDetialsFirstName = "";
    private string employeeDetialsMiddleName = "";
    private string employeeDetialsDirectorate = "";
    private string employeeDetialsDepartment = "";
    private string employeeDetialsUnit = "";
    private string employeeDetialsImmediateSupervisor = "";
    private string employeeDetialsCostCenter = "";
    private string employeeDetialsJobClass = "";
    private string employeeDetialsJobTitle = "";
    private string employeeDetialsJobGrade = "";
    private string employeeDetialsGradeLevel = "";
    private string employeeDetialsGradePoint = "";
    private string bankDetialsBankName = "";
    private string bankDetialsBankBranchName = "";
    private string bankDetialsBankAccount = "";
    private string biographicalDataMaidenName = "";
    private string biographicalDataPlaceOfBirth = "";
    private string biographicalDataHomeTown = "";
    private string biographicalDataReligion = "";
    private string residentialHouseNo = "";
    private string residentialStreetName = "";
    private string residentialArea = "";
    private string residentialTownCity = "";
    private string otherPostalAddress = "";
    private string otherEmailAddress = "";
    private string otherPhoneNo = "";
    private string otherMobileNo = "";
    private string disableState = "";
    private string disableReason = "";
    private string nextOfKinSurname = "";
    private string nextOfKinFirstName = "";
    private string nextOfKinRelationship = "";
    private string nextOfKinContactHouseNo = "";
    private string nextOfKinContactStreetName = "";
    private string nextOfKinContactArea = "";
    private string nextOfKinContactCityTown = "";
    private string nextOfKinContactPhoneNo = "";
    private string dependant1Surname = "";
    private string dependant1FirstName = "";
    private string dependant1MiddleName = "";
    private string dependant1Relationship = "";
    private string dependant2Surname = "";
    private string dependant2FirstName = "";
    private string dependant2MiddleName = "";
    private string dependant2Relationship = "";
    private string dependant3Surname = "";
    private string dependant3FirstName = "";
    private string dependant3MiddleName = "";
    private string dependant3Relationship;
    private string dependant4Surname = "";
    private string dependant4FirstName = "";
    private string dependant4MiddleName = "";
    private string dependant4Relationship = "";
    private string dependant5Surname = "";
    private string dependant5FirstName = "";
    private string dependant5MiddleName = "";
    private string dependant5Relationship;
    private string educationInstitutionName = "";
    private string educationQualificationObtained = "";
    private string educationCourseStudied = "";
    private string educationEntryCertificate = "";
    private string skills1Type = "";
    private string skills2Type = "";
    private string skills3Type = "";
    private string skills1InstitutionName = "";
    private string skills2InstitutionName = "";
    private string skills3InstitutionName = "";
    private string association1Name = "";
    private string association2Name = "";
    private string association3Name = "";
    private string language1Name = "";
    private string language2Name = "";
    private string language3Name = "";
    //
    private bool testInputIdentificationStaffIDError = false;
    private bool testInputIdentificationSocialSecurityError = false;
    private bool testInputIdentificationNHISError = false;
    private bool testInputIdentificationIntPassportError = false;
    private bool testInputIdentificationVotersIDError = false;
    private bool testInputIdentificationNationalIDError = false;
    private bool testInputIdentificationDriversLicenseError = false;
    private bool testInputEmployeeDetialsSurnameError = false;
    private bool testInputEmployeeDetialsFirstNameError = false;
    private bool testInputEmployeeDetialsMiddleNameError = false;
    private bool testInputEmployeeDetialsDirectorateError = false;
    private bool testInputEmployeeDetialsDepartmentError = false;
    private bool testInputEmployeeDetialsUnitError = false;
    private bool testInputEmployeeDetialsImmediateSupervisorError = false;
    private bool testInputEmployeeDetialsCostCenterError = false;
    private bool testInputEmployeeDetialsJobClassError = false;
    private bool testInputEmployeeDetialsJobTitleError = false;
    private bool testInputEmployeeDetialsJobGradeError = false;
    private bool testInputEmployeeDetialsGradeLevelError = false;
    private bool testInputEmployeeDetialsGradePointError = false;
    private bool testInputBankDetialsBankNameError = false;
    private bool testInputBankDetialsBankBranchNameError = false;
    private bool testInputBankDetialsBankAccountError = false;
    private bool testInputBiographicalDataMaidenNameError = false;
    private bool testInputBiographicalDataPlaceOfBirthError = false;
    private bool testInputBiographicalDataHomeTownError = false;
    private bool testInputBiographicalDataReligionError = false;
    private bool testInputResidentialHouseNoError = false;
    private bool testInputResidentialStreetNameError = false;
    private bool testInputResidentialAreaEroor = false;
    private bool testInputResidentialTownCityError = false;
    private bool testInputOtherPortalAddressError = false;
    private bool testInputOtherEmailAddressError = false;
    private bool testInputOtherPhoneNoError = false;
    private bool testInputOtherMobileNoError = false;
    private bool testInputDisableYes = false;
    private bool testInputDisableNo = false;
    private bool testInputNextOfKinSurnameError = false;
    private bool testInputNextOfKinFirstNameError = false;
    private bool testInputNextOfKinRelationshipError = false;
    private bool testInputNextOfKinContactHouseNoError = false;
    private bool testInputNextOfKinContactStreetNameError = false;
    private bool testInputNextOfKinContactAreaError = false;
    private bool testInputNextOfKinContactCityTownError = false;
    private bool testInputNextOfKinContactPhoneNoError = false;
    private bool testInputDependant1SurnameError = false;
    private bool testInputDependant1FirstNameError = false;
    private bool testInputDependant1MiddleNameError = false;
    private bool testInputDependant1RelationshipError = false;
    private bool testInputDependant2SurnameError = false;
    private bool testInputDependant2FirstNameError = false;
    private bool testInputDependant2MiddleNameError = false;
    private bool testInputDependant2RelationshipError = false;
    private bool testInputDependant3SurnameError = false;
    private bool testInputDependant3FirstNameError = false;
    private bool testInputDependant3MiddleNameError = false;
    private bool testInputDependant3RelationshipError = false;
    private bool testInputDependant4SurnameError = false;
    private bool testInputDependant4FirstNameError = false;
    private bool testInputDependant4MiddleNameError = false;
    private bool testInputDependant4RelationshipError = false;
    private bool testInputDependant5SurnameError = false;
    private bool testInputDependant5FirstNameError = false;
    private bool testInputDependant5MiddleNameError = false;
    private bool testInputDependant5RelationshipError = false;
    private bool testInputEducationInstitutionNameError = false;
    private bool testInputEducationQualificationObtainedError = false;
    private bool testInputEducationCourseStudiedError = false;
    private bool testInputEducationEntryCertificateError = false;
    private bool testInputSkills1TypeError = false;
    private bool testInputSkills2TypeError = false;
    private bool testInputSkills3TypeError = false;
    private bool testInputSkills1InstitutionNameError = false;
    private bool testInputSkills2InstitutionNameError = false;
    private bool testInputSkills3InstitutionNameError = false;
    private bool testInputAssociation1NameError = false;
    private bool testInputAssociation2NameError = false;
    private bool testInputAssociation3NameError = false;
    private bool testInputLanguage1NameError = false;
    private bool testInputLanguage2NameError = false;
    private bool testInputLanguage3NameError = false;


    //date picker
    private string identificationIntPassportExpiryDate;
    private string employeeDetialsAppointmentDate;
    private string employeeDetialsRetirementDate;
    private string employeeDetialsLastPromotionDate;
    private string biographicalDataDateOfBirth;
    private string dependant1DateOfBirth;
    private string dependant2DateOfBirth;
    private string dependant3DateOfBirth;
    private string dependant4DateOfBirth;
    private string dependant5DateOfBirth;
    private string educationTo;
    private string educationFrom;
    private string skills1YearObtained;
    private string skills2YearObtained;
    private string skills3YearObtained;
    //
    private bool testInputIdentificationIntPassportExpiryDateError = false;
    private bool testInputEmployeeDetialsAppointmentDateError = false;
    private bool testInputEmployeeDetialsRetirementDateError = false;
    private bool testInputEmployeeDetialsLastPromotionDateError = false;
    private bool testInputBiographicalDataDateOfBirthError = false;
    private bool testInputDependant1DateOfBirthError = false;
    private bool testInputDependant2DateOfBirthError = false;
    private bool testInputDependant3DateOfBirthError = false;
    private bool testInputDependant4DateOfBirthError = false;
    private bool testInputDependant5DateOfBirthError = false;
    private bool testInputEducationToError = false;
    private bool testInputEducationFromError = false;
    private bool testInputSkills1YearObtainedError = false;
    private bool testInputSkills2YearObtainedError = false;
    private bool testInputSkills3YearObtainedError = false;


    void OnDatePickerIntPassportExpiryDate(object sender, DateChangedEventArgs e)
    {
        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 02, 01);
        string desiredDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desiredDateFormat)
        {
            identificationIntPassportExpiryDate = "";
        }
        else
        {
            identificationIntPassportExpiryDate = selectedDateFormat;
        }
    }

    void OnDatePickerEmployeeDetialsAppointmentDateDate(object sender, DateChangedEventArgs e)
    {
        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 02, 01);
        string desireDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            testInputEmployeeDetialsAppointmentDateError = false;
            isvalidFirstAppointmentDate = false;
        }
        else
        {
            testInputEmployeeDetialsAppointmentDateError = true;
            employeeDetialsAppointmentDate = selectedDateFormat;
            inputEmployeeDetailsAppointmentDateError.IsVisible = false;
            inputEmployeeDetailsAppointmentDateError.Text = string.Empty;
            isvalidFirstAppointmentDate = true;
        }
    }

    void OnDatePickerEmployeeDetialsRetirementDate(object sender, DateChangedEventArgs e)
    {

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 02, 01);
        string desireDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            testInputEmployeeDetialsRetirementDateError = false;
            employeeDetialsRetirementDate = "";
        }
        else
        {
            employeeDetialsRetirementDate = selectedDateFormat;
            testInputEmployeeDetialsRetirementDateError = true;
        }
    }

    void OnDatePickerEmployeeDetialsLastPromotionDate(object sender, DateChangedEventArgs e)
    {

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 02, 01);
        string desireDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            testInputEmployeeDetialsLastPromotionDateError = false;
            employeeDetialsLastPromotionDate = "";
        }
        else
        {
            employeeDetialsLastPromotionDate = selectedDateFormat;
            testInputEmployeeDetialsLastPromotionDateError = true;
        }
    }

    void OnDatePickerBiographicalDataDateOfBirthDate(object sender, DateChangedEventArgs e)
    {

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 02, 01);
        string desireDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            testInputBiographicalDataDateOfBirthError = false;
            biographicalDataDateOfBirth = "";
        }
        else
        {
            biographicalDataDateOfBirth = selectedDateFormat;
            testInputBiographicalDataDateOfBirthError = true;
        }
    }

    void OnDatePickerDependant1DateOfBirthDate(object sender, DateChangedEventArgs e)
    {

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 02, 01);
        string desireDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            testInputDependant1DateOfBirthError = false;
            dependant1DateOfBirth = "";
        }
        else
        {
            dependant1DateOfBirth = selectedDateFormat;
            testInputDependant1DateOfBirthError = true;
        }
    }

    void OnDatePickerDependant2DateOfBirthDate(object sender, DateChangedEventArgs e)
    {

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 02, 01);
        string desireDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            testInputDependant2DateOfBirthError = false;
            dependant2DateOfBirth = "";
        }
        else
        {
            dependant2DateOfBirth = selectedDateFormat;
            testInputDependant2DateOfBirthError = true;
        }
    }

    void OnDatePickerDependant3DateOfBirthDate(object sender, DateChangedEventArgs e)
    {

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 02, 01);
        string desireDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            testInputDependant3DateOfBirthError = false;
            dependant3DateOfBirth = "";
        }
        else
        {
            dependant3DateOfBirth = selectedDateFormat;
            testInputDependant3DateOfBirthError = true;
        }
    }

    void OnDatePickerDependant4DateOfBirthDate(object sender, DateChangedEventArgs e)
    {

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 02, 01);
        string desireDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            testInputDependant4DateOfBirthError = false;
            dependant4DateOfBirth = "";
        }
        else
        {
            dependant4DateOfBirth = selectedDateFormat;
            testInputDependant4DateOfBirthError = true;
        }
    }

    void OnDatePickerDependant5DateOfBirthDate(object sender, DateChangedEventArgs e)
    {

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 02, 01);
        string desireDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            testInputDependant5DateOfBirthError = false;
            dependant5DateOfBirth = "";
        }
        else
        {
            dependant5DateOfBirth = selectedDateFormat;
            testInputDependant5DateOfBirthError = true;
        }
    }

    void OnDatePickerEducationToDate(object sender, DateChangedEventArgs e)
    {

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 02, 01);
        string desireDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            testInputEducationToError = false;
            educationTo = "";
        }
        else
        {
            educationTo = selectedDateFormat;
            testInputEducationToError = true;
        }
    }


    void OnDatePickerEducationFromDate(object sender, DateChangedEventArgs e)
    {

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 02, 01);
        string desireDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            testInputEducationFromError = false;
            educationFrom = "";
        }
        else
        {
            educationFrom = selectedDateFormat;
            testInputEducationFromError = true;
        }
    }

    void OnDatePickerSkills1YearObtainedDate(object sender, DateChangedEventArgs e)
    {

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 02, 01);
        string desireDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            testInputSkills1YearObtainedError = false;
            skills1YearObtained = "";
        }
        else
        {
            skills1YearObtained = selectedDateFormat;
            testInputSkills1YearObtainedError = true;
        }
    }

    void OnDatePickerSkills2YearObtainedDate(object sender, DateChangedEventArgs e)
    {

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 02, 01);
        string desireDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            testInputSkills2YearObtainedError = false;
            skills2YearObtained = "";
        }
        else
        {
            skills2YearObtained = selectedDateFormat;
            testInputSkills2YearObtainedError = true;
        }
    }

    void OnDatePickerSkills3YearObtainedDate(object sender, DateChangedEventArgs e)
    {

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 02, 01);
        string desireDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            testInputSkills3YearObtainedError = false;
            skills3YearObtained = "";
        }
        else
        {
            skills3YearObtained = selectedDateFormat;
            testInputSkills3YearObtainedError = true;
        }
    }







    void OnInputStaffIDTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputIdentificationStaffID.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            testInputIdentificationStaffIDError = true;
            identificationStaffID = entryValue;
            inputIdentificationStaffIDError.IsVisible = false;
            isvalidStaffID = true;
        }
        else
        {
            testInputIdentificationStaffIDError = false;
            isvalidStaffID = false;
        }

    }

    void OnInputSocialSecurityTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputIdentificationSocialSecurity.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            testInputIdentificationSocialSecurityError = true;
            identificationSocialSecurity = entryValue;
            inputIdentificationSocialSecurityError.IsVisible = false;
        }
        else
        {
            testInputIdentificationSocialSecurityError = false;
        }
    }

    void OnInputNHISTextChanged(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputIdentificationNHIS.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            testInputIdentificationNHISError = true;
            identificationNHIS = entryValue;
            inputIdentificationNHISError.IsVisible = false;
        }
        else
        {
            testInputIdentificationNHISError = false;
        }
    }

    void OnInputIntPassportTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputIdentificationIntPassport.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            testInputIdentificationIntPassportError = true;
            identificationIntPassport = entryValue;
            inputIdentificationIntPassportError.IsVisible = false;
        }
        else
        {
            testInputIdentificationIntPassportError = false;
        }
    }


    void OnInputVotersIDTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputIdentificationVotersID.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            testInputIdentificationVotersIDError = true;
            identificationVotersID = entryValue;
            inputIdentificationVotersIDError.IsVisible = false;
        }
        else
        {
            testInputIdentificationVotersIDError = false;
        }
    }

    void OnInputNationalIDTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputIdentificationNationalID.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            testInputIdentificationNationalIDError = true;
            identificationNationalID = entryValue;
            inputIdentificationNationalIDError.IsVisible = false;
        }
        else
        {
            testInputIdentificationNationalIDError = false;
        }
    }

    void OnInputDriversLicenseTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputIdentificationDriversLicense.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            testInputIdentificationDriversLicenseError = true;
            identificationDriversLicense = entryValue;
            inputIdentificationDriversLicenseError.IsVisible = false;
        }
        else
        {
            testInputIdentificationDriversLicenseError = false;
        }
    }



    //a
    void OnInputSurnameTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputEmployeeDetialsSurname.Text;
        if (!(string.IsNullOrEmpty(entryValue)) && entryValue.All(char.IsLetter))
        {
            employeeDetialsSurname = entryValue;
            testInputEmployeeDetialsSurnameError = true;
            inputEmployeeDetialsSurnameError.IsVisible = false;
            isvalidEmployeeSurname = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            inputEmployeeDetialsSurnameError.IsVisible = true;
            inputEmployeeDetialsSurnameError.Text = "This field must contain only letters";
            testInputEmployeeDetialsSurnameError = true;
            isvalidEmployeeSurname = false;
        }
        else
        {
            testInputEmployeeDetialsSurnameError = false;
            inputEmployeeDetialsSurnameError.IsVisible = false;
            isvalidEmployeeSurname = false;
        }

    }
    //a
    void OnInputFirstNameTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputEmployeeDetialsFirstName.Text;
        if (!(string.IsNullOrEmpty(entryValue)) && entryValue.All(char.IsLetter))
        {
            employeeDetialsFirstName = entryValue;
            testInputEmployeeDetialsFirstNameError = true;
            inputEmployeeDetialsFirstNameError.IsVisible = false;
            isvalidEmployeeFirstName = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            testInputEmployeeDetialsFirstNameError = true;
            inputEmployeeDetialsFirstNameError.IsVisible = true;
            inputEmployeeDetialsFirstNameError.Text = "This field must contain only letters";
            isvalidEmployeeFirstName = false;
        }
        else
        {
            testInputEmployeeDetialsFirstNameError = false;
            inputEmployeeDetialsFirstNameError.IsVisible = false;
            isvalidEmployeeFirstName = false;

        }
    }
    //a
    void OnInputMiddleNameTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputEmployeeDetialsMiddleName.Text;
        if (!(string.IsNullOrEmpty(entryValue)) && entryValue.All(char.IsLetter))
        {
            employeeDetialsMiddleName = entryValue;
            testInputEmployeeDetialsMiddleNameError = true;
            inputEmployeeDetialsMiddleNameError.IsVisible = false;
            isvalidEmployeeMiddleName = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            testInputEmployeeDetialsMiddleNameError = true;
            inputEmployeeDetialsMiddleNameError.IsVisible = true;
            inputEmployeeDetialsMiddleNameError.Text = "This field must contain only letters";
            isvalidEmployeeMiddleName = false;
        }
        else
        {
            employeeDetialsMiddleName = "";
            testInputEmployeeDetialsMiddleNameError = false;
            inputEmployeeDetialsMiddleNameError.IsVisible = false;
            isvalidEmployeeMiddleName = true;
        }
    }

    //a
    void OnInputDirectorateTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputEmployeeDetialsDirectorate.Text;
        if (!(string.IsNullOrEmpty(entryValue)) && entryValue.All(char.IsLetter))
        {
            employeeDetialsDirectorate = entryValue;
            testInputEmployeeDetialsDirectorateError = true;
            inputEmployeeDetialsDirectorateError.IsVisible = false;
            isvalidDirectorate = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            testInputEmployeeDetialsDirectorateError = true;
            inputEmployeeDetialsDirectorateError.IsVisible = true;
            inputEmployeeDetialsDirectorateError.Text = "This field must contain only letters";
            isvalidDirectorate = false;
        }
        else
        {
            testInputEmployeeDetialsDirectorateError = false;
            inputEmployeeDetialsDirectorateError.IsVisible = false;
            isvalidDirectorate = false;
        }
    }

    void OnInputDepartmentTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputEmployeeDetialsDepartment.Text;
        if (!(string.IsNullOrEmpty(entryValue)) && entryValue.All(char.IsLetter))
        {
            employeeDetialsDepartment = entryValue;
            testInputEmployeeDetialsDepartmentError = true;
            inputEmployeeDetialsDepartmentError.IsVisible = false;
            isvalidDepartment = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            testInputEmployeeDetialsDepartmentError = true;
            inputEmployeeDetialsDepartmentError.IsVisible = true;
            inputEmployeeDetialsDepartmentError.Text = "This field must contain only letters";
            isvalidDepartment = false;
        }
        else
        {
            testInputEmployeeDetialsDepartmentError = false;
            inputEmployeeDetialsDepartmentError.IsVisible = false;
            isvalidDepartment = false;

        }
    }

    void OnInputUnitTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputEmployeeDetialsUnit.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            employeeDetialsUnit = entryValue;
            inputEmployeeDetialsUnitError.IsVisible = false;
            testInputEmployeeDetialsUnitError = true;
            isvalidUnit = true;
        }
        else
        {
            testInputEmployeeDetialsUnitError = false;
            isvalidUnit = false;
        }
    }

    //a
    void OnInputImmediateSupervisorTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputEmployeeDetialsImmediateSupervisor.Text;
        if (!(string.IsNullOrEmpty(entryValue)) && entryValue.All(char.IsLetter))
        {
            employeeDetialsImmediateSupervisor = entryValue;
            testInputEmployeeDetialsImmediateSupervisorError = true;
            inputEmployeeDetialsImmediateSupervisorError.IsVisible = false;
            isvalidSupervisor = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            testInputEmployeeDetialsImmediateSupervisorError = true;
            inputEmployeeDetialsImmediateSupervisorError.IsVisible = true;
            inputEmployeeDetialsImmediateSupervisorError.Text = "This field must contain only letters";
            isvalidSupervisor = false;
        }
        else
        {
            employeeDetialsImmediateSupervisor = "";
            testInputEmployeeDetialsImmediateSupervisorError = false;
            inputEmployeeDetialsImmediateSupervisorError.IsVisible = false;

            isvalidSupervisor = true;
        }
    }

    void OnInputCostCenterTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputEmployeeDetialsCostCenter.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            employeeDetialsCostCenter = entryValue;
            testInputEmployeeDetialsCostCenterError = true;
            inputEmployeeDetialsCostCenterError.IsVisible = false;
        }
        else
        {
            employeeDetialsCostCenter = "";
            testInputEmployeeDetialsCostCenterError = false;
        }
    }

    void OnInputJobClassTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputEmployeeDetialsJobClass.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            employeeDetialsJobClass = entryValue;
            inputEmployeeDetialsJobClassError.IsVisible = false;
            testInputEmployeeDetialsJobClassError = true;
            isvalidJobClass = true;
        }
        else
        {
            testInputEmployeeDetialsJobClassError = false;
            isvalidJobClass = false;
        }
    }

    void OnInputJobTitleTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputEmployeeDetialsJobTitle.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            employeeDetialsJobTitle = entryValue;
            inputEmployeeDetialsJobTitleError.IsVisible = false;
            testInputEmployeeDetialsJobTitleError = true;
            isvalidJobTitle = true;
        }
        else
        {
            testInputEmployeeDetialsJobTitleError = false;
            isvalidJobTitle = false;
        }
    }

    void OnInputJobGradeTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputEmployeeDetialsJobGrade.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            employeeDetialsJobGrade = entryValue;
            testInputEmployeeDetialsJobGradeError = true;
            inputEmployeeDetialsJobGradeError.IsVisible = false;
            isvalidJobGrade = true;
        }
        else
        {
            testInputEmployeeDetialsJobGradeError = false;
            isvalidJobGrade = false;
        }
    }

    void OnInputGradeLevelTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputEmployeeDetialsGradeLevel.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            employeeDetialsGradeLevel = entryValue;
            testInputEmployeeDetialsJobGradeError = true;
            inputEmployeeDetialsGradeLevelError.IsVisible = false;
        }
        else
        {
            employeeDetialsGradeLevel = "";
            testInputEmployeeDetialsGradeLevelError = false;
        }

    }

    void OnInputGradePointTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputEmployeeDetialsGradePoint.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            employeeDetialsGradePoint = entryValue;
            testInputEmployeeDetialsGradePointError = true;
            inputEmployeeDetialsGradePointError.IsVisible = false;

        }
        else
        {
            employeeDetialsGradePoint = "";
            testInputEmployeeDetialsGradePointError = false;
        }
    }

    void OnInputBankNameTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputBankDetialsBankName.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            bankDetialsBankName = entryValue;
            testInputBankDetialsBankNameError = true;
            inputBankDetialsBankBranchNameError.IsVisible = false;
        }
        else
        {
            bankDetialsBankName = "";
            testInputBankDetialsBankNameError = false;
        }

    }

    void OnInputBankBranchNameTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputBankDetialsBankBranchName.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            testInputBankDetialsBankBranchNameError = true;
            inputBankDetialsBankBranchNameError.IsVisible = false;
            bankDetialsBankBranchName = entryValue;
        }
        else
        {
            bankDetialsBankBranchName = "";
            testInputBankDetialsBankBranchNameError = false;
        }


    }

    void OnInputBankAccountTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputBankDetialsBankAccount.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            bankDetialsBankAccount = entryValue;
            inputBankDetialsBankAccountError.IsVisible = false;
            testInputBankDetialsBankAccountError = true;
        }
        else
        {
            bankDetialsBankAccount = "";
            testInputBankDetialsBankBranchNameError = false;
        }
    }

    void OnInputMaidenNameTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputBiographicalDataMaidenName.Text;
        if (!(string.IsNullOrEmpty(entryValue)) && entryValue.All(char.IsLetter))
        {
            biographicalDataMaidenName = entryValue;
            testInputBiographicalDataMaidenNameError = true;
            inputBiographicalDataMaidenNameError.IsVisible = false;
            isvalidMaidenName = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            testInputBiographicalDataMaidenNameError = true;
            inputBiographicalDataMaidenNameError.IsVisible = true;
            inputBiographicalDataMaidenNameError.Text = "This field must contain only letters";
            isvalidMaidenName = false;
        }
        else
        {
            biographicalDataMaidenName = "";
            testInputBiographicalDataMaidenNameError = false;
            isvalidMaidenName = true;
        }
    }

    void OnInputPlaceOfBirthTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputBiographicalDataPlaceOfBirth.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            biographicalDataPlaceOfBirth = entryValue;
            testInputBiographicalDataPlaceOfBirthError = true;
            inputBiographicalDataPlaceOfBirthError.IsVisible = false;
        }
        else
        {
            biographicalDataPlaceOfBirth = "";
            testInputBiographicalDataPlaceOfBirthError = false;
        }
    }

    void OnInputHomeTownTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputBiographicalDataHomeTown.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            biographicalDataHomeTown = entryValue;
            testInputBiographicalDataHomeTownError = true;
            inputBiographicalDataHomeTownError.IsVisible = false;
        }
        else
        {
            biographicalDataHomeTown = "";
            testInputBiographicalDataHomeTownError = false;

        }
    }

    void OnInputReligionTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputBiographicalDataReligion.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            biographicalDataReligion = entryValue;
            testInputBiographicalDataReligionError = true;
            inputBiographicalDataReligionError.IsVisible = false;
        }
        else
        {
            biographicalDataReligion = "";
            testInputBiographicalDataReligionError = false;
        }
    }

    void OnInputHouseNoTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputResidentialHouseNo.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            residentialHouseNo = entryValue;
            testInputResidentialHouseNoError = true;
            inputResidentialHouseNoError.IsVisible = false;
        }
        else
        {
            residentialHouseNo = "";
            testInputResidentialHouseNoError = false;
        }
    }

    void OnInputStreetNameTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputResidentialStreetName.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            residentialStreetName = entryValue;
            testInputResidentialStreetNameError = true;
            inputResidentialStreetNameError.IsVisible = false;
        }
        else
        {
            residentialStreetName = "";
            testInputResidentialStreetNameError = false;
        }
    }

    void OnInputAreaTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputResidentialArea.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            residentialArea = entryValue;
            testInputResidentialAreaEroor = true;
            inputResidentialAreaError.IsVisible = false;
        }
        else
        {
            residentialArea = "";
            testInputResidentialAreaEroor = false;
        }
    }

    void OnInputTownCityTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputResidentialTownCity.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            residentialTownCity = entryValue;
            testInputResidentialTownCityError = true;
            inputResidentialTownCityError.IsVisible = false;
        }
        else
        {
            residentialArea = "";
            testInputResidentialTownCityError = false;
        }
    }

    void OnInputPostalAddressTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputOtherPostalAddress.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            otherPostalAddress = entryValue;
            testInputOtherPortalAddressError = true;
            inputOtherPostalAddressError.IsVisible = false;
        }
        else
        {
            otherPostalAddress = "";
            testInputOtherPortalAddressError = false;
        }
    }

    void OnInputEmailAddressTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputOtherEmailAddress.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && IsEmailValid(entryValue))
        {
            otherEmailAddress = entryValue;
            testInputOtherEmailAddressError = true;
            inputOtherEmailAddressError.IsVisible = false;
        }
        else if (!(IsEmailValid(entryValue)))
        {
            inputOtherEmailAddressError.IsVisible = true;
            inputOtherEmailAddressError.Text = "This is not a valid email address";
        }
        else
        {
            otherEmailAddress = "";
            testInputOtherEmailAddressError = false;
            inputOtherEmailAddressError.IsVisible = false;
        }
    }

    void OnInputPhoneNoTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputOtherPhoneNo.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            if (IsPhoneNumberValid(entryValue))
            {
                otherPhoneNo = entryValue;
                testInputOtherPhoneNoError = true;
                inputOtherPhoneNoError.IsVisible = false;
            }
            else
            {
                testInputOtherPhoneNoError = false;
                inputOtherPhoneNoError.IsVisible = true;
                inputOtherPhoneNoError.Text = "This field can be only number";
            }
        }
        else
        {
            otherPhoneNo = "";
            testInputOtherPhoneNoError = false;
            inputOtherPhoneNoError.IsVisible = false;

        }
    }

    void OnInputMobileNoTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputOtherMobileNo.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && IsPhoneNumberValid(entryValue))
        {
            otherMobileNo = entryValue;
            testInputOtherMobileNoError = true;
            inputOtherMobileNoError.IsVisible = false;
        }
        else if (!(IsPhoneNumberValid(entryValue)))
        {
            testInputOtherPhoneNoError = true;
            inputOtherMobileNoError.IsVisible = true;
            inputOtherMobileNoError.Text = "This field can be only number";
        }
        else
        {
            otherMobileNo = "";
            testInputOtherMobileNoError = false;
            inputOtherMobileNoError.IsVisible = false;

        }
    }

    void OnCheckDiableYes(object sender, CheckedChangedEventArgs e)
    {
        inputDiableState.IsVisible = true;
        specifyYes.IsVisible = true;
        disableState = "Yes";
    }

    void OnCheckDiableNo(object sender, CheckedChangedEventArgs e)
    {
        inputDiableState.IsVisible = false;
        specifyYes.IsVisible = false;
        disableState = "No";
        disableReason = "";
        inputDiableState.Text = string.Empty;

    }

    void OnDiableStateTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputDiableState.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            disableReason = entryValue;
        }
        else
        {
            disableReason = "";
        }
    }


    void OnInputNextOfKinSurnameTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputNextOfKinSurname.Text;
        if (!(string.IsNullOrEmpty(entryValue)) && entryValue.All(char.IsLetter))
        {
            nextOfKinSurname = entryValue;
            testInputNextOfKinSurnameError = true;
            inputNextOfKinSurnameError.IsVisible = false;
            isvalidNextOfKinSurname = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            testInputNextOfKinSurnameError = true;
            inputNextOfKinSurnameError.IsVisible = true;
            inputNextOfKinSurnameError.Text = "This field must contain only letters";
            isvalidNextOfKinSurname = false;
        }
        else
        {
            nextOfKinSurname = "";
            testInputNextOfKinSurnameError = true;
            inputNextOfKinSurnameError.IsVisible = false;
            isvalidNextOfKinSurname = true;
        }

    }

    void OnInputNextOfKinFirstNameTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputNextOfKinFirstName.Text;
        if (!(string.IsNullOrEmpty(entryValue)) && entryValue.All(char.IsLetter))
        {
            nextOfKinFirstName = entryValue;
            testInputNextOfKinFirstNameError = true;
            inputNextOfKinFirstNameError.IsVisible = false;
            isvalidNextOfKinFirstName = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            testInputNextOfKinFirstNameError = true;
            inputNextOfKinFirstNameError.IsVisible = true;
            inputNextOfKinFirstNameError.Text = "This field must contain only letters";
            isvalidNextOfKinFirstName = false;
        }
        else
        {
            testInputNextOfKinFirstNameError = false;
            nextOfKinFirstName = "";
            inputNextOfKinFirstNameError.IsVisible = false;
            isvalidNextOfKinFirstName = true;
        }
    }

    void OnInputNextOfKinRelationshipTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputNextOfKinRelationship.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            nextOfKinRelationship = entryValue;
            testInputNextOfKinRelationshipError = true;
            inputNextOfKinRelationshipError.IsVisible = false;
        }
        else
        {
            nextOfKinRelationship = "";
            testInputNextOfKinRelationshipError = false;
        }
    }

    void OnInputNextOfKinContactHouseNoTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputNextOfKinContactHouseNo.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            nextOfKinContactHouseNo = entryValue;
            testInputNextOfKinContactHouseNoError = true;
            inputNextOfKinContactHouseNoError.IsVisible = false;
        }
        else
        {
            nextOfKinContactHouseNo = "";
            testInputNextOfKinContactHouseNoError = false;
            inputNextOfKinContactHouseNoError.IsVisible = false;

        }
    }

    void OnInputNextOfKinContactStreetNameTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputNextOfKinContactStreetName.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            nextOfKinContactStreetName = entryValue;
            testInputNextOfKinContactStreetNameError = true;
            inputNextOfKinContactStreetNameError.IsVisible = false;
        }
        else
        {
            nextOfKinContactStreetName = "";
            testInputNextOfKinContactStreetNameError = false;
        }
    }

    void OnInputNextOfKinContactAreaTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputNextOfKinContactArea.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            nextOfKinContactArea = entryValue;
            testInputNextOfKinContactAreaError = true;
            inputNextOfKinContactAreaError.IsVisible = false;
        }
        else
        {
            nextOfKinContactArea = "";
            testInputNextOfKinContactAreaError = false;
        }
    }

    void OnInputNextOfKinContactCityTownTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = inputNextOfKinContactCityTown.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            nextOfKinContactCityTown = entryValue;
            inputNextOfKinContactCityTownError.IsVisible = false;
            testInputNextOfKinContactCityTownError = true;
        }
        else
        {
            testInputNextOfKinContactCityTownError = false;
            nextOfKinContactCityTown = "";
        }
    }

    void OnInputNextOfKinContactPhoneNoTextChange(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputNextOfKinContactPhoneNo.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && IsPhoneNumberValid(entryValue))
        {
            nextOfKinContactPhoneNo = entryValue;
            testInputNextOfKinContactPhoneNoError = true;
            inputNextOfKinContactPhoneNoError.IsVisible = false;
        }
        else if (!(IsPhoneNumberValid(entryValue)))
        {
            testInputNextOfKinContactPhoneNoError = true;
            inputNextOfKinContactPhoneNoError.Text = "This field can be numbers only";
            inputNextOfKinContactPhoneNoError.IsVisible = true;
        }
        else
        {
            nextOfKinContactPhoneNo = "";
            testInputNextOfKinContactPhoneNoError = false;
            inputNextOfKinContactPhoneNoError.IsVisible = false;

        }
    }

    void OnInputDependant1SurnameTextChange(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputDependant1Surname.Text;
        if (!(string.IsNullOrEmpty(entryValue)) && entryValue.All(char.IsLetter))
        {
            dependant1Surname = entryValue;
            testInputDependant1SurnameError = true;
            inputDependant1SurnameError.IsVisible = false;
            isvalidDependant1Surname = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            testInputDependant1SurnameError = true;
            inputDependant1SurnameError.IsVisible = true;
            inputDependant1SurnameError.Text = "This field must contain only letters";
            isvalidDependant1Surname = false;
        }
        else
        {
            dependant1Surname = "";
            testInputDependant1SurnameError = false;
            inputDependant1SurnameError.IsVisible = false;
            isvalidDependant1Surname = true;
        }

    }

    void OnInputDependant1FirstNameTextChange(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputDependant1FirstName.Text;
        if (!(string.IsNullOrEmpty(entryValue)) && entryValue.All(char.IsLetter))
        {
            dependant1FirstName = entryValue;
            testInputDependant1FirstNameError = true;
            inputDependant1FirstNameError.IsVisible = false;
            isvalidDependant1FirstName = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            testInputDependant1FirstNameError = true;
            inputDependant1FirstNameError.IsVisible = true;
            inputDependant1FirstNameError.Text = "This field must contain only letters";
            isvalidDependant1FirstName = false;
        }
        else
        {
            dependant1FirstName = "";
            testInputDependant1FirstNameError = false;
            inputDependant1FirstNameError.IsVisible = false;
            isvalidDependant1FirstName = true;

        }

    }

    void OnInputDependant1MiddleNameTextChange(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputDependant1MiddleName.Text;
        if (!(string.IsNullOrEmpty(entryValue)) && entryValue.All(char.IsLetter))
        {
            dependant1MiddleName = entryValue;
            testInputDependant1MiddleNameError = true;
            inputDependant1MiddleNameError.IsVisible = false;
            isvalidDependant1MiddleName = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            testInputDependant1MiddleNameError = true;
            inputDependant1MiddleNameError.IsVisible = true;
            inputDependant1MiddleNameError.Text = "This field must contain only letters";
            isvalidDependant1MiddleName = false;
        }
        else
        {
            dependant1MiddleName = "";
            testInputDependant1MiddleNameError = false;
            inputDependant1MiddleNameError.IsVisible = false;
            isvalidDependant1MiddleName = true;
        }
    }

    void OnInputDependant1RelationshipTextChange(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputDependant1Relationship.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            dependant1Relationship = entryValue;
            testInputDependant1RelationshipError = true;
            inputDependant1RelationshipError.IsVisible = false;
        }
        else
        {
            testInputDependant1RelationshipError = false;
            dependant1Relationship = "";
        }
    }


    void OnInputDependant2SurnameTextChange(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputDependant2Surname.Text;
        if (!(string.IsNullOrEmpty(entryValue)) && entryValue.All(char.IsLetter))
        {
            dependant2Surname = entryValue;
            testInputDependant2SurnameError = true;
            inputDependant2SurnameError.IsVisible = false;
            isvalidDependant2Surname = true;

        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            testInputDependant2SurnameError = true;
            inputDependant2SurnameError.IsVisible = true;
            inputDependant2SurnameError.Text = "This field must contain only letters";
            isvalidDependant2Surname = false;
        }
        else
        {
            dependant2Surname = "";
            testInputDependant2SurnameError = false;
            inputDependant2SurnameError.IsVisible = false;
            isvalidDependant2Surname = true;
        }

    }

    void OnInputDependant2FirstNameTextChange(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputDependant2FirstName.Text;
        if (!(string.IsNullOrEmpty(entryValue)) && entryValue.All(char.IsLetter))
        {
            dependant2FirstName = entryValue;
            testInputDependant2FirstNameError = true;
            inputDependant2FirstNameError.IsVisible = false;
            isvalidDependant2FirstName = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            testInputDependant2FirstNameError = true;
            inputDependant2FirstNameError.IsVisible = true;
            inputDependant2FirstNameError.Text = "This field must contain only letters";
            isvalidDependant2FirstName = false;
        }
        else
        {
            dependant2FirstName = "";
            testInputDependant2FirstNameError = false;
            inputDependant2FirstNameError.IsVisible = false;
            isvalidDependant2FirstName = true;
        }

    }

    void OnInputDependant2MiddleNameTextChange(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputDependant2MiddleName.Text;
        if (!(string.IsNullOrEmpty(entryValue)) && entryValue.All(char.IsLetter))
        {
            dependant2MiddleName = entryValue;
            testInputDependant2MiddleNameError = true;
            inputDependant2MiddleNameError.IsVisible = false;
            isvalidDependant2MiddleName = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            testInputDependant2MiddleNameError = true;
            inputDependant2MiddleNameError.IsVisible = true;
            inputDependant2MiddleNameError.Text = "This field must contain only letters";
            isvalidDependant2MiddleName = false;
        }
        else
        {
            dependant2MiddleName = "";
            testInputDependant2MiddleNameError = false;
            inputDependant2MiddleNameError.IsVisible = false;
            isvalidDependant2MiddleName = true;
        }
    }

    void OnInputDependant2RelationshipTextChange(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputDependant2Relationship.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            dependant2Relationship = entryValue;
            testInputDependant2RelationshipError = true;
            inputDependant2RelationshipError.IsVisible = false;
        }
        else
        {
            testInputDependant2RelationshipError = false;
            dependant2Relationship = "";
        }
    }

    void OnInputDependant3SurnameTextChange(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputDependant3Surname.Text;
        if (!(string.IsNullOrEmpty(entryValue)) && entryValue.All(char.IsLetter))
        {
            dependant3Surname = entryValue;
            testInputDependant3SurnameError = true;
            inputDependant3SurnameError.IsVisible = false;
            isvalidDependant3Surname = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            testInputDependant3SurnameError = true;
            inputDependant3SurnameError.IsVisible = true;
            inputDependant3SurnameError.Text = "This field must contain only letters";
            isvalidDependant3Surname = false;
        }
        else
        {
            dependant3Surname = "";
            testInputDependant3SurnameError = false;
            inputDependant3SurnameError.IsVisible = false;
            isvalidDependant3Surname = true;
        }

    }

    void OnInputDependant3FirstNameTextChange(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputDependant3FirstName.Text;
        if (!(string.IsNullOrEmpty(entryValue)) && entryValue.All(char.IsLetter))
        {
            dependant3FirstName = entryValue;
            testInputDependant3FirstNameError = true;
            inputDependant3FirstNameError.IsVisible = false;
            isvalidDependant3FirstName = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            testInputDependant3FirstNameError = true;
            inputDependant3FirstNameError.IsVisible = true;
            inputDependant3FirstNameError.Text = "This field must contain only letters";
            isvalidDependant3FirstName = false;
        }
        else
        {
            dependant3FirstName = "";
            testInputDependant3FirstNameError = false;
            inputDependant3FirstNameError.IsVisible = false;
            isvalidDependant3FirstName = true;
        }

    }

    void OnInputDependant3MiddleNameTextChange(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputDependant3MiddleName.Text;
        if (!(string.IsNullOrEmpty(entryValue)) && entryValue.All(char.IsLetter))
        {
            dependant3MiddleName = entryValue;
            testInputDependant3MiddleNameError = true;
            inputDependant3MiddleNameError.IsVisible = false;
            isvalidDependant3MiddleName = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            testInputDependant3MiddleNameError = true;
            inputDependant3MiddleNameError.IsVisible = true;
            inputDependant3MiddleNameError.Text = "This field must contain only letters";
            isvalidDependant3MiddleName = false;
        }
        else
        {
            dependant3MiddleName = "";
            testInputDependant3MiddleNameError = false;
            inputDependant3MiddleNameError.IsVisible = false;
            isvalidDependant3MiddleName = true;
        }
    }

    void OnInputDependant3RelationshipTextChange(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputDependant3Relationship.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            dependant3Relationship = entryValue;
            testInputDependant3RelationshipError = true;
            inputDependant3RelationshipError.IsVisible = false;
        }
        else
        {
            testInputDependant3RelationshipError = false;
            dependant3Relationship = "";
        }
    }

    void OnInputDependant4SurnameTextChange(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputDependant4Surname.Text;
        if (!(string.IsNullOrEmpty(entryValue)) && entryValue.All(char.IsLetter))
        {
            dependant4Surname = entryValue;
            testInputDependant4SurnameError = true;
            inputDependant4SurnameError.IsVisible = false;
            isvalidDependant4Surname = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            testInputDependant4SurnameError = true;
            inputDependant4SurnameError.IsVisible = true;
            inputDependant4SurnameError.Text = "This field must contain only letters";
            isvalidDependant4Surname = false;
        }
        else
        {
            dependant4Surname = "";
            testInputDependant4SurnameError = false;
            inputDependant4SurnameError.IsVisible = false;
            isvalidDependant4Surname = true;
        }

    }

    void OnInputDependant4FirstNameTextChange(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputDependant4FirstName.Text;
        if (!(string.IsNullOrEmpty(entryValue)) && entryValue.All(char.IsLetter))
        {
            dependant4FirstName = entryValue;
            testInputDependant4FirstNameError = true;
            inputDependant4FirstNameError.IsVisible = false;
            isvalidDependant4FirstName = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            testInputDependant4FirstNameError = true;
            inputDependant4FirstNameError.IsVisible = true;
            inputDependant4FirstNameError.Text = "This field must contain only letters";
            isvalidDependant4FirstName = false;
        }
        else
        {
            dependant4FirstName = "";
            testInputDependant4FirstNameError = false;
            inputDependant4FirstNameError.IsVisible = false;
            isvalidDependant4FirstName = true;
        }

    }

    void OnInputDependant4MiddleNameTextChange(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputDependant4MiddleName.Text;
        if (!(string.IsNullOrEmpty(entryValue)) && entryValue.All(char.IsLetter))
        {
            dependant4MiddleName = entryValue;
            testInputDependant4MiddleNameError = true;
            inputDependant4MiddleNameError.IsVisible = false;
            isvalidDependant4MiddleName = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            testInputDependant4MiddleNameError = true;
            inputDependant4MiddleNameError.IsVisible = true;
            inputDependant4MiddleNameError.Text = "This field must contain only letters";
            isvalidDependant4MiddleName = false;
        }
        else
        {
            dependant4MiddleName = "";
            testInputDependant4MiddleNameError = false;
            inputDependant4MiddleNameError.IsVisible = false;
            isvalidDependant4MiddleName = true;
        }
    }

    void OnInputDependant4RelationshipTextChange(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputDependant4Relationship.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            dependant4Relationship = entryValue;
            testInputDependant4RelationshipError = true;
            inputDependant4RelationshipError.IsVisible = false;
        }
        else
        {
            testInputDependant4RelationshipError = false;
            dependant4Relationship = "";
        }
    }


    void OnInputDependant5SurnameTextChange(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputDependant5Surname.Text;
        if (!(string.IsNullOrEmpty(entryValue)) && entryValue.All(char.IsLetter))
        {
            dependant5Surname = entryValue;
            testInputDependant5SurnameError = true;
            inputDependant5SurnameError.IsVisible = false;
            isvalidDependant5Surname = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            testInputDependant5SurnameError = true;
            inputDependant5SurnameError.IsVisible = true;
            inputDependant5SurnameError.Text = "This field must contain only letters";
            isvalidDependant5Surname = false;
        }
        else
        {
            dependant5Surname = "";
            testInputDependant5SurnameError = false;
            inputDependant5SurnameError.IsVisible = false;
            isvalidDependant5Surname = true;
        }

    }

    void OnInputDependant5FirstNameTextChange(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputDependant5FirstName.Text;
        if (!(string.IsNullOrEmpty(entryValue)) && entryValue.All(char.IsLetter))
        {
            dependant5FirstName = entryValue;
            testInputDependant5FirstNameError = true;
            inputDependant5FirstNameError.IsVisible = false;
            isvalidDependant5FirstName = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            testInputDependant5FirstNameError = true;
            inputDependant5FirstNameError.IsVisible = true;
            inputDependant5FirstNameError.Text = "This field must contain only letters";
            isvalidDependant5FirstName = false;
        }
        else
        {
            dependant5FirstName = "";
            testInputDependant5FirstNameError = false;
            inputDependant5FirstNameError.IsVisible = false;
            isvalidDependant5FirstName = true;
        }

    }

    void OnInputDependant5MiddleNameTextChange(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputDependant5MiddleName.Text;
        if (!(string.IsNullOrEmpty(entryValue)) && entryValue.All(char.IsLetter))
        {
            dependant5MiddleName = entryValue;
            testInputDependant5MiddleNameError = true;
            inputDependant5MiddleNameError.IsVisible = false;
            isvalidDependant5MiddleName = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            testInputDependant5MiddleNameError = true;
            inputDependant5MiddleNameError.IsVisible = true;
            inputDependant5MiddleNameError.Text = "This field must contain only letters";
            isvalidDependant5MiddleName = false;
        }
        else
        {
            dependant5MiddleName = "";
            testInputDependant5MiddleNameError = false;
            inputDependant5MiddleNameError.IsVisible = false;
            isvalidDependant5MiddleName = true;
        }
    }

    void OnInputDependant5RelationshipTextChange(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputDependant5Relationship.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            dependant5Relationship = entryValue;
            testInputDependant5RelationshipError = true;
            inputDependant5RelationshipError.IsVisible = false;
        }
        else
        {
            testInputDependant5RelationshipError = false;
            dependant5Relationship = "";
        }
    }

    void OnInputEducationInstitutionName(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputEducationInstitutionName.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            educationInstitutionName = entryValue;
            testInputEducationInstitutionNameError = true;
            inputEducationInstitutionNameError.IsVisible = false;
        }

        else
        {
            educationInstitutionName = "";
            testInputEducationInstitutionNameError = false;
            inputEducationInstitutionNameError.IsVisible = false;
        }
    }

    void OnInputEducationQualificationObtained(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputEducationQualificationObtained.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            educationQualificationObtained = entryValue;
            testInputEducationQualificationObtainedError = true;
            inputEducationQualificationObtainedError.IsVisible = false;
        }
        else
        {
            educationQualificationObtained = "";
            testInputEducationQualificationObtainedError = false;
        }
    }

    void OnInputEducationCourseStudied(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputEducationCourseStudied.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            educationCourseStudied = entryValue;
            testInputEducationCourseStudiedError = true;
            inputEducationCourseStudiedError.IsVisible = false;
        }
        else
        {
            educationCourseStudied = "";
            testInputEducationCourseStudiedError = false;
        }
    }

    void OnInputEducationEntryCertificate(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputEducationEntryCertificate.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            educationEntryCertificate = entryValue;
            testInputEducationEntryCertificateError = true;
            inputEducationEntryCertificateError.IsVisible = false;
        }
        else
        {
            educationEntryCertificate = "";
            testInputEducationEntryCertificateError = false;
        }
    }

    void OnInputSkills1Type(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputSkills1Type.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            skills1Type = entryValue;
            testInputSkills1TypeError = true;
            inputSkills1TypeError.IsVisible = false;

        }
        else
        {
            skills1Type = "";
            testInputSkills1TypeError = false;
        }
    }

    void OnInputSkills2Type(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputSkills2Type.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            skills2Type = entryValue;
            testInputSkills2TypeError = true;
            inputSkills2TypeError.IsVisible = false;

        }
        else
        {
            skills2Type = "";
            testInputSkills2TypeError = false;
        }
    }

    void OnInputSkills3Type(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputSkills3Type.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            skills3Type = entryValue;
            testInputSkills3TypeError = true;
            inputSkills3TypeError.IsVisible = false;

        }
        else
        {
            skills3Type = "";
            testInputSkills3TypeError = false;
        }
    }

    void OnInputSkills1InstitutionName(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputSkills1InstitutionName.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            skills1InstitutionName = entryValue;
            testInputSkills1InstitutionNameError = true;
            inputSkills1InstitutionNameError.IsVisible = false;
        }

        else
        {
            skills1InstitutionName = "";
            testInputSkills1InstitutionNameError = false;
            inputSkills1InstitutionNameError.IsVisible = false;

        }
    }

    void OnInputSkills2InstitutionName(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputSkills2InstitutionName.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            skills2InstitutionName = entryValue;
            testInputSkills2InstitutionNameError = true;
            inputSkills2InstitutionNameError.IsVisible = false;
        }

        else
        {
            skills2InstitutionName = "";
            testInputSkills2InstitutionNameError = false;
            inputSkills2InstitutionNameError.IsVisible = false;
        }
    }

    void OnInputSkills3InstitutionName(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputSkills3InstitutionName.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            skills3InstitutionName = entryValue;
            testInputSkills3InstitutionNameError = true;
            inputSkills3InstitutionNameError.IsVisible = false;
        }

        else
        {
            skills3InstitutionName = "";
            testInputSkills3InstitutionNameError = false;
            inputSkills3InstitutionNameError.IsVisible = false;
        }
    }

    void OnInputAssociation1Name(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputAssociation1Name.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            association1Name = entryValue;
            testInputAssociation1NameError = true;
            inputAssociation1NameError.IsVisible = false;

        }

        else
        {
            association1Name = "";
            testInputAssociation1NameError = false;
            inputAssociation1NameError.IsVisible = false;

        }
    }

    void OnInputAssociation2Name(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputAssociation2Name.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            association2Name = entryValue;
            testInputAssociation2NameError = true;
            inputAssociation2NameError.IsVisible = false;
        }

        else
        {
            association2Name = "";
            testInputAssociation2NameError = false;
            inputAssociation2NameError.IsVisible = false;

        }
    }

    void OnInputAssociation3Name(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputAssociation3Name.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            association3Name = entryValue;
            testInputAssociation3NameError = true;
            inputAssociation3NameError.IsVisible = false;
        }
        else
        {
            association3Name = "";
            testInputAssociation3NameError = false;
            inputAssociation3NameError.IsVisible = false;

        }
    }

    void OnInputLanguage1Name(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputLanguage1Name.Text;
        if (!(string.IsNullOrEmpty(entryValue)) && entryValue.All(char.IsLetter))
        {
            language1Name = entryValue;
            testInputLanguage1NameError = true;
            inputLanguage1NameError.IsVisible = false;
            language1 = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            testInputLanguage1NameError = true;
            inputLanguage1NameError.IsVisible = true;
            inputLanguage1NameError.Text = "This field must contain only letters";
            language1 = false;

        }
        else
        {
            language1Name = "";
            testInputLanguage1NameError = false;
            inputLanguage1NameError.IsVisible = false;
            language1 = true;

        }
    }

    void OnInputLanguage2Name(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputLanguage2Name.Text;
        if (!(string.IsNullOrEmpty(entryValue)) && entryValue.All(char.IsLetter))
        {
            language2Name = entryValue;
            testInputLanguage2NameError = true;
            inputLanguage2NameError.IsVisible = false;
            language2 = true;

        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            testInputLanguage2NameError = true;
            inputLanguage2NameError.IsVisible = true;
            inputLanguage2NameError.Text = "This field must contain only letters";
            language2 = false;

        }
        else
        {
            language2Name = "";
            testInputLanguage2NameError = false;
            inputLanguage2NameError.IsVisible = false;
            language2 = true;

        }
    }

    void OnInputLanguage3Name(Object sender, TextChangedEventArgs e)
    {
        string entryValue = inputLanguage3Name.Text;
        if (!(string.IsNullOrEmpty(entryValue)) && entryValue.All(char.IsLetter))
        {
            language3Name = entryValue;
            testInputLanguage3NameError = true;
            inputLanguage3NameError.IsVisible = false;
            language3 = true;

        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            testInputLanguage3NameError = true;
            inputLanguage3NameError.IsVisible = true;
            inputLanguage3NameError.Text = "This field must contain only letters";
            language3 = false;

        }
        else
        {
            language3Name = "";
            testInputLanguage3NameError = false;
            inputLanguage3NameError.IsVisible = false;
            language3 = true;

        }
    }





    async void inputSubmitbtn(object sender, EventArgs e)
    {

        inputSubmitbName.Background = Colors.Teal;
        await Task.Delay(500); // Wait for 0.5 seconds (adjust time as needed)
        inputSubmitbName.Background = Colors.DarkSlateGray;
        //entries 

        if (testInputIdentificationStaffIDError == false)
        {
            inputIdentificationStaffIDError.Text = "This field cannot be empty or blank";
            inputIdentificationStaffIDError.IsVisible = true;
        }

        /*if (testInputIdentificationSocialSecurityError == false)
        {
            inputIdentificationSocialSecurityError.Text = "This field cannot be empty or blank";
            inputIdentificationSocialSecurityError.IsVisible = true;
        }

        if (testInputIdentificationNHISError == false)
        {
            inputIdentificationNHISError.Text = "This field cannot be empty or blank";
            inputIdentificationNHISError.IsVisible = true;
        }
        if (testInputIdentificationIntPassportError == false)
        {
            inputIdentificationIntPassportError.Text = "This field cannot be empty or blank";
            inputIdentificationIntPassportError.IsVisible = true;
        }

        if (testInputIdentificationVotersIDError == false)
        {
            inputIdentificationVotersIDError.Text = "This field cannot be empty or blank";
            inputIdentificationVotersIDError.IsVisible = true;
        }

        if (testInputIdentificationNationalIDError == false)
        {
            inputIdentificationNationalIDError.Text = "This field cannot be empty or blank";
            inputIdentificationNationalIDError.IsVisible = true;
        }

        if (testInputIdentificationDriversLicenseError == false)
        {
            inputIdentificationDriversLicenseError.Text = "This field cannot be empty or blank";
            inputIdentificationDriversLicenseError.IsVisible = true;
        }*/


        if (testInputEmployeeDetialsSurnameError == false)
        {
            inputEmployeeDetialsSurnameError.Text = "This field cannot be empty";
            inputEmployeeDetialsSurnameError.IsVisible = true;
        }

        if (testInputEmployeeDetialsFirstNameError == false)
        {
            inputEmployeeDetialsFirstNameError.Text = "This field cannot be empty";
            inputEmployeeDetialsFirstNameError.IsVisible = true;
        }

        if (testInputEmployeeDetialsDirectorateError == false)
        {
            inputEmployeeDetialsDirectorateError.Text = "This field cannot be empty";
            inputEmployeeDetialsDirectorateError.IsVisible = true;
        }

        if (testInputEmployeeDetialsDepartmentError == false)
        {
            inputEmployeeDetialsDepartmentError.Text = "This field cannot be empty";
            inputEmployeeDetialsDepartmentError.IsVisible = true;
        }

        if (testInputEmployeeDetialsUnitError == false)
        {
            inputEmployeeDetialsUnitError.IsVisible = true;
            inputEmployeeDetialsUnitError.Text = "This field cannot be empty";
        }


        if (testInputEmployeeDetialsJobClassError == false)
        {
            inputEmployeeDetialsJobClassError.IsVisible = true;
            inputEmployeeDetialsJobClassError.Text = "This field cannot be empty";
        }

        if (testInputEmployeeDetialsJobTitleError == false)
        {
            inputEmployeeDetialsJobTitleError.IsVisible = true;
            inputEmployeeDetialsJobTitleError.Text = "This field cannot be empty";
        }
        else
        {
            inputEmployeeDetialsJobTitleError.IsVisible = false;
        }

        if (testInputEmployeeDetialsJobGradeError == false)
        {
            inputEmployeeDetialsJobGradeError.IsVisible = true;
            inputEmployeeDetialsJobGradeError.Text = "This field cannot be empty";
        }

        //pickers

        if (testInputSubMetroError == false)
        {
            inputLgsSubMetroError.Text = "This field cannot be empty";
            inputLgsSubMetroError.IsVisible = true;
        }

        if (testInputPaymentModeError == false)
        {
            inputIdentificationPaymentModeError.Text = "This field cannot be empty ";
            inputIdentificationPaymentModeError.IsVisible = true;
        }

        if (testInputEmployementDetialsTitleError == false)
        {
            inputEmployeeDetialsTitleError.Text = "This field cannot be empty";
            inputEmployeeDetialsTitleError.IsVisible = true;

        }

        /* if (testInputBiographicalDataSexError == false)
         {
             inputBiograhicalDataSexError.Text = "This field cannot be empty";
             inputBiograhicalDataSexError.IsVisible = true;
         }

         if (testInputBiographicalMaritalStatusError == false)
         {
             inputBiograhicalDataMaritalStatusError.Text = "This field cannot be empty";
             inputBiograhicalDataMaritalStatusError.IsVisible = true;
         }

         if (testInputBiographicalRegionError == false)
         {
             inputBiographicalRegionError.IsVisible = true;
             inputBiographicalRegionError.Text = "This field cannot be empty";
         }

         if (testInputBiographicalDataCountriesError == false)
         {
             inputBiographicalDataCountriesError.Text = "This field cannot be empty";
             inputBiographicalDataCountriesError.IsVisible = true;

         }

         if (testInputResidentialRegionError == false)
         {
             inputResidentialRegionError.IsVisible = true;
             inputResidentialRegionError.Text = "This field cannot be empty";
         }

         if (testInputNextOfKinRegionError == false)
         {
             inputNextOfKinRegionError.IsVisible = true;
             inputNextOfKinRegionError.Text = "This field cannot be empty";
         }

         if (testInputNextOfKinCountriesError == false)
         {
             inputNextOfKinCountriesError.Text = "This field cannot be empty";
             inputNextOfKinCountriesError.IsVisible = true;

         }

         if (testInputDependant1TitleError == false)
         {
             inputDependant1TitleError.IsVisible = true;
             inputDependant1TitleError.Text = "This field cannot be empty";

         }

         if (testInputDependant2TitleError == false)
         {
             inputDependant2TitleError.IsVisible = true;
             inputDependant2TitleError.Text = "This field cannot be empty";

         }

         if (testInputDependant3TitleError == false)
         {
             inputDependant3TitleError.IsVisible = true;
             inputDependant3TitleError.Text = "This field cannot be empty";

         }

         if (testInputDependant4TitleError == false)
         {
             inputDependant4TitleError.IsVisible = true;
             inputDependant4TitleError.Text = "This field cannot be empty";

         }

         if (testInputDependant5TitleError == false)
         {
             inputDependant5TitleError.IsVisible = true;
             inputDependant5TitleError.Text = "This field cannot be empty";

         }*/

        /*if(testInputLanguageSpoken1Error == false)
        {
            inputLanguageSpoken1Error.IsVisible = false;
            inputLanguageSpoken1Error.Text = "";
        }

        */


        //datepicker

        if (testInputEmployeeDetialsAppointmentDateError == false)
        {
            inputEmployeeDetailsAppointmentDateError.IsVisible = true;
            inputEmployeeDetailsAppointmentDateError.Text = "Please select a date";
        }
        else
        {
            inputEmployeeDetailsAppointmentDateError.IsVisible = false;
            inputEmployeeDetailsAppointmentDateError.Text = string.Empty;
        }


        /*  */

        /*
private bool isvalidStaffID = false;
private bool isvalidPaymentMode = false;
private bool isvalidSubMetro = false;
private bool isvalidEmployeeTitle = false;
private bool isvalidEmployeeSurname = false;
private bool isvalidEmployeeFirstName = false;
private bool isvalidEmployeeMiddleName = false;
private bool isvalidFirstAppointmentDate = false;
private bool isvalidDirectorate = false;
private bool isvalidDepartment = false;
private bool isvalidUnit = false;
private bool isvalidSupervisor = false;
private bool isvalidJobClass = false;
private bool isvalidJobTitle = false;
private bool isvalidJobGrade = false;
private bool isvalidMaidenName = false;
private bool isvalidNextOfKinSurname = false;
private bool isvalidNextOfKinFirstName = false;
private bool isvalidDependant1Surname = false;
private bool isvalidDependant1FirstName = false;
private bool isvalidDependant1MiddleName = false;
private bool isvalidDependant2Surname = false;
private bool isvalidDependant2FirstName = false;
private bool isvalidDependant2MiddleName = false;
private bool isvalidDependant3Surname = false;
private bool isvalidDependant3FirstName = false;
private bool isvalidDependant3MiddleName = false;
private bool isvalidDependant4Surname = false;
private bool isvalidDependant4FirstName = false;
private bool isvalidDependant4MiddleName = false;
private bool isvalidDependant5Surname = false;
private bool isvalidDependant5FirstName = false;
private bool isvalidDependant5MiddleName = false;
private bool language1 = false;
private bool language2 = false;
private bool language3 = false;
*/

        bool readyToGo = (language1 && language2 && language3 && isvalidDependant5MiddleName && isvalidDependant5FirstName && isvalidDependant5Surname && isvalidDependant4MiddleName
            && isvalidDependant4FirstName && isvalidDependant4Surname && isvalidDependant3MiddleName && isvalidDependant3FirstName && isvalidDependant3Surname && isvalidDependant2MiddleName
            && isvalidDependant2FirstName && isvalidDependant2Surname && isvalidDependant1MiddleName && isvalidDependant1FirstName && isvalidDependant1Surname && isvalidNextOfKinFirstName
            && isvalidNextOfKinSurname && isvalidMaidenName && isvalidJobGrade && isvalidJobTitle && isvalidJobClass && isvalidSupervisor && isvalidUnit && isvalidDepartment
            && isvalidDirectorate && isvalidFirstAppointmentDate && isvalidEmployeeMiddleName && isvalidEmployeeFirstName && isvalidEmployeeSurname && isvalidEmployeeTitle
            && isvalidStaffID && isvalidSubMetro && isvalidPaymentMode);

        if (readyToGo)
        {

           await App.EmployeeRep.AddNewEmployee(identificationStaffID, identificationSocialSecurity, identificationNHIS, identificationIntPassport,
                identificationVotersID, identificationNationalID, identificationDriversLicense, employeeDetialsSurname, employeeDetialsFirstName,
                employeeDetialsMiddleName, employeeDetialsDirectorate, employeeDetialsDepartment, employeeDetialsUnit, employeeDetialsImmediateSupervisor,
                employeeDetialsCostCenter, employeeDetialsJobClass, employeeDetialsJobTitle, employeeDetialsJobGrade, employeeDetialsGradeLevel,
                employeeDetialsGradePoint, bankDetialsBankName, bankDetialsBankBranchName, bankDetialsBankAccount, biographicalDataMaidenName,
                biographicalDataPlaceOfBirth, biographicalDataHomeTown, biographicalDataReligion, residentialHouseNo, residentialStreetName,
                residentialArea, residentialTownCity, otherPostalAddress, otherEmailAddress, otherPhoneNo, otherMobileNo, disableState,
                disableReason, nextOfKinSurname, nextOfKinFirstName, nextOfKinRelationship, nextOfKinContactHouseNo, nextOfKinContactStreetName, nextOfKinContactArea,
                nextOfKinContactCityTown, nextOfKinContactPhoneNo, dependant1Surname, dependant1FirstName, dependant1MiddleName, dependant1Relationship,
                dependant2Surname, dependant2FirstName, dependant2MiddleName, dependant2Relationship, dependant3Surname, dependant3FirstName,
                dependant3MiddleName, dependant3Relationship, dependant4Surname, dependant4FirstName, dependant4MiddleName, dependant4Relationship,
                dependant5Surname, dependant5FirstName, dependant5MiddleName, dependant5Relationship, educationInstitutionName, educationQualificationObtained,
                educationCourseStudied, educationEntryCertificate, skills1Type, skills2Type, skills3Type, skills1InstitutionName,
                skills2InstitutionName, skills3InstitutionName, association1Name, association2Name, association3Name, language1Name, language2Name, language3Name,
                identificationIntPassportExpiryDate, employeeDetialsAppointmentDate, employeeDetialsRetirementDate, employeeDetialsLastPromotionDate, biographicalDataDateOfBirth,
                dependant1DateOfBirth, dependant2DateOfBirth, dependant3DateOfBirth, dependant4DateOfBirth, dependant5DateOfBirth, educationTo,
                educationFrom, skills1YearObtained, skills2YearObtained, skills3YearObtained, LgsSubMetro, identificationPaymentMode, employementDetialsTitle,
                biographicalDataSex, biographicalMaritalStatus, biographicalRegion, biographicalCountries, residentialRegion, nextOFKinRegion,
                nextOfKinCountries, dependant1Title, dependant2Title, dependant3Title, dependant4Title, dependant5Title, languageSpoken1,
                languageSpoken2, languageSpoken3, languageReading1, languageReading2, languageReading3, languageWriting1, languageWriting2, languageWriting3
                );

            string check = App.EmployeeRep.statusMessage;
            if (check == "Success")
            {
                addEmployeeStatusMessage.Text = "Success";

                if (File.Exists(fullPath))
                {
                    addFileRecord(identificationStaffID, identificationSocialSecurity, identificationPaymentMode, LgsSubMetro, identificationNHIS, identificationDriversLicense, identificationVotersID, identificationIntPassport, identificationIntPassportExpiryDate,
                                    employementDetialsTitle, employeeDetialsSurname, employeeDetialsFirstName, employeeDetialsMiddleName, employeeDetialsAppointmentDate, employeeDetialsDirectorate, employeeDetialsDepartment,
                                    employeeDetialsUnit, employeeDetialsCostCenter, employeeDetialsJobClass, employeeDetialsJobTitle, employeeDetialsJobGrade, employeeDetialsGradeLevel, employeeDetialsGradePoint, employeeDetialsLastPromotionDate,
                                    employeeDetialsRetirementDate, employeeDetialsImmediateSupervisor, bankDetialsBankName, bankDetialsBankBranchName, bankDetialsBankAccount, biographicalDataMaidenName, biographicalDataSex, biographicalMaritalStatus,
                                    biographicalDataPlaceOfBirth, biographicalDataDateOfBirth, biographicalDataHomeTown, biographicalRegion, biographicalCountries, biographicalDataReligion, residentialHouseNo, residentialStreetName, residentialArea,
                                    residentialTownCity, residentialRegion, otherPostalAddress, otherEmailAddress, otherPhoneNo, otherMobileNo, disableState, disableReason, nextOfKinSurname, nextOfKinFirstName, nextOfKinRelationship,
                                    nextOfKinContactHouseNo, nextOfKinContactStreetName, nextOfKinContactArea, nextOfKinContactCityTown, nextOFKinRegion, nextOfKinCountries, nextOfKinContactPhoneNo, dependant1Title, dependant1Surname, dependant1FirstName,
                                    dependant1MiddleName, dependant1DateOfBirth, dependant1Relationship, dependant2Title, dependant2Surname, dependant2FirstName, dependant2MiddleName, dependant2DateOfBirth, dependant2Relationship,
                                    dependant3Title, dependant3Surname, dependant3FirstName, dependant3MiddleName, dependant3DateOfBirth, dependant3Relationship, dependant4Title, dependant4Surname, dependant4FirstName, dependant4MiddleName,
                                     dependant4DateOfBirth, dependant4Relationship, dependant5Title, dependant5Surname, dependant5FirstName, dependant5MiddleName, dependant5DateOfBirth, dependant5Relationship, educationInstitutionName, educationTo, educationFrom,
                                     educationQualificationObtained, educationCourseStudied, educationEntryCertificate, skills1Type, skills1InstitutionName, skills1YearObtained, skills2Type, skills2InstitutionName, skills2YearObtained
                                     , skills3Type, skills3InstitutionName, skills3YearObtained, association1Name, association2Name, association3Name, language1Name, languageSpoken1, languageReading1, languageWriting1, language2Name, languageSpoken2,
                                     languageReading2, languageWriting2, language3Name, languageSpoken3, languageReading3, languageWriting3, fullPath);
                }

            }
            else
            {
                addEmployeeStatusMessage.Text = check;
            }

        }
        else
        {
            viewaddemployee.Text = "An error occured";
            viewaddemployee.TextColor = Colors.Red;
        }






    }


    //pickers

    private string LgsSubMetro;
    private string identificationPaymentMode;
    private string employementDetialsTitle;
    private string biographicalDataSex = "";
    private string biographicalMaritalStatus = "";
    private string biographicalRegion = "";
    private string biographicalCountries = "";
    private string residentialRegion = "";
    private string nextOFKinRegion = "";
    private string nextOfKinCountries = "";
    private string dependant1Title = "";
    private string dependant2Title = "";
    private string dependant3Title = "";
    private string dependant4Title = "";
    private string dependant5Title = "";
    private string languageSpoken1 = "";
    private string languageSpoken2 = "";
    private string languageSpoken3 = "";
    private string languageReading1 = "";
    private string languageReading2 = "";
    private string languageReading3 = "";
    private string languageWriting1 = "";
    private string languageWriting2 = "";
    private string languageWriting3 = "";



    //test
    private bool testInputSubMetroError = false;
    private bool testInputPaymentModeError = false;
    private bool testInputEmployementDetialsTitleError = false;
    private bool testInputBiographicalDataSexError = false;
    private bool testInputBiographicalMaritalStatusError = false;
    private bool testInputBiographicalRegionError = false;
    private bool testInputBiographicalDataCountriesError = false;
    private bool testInputResidentialRegionError = false;
    private bool testInputNextOfKinRegionError = false;
    private bool testInputNextOfKinCountriesError = false;
    private bool testInputDependant1TitleError = false;
    private bool testInputDependant2TitleError = false;
    private bool testInputDependant3TitleError = false;
    private bool testInputDependant4TitleError = false;
    private bool testInputDependant5TitleError = false;
    private bool testInputLanguageSpoken1Error = false;
    private bool testInputLanguageSpoken2Error = false;
    private bool testInputLanguageSpoken3Error = false;
    private bool testInputLanguageReading1Error = false;
    private bool testInputLanguageReading2Error = false;
    private bool testInputLanguageReading3Error = false;
    private bool testInputLanguageWriting1Error = false;
    private bool testInputLanguageWriting2Error = false;
    private bool testInputLanguageWriting3Error = false;







    void OnPickerSelectedItem(object sender, EventArgs e)
    {

        string selectedValue = inputLgsSubMetro.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            testInputSubMetroError = true;
            inputLgsSubMetroError.IsVisible = false;
            LgsSubMetro = selectedValue;
            isvalidSubMetro = true;
        }
        else
        {
            testInputSubMetroError = false;
            isvalidSubMetro = false;
        }

    }

    void OnPickerPaymentModeSelectedItem(object sender, EventArgs e)
    {
        string selectedValue = inputIdentificationPaymentMode.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            inputIdentificationPaymentModeError.IsVisible = false;
            identificationPaymentMode = selectedValue;
            testInputPaymentModeError = true;
            isvalidPaymentMode = true;
        }
        else
        {
            testInputPaymentModeError = true;
            isvalidPaymentMode = false;
        }
    }

    void OnPickerEmployeeDetialsTitleSelectedItem(object sender, EventArgs e)
    {
        string selectedValue = inputEmployeeDetialsTitle.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            inputEmployeeDetialsTitleError.IsVisible = false;
            employementDetialsTitle = selectedValue;
            testInputEmployementDetialsTitleError = true;
            isvalidEmployeeTitle = true;
        }

        else
        {
            testInputEmployementDetialsTitleError = true;
            isvalidEmployeeTitle = false;
        }
    }

    void OnPickerBiographicalDataSexSelectedItem(object sender, EventArgs e)
    {
        string selectedValue = inputBiographicalDataSex.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            inputBiograhicalDataSexError.IsVisible = false;
            biographicalDataSex = selectedValue;
            testInputBiographicalDataSexError = true;
        }
        else
        {
            biographicalDataSex = "";
            testInputBiographicalDataSexError = false;
        }
    }

    void OnPickerBiographicalDataMatrialStatusSelectedItem(object sender, EventArgs e)
    {
        string selectedValue = inputBiographicalDataMaritalStatus.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            inputBiograhicalDataMaritalStatusError.IsVisible = false;
            testInputBiographicalMaritalStatusError = true;
            biographicalMaritalStatus = selectedValue;
        }
        else
        {
            biographicalMaritalStatus = "";
            testInputBiographicalMaritalStatusError = false;
        }
    }

    void OnPickerBiographicalDataRegionSelectedItem(object sender, EventArgs e)
    {
        string selectedValue = inputBiographicalDataRegion.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            inputBiographicalRegionError.IsVisible = false;
            testInputBiographicalRegionError = true;
            biographicalRegion = selectedValue;

        }
        else
        {
            biographicalRegion = "";
            testInputBiographicalRegionError = false;
        }

    }

    void OnPickerBiographicalDataCountriesSelectedItem(object sender, EventArgs e)
    {
        string selectedValue = inputbiographicalDataCountries.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            inputBiographicalDataCountriesError.IsVisible = false;
            testInputBiographicalDataCountriesError = true;
            biographicalCountries = selectedValue;
        }
        else
        {
            biographicalCountries = "";
            testInputBiographicalDataCountriesError = false;
        }
    }

    void OnPickerResidentialRegionSelectedItem(object sender, EventArgs e)
    {
        string selectedValue = inputResidentialRegion.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            inputResidentialRegionError.IsVisible = false;
            residentialRegion = selectedValue;
            testInputResidentialRegionError = true;

        }
        else
        {
            testInputResidentialRegionError = false;
            residentialRegion = "";

        }

    }

    void OnPickerNextOfKinRegionSelectedItem(object sender, EventArgs e)
    {
        string selectedValue = inputNextOfKinRegion.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            inputNextOfKinRegionError.IsVisible = false;
            nextOFKinRegion = selectedValue;
            testInputNextOfKinRegionError = true;
        }
        else
        {
            testInputNextOfKinRegionError = false;
            nextOFKinRegion = "";

        }

    }

    void OnPickerNextOfKinCountriesSelectedItem(object sender, EventArgs e)
    {
        string selectedValue = inputNextOfKinCountries.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            inputNextOfKinCountriesError.IsVisible = false;
            testInputNextOfKinCountriesError = true;
            nextOfKinCountries = selectedValue;
        }
        else
        {
            testInputNextOfKinCountriesError = false;
            nextOfKinCountries = "";

        }
    }

    void OnPickerDependant1TitleSelectedItem(object sender, EventArgs e)
    {
        string selectedValue = inputDependant1Title.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            inputDependant1TitleError.IsVisible = false;
            testInputDependant1TitleError = true;
            dependant1Title = selectedValue;
        }
        else
        {
            testInputDependant1TitleError = false;
            dependant1Title = "";

        }
    }

    void OnPickerDependant2TitleSelectedItem(object sender, EventArgs e)
    {
        string selectedValue = inputDependant2Title.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            inputDependant2TitleError.IsVisible = false;
            testInputDependant2TitleError = true;
            dependant2Title = selectedValue;
        }
        else
        {
            testInputDependant2TitleError = false;
            dependant2Title = "";
        }
    }

    void OnPickerDependant3TitleSelectedItem(object sender, EventArgs e)
    {
        string selectedValue = inputDependant3Title.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            inputDependant3TitleError.IsVisible = false;
            testInputDependant3TitleError = true;
            dependant3Title = selectedValue;
        }
        else
        {
            testInputDependant3TitleError = false;
            dependant3Title = "";
        }
    }

    void OnPickerDependant4TitleSelectedItem(object sender, EventArgs e)
    {
        string selectedValue = inputDependant4Title.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            inputDependant4TitleError.IsVisible = false;
            testInputDependant4TitleError = true;
            dependant4Title = selectedValue;
        }
        else
        {
            testInputDependant4TitleError = false;
            dependant4Title = "";
        }
    }

    void OnPickerDependant5TitleSelectedItem(object sender, EventArgs e)
    {
        string selectedValue = inputDependant5Title.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            inputDependant5TitleError.IsVisible = false;
            testInputDependant5TitleError = true;
            dependant5Title = selectedValue;
        }
        else
        {
            testInputDependant5TitleError = false;
            dependant5Title = "";
        }
    }

    void OnPickerLanguageSpoken1SelectedItem(object sender, EventArgs e)
    {
        string selectedValue = inputLanguageSpoken1.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            languageSpoken1 = selectedValue;
            inputLanguageSpoken1Error.IsVisible = false;
            testInputLanguageSpoken1Error = true;
        }
        else
        {
            languageSpoken1 = "";
            testInputLanguageSpoken1Error = false;
        }
    }

    void OnPickerLanguageSpoken2SelectedItem(object sender, EventArgs e)
    {
        string selectedValue = inputLanguageSpoken2.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            languageSpoken2 = selectedValue;
            inputLanguageSpoken2Error.IsVisible = false;
            testInputLanguageSpoken2Error = true;
        }
        else
        {
            languageSpoken2 = "";
            testInputLanguageSpoken2Error = false;
        }
    }

    void OnPickerLanguageSpoken3SelectedItem(object sender, EventArgs e)
    {
        string selectedValue = inputLanguageSpoken3.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            languageSpoken3 = selectedValue;
            inputLanguageSpoken3Error.IsVisible = false;
            testInputLanguageSpoken3Error = true;
        }
        else
        {
            languageSpoken3 = "";
            testInputLanguageSpoken3Error = false;
        }
    }

    void OnPickerLanguageReading1SelectedItem(object sender, EventArgs e)
    {
        string selectedValue = inputLanguageReading1.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            languageReading1 = selectedValue;
            inputLanguageReading1Error.IsVisible = false;
            testInputLanguageReading1Error = true;
        }
        else
        {
            languageReading1 = "";
            testInputLanguageReading1Error = false;
        }
    }

    void OnPickerLanguageReading2SelectedItem(object sender, EventArgs e)
    {
        string selectedValue = inputLanguageReading2.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            languageReading2 = selectedValue;
            inputLanguageReading2Error.IsVisible = false;
            testInputLanguageReading2Error = true;
        }
        else
        {
            languageReading2 = "";
            testInputLanguageReading2Error = false;
        }
    }

    void OnPickerLanguageReading3SelectedItem(object sender, EventArgs e)
    {
        string selectedValue = inputLanguageReading3.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            languageReading3 = selectedValue;
            inputLanguageReading3Error.IsVisible = false;
            testInputLanguageReading3Error = true;
        }
        else
        {
            languageReading3 = "";
            testInputLanguageReading3Error = false;
        }
    }

    void OnPickerLanguageWriting1SelectedItem(object sender, EventArgs e)
    {
        string selectedValue = inputLanguageWriting1.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            languageWriting1 = selectedValue;
            inputLanguageWriting1Error.IsVisible = false;
            testInputLanguageWriting1Error = true;
        }
        else
        {
            languageWriting1 = "";
            testInputLanguageWriting1Error = false;
        }
    }

    void OnPickerLanguageWriting2SelectedItem(object sender, EventArgs e)
    {
        string selectedValue = inputLanguageWriting2.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            languageWriting2 = selectedValue;
            inputLanguageWriting2Error.IsVisible = false;
            testInputLanguageWriting2Error = true;
        }
        else
        {
            languageWriting2 = "";
            testInputLanguageWriting2Error = false;
        }
    }

    void OnPickerLanguageWriting3SelectedItem(object sender, EventArgs e)
    {
        string selectedValue = inputLanguageWriting3.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            languageWriting3 = selectedValue;
            inputLanguageWriting3Error.IsVisible = false;
            testInputLanguageWriting3Error = true;
        }
        else
        {
            languageWriting3 = "";
            testInputLanguageWriting3Error = false;
        }

    }
    // input employee record button



    /*private void Entry_Focused(object sender, FocusEventArgs e)
	{

	}

	private void OnPayMode(object sender, EventArgs e)
	{
		Picker picker = (Picker)sender;
		string selectedString = picker.SelectedItem.ToString();
	}*/



    void openSearchByStaffIDForm(object sender, EventArgs e)
    {




        searchByStaffID.IsVisible = true;
        searchByDepartment.IsVisible = false;
        searchBySubMetro.IsVisible = false;
        searchByPaymentMode.IsVisible = false;
        openSearchByStaffIDFormLabel.TextColor = Colors.White;
        openSearchByStaffIDFormFrame.BackgroundColor = Color.Parse("#1B4242");
        openSearchByDepartmentFormLabel.TextColor = Colors.Black;
        openSearchByDepartmentFormFrame.BackgroundColor = Color.Parse("#5C8374");
        openSearchByPaymentModeLabel.TextColor = Colors.Black;
        openSearchByPaymentModeFrame.BackgroundColor = Color.Parse("#5C8374");
        openSearchBySubMetroFormLabel.TextColor = Colors.Black;
        openSearchBySubMetroFormFrame.BackgroundColor = Color.Parse("#5C8374");
    }

    void openSearchByDepartmentForm(object sender, EventArgs e)
    {
        searchByDepartment.IsVisible = true;
        searchByPaymentMode.IsVisible = false;
        searchByStaffID.IsVisible = false;
        searchBySubMetro.IsVisible = false;
        openSearchByStaffIDFormLabel.TextColor = Colors.Black;
        openSearchByStaffIDFormFrame.BackgroundColor = Color.Parse("#5C8374");
        openSearchByDepartmentFormLabel.TextColor = Colors.White;
        openSearchByDepartmentFormFrame.BackgroundColor = Color.Parse("#1B4242");
        openSearchByPaymentModeLabel.TextColor = Colors.Black;
        openSearchByPaymentModeFrame.BackgroundColor = Color.Parse("#5C8374");
        openSearchBySubMetroFormLabel.TextColor = Colors.Black;
        openSearchBySubMetroFormFrame.BackgroundColor = Color.Parse("#5C8374");
    }
    void openSearchBySubMetroForm(object sender, EventArgs e)
    {
        searchBySubMetro.IsVisible = true;
        searchByStaffID.IsVisible = false;
        searchByDepartment.IsVisible = false;
        searchByPaymentMode.IsVisible = false;
        openSearchByStaffIDFormLabel.TextColor = Colors.Black;
        openSearchByStaffIDFormFrame.BackgroundColor = Color.Parse("#5C8374");
        openSearchByDepartmentFormLabel.TextColor = Colors.Black;
        openSearchByDepartmentFormFrame.BackgroundColor = Color.Parse("#5C8374");
        openSearchByPaymentModeLabel.TextColor = Colors.Black;
        openSearchByPaymentModeFrame.BackgroundColor = Color.Parse("#5C8374");
        openSearchBySubMetroFormLabel.TextColor = Colors.White;
        openSearchBySubMetroFormFrame.BackgroundColor = Color.Parse("#1B4242");
    }
    void openSearchByPaymentMode(object sender, EventArgs e)
    {
        searchByPaymentMode.IsVisible = true;
        searchByDepartment.IsVisible = false;
        searchByStaffID.IsVisible = false;
        searchBySubMetro.IsVisible = false;
        openSearchByStaffIDFormLabel.TextColor = Colors.Black;
        openSearchByStaffIDFormFrame.BackgroundColor = Color.Parse("#5C8374");
        openSearchByDepartmentFormLabel.TextColor = Colors.Black;
        openSearchByDepartmentFormFrame.BackgroundColor = Color.Parse("#5C8374");
        openSearchByPaymentModeLabel.TextColor = Colors.White;
        openSearchByPaymentModeFrame.BackgroundColor = Color.Parse("#1B4242");
        openSearchBySubMetroFormLabel.TextColor = Colors.Black;
        openSearchBySubMetroFormFrame.BackgroundColor = Color.Parse("#5C8374");
    }





    async void openLeaveAddEmployee(object sender, EventArgs e)
    {
        openLeaveAddEmployeeButton.BackgroundColor = Colors.Teal;
        await Task.Delay(500);
        openLeaveAddEmployeeButton.BackgroundColor = Colors.DarkSlateGray;

        leaveAddEmployee.IsVisible = true;
        leaveDeleteEmployee.IsVisible = false;
        leaveSearchEmployee.IsVisible = false;
        leaveUpdateEmployee.IsVisible = false;

    }

    async void openLeaveSearchEmployee(object sender, EventArgs e)
    {
        openLeaveSearchEmployeeButton.BackgroundColor = Colors.Teal;
        await Task.Delay(500);
        openLeaveSearchEmployeeButton.BackgroundColor = Colors.DarkSlateGray;

        leaveAddEmployee.IsVisible = false;
        leaveDeleteEmployee.IsVisible = false;
        leaveSearchEmployee.IsVisible = true;
        leaveUpdateEmployee.IsVisible = false;
        leaveSearch__.ItemsSource = await App.LeaveRep.GetAllPeople();

    }

    async void openLeaveDeleteEmployee(object sender, EventArgs e)
    {
        openLeaveDeleteEmployeeButton.BackgroundColor = Colors.Teal;
        await Task.Delay(500);
        openLeaveDeleteEmployeeButton.BackgroundColor = Colors.DarkSlateGray;
        leaveAddEmployee.IsVisible = false;
        leaveDeleteEmployee.IsVisible = true;
        leaveSearchEmployee.IsVisible = false;
        leaveUpdateEmployee.IsVisible = false;

    }

    async void openLeaveUpdateEmployee(object sender, EventArgs e)
    {
        openLeaveUpdateEmployeeButton.BackgroundColor = Colors.Teal;
        await Task.Delay(500);
        openLeaveUpdateEmployeeButton.BackgroundColor = Colors.DarkSlateGray;
        leaveUpdateEmployee.IsVisible = true;
        leaveAddEmployee.IsVisible = false;
        leaveDeleteEmployee.IsVisible = false;
        leaveSearchEmployee.IsVisible = false;
    }
    void openSearchEmployeeFrame(object sender, EventArgs e)
    {
        searchFram.IsVisible = true;
        addEmployeeFrame.IsVisible = false;
        updateEmployeeFrame.IsVisible = false;
        performanceFrame.IsVisible = false;
        deleteEmployeeFrame.IsVisible = false;
        leaveManagementFrame.IsVisible = false;
        hoverSearch.BorderColor = Colors.White;
        hoverSearchLabel.TextColor = Colors.White;
        hoverAdd.BorderColor = Colors.Transparent;
        hoverAddLabel.TextColor = Colors.Gray;
        hoverUpdate.BorderColor = Colors.Transparent;
        hoverUpdateLabel.TextColor = Colors.Gray;
        hoverDelete.BorderColor = Colors.Transparent;
        hoverDeleteLabel.TextColor = Colors.Gray;
        hoverLeave.BorderColor = Colors.Transparent;
        hoverLeaveLabel.TextColor = Colors.Gray;
        hoverPerformance.BorderColor = Colors.Transparent;
        hoverPerformanceLabel.TextColor = Colors.Gray;
        hoverSearchImage.Source = "white_people_search.png";
        hoverAddImage.Source = "add_person.png";
        hoverUpdateImage.Source = "renew.png";
        hoverDeleteImage.Source = "user_delete_icon.png";


    }


    async void openPerformanceAddEmployee(object sender, EventArgs e)
    {
        openPerformanceAddEmployeeButton.BackgroundColor = Colors.Teal;
        await Task.Delay(500);
        openPerformanceAddEmployeeButton.BackgroundColor = Colors.DarkSlateGray;

        performanceAddEmployee.IsVisible = true;
        performanceDeleteEmployee.IsVisible = false;
        performanceUpdateEmployee.IsVisible = false;
        performanceSearchEmployee.IsVisible = true;
        performanceSearchEmployee.IsVisible = false;

    }

    async void openPerformanceUpdateEmployee(object sender, EventArgs e)
    {
        openPerformanceUpdateEmployeeButton.BackgroundColor = Colors.Teal;
        await Task.Delay(500);
        openPerformanceUpdateEmployeeButton.BackgroundColor = Colors.DarkSlateGray;
        performanceAddEmployee.IsVisible = false;
        performanceDeleteEmployee.IsVisible = false;
        performanceUpdateEmployee.IsVisible = true;
        performanceSearchEmployee.IsVisible = false;

    }

    async void openPerformanceDeleteEmployee(object sender, EventArgs e)
    {
        openPerformanceDeleteEmployeeButton.BackgroundColor = Colors.Teal;
        await Task.Delay(500);
        openPerformanceDeleteEmployeeButton.BackgroundColor = Colors.DarkSlateGray;
        performanceAddEmployee.IsVisible = false;
        performanceDeleteEmployee.IsVisible = true;
        performanceUpdateEmployee.IsVisible = false;
        performanceSearchEmployee.IsVisible = false;

    }

    async void openPerformanceSearchEmployee(object sender, EventArgs e)
    {
        openPerformanceSearchEmployeeButton.BackgroundColor = Colors.Teal;
        await Task.Delay(500);
        openPerformanceSearchEmployeeButton.BackgroundColor = Colors.DarkSlateGray;
        performanceSearchEmployee.IsVisible = true;
        performanceAddEmployee.IsVisible = false;
        performanceDeleteEmployee.IsVisible = false;
        performanceUpdateEmployee.IsVisible = false;

        _showAllPerformanceReview.ItemsSource = await App.PerformanceRep.GetAllPeople();
    }


    void openAddEmployeeFrame(object sender, EventArgs e)
    {
        addEmployeeFrame.IsVisible = true;
        searchFram.IsVisible = false;
        updateEmployeeFrame.IsVisible = false;
        deleteEmployeeFrame.IsVisible = false;
        performanceFrame.IsVisible = false;
        leaveManagementFrame.IsVisible = false;
        reset.IsVisible = false;
        hoverSearch.BorderColor = Colors.Transparent;
        hoverSearchLabel.TextColor = Colors.Gray;
        hoverAdd.BorderColor = Colors.White;
        hoverAddLabel.TextColor = Colors.White;
        hoverUpdate.BorderColor = Colors.Transparent;
        hoverUpdateLabel.TextColor = Colors.Gray;
        hoverDelete.BorderColor = Colors.Transparent;
        hoverDeleteLabel.TextColor = Colors.Gray;
        hoverLeave.BorderColor = Colors.Transparent;
        hoverLeaveLabel.TextColor = Colors.Gray;
        hoverPerformance.BorderColor = Colors.Transparent;
        hoverPerformanceLabel.TextColor = Colors.Gray;
        hoverSearchImage.Source = "search_person.png";
        hoverAddImage.Source = "white_person_add.png";
        hoverUpdateImage.Source = "renew.png";
        hoverDeleteImage.Source = "user_delete_icon.png";
        hoverLeaveImage.Source = "leave_manage.png";
        hoverPerformanceImage.Source = "assessment.png";
    }




    void openUpdateEmployeeFrame(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.Write("checking something");
        searchMatch();

        updateEmployeeFrame.IsVisible = true;
        searchFram.IsVisible = false;
        addEmployeeFrame.IsVisible = false;
        deleteEmployeeFrame.IsVisible = false;
        leaveManagementFrame.IsVisible = false;
        performanceFrame.IsVisible = false;
        reset.IsVisible = false;
        hoverSearch.BorderColor = Colors.Transparent;
        hoverSearchLabel.TextColor = Colors.Gray;
        hoverAdd.BorderColor = Colors.Transparent;
        hoverAddLabel.TextColor = Colors.Gray;
        hoverUpdate.BorderColor = Colors.White;
        hoverUpdateLabel.TextColor = Colors.White;
        hoverDelete.BorderColor = Colors.Transparent;
        hoverDeleteLabel.TextColor = Colors.Gray;
        hoverLeave.BorderColor = Colors.Transparent;
        hoverLeaveLabel.TextColor = Colors.Gray;
        hoverPerformance.BorderColor = Colors.Transparent;
        hoverPerformanceLabel.TextColor = Colors.Gray;
        hoverSearchImage.Source = "search_person.png";
        hoverAddImage.Source = "add_person.png";
        hoverUpdateImage.Source = "white_renew.png";
        hoverDeleteImage.Source = "user_delete_icon.png";
        hoverLeaveImage.Source = "leave_manage.png";
        hoverPerformanceImage.Source = "assessment.png";
    }

    void openDeleteEmployeeFrame(object sender, EventArgs e)
    {
        deleteEmployeeFrame.IsVisible = true;
        searchFram.IsVisible = false;
        addEmployeeFrame.IsVisible = false;
        updateEmployeeFrame.IsVisible = false;
        leaveManagementFrame.IsVisible = false;
        performanceFrame.IsVisible = false;
        reset.IsVisible = false;
        hoverSearch.BorderColor = Colors.Transparent;
        hoverSearchLabel.TextColor = Colors.Gray;
        hoverAdd.BorderColor = Colors.Transparent;
        hoverAddLabel.TextColor = Colors.Gray;
        hoverUpdate.BorderColor = Colors.Transparent;
        hoverUpdateLabel.TextColor = Colors.Gray;
        hoverDelete.BorderColor = Colors.White;
        hoverDeleteLabel.TextColor = Colors.White;
        hoverLeave.BorderColor = Colors.Transparent;
        hoverLeaveLabel.TextColor = Colors.Gray;
        hoverPerformance.BorderColor = Colors.Transparent;
        hoverPerformanceLabel.TextColor = Colors.Gray;
        hoverSearchImage.Source = "search_person.png";
        hoverAddImage.Source = "add_person.png";
        hoverUpdateImage.Source = "renew.png";
        hoverDeleteImage.Source = "white_user_delete.png";
        hoverLeaveImage.Source = "leave_manage.png";
        hoverPerformanceImage.Source = "assessment.png";


    }

    void openLeaveManagementFrame(object sender, EventArgs e)
    {
        leaveManagementFrame.IsVisible = true;
        searchFram.IsVisible = false;
        addEmployeeFrame.IsVisible = false;
        updateEmployeeFrame.IsVisible = false;
        deleteEmployeeFrame.IsVisible = false;
        performanceFrame.IsVisible = false;
        reset.IsVisible = false;
        hoverSearch.BorderColor = Colors.Transparent;
        hoverSearchLabel.TextColor = Colors.Gray;
        hoverAdd.BorderColor = Colors.Transparent;
        hoverAddLabel.TextColor = Colors.Gray;
        hoverUpdate.BorderColor = Colors.Transparent;
        hoverUpdateLabel.TextColor = Colors.Gray;
        hoverDelete.BorderColor = Colors.Transparent;
        hoverDeleteLabel.TextColor = Colors.Gray;
        hoverLeave.BorderColor = Colors.White;
        hoverLeaveLabel.TextColor = Colors.White;
        hoverPerformance.BorderColor = Colors.Transparent;
        hoverPerformanceLabel.TextColor = Colors.Gray;
        hoverSearchImage.Source = "search_person.png";
        hoverAddImage.Source = "add_person.png";
        hoverUpdateImage.Source = "renew.png";
        hoverDeleteImage.Source = "user_delete_icon.png";
        hoverLeaveImage.Source = "white_green.png";
        hoverPerformanceImage.Source = "assessment.png";



    }

    void openPerformanceManagementFrame(object sender, EventArgs e)
    {
        performanceFrame.IsVisible = true;
        searchFram.IsVisible = false;
        addEmployeeFrame.IsVisible = false;
        updateEmployeeFrame.IsVisible = false;
        deleteEmployeeFrame.IsVisible = false;
        leaveManagementFrame.IsVisible = false;
        reset.IsVisible = false;
        hoverSearch.BorderColor = Colors.Transparent;
        hoverSearchLabel.TextColor = Colors.Gray;
        hoverAdd.BorderColor = Colors.Transparent;
        hoverAddLabel.TextColor = Colors.Gray;
        hoverUpdate.BorderColor = Colors.Transparent;
        hoverUpdateLabel.TextColor = Colors.Gray;
        hoverDelete.BorderColor = Colors.Transparent;
        hoverDeleteLabel.TextColor = Colors.Gray;
        hoverLeave.BorderColor = Colors.Transparent;
        hoverLeaveLabel.TextColor = Colors.Gray;
        hoverPerformance.BorderColor = Colors.White;
        hoverPerformanceLabel.TextColor = Colors.White;
        hoverSearchImage.Source = "search_person.png";
        hoverAddImage.Source = "add_person.png";
        hoverUpdateImage.Source = "renew.png";
        hoverDeleteImage.Source = "user_delete_icon.png";
        hoverLeaveImage.Source = "leave_manage.png";
        hoverPerformanceImage.Source = "white_assignment.png";
    }

    void openReset(object sender, EventArgs e)
    {
        reset.IsVisible = true;
        performanceFrame.IsVisible = false;
        searchFram.IsVisible = false;
        addEmployeeFrame.IsVisible = false;
        updateEmployeeFrame.IsVisible = false;
        deleteEmployeeFrame.IsVisible = false;
        leaveManagementFrame.IsVisible = false;
    }
    async void logout(object sender, EventArgs e)
    {
        logoutButton.BackgroundColor = Colors.Coral;
        await Navigation.PopAsync();
        logoutButton.BackgroundColor = Colors.IndianRed;
    }

    private List<string> countries = new List<string>
    {
        "Afghanistan", "Albania", "Algeria", "Andorra", "Angola", "Antigua and Barbuda", "Argentina", "Armenia", "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bhutan", "Bolivia", "Bosnia and Herzegovina", "Botswana", "Brazil", "Brunei", "Bulgaria", "Burkina Faso", "Burundi", "Cabo Verde", "Cambodia", "Cameroon", "Canada", "Central African Republic", "Chad", "Chile", "China", "Colombia", "Comoros", "Congo", "Costa Rica", "Côte d'Ivoire", "Croatia", "Cuba", "Cyprus", "Czech Republic", "Democratic Republic of the Congo", "Denmark", "Djibouti", "Dominica", "Dominican Republic", "East Timor", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Eswatini", "Ethiopia", "Fiji", "Finland", "France", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Greece", "Grenada", "Guatemala", "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Honduras", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Israel", "Italy", "Jamaica", "Japan", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Kosovo", "Kuwait", "Kyrgyzstan", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Marshall Islands", "Mauritania", "Mauritius", "Mexico", "Micronesia", "Moldova", "Monaco", "Mongolia", "Montenegro", "Morocco", "Mozambique", "Myanmar", "Namibia", "Nauru", "Nepal", "Netherlands", "New Zealand", "Nicaragua", "Niger", "Nigeria", "North Korea", "North Macedonia", "Norway", "Oman", "Pakistan", "Palau", "Palestine", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Poland", "Portugal", "Qatar", "Romania", "Russia", "Rwanda", "Saint Kitts and Nevis", "Saint Lucia", "Saint Vincent and the Grenadines", "Samoa", "San Marino", "São Tomé and Príncipe", "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "South Korea", "South Sudan", "Spain", "Sri Lanka", "Sudan", "Suriname", "Sweden", "Switzerland", "Syria", "Taiwan", "Tajikistan", "Tanzania", "Thailand", "Timor-Leste", "Togo", "Tonga", "Trinidad and Tobago", "Tunisia", "Turkey", "Turkmenistan", "Tuvalu", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "United States", "Uruguay", "Uzbekistan", "Vanuatu", "Vatican City", "Venezuela", "Vietnam", "Yemen", "Zambia", "Zimbabwe"

    };

    private void inputIdentificationNHIS_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {

    }

    //delete
    private string recordDelete_staffID;
    private bool test_recordDeleteStaffID = false;
    private bool isvalid_recordDeleteStaffID = false;
    void OnRecordDeleteStaffid(object sender, TextChangedEventArgs e)
    {
        string entryValue = recordDeleteStafID.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            recordDelete_staffID = entryValue;
            isvalid_recordDeleteStaffID = true;
            test_recordDeleteStaffID = true;
            error_recordDeleteStaffID.IsVisible = false;
            recordDeleteCheckStaffID.IsVisible = false;
            successfulDelete.IsVisible = false;
        }
    }

    async void openConfirmDelete(object sender, EventArgs e)
    {
        openConfirmDeleteName.Background = Colors.Teal;
        await Task.Delay(500);
        openConfirmDeleteName.Background = Colors.DarkSlateGray;
        deAct.IsRunning = true;
        if (!test_recordDeleteStaffID)
        {
            error_recordDeleteStaffID.IsVisible = true;
            error_recordDeleteStaffID.Text = "This field cannot be empty";
            deAct.IsRunning = false;
        }

        if (isvalid_recordDeleteStaffID)
        {
            List<EmployeeDB> list = await App.EmployeeRep.GetPeopleDeleteByStaffID(recordDelete_staffID);
            bool done = App.EmployeeRep.done;
            if (App.EmployeeRep.testData)
            {
                if (done)
                {
                    foreach (EmployeeDB emp in list)
                    {
                        deleteStaffID.Text = emp.identificationStaffID;
                        deleteFullName.Text = emp.employeeDetialsSurname + " " + emp.employeeDetialsFirstName + " " + emp.employeeDetialsMiddleName;
                        deleteDepartment.Text = emp.employeeDetialsDepartment;
                        deleteSupervisor.Text = emp.employeeDetialsImmediateSupervisor;
                        deleteSocialSecurityNo.Text = emp.identificationSocialSecurity;
                        deleteSubMetro.Text = emp.LgsSubMetro;
                        deletePaymentMode.Text = emp.identificationPaymentMode;
                        deleteJobTitle.Text = emp.employeeDetialsJobTitle;
                    }
                }
                recordDeleteCheckStaffID.Text = App.EmployeeRep.statusMessage;
                confirmDeleteFrmae.IsVisible = true;
                successfulDelete.IsVisible = false;
                recordDeleteStafID.Text = string.Empty;
                deAct.IsRunning = false;
            }
            else
            {
                recordDeleteCheckStaffID.Text = recordDelete_staffID + " does not exist";
                recordDeleteCheckStaffID.IsVisible = true;
                deAct.IsRunning = false;
            }

        }



    }

    async void deleteEmployeeButton(object sender, EventArgs e)
    {
        deAct1.IsRunning = true;
        bool result = await App.EmployeeRep.DeleteEmployeeByStaffID(recordDelete_staffID);
        successfulDelete.Text = App.EmployeeRep.statusMessage;
        successfulDelete.IsVisible = true;
        confirmDeleteFrmae.IsVisible = false;
        deAct1.IsRunning = false;
    }



    //updat_e
    private string _identificationIntPassportExpiryDate;
    private string _employeeDetialsAppointmentDate;
    private string _employeeDetialsRetirementDate;
    private string _employeeDetialsLastPromotionDate;
    private string _biographicalDataDateOfBirth;
    private string _dependant1DateOfBirth;
    private string _dependant2DateOfBirth;
    private string _dependant3DateOfBirth;
    private string _dependant4DateOfBirth;
    private string _dependant5DateOfBirth;
    private string _educationTo;
    private string _educationFrom;
    private string _skills1YearObtained;
    private string _skills2YearObtained;
    private string _skills3YearObtained;
    //
    private string _identificationStaffID;
    private string _identificationSocialSecurity = "";
    private string _identificationNHIS = "";
    private string _identificationIntPassport = "";
    private string _identificationVotersID = "";
    private string _identificationNationalID = "";
    private string _identificationDriversLicense = "";
    private string _employeeDetialsSurname;
    private string _employeeDetialsFirstName;
    private string _employeeDetialsMiddleName;
    private string _employeeDetialsDirectorate;
    private string _employeeDetialsDepartment;
    private string _employeeDetialsUnit;
    private string _employeeDetialsImmediateSupervisor;
    private string _employeeDetialsCostCenter;
    private string _employeeDetialsJobClass;
    private string _employeeDetialsJobTitle;
    private string _employeeDetialsJobGrade;
    private string _employeeDetialsGradeLevel;
    private string _employeeDetialsGradePoint;
    private string _bankDetialsBankName;
    private string _bankDetialsBankBranchName = "";
    private string _bankDetialsBankAccount = "";
    private string _biographicalDataMaidenName = "";
    private string _biographicalDataPlaceOfBirth = "";
    private string _biographicalDataHomeTown = "";
    private string _biographicalDataReligion = "";
    private string _residentialHouseNo = "";
    private string _residentialStreetName = "";
    private string _residentialArea = "";
    private string _residentialTownCity = "";
    private string _otherPostalAddress = "";
    private string _otherEmailAddress = "";
    private string _otherPhoneNo = "";
    private string _otherMobileNo = "";
    private string _disableState = "";
    private string _disableReason = "";
    private string _nextOfKinSurname = "";
    private string _nextOfKinFirstName = "";
    private string _nextOfKinRelationship = "";
    private string _nextOfKinContactHouseNo = "";
    private string _nextOfKinContactStreetName = "";
    private string _nextOfKinContactArea = "";
    private string _nextOfKinContactCityTown = "";
    private string _nextOfKinContactPhoneNo = "";
    private string _dependant1Surname = "";
    private string _dependant1FirstName = "";
    private string _dependant1MiddleName = "";
    private string _dependant1Relationship = "";
    private string _dependant2Surname = "";
    private string _dependant2FirstName = "";
    private string _dependant2MiddleName = "";
    private string _dependant2Relationship = "";
    private string _dependant3Surname = "";
    private string _dependant3FirstName = "";
    private string _dependant3MiddleName = "";
    private string _dependant3Relationship = "";
    private string _dependant4Surname = "";
    private string _dependant4FirstName = "";
    private string _dependant4MiddleName = "";
    private string _dependant4Relationship = "";
    private string _dependant5Surname = "";
    private string _dependant5FirstName = "";
    private string _dependant5MiddleName = "";
    private string _dependant5Relationship = "";
    private string _educationInstitutionName = "";
    private string _educationQualificationObtained = "";
    private string _educationCourseStudied = "";
    private string _educationEntryCertificate = "";
    private string _skills1Type = "";
    private string _skills2Type = "";
    private string _skills3Type = "";
    private string _skills1InstitutionName = "";
    private string _skills2InstitutionName = "";
    private string _skills3InstitutionName = "";
    private string _association1Name = "";
    private string _association2Name = "";
    private string _association3Name = "";
    private string _language1Name = "";
    private string _language2Name = "";
    private string _language3Name = "";


    private bool _testInputIdentificationIntPassportExpiryDateError = false;
    private bool _testInputEmployeeDetialsAppointmentDateError = true;
    private bool _testInputEmployeeDetialsRetirementDateError = false;
    private bool _testInputEmployeeDetialsLastPromotionDateError = false;
    private bool _testInputBiographicalDataDateOfBirthError = false;
    private bool _testInputDependant1DateOfBirthError = false;
    private bool _testInputDependant2DateOfBirthError = false;
    private bool _testInputDependant3DateOfBirthError = false;
    private bool _testInputDependant4DateOfBirthError = false;
    private bool _testInputDependant5DateOfBirthError = false;
    private bool _testInputEducationToError = false;
    private bool _testInputEducationFromError = false;
    private bool _testInputSkills1YearObtainedError = false;
    private bool _testInputSkills2YearObtainedError = false;
    private bool _testInputSkills3YearObtainedError = false;
    //
    private bool _testInputIdentificationStaffIDError = false;
    private bool _testInputIdentificationSocialSecurityError = false;
    private bool _testInputIdentificationNHISError = false;
    private bool _testInputIdentificationIntPassportError = false;
    private bool _testInputIdentificationVotersIDError = false;
    private bool _testInputIdentificationNationalIDError = false;
    private bool _testInputIdentificationDriversLicenseError = false;
    private bool _testInputEmployeeDetialsSurnameError = false;
    private bool _testInputEmployeeDetialsFirstNameError = false;
    private bool _testInputEmployeeDetialsMiddleNameError = false;
    private bool _testInputEmployeeDetialsDirectorateError = false;
    private bool _testInputEmployeeDetialsDepartmentError = false;
    private bool _testInputEmployeeDetialsUnitError = false;
    private bool _testInputEmployeeDetialsImmediateSupervisorError = false;
    private bool _testInputEmployeeDetialsCostCenterError = false;
    private bool _testInputEmployeeDetialsJobClassError = false;
    private bool _testInputEmployeeDetialsJobTitleError = false;
    private bool _testInputEmployeeDetialsJobGradeError = false;
    private bool _testInputEmployeeDetialsGradeLevelError = false;
    private bool _testInputEmployeeDetialsGradePointError = false;
    private bool _testInputBankDetialsBankNameError = false;
    private bool _testInputBankDetialsBankBranchNameError = false;
    private bool _testInputBankDetialsBankAccountError = false;
    private bool _testInputBiographicalDataMaidenNameError = false;
    private bool _testInputBiographicalDataPlaceOfBirthError = false;
    private bool _testInputBiographicalDataHomeTownError = false;
    private bool _testInputBiographicalDataReligionError = false;
    private bool _testInputResidentialHouseNoError = false;
    private bool _testInputResidentialStreetNameError = false;
    private bool _testInputResidentialAreaEroor = false;
    private bool _testInputResidentialTownCityError = false;
    private bool _testInputOtherPortalAddressError = false;
    private bool _testInputOtherEmailAddressError = false;
    private bool _testInputOtherPhoneNoError = false;
    private bool _testInputOtherMobileNoError = false;
    private bool _testInputDisableYes = false;
    private bool _testInputDisableNo = false;
    private bool _testInputNextOfKinSurnameError = false;
    private bool _testInputNextOfKinFirstNameError = false;
    private bool _testInputNextOfKinRelationshipError = false;
    private bool _testInputNextOfKinContactHouseNoError = false;
    private bool _testInputNextOfKinContactStreetNameError = false;
    private bool _testInputNextOfKinContactAreaError = false;
    private bool _testInputNextOfKinContactCityTownError = false;
    private bool _testInputNextOfKinContactPhoneNoError = false;
    private bool _testInputDependant1SurnameError = false;
    private bool _testInputDependant1FirstNameError = false;
    private bool _testInputDependant1MiddleNameError = false;
    private bool _testInputDependant1RelationshipError = false;
    private bool _testInputDependant2SurnameError = false;
    private bool _testInputDependant2FirstNameError = false;
    private bool _testInputDependant2MiddleNameError = false;
    private bool _testInputDependant2RelationshipError = false;
    private bool _testInputDependant3SurnameError = false;
    private bool _testInputDependant3FirstNameError = false;
    private bool _testInputDependant3MiddleNameError = false;
    private bool _testInputDependant3RelationshipError = false;
    private bool _testInputDependant4SurnameError = false;
    private bool _testInputDependant4FirstNameError = false;
    private bool _testInputDependant4MiddleNameError = false;
    private bool _testInputDependant4RelationshipError = false;
    private bool _testInputDependant5SurnameError = false;
    private bool _testInputDependant5FirstNameError = false;
    private bool _testInputDependant5MiddleNameError = false;
    private bool _testInputDependant5RelationshipError = false;
    private bool _testInputEducationInstitutionNameError = false;
    private bool _testInputEducationQualificationObtainedError = false;
    private bool _testInputEducationCourseStudiedError = false;
    private bool _testInputEducationEntryCertificateError = false;
    private bool _testInputSkills1TypeError = false;
    private bool _testInputSkills2TypeError = false;
    private bool _testInputSkills3TypeError = false;
    private bool _testInputSkills1InstitutionNameError = false;
    private bool _testInputSkills2InstitutionNameError = false;
    private bool _testInputSkills3InstitutionNameError = false;
    private bool _testInputAssociation1NameError = false;
    private bool _testInputAssociation2NameError = false;
    private bool _testInputAssociation3NameError = false;
    private bool _testInputLanguage1NameError = false;
    private bool _testInputLanguage2NameError = false;
    private bool _testInputLanguage3NameError = false;



    void _OnDatePickerIntPassportExpiryDate(object sender, DateChangedEventArgs e)
    {
        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 2, 1);
        string desiredDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desiredDateFormat)
        {
            _identificationIntPassportExpiryDate = "";
        }
        else
        {
            _identificationIntPassportExpiryDate = selectedDateFormat;
        }
    }

    void _OnDatePickerEmployeeDetialsAppointmentDateDate(object sender, DateChangedEventArgs e)
    {
        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 2, 1);
        string desireDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            _testInputEmployeeDetialsAppointmentDateError = false;
            _isvalidFirstAppointmentDate = false;
        }
        else
        {
            _testInputEmployeeDetialsAppointmentDateError = true;
            _employeeDetialsAppointmentDate = selectedDateFormat;
            _inputEmployeeDetailsAppointmentDateError.IsVisible = false;
            _inputEmployeeDetailsAppointmentDateError.Text = string.Empty;
            _isvalidFirstAppointmentDate = true;
        }
    }

    void _OnDatePickerEmployeeDetialsRetirementDate(object sender, DateChangedEventArgs e)
    {

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 2, 1);
        string desireDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            _testInputEmployeeDetialsRetirementDateError = false;
            _employeeDetialsRetirementDate = "";
        }
        else
        {
            _employeeDetialsRetirementDate = selectedDateFormat;
            _testInputEmployeeDetialsRetirementDateError = true;
        }
    }

    void _OnDatePickerEmployeeDetialsLastPromotionDate(object sender, DateChangedEventArgs e)
    {

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 2, 1);
        string desireDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            _testInputEmployeeDetialsLastPromotionDateError = false;
            _employeeDetialsLastPromotionDate = "";
        }
        else
        {
            _employeeDetialsLastPromotionDate = selectedDateFormat;
            _testInputEmployeeDetialsLastPromotionDateError = true;
        }
    }

    void _OnDatePickerBiographicalDataDateOfBirthDate(object sender, DateChangedEventArgs e)
    {

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 2, 1);
        string desireDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            _testInputBiographicalDataDateOfBirthError = false;
            _biographicalDataDateOfBirth = "";
        }
        else
        {
            _biographicalDataDateOfBirth = selectedDateFormat;
            _testInputBiographicalDataDateOfBirthError = true;
        }
    }

    void _OnDatePickerDependant1DateOfBirthDate(object sender, DateChangedEventArgs e)
    {

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 2, 1);
        string desireDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            _testInputDependant1DateOfBirthError = false;
            _dependant1DateOfBirth = "";
        }
        else
        {
            _dependant1DateOfBirth = selectedDateFormat;
            _testInputDependant1DateOfBirthError = true;
        }
    }

    void _OnDatePickerDependant2DateOfBirthDate(object sender, DateChangedEventArgs e)
    {

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 2, 1);
        string desireDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            _testInputDependant2DateOfBirthError = false;
            _dependant2DateOfBirth = "";
        }
        else
        {
            _dependant2DateOfBirth = selectedDateFormat;
            _testInputDependant2DateOfBirthError = true;
        }
    }

    void _OnDatePickerDependant3DateOfBirthDate(object sender, DateChangedEventArgs e)
    {

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 2, 1);
        string desireDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            _testInputDependant3DateOfBirthError = false;
            _dependant3DateOfBirth = "";
        }
        else
        {
            _dependant3DateOfBirth = selectedDateFormat;
            _testInputDependant3DateOfBirthError = true;
        }
    }

    void _OnDatePickerDependant4DateOfBirthDate(object sender, DateChangedEventArgs e)
    {

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 2, 1);
        string desireDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            _testInputDependant4DateOfBirthError = false;
            _dependant4DateOfBirth = "";
        }
        else
        {
            _dependant4DateOfBirth = selectedDateFormat;
            _testInputDependant4DateOfBirthError = true;
        }
    }

    void _OnDatePickerDependant5DateOfBirthDate(object sender, DateChangedEventArgs e)
    {

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 2, 1);
        string desireDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            _testInputDependant5DateOfBirthError = false;
            _dependant5DateOfBirth = "";
        }
        else
        {
            _dependant5DateOfBirth = selectedDateFormat;
            _testInputDependant5DateOfBirthError = true;
        }
    }

    void _OnDatePickerEducationToDate(object sender, DateChangedEventArgs e)
    {

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 2, 1);
        string desireDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            _testInputEducationToError = false;
            _educationTo = "";
        }
        else
        {
            _educationTo = selectedDateFormat;
            _testInputEducationToError = true;
        }
    }


    void _OnDatePickerEducationFromDate(object sender, DateChangedEventArgs e)
    {

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 2, 1);
        string desireDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            _testInputEducationFromError = false;
            _educationFrom = "";
        }
        else
        {
            _educationFrom = selectedDateFormat;
            _testInputEducationFromError = true;
        }
    }

    void _OnDatePickerSkills1YearObtainedDate(object sender, DateChangedEventArgs e)
    {

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 2, 1);
        string desireDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            _testInputSkills1YearObtainedError = false;
            _skills1YearObtained = "";
        }
        else
        {
            _skills1YearObtained = selectedDateFormat;
            _testInputSkills1YearObtainedError = true;
        }
    }

    void _OnDatePickerSkills2YearObtainedDate(object sender, DateChangedEventArgs e)
    {

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 2, 1);
        string desireDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            _testInputSkills2YearObtainedError = false;
            _skills2YearObtained = "";
        }
        else
        {
            _skills2YearObtained = selectedDateFormat;
            _testInputSkills2YearObtainedError = true;
        }
    }

    void _OnDatePickerSkills3YearObtainedDate(object sender, DateChangedEventArgs e)
    {

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 2, 1);
        string desireDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            _testInputSkills3YearObtainedError = false;
            _skills3YearObtained = "";
        }
        else
        {
            _skills3YearObtained = selectedDateFormat;
            _testInputSkills3YearObtainedError = true;
        }
    }










    private bool _isvalidStaffID = false;
    private bool _isvalidPaymentMode = false;
    private bool _isvalidSubMetro = false;
    private bool _isvalidEmployeeTitle = false;
    private bool _isvalidEmployeeSurname = false;
    private bool _isvalidEmployeeFirstName = false;
    private bool _isvalidEmployeeMiddleName = false;
    private bool _isvalidFirstAppointmentDate = false;
    private bool _isvalidDirectorate = false;
    private bool _isvalidDepartment = false;
    private bool _isvalidUnit = false;
    private bool _isvalidSupervisor = true;
    private bool _isvalidJobClass = false;
    private bool _isvalidJobTitle = false;
    private bool _isvalidJobGrade = false;
    private bool _isvalidMaidenName = true;
    private bool _isvalidNextOfKinSurname = true;
    private bool _isvalidNextOfKinFirstName = true;
    private bool _isvalidDependant1Surname = true;
    private bool _isvalidDependant1FirstName = true;
    private bool _isvalidDependant1MiddleName = true;
    private bool _isvalidDependant2Surname = true;
    private bool _isvalidDependant2FirstName = true;
    private bool _isvalidDependant2MiddleName = false;
    private bool _isvalidDependant3Surname = true;
    private bool _isvalidDependant3FirstName = true;
    private bool _isvalidDependant3MiddleName = true;
    private bool _isvalidDependant4Surname = true;
    private bool _isvalidDependant4FirstName = true;
    private bool _isvalidDependant4MiddleName = true;
    private bool _isvalidDependant5Surname = true;
    private bool _isvalidDependant5FirstName = true;
    private bool _isvalidDependant5MiddleName = true;
    private bool _language1 = true;
    private bool _language2 = true;
    private bool _language3 = true;




    void _OnInputStaffIDTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputIdentificationStaffID.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _testInputIdentificationStaffIDError = true;
            _identificationStaffID = entryValue;
            _inputIdentificationStaffIDError.IsVisible = false;
            _isvalidStaffID = true;
        }
        else
        {
            _testInputIdentificationStaffIDError = false;
            _isvalidStaffID = false;
        }

    }

    void _OnInputSocialSecurityTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputIdentificationSocialSecurity.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _testInputIdentificationSocialSecurityError = true;
            _identificationSocialSecurity = entryValue;
            _inputIdentificationSocialSecurityError.IsVisible = false;
        }
        else
        {
            _testInputIdentificationSocialSecurityError = false;
            _identificationSocialSecurity = "";
        }
    }

    void _OnInputNHISTextChanged(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputIdentificationNHIS.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _testInputIdentificationNHISError = true;
            _identificationNHIS = entryValue;
            _inputIdentificationNHISError.IsVisible = false;
        }
        else
        {
            _testInputIdentificationNHISError = false;
            _identificationNHIS = "";
        }
    }

    void _OnInputIntPassportTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputIdentificationIntPassport.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _testInputIdentificationIntPassportError = true;
            _identificationIntPassport = entryValue;
            _inputIdentificationIntPassportError.IsVisible = false;
        }
        else
        {
            _testInputIdentificationIntPassportError = false;
            _identificationIntPassport = "";
        }
    }

    void _OnInputVotersIDTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputIdentificationVotersID.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _testInputIdentificationVotersIDError = true;
            _identificationVotersID = entryValue;
            _inputIdentificationVotersIDError.IsVisible = false;
        }
        else
        {
            _testInputIdentificationVotersIDError = false;
            _identificationVotersID = "";
        }
    }

    void _OnInputNationalIDTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputIdentificationNationalID.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _testInputIdentificationNationalIDError = true;
            _identificationNationalID = entryValue;
            _inputIdentificationNationalIDError.IsVisible = false;
        }
        else
        {
            _testInputIdentificationNationalIDError = false;
            _identificationNationalID = "";
        }
    }

    void _OnInputDriversLicenseTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputIdentificationDriversLicense.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _testInputIdentificationDriversLicenseError = true;
            _identificationDriversLicense = entryValue;
            _inputIdentificationDriversLicenseError.IsVisible = false;
        }
        else
        {
            _testInputIdentificationDriversLicenseError = false;
            _identificationDriversLicense = "";
        }
    }

    //a
    void _OnInputSurnameTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputEmployeeDetialsSurname.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            _employeeDetialsSurname = entryValue;
            _testInputEmployeeDetialsSurnameError = true;
            _inputEmployeeDetialsSurnameError.IsVisible = false;
            _isvalidEmployeeSurname = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            _inputEmployeeDetialsSurnameError.IsVisible = true;
            _inputEmployeeDetialsSurnameError.Text = "This field must contain only letters";
            _testInputEmployeeDetialsSurnameError = true;
            _isvalidEmployeeSurname = false;
        }
        else
        {
            _testInputEmployeeDetialsSurnameError = false;
            _inputEmployeeDetialsSurnameError.IsVisible = false;
            _isvalidEmployeeSurname = false;

        }

    }
    //a
    void _OnInputFirstNameTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputEmployeeDetialsFirstName.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            _employeeDetialsFirstName = entryValue;
            _testInputEmployeeDetialsFirstNameError = true;
            _inputEmployeeDetialsFirstNameError.IsVisible = false;
            _isvalidEmployeeFirstName = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            _testInputEmployeeDetialsFirstNameError = true;
            _inputEmployeeDetialsFirstNameError.IsVisible = true;
            _inputEmployeeDetialsFirstNameError.Text = "This field must contain only letters";
            _isvalidEmployeeFirstName = false;
        }
        else
        {
            _testInputEmployeeDetialsFirstNameError = false;
            _inputEmployeeDetialsFirstNameError.IsVisible = false;
            _isvalidEmployeeFirstName = false;
        }
    }
    //a
    void _OnInputMiddleNameTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputEmployeeDetialsMiddleName.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            _employeeDetialsMiddleName = entryValue;
            _testInputEmployeeDetialsMiddleNameError = true;
            _inputEmployeeDetialsMiddleNameError.IsVisible = false;
            _isvalidEmployeeMiddleName = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            _testInputEmployeeDetialsMiddleNameError = true;
            _inputEmployeeDetialsMiddleNameError.IsVisible = true;
            _inputEmployeeDetialsMiddleNameError.Text = "This field must contain only letters";
            _isvalidEmployeeMiddleName = false;

        }
        else
        {
            _employeeDetialsMiddleName = "";
            _testInputEmployeeDetialsMiddleNameError = false;
            _inputEmployeeDetialsMiddleNameError.IsVisible = false;
            _isvalidEmployeeMiddleName = true;

        }
    }

    //a
    void _OnInputDirectorateTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputEmployeeDetialsDirectorate.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _employeeDetialsDirectorate = entryValue;
            _testInputEmployeeDetialsDirectorateError = true;
            _inputEmployeeDetialsDirectorateError.IsVisible = false;
            _isvalidDirectorate = true;
        }
        else
        {
            _testInputEmployeeDetialsDirectorateError = false;
            _inputEmployeeDetialsDirectorateError.IsVisible = false;
            _isvalidDirectorate = false;
        }
    }

    void _OnInputDepartmentTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputEmployeeDetialsDepartment.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _employeeDetialsDepartment = entryValue;
            _testInputEmployeeDetialsDepartmentError = true;
            _inputEmployeeDetialsDepartmentError.IsVisible = false;
            _isvalidDepartment = true;
        }
        else
        {
            _testInputEmployeeDetialsDepartmentError = false;
            _isvalidDirectorate = false;
        }
    }

    void _OnInputUnitTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputEmployeeDetialsUnit.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _employeeDetialsUnit = entryValue;
            _inputEmployeeDetialsUnitError.IsVisible = false;
            _testInputEmployeeDetialsUnitError = true;
            _isvalidUnit = true; ;
        }
        else
        {
            _testInputEmployeeDetialsUnitError = false;
            _isvalidUnit = false;
        }
    }

    //a
    void _OnInputImmediateSupervisorTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputEmployeeDetialsImmediateSupervisor.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            _employeeDetialsImmediateSupervisor = entryValue;
            _testInputEmployeeDetialsImmediateSupervisorError = true;
            _inputEmployeeDetialsImmediateSupervisorError.IsVisible = false;
            _isvalidSupervisor = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            _testInputEmployeeDetialsImmediateSupervisorError = true;
            _inputEmployeeDetialsImmediateSupervisorError.IsVisible = true;
            _inputEmployeeDetialsImmediateSupervisorError.Text = "This field must contain only letters";
            _isvalidSupervisor = false;
        }
        else
        {
            _employeeDetialsImmediateSupervisor = "";
            _testInputEmployeeDetialsImmediateSupervisorError = false;
            _inputEmployeeDetialsImmediateSupervisorError.IsVisible = false;
            _isvalidSupervisor = true;
        }
    }

    void _OnInputCostCenterTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputEmployeeDetialsCostCenter.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _employeeDetialsCostCenter = entryValue;
            _testInputEmployeeDetialsCostCenterError = true;
            _inputEmployeeDetialsCostCenterError.IsVisible = false;
        }
        else
        {
            _employeeDetialsCostCenter = "";
            _testInputEmployeeDetialsCostCenterError = false;
        }
    }

    void _OnInputJobClassTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputEmployeeDetialsJobClass.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _employeeDetialsJobClass = entryValue;
            _inputEmployeeDetialsJobClassError.IsVisible = false;
            _testInputEmployeeDetialsJobClassError = true;
            _isvalidJobClass = true;
        }
        else
        {
            _testInputEmployeeDetialsJobClassError = false;
            _isvalidJobClass = false;
        }
    }

    void _OnInputJobTitleTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputEmployeeDetialsJobTitle.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _employeeDetialsJobTitle = entryValue;
            _inputEmployeeDetialsJobTitleError.IsVisible = false;
            _testInputEmployeeDetialsJobTitleError = true;
            _isvalidJobTitle = true;
        }
        else
        {
            _testInputEmployeeDetialsJobTitleError = false;
            _isvalidJobTitle = false;
        }
    }

    void _OnInputJobGradeTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputEmployeeDetialsJobGrade.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _employeeDetialsJobGrade = entryValue;
            _testInputEmployeeDetialsJobGradeError = true;
            _inputEmployeeDetialsJobGradeError.IsVisible = false;
            _isvalidJobGrade = true;
        }
        else
        {
            _testInputEmployeeDetialsJobGradeError = false;
            _isvalidJobGrade = false;
        }
    }

    void _OnInputGradeLevelTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputEmployeeDetialsGradeLevel.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _employeeDetialsGradeLevel = entryValue;
            _testInputEmployeeDetialsJobGradeError = true;
            _inputEmployeeDetialsGradeLevelError.IsVisible = false;
        }
        else
        {
            _employeeDetialsGradeLevel = "";
            _testInputEmployeeDetialsGradeLevelError = false;
        }

    }

    void _OnInputGradePointTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputEmployeeDetialsGradePoint.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _employeeDetialsGradePoint = entryValue;
            _testInputEmployeeDetialsGradePointError = true;
            _inputEmployeeDetialsGradePointError.IsVisible = false;

        }
        else
        {
            _employeeDetialsGradePoint = "";
            _testInputEmployeeDetialsGradePointError = false;
        }
    }

    void _OnInputBankNameTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputBankDetialsBankName.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _bankDetialsBankName = entryValue;
            _testInputBankDetialsBankNameError = true;
            _inputBankDetialsBankBranchNameError.IsVisible = false;
        }
        else
        {
            _bankDetialsBankName = "";
            _testInputBankDetialsBankNameError = false;
        }

    }

    void _OnInputBankBranchNameTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputBankDetialsBankBranchName.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _testInputBankDetialsBankBranchNameError = true;
            _inputBankDetialsBankBranchNameError.IsVisible = false;
            _bankDetialsBankBranchName = entryValue;
        }
        else
        {
            _bankDetialsBankBranchName = "";
            _testInputBankDetialsBankBranchNameError = false;
        }


    }

    void _OnInputBankAccountTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputBankDetialsBankAccount.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _bankDetialsBankAccount = entryValue;
            _inputBankDetialsBankAccountError.IsVisible = false;
            _testInputBankDetialsBankAccountError = true;
        }
        else
        {
            _bankDetialsBankAccount = "";
            _testInputBankDetialsBankBranchNameError = false;
        }
    }

    void _OnInputMaidenNameTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputBiographicalDataMaidenName.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            _biographicalDataMaidenName = entryValue;
            _testInputBiographicalDataMaidenNameError = true;
            _inputBiographicalDataMaidenNameError.IsVisible = false;
            _isvalidMaidenName = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            _testInputBiographicalDataMaidenNameError = true;
            _inputBiographicalDataMaidenNameError.IsVisible = true;
            _inputBiographicalDataMaidenNameError.Text = "This field must contain only letters";
            _isvalidMaidenName = false;
        }
        else
        {
            _biographicalDataMaidenName = "";
            _testInputBiographicalDataMaidenNameError = false;
            _isvalidMaidenName = true;
        }
    }

    void _OnInputPlaceOfBirthTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputBiographicalDataPlaceOfBirth.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _biographicalDataPlaceOfBirth = entryValue;
            _testInputBiographicalDataPlaceOfBirthError = true;
            _inputBiographicalDataPlaceOfBirthError.IsVisible = false;
        }
        else
        {
            _biographicalDataPlaceOfBirth = "";
            _testInputBiographicalDataPlaceOfBirthError = false;
        }
    }

    void _OnInputHomeTownTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputBiographicalDataHomeTown.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _biographicalDataHomeTown = entryValue;
            _testInputBiographicalDataHomeTownError = true;
            _inputBiographicalDataHomeTownError.IsVisible = false;
        }
        else
        {
            _biographicalDataHomeTown = "";
            _testInputBiographicalDataHomeTownError = false;

        }
    }

    void _OnInputReligionTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputBiographicalDataReligion.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _biographicalDataReligion = entryValue;
            _testInputBiographicalDataReligionError = true;
            _inputBiographicalDataReligionError.IsVisible = false;
        }
        else
        {
            _biographicalDataReligion = "";
            _testInputBiographicalDataReligionError = false;
        }
    }

    void _OnInputHouseNoTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputResidentialHouseNo.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _residentialHouseNo = entryValue;
            _testInputResidentialHouseNoError = true;
            _inputResidentialHouseNoError.IsVisible = false;
        }
        else
        {
            _residentialHouseNo = "";
            _testInputResidentialHouseNoError = false;
        }
    }

    void _OnInputStreetNameTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputResidentialStreetName.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _residentialStreetName = entryValue;
            _testInputResidentialStreetNameError = true;
            _inputResidentialStreetNameError.IsVisible = false;
        }
        else
        {
            _residentialStreetName = "";
            _testInputResidentialStreetNameError = false;
        }
    }

    void _OnInputAreaTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputResidentialArea.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _residentialArea = entryValue;
            _testInputResidentialAreaEroor = true;
            _inputResidentialAreaError.IsVisible = false;
        }
        else
        {
            _residentialArea = "";
            _testInputResidentialAreaEroor = false;
        }
    }

    void _OnInputTownCityTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputResidentialTownCity.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _residentialTownCity = entryValue;
            _testInputResidentialTownCityError = true;
            _inputResidentialTownCityError.IsVisible = false;
        }
        else
        {
            _residentialArea = "";
            _testInputResidentialTownCityError = false;
        }
    }

    void _OnInputPostalAddressTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputOtherPostalAddress.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _otherPostalAddress = entryValue;
            _testInputOtherPortalAddressError = true;
            _inputOtherPostalAddressError.IsVisible = false;
        }
        else
        {
            _otherPostalAddress = "";
            _testInputOtherPortalAddressError = false;
        }
    }

    void _OnInputEmailAddressTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputOtherEmailAddress.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && IsEmailValid(entryValue))
        {
            _otherEmailAddress = entryValue;
            _testInputOtherEmailAddressError = true;
            _inputOtherEmailAddressError.IsVisible = false;
        }
        else if (!(IsEmailValid(entryValue)))
        {
            _inputOtherEmailAddressError.IsVisible = true;
            _inputOtherEmailAddressError.Text = "This is not a valid email address";
        }
        else
        {
            _otherEmailAddress = "";
            _testInputOtherEmailAddressError = false;
            _inputOtherEmailAddressError.IsVisible = false;
        }
    }

    void _OnInputPhoneNoTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputOtherPhoneNo.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && IsPhoneNumberValid(entryValue))
        {
            _otherPhoneNo = entryValue;
            _testInputOtherPhoneNoError = true;
            _inputOtherPhoneNoError.IsVisible = false;

        }
        else if (!(IsPhoneNumberValid(entryValue)))
        {
            _testInputOtherPhoneNoError = true;
            _inputOtherPhoneNoError.IsVisible = true;
            _inputOtherPhoneNoError.Text = "This field can be only number";
        }
        else
        {
            _otherPhoneNo = "";
            _testInputOtherPhoneNoError = false;
            _inputOtherPhoneNoError.IsVisible = false;

        }
    }

    void _OnInputMobileNoTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputOtherMobileNo.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _otherMobileNo = entryValue;
            _testInputOtherMobileNoError = true;
            _inputOtherMobileNoError.IsVisible = false;
        }
        else if (!(IsPhoneNumberValid(entryValue)))
        {
            _testInputOtherPhoneNoError = true;
            _inputOtherMobileNoError.IsVisible = true;
            _inputOtherMobileNoError.Text = "This field can be only number";
        }
        else
        {
            _otherMobileNo = "";
            _testInputOtherMobileNoError = false;
            _inputOtherMobileNoError.IsVisible = false;

        }
    }

    void _OnCheckDiableYes(object sender, CheckedChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        _inputDiableState.IsVisible = true;
        _specifyYes.IsVisible = true;
        _disableState = "Yes";
    }

    void _OnCheckDiableNo(object sender, CheckedChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        _inputDiableState.IsVisible = false;
        _specifyYes.IsVisible = false;
        _disableState = "No";
        _disableReason = "";
        _inputDiableState.Text = string.Empty;

    }

    void _OnDiableStateTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputDiableState.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _disableReason = entryValue;
        }
        else
        {
            _disableReason = "";
        }
    }

    void _OnInputNextOfKinSurnameTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputNextOfKinSurname.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            _nextOfKinSurname = entryValue;
            _testInputNextOfKinSurnameError = true;
            _inputNextOfKinSurnameError.IsVisible = false;
            _isvalidNextOfKinSurname = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            _testInputNextOfKinSurnameError = true;
            _inputNextOfKinSurnameError.IsVisible = true;
            _inputNextOfKinSurnameError.Text = "This field must contain only letters";
            _isvalidNextOfKinSurname = false;
        }
        else
        {
            _nextOfKinSurname = "";
            _testInputNextOfKinSurnameError = true;
            _inputNextOfKinSurnameError.IsVisible = false;
            _isvalidNextOfKinSurname = true;

        }

    }

    void _OnInputNextOfKinFirstNameTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputNextOfKinFirstName.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            _nextOfKinFirstName = entryValue;
            _testInputNextOfKinFirstNameError = true;
            _inputNextOfKinFirstNameError.IsVisible = false;
            _isvalidNextOfKinFirstName = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            _testInputNextOfKinFirstNameError = true;
            _inputNextOfKinFirstNameError.IsVisible = true;
            _inputNextOfKinFirstNameError.Text = "This field must contain only letters";
            _isvalidNextOfKinFirstName = false;
        }
        else
        {
            _testInputNextOfKinFirstNameError = false;
            _nextOfKinFirstName = "";
            _inputNextOfKinFirstNameError.IsVisible = false;
            _isvalidNextOfKinFirstName = true;
        }
    }

    void _OnInputNextOfKinRelationshipTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputNextOfKinRelationship.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _nextOfKinRelationship = entryValue;
            _testInputNextOfKinRelationshipError = true;
            _inputNextOfKinRelationshipError.IsVisible = false;
        }
        else
        {
            _nextOfKinRelationship = "";
            _testInputNextOfKinRelationshipError = false;
        }
    }

    void _OnInputNextOfKinContactHouseNoTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputNextOfKinContactHouseNo.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _nextOfKinContactHouseNo = entryValue;
            _testInputNextOfKinContactHouseNoError = true;
            _inputNextOfKinContactHouseNoError.IsVisible = false;
        }
        else
        {
            _nextOfKinContactHouseNo = "";
            _testInputNextOfKinContactHouseNoError = false;
            _inputNextOfKinContactHouseNoError.IsVisible = false;

        }
    }

    void _OnInputNextOfKinContactStreetNameTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputNextOfKinContactStreetName.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _nextOfKinContactStreetName = entryValue;
            _testInputNextOfKinContactStreetNameError = true;
            _inputNextOfKinContactStreetNameError.IsVisible = false;
        }
        else
        {
            _nextOfKinContactStreetName = "";
            _testInputNextOfKinContactStreetNameError = false;
        }
    }

    void _OnInputNextOfKinContactAreaTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputNextOfKinContactArea.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _nextOfKinContactArea = entryValue;
            _testInputNextOfKinContactAreaError = true;
            _inputNextOfKinContactAreaError.IsVisible = false;
        }
        else
        {
            _nextOfKinContactArea = "";
            _testInputNextOfKinContactAreaError = false;
        }
    }

    void _OnInputNextOfKinContactCityTownTextChange(object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputNextOfKinContactCityTown.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _nextOfKinContactCityTown = entryValue;
            _inputNextOfKinContactCityTownError.IsVisible = false;
            _testInputNextOfKinContactCityTownError = true;
        }
        else
        {
            _testInputNextOfKinContactCityTownError = false;
            _nextOfKinContactCityTown = "";
        }
    }

    void _OnInputNextOfKinContactPhoneNoTextChange(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputNextOfKinContactPhoneNo.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && IsPhoneNumberValid(entryValue))
        {
            _nextOfKinContactPhoneNo = entryValue;
            _testInputNextOfKinContactPhoneNoError = true;
            _inputNextOfKinContactPhoneNoError.IsVisible = false;
        }
        else if (!(IsPhoneNumberValid(entryValue)))
        {
            _testInputNextOfKinContactPhoneNoError = true;
            _inputNextOfKinContactPhoneNoError.Text = "This field can be numbers only";
            _inputNextOfKinContactPhoneNoError.IsVisible = true;
        }
        else
        {
            _nextOfKinContactPhoneNo = "";
            _testInputNextOfKinContactPhoneNoError = false;
            _inputNextOfKinContactPhoneNoError.IsVisible = false;

        }
    }

    void _OnInputDependant1SurnameTextChange(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputDependant1Surname.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            _dependant1Surname = entryValue;
            _testInputDependant1SurnameError = true;
            _inputDependant1SurnameError.IsVisible = false;
            _isvalidDependant1Surname = true;

        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            _testInputDependant1SurnameError = true;
            _inputDependant1SurnameError.IsVisible = true;
            _inputDependant1SurnameError.Text = "This field must contain only letters";
            _isvalidDependant1Surname = false;
        }
        else
        {
            _dependant1Surname = "";
            _testInputDependant1SurnameError = false;
            _inputDependant1SurnameError.IsVisible = false;
            _isvalidDependant1Surname = true;
        }

    }

    void _OnInputDependant1FirstNameTextChange(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputDependant1FirstName.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            _dependant1FirstName = entryValue;
            _testInputDependant1FirstNameError = true;
            _inputDependant1FirstNameError.IsVisible = false;
            _isvalidDependant1FirstName = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            _testInputDependant1FirstNameError = true;
            _inputDependant1FirstNameError.IsVisible = true;
            _inputDependant1FirstNameError.Text = "This field must contain only letters";
            _isvalidDependant1FirstName = false;
        }
        else
        {
            _dependant1FirstName = "";
            _testInputDependant1FirstNameError = false;
            _inputDependant1FirstNameError.IsVisible = false;
            _isvalidDependant1FirstName = true;
        }

    }

    void _OnInputDependant1MiddleNameTextChange(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputDependant1MiddleName.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            _dependant1MiddleName = entryValue;
            _testInputDependant1MiddleNameError = true;
            _inputDependant1MiddleNameError.IsVisible = false;
            _isvalidDependant1MiddleName = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            _testInputDependant1MiddleNameError = true;
            _inputDependant1MiddleNameError.IsVisible = true;
            _inputDependant1MiddleNameError.Text = "This field must contain only letters";
            _isvalidDependant1MiddleName = false;
        }
        else
        {
            _dependant1MiddleName = "";
            _testInputDependant1MiddleNameError = false;
            _inputDependant1MiddleNameError.IsVisible = false;
            _isvalidDependant1MiddleName = true;
        }
    }

    void _OnInputDependant1RelationshipTextChange(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputDependant1Relationship.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _dependant1Relationship = entryValue;
            _testInputDependant1RelationshipError = true;
            _inputDependant1RelationshipError.IsVisible = false;
        }
        else
        {
            _testInputDependant1RelationshipError = false;
            _dependant1Relationship = "";
        }
    }


    void _OnInputDependant2SurnameTextChange(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputDependant2Surname.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            _dependant2Surname = entryValue;
            _testInputDependant2SurnameError = true;
            _inputDependant2SurnameError.IsVisible = false;
            _isvalidDependant2Surname = true;

        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            _testInputDependant2SurnameError = true;
            _inputDependant2SurnameError.IsVisible = true;
            _inputDependant2SurnameError.Text = "This field must contain only letters";
            _isvalidDependant2Surname = false;
        }
        else
        {
            _dependant2Surname = "";
            _testInputDependant2SurnameError = false;
            _inputDependant2SurnameError.IsVisible = false;
            _isvalidDependant2Surname = true;
        }

    }

    void _OnInputDependant2FirstNameTextChange(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputDependant2FirstName.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            _dependant2FirstName = entryValue;
            _testInputDependant2FirstNameError = true;
            _inputDependant2FirstNameError.IsVisible = false;
            _isvalidDependant2FirstName = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            _testInputDependant2FirstNameError = true;
            _inputDependant2FirstNameError.IsVisible = true;
            _inputDependant2FirstNameError.Text = "This field must contain only letters";
            _isvalidDependant2FirstName = false;
        }
        else
        {
            _dependant2FirstName = "";
            _testInputDependant2FirstNameError = false;
            _inputDependant2FirstNameError.IsVisible = false;
            _isvalidDependant2FirstName = true;
        }

    }

    void _OnInputDependant2MiddleNameTextChange(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputDependant2MiddleName.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            _dependant2MiddleName = entryValue;
            _testInputDependant2MiddleNameError = true;
            _inputDependant2MiddleNameError.IsVisible = false;
            _isvalidDependant2MiddleName = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            _testInputDependant2MiddleNameError = true;
            _inputDependant2MiddleNameError.IsVisible = true;
            _inputDependant2MiddleNameError.Text = "This field must contain only letters";
            _isvalidDependant2MiddleName = false;
        }
        else
        {
            _dependant2MiddleName = "";
            _testInputDependant2MiddleNameError = false;
            _inputDependant2MiddleNameError.IsVisible = false;
            _isvalidDependant2MiddleName = true;
        }
    }

    void _OnInputDependant2RelationshipTextChange(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputDependant2Relationship.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _dependant2Relationship = entryValue;
            _testInputDependant2RelationshipError = true;
            _inputDependant2RelationshipError.IsVisible = false;
        }
        else
        {
            _testInputDependant2RelationshipError = false;
            _dependant2Relationship = "";
        }
    }

    void _OnInputDependant3SurnameTextChange(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputDependant3Surname.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            _dependant3Surname = entryValue;
            _testInputDependant3SurnameError = true;
            _inputDependant3SurnameError.IsVisible = false;
            _isvalidDependant3Surname = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            _testInputDependant3SurnameError = true;
            _inputDependant3SurnameError.IsVisible = true;
            _inputDependant3SurnameError.Text = "This field must contain only letters";
            _isvalidDependant3Surname = false;
        }
        else
        {
            _dependant3Surname = "";
            _testInputDependant3SurnameError = false;
            _inputDependant3SurnameError.IsVisible = false;
            _isvalidDependant3Surname = true;
        }

    }

    void _OnInputDependant3FirstNameTextChange(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputDependant3FirstName.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            _dependant3FirstName = entryValue;
            _testInputDependant3FirstNameError = true;
            _inputDependant3FirstNameError.IsVisible = false;
            _isvalidDependant3FirstName = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            _testInputDependant3FirstNameError = true;
            _inputDependant3FirstNameError.IsVisible = true;
            _inputDependant3FirstNameError.Text = "This field must contain only letters";
            _isvalidDependant3FirstName = false;
        }
        else
        {
            _dependant3FirstName = "";
            _testInputDependant3FirstNameError = false;
            _inputDependant3FirstNameError.IsVisible = false;
            _isvalidDependant3FirstName = true;
        }

    }

    void _OnInputDependant3MiddleNameTextChange(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputDependant3MiddleName.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            _dependant3MiddleName = entryValue;
            _testInputDependant3MiddleNameError = true;
            _inputDependant3MiddleNameError.IsVisible = false;
            _isvalidDependant3MiddleName = true;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            _testInputDependant3MiddleNameError = true;
            _inputDependant3MiddleNameError.IsVisible = true;
            _inputDependant3MiddleNameError.Text = "This field must contain only letters";
            _isvalidDependant3MiddleName = false;
        }
        else
        {
            _dependant3MiddleName = "";
            _testInputDependant3MiddleNameError = false;
            _inputDependant3MiddleNameError.IsVisible = false;
            _isvalidDependant3MiddleName = true;
        }
    }

    void _OnInputDependant3RelationshipTextChange(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;


        string entryValue = _inputDependant3Relationship.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _dependant3Relationship = entryValue;
            _testInputDependant3RelationshipError = true;
            _inputDependant3RelationshipError.IsVisible = false;

        }
        else
        {
            _testInputDependant3RelationshipError = false;
            _dependant3Relationship = "";
        }
    }

    void _OnInputDependant4SurnameTextChange(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputDependant4Surname.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            _dependant4Surname = entryValue;
            _testInputDependant4SurnameError = true;
            _inputDependant4SurnameError.IsVisible = false;
            _isvalidDependant4Surname = true;

        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            _testInputDependant4SurnameError = true;
            _inputDependant4SurnameError.IsVisible = true;
            _inputDependant4SurnameError.Text = "This field must contain only letters";
            _isvalidDependant4Surname = false;
        }
        else
        {
            _dependant4Surname = "";
            _testInputDependant4SurnameError = false;
            _inputDependant4SurnameError.IsVisible = false;
            _isvalidDependant4Surname = true;
        }

    }

    void _OnInputDependant4FirstNameTextChange(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputDependant4FirstName.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            _dependant4FirstName = entryValue;
            _testInputDependant4FirstNameError = true;
            _inputDependant4FirstNameError.IsVisible = false;
            _isvalidDependant5FirstName = true;

        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            _testInputDependant4FirstNameError = true;
            _inputDependant4FirstNameError.IsVisible = true;
            _inputDependant4FirstNameError.Text = "This field must contain only letters";
            _isvalidDependant5FirstName = false;
        }
        else
        {
            _dependant4FirstName = "";
            _testInputDependant4FirstNameError = false;
            _inputDependant4FirstNameError.IsVisible = false;
            _isvalidDependant5FirstName = true;
        }

    }

    void _OnInputDependant4MiddleNameTextChange(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputDependant4MiddleName.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            _dependant4MiddleName = entryValue;
            _testInputDependant4MiddleNameError = true;
            _inputDependant4MiddleNameError.IsVisible = false;
            _isvalidDependant4MiddleName = true;

        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            _testInputDependant4MiddleNameError = true;
            _inputDependant4MiddleNameError.IsVisible = true;
            _inputDependant4MiddleNameError.Text = "This field must contain only letters";
            _isvalidDependant4MiddleName = false;
        }
        else
        {
            _dependant4MiddleName = "";
            _testInputDependant4MiddleNameError = false;
            _inputDependant4MiddleNameError.IsVisible = false;
            _isvalidDependant4MiddleName = true;
        }
    }

    void _OnInputDependant4RelationshipTextChange(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputDependant4Relationship.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _dependant4Relationship = entryValue;
            _testInputDependant4RelationshipError = true;
            _inputDependant4RelationshipError.IsVisible = false;

        }
        else
        {
            _testInputDependant4RelationshipError = false;
            _dependant4Relationship = "";
        }
    }


    void _OnInputDependant5SurnameTextChange(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputDependant5Surname.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            _dependant5Surname = entryValue;
            _testInputDependant5SurnameError = true;
            _inputDependant5SurnameError.IsVisible = false;
            _isvalidDependant5Surname = true;

        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            _testInputDependant5SurnameError = true;
            _inputDependant5SurnameError.IsVisible = true;
            _inputDependant5SurnameError.Text = "This field must contain only letters";
            _isvalidDependant5Surname = false;
        }
        else
        {
            _dependant5Surname = "";
            _testInputDependant5SurnameError = false;
            _inputDependant5SurnameError.IsVisible = false;
            _isvalidDependant5Surname = true;
        }

    }

    void _OnInputDependant5FirstNameTextChange(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputDependant5FirstName.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            _dependant5FirstName = entryValue;
            _testInputDependant5FirstNameError = true;
            _inputDependant5FirstNameError.IsVisible = false;
            _isvalidDependant5FirstName = true;

        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            _testInputDependant5FirstNameError = true;
            _inputDependant5FirstNameError.IsVisible = true;
            _inputDependant5FirstNameError.Text = "This field must contain only letters";
            _isvalidDependant5FirstName = false;
        }
        else
        {
            _dependant5FirstName = "";
            _testInputDependant5FirstNameError = false;
            _inputDependant5FirstNameError.IsVisible = false;
            _isvalidDependant5FirstName = true;
        }

    }

    void _OnInputDependant5MiddleNameTextChange(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputDependant5MiddleName.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            _dependant5MiddleName = entryValue;
            _testInputDependant5MiddleNameError = true;
            _inputDependant5MiddleNameError.IsVisible = false;
            _isvalidDependant5MiddleName = true;

        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            _testInputDependant5MiddleNameError = true;
            _inputDependant5MiddleNameError.IsVisible = true;
            _inputDependant5MiddleNameError.Text = "This field must contain only letters";
            _isvalidDependant5MiddleName = false;
        }
        else
        {
            _dependant5MiddleName = "";
            _testInputDependant5MiddleNameError = false;
            _inputDependant5MiddleNameError.IsVisible = false;
            _isvalidDependant5MiddleName = true;
        }
    }

    void _OnInputDependant5RelationshipTextChange(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputDependant5Relationship.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _dependant5Relationship = entryValue;
            _testInputDependant5RelationshipError = true;
            _inputDependant5RelationshipError.IsVisible = false;


        }
        else
        {
            _testInputDependant5RelationshipError = false;
            _dependant5Relationship = "";
        }
    }

    void _OnInputEducationInstitutionName(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputEducationInstitutionName.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _educationInstitutionName = entryValue;
            _testInputEducationInstitutionNameError = true;
            _inputEducationInstitutionNameError.IsVisible = false;

        }

        else
        {
            _educationInstitutionName = "";
            _testInputEducationInstitutionNameError = false;
            _inputEducationInstitutionNameError.IsVisible = false;
        }
    }

    void _OnInputEducationQualificationObtained(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputEducationQualificationObtained.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _educationQualificationObtained = entryValue;
            _testInputEducationQualificationObtainedError = true;
            _inputEducationQualificationObtainedError.IsVisible = false;

        }
        else
        {
            _educationQualificationObtained = "";
            _testInputEducationQualificationObtainedError = false;
        }
    }

    void _OnInputEducationCourseStudied(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputEducationCourseStudied.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _educationCourseStudied = entryValue;
            _testInputEducationCourseStudiedError = true;
            _inputEducationCourseStudiedError.IsVisible = false;

        }
        else
        {
            _educationCourseStudied = "";
            _testInputEducationCourseStudiedError = false;
        }
    }

    void _OnInputEducationEntryCertificate(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputEducationEntryCertificate.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _educationEntryCertificate = entryValue;
            _testInputEducationEntryCertificateError = true;
            _inputEducationEntryCertificateError.IsVisible = false;

        }
        else
        {
            _educationEntryCertificate = "";
            _testInputEducationEntryCertificateError = false;
        }
    }

    void _OnInputSkills1Type(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputSkills1Type.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _skills1Type = entryValue;
            _testInputSkills1TypeError = true;
            _inputSkills1TypeError.IsVisible = false;

        }
        else
        {
            _skills1Type = "";
            _testInputSkills1TypeError = false;
        }
    }

    void _OnInputSkills2Type(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputSkills2Type.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _skills2Type = entryValue;
            _testInputSkills2TypeError = true;
            _inputSkills2TypeError.IsVisible = false;

        }
        else
        {
            _skills2Type = "";
            _testInputSkills2TypeError = false;
        }
    }

    void _OnInputSkills3Type(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputSkills3Type.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _skills3Type = entryValue;
            _testInputSkills3TypeError = true;
            _inputSkills3TypeError.IsVisible = false;

        }
        else
        {
            _skills3Type = "";
            _testInputSkills3TypeError = false;
        }
    }

    void _OnInputSkills1InstitutionName(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputSkills1InstitutionName.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _skills1InstitutionName = entryValue;
            _testInputSkills1InstitutionNameError = true;
            _inputSkills1InstitutionNameError.IsVisible = false;

        }

        else
        {
            _skills1InstitutionName = "";
            _testInputSkills1InstitutionNameError = false;
            _inputSkills1InstitutionNameError.IsVisible = false;

        }
    }

    void _OnInputSkills2InstitutionName(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputSkills2InstitutionName.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _skills2InstitutionName = entryValue;
            _testInputSkills2InstitutionNameError = true;
            _inputSkills2InstitutionNameError.IsVisible = false;
        }

        else
        {
            _skills2InstitutionName = "";
            _testInputSkills2InstitutionNameError = false;
            _inputSkills2InstitutionNameError.IsVisible = false;
        }
    }

    void _OnInputSkills3InstitutionName(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputSkills3InstitutionName.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _skills3InstitutionName = entryValue;
            _testInputSkills3InstitutionNameError = true;
            _inputSkills3InstitutionNameError.IsVisible = false;

        }

        else
        {
            _skills3InstitutionName = "";
            _testInputSkills3InstitutionNameError = false;
            _inputSkills3InstitutionNameError.IsVisible = false;
        }
    }

    void _OnInputAssociation1Name(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputAssociation1Name.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _association1Name = entryValue;
            _testInputAssociation1NameError = true;
            _inputAssociation1NameError.IsVisible = false;

        }

        else
        {
            _association1Name = "";
            _testInputAssociation1NameError = false;
            _inputAssociation1NameError.IsVisible = false;

        }
    }

    void _OnInputAssociation2Name(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputAssociation2Name.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _association2Name = entryValue;
            _testInputAssociation2NameError = true;
            _inputAssociation2NameError.IsVisible = false;

        }

        else
        {
            _association2Name = "";
            _testInputAssociation2NameError = false;
            _inputAssociation2NameError.IsVisible = false;

        }
    }

    void _OnInputAssociation3Name(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputAssociation3Name.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _association3Name = entryValue;
            _testInputAssociation3NameError = true;
            _inputAssociation3NameError.IsVisible = false;

        }

        else
        {
            _association3Name = "";
            _testInputAssociation3NameError = false;
            _inputAssociation3NameError.IsVisible = false;

        }
    }

    void _OnInputLanguage1Name(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputLanguage1Name.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            _language1Name = entryValue;
            _testInputLanguage1NameError = true;
            _inputLanguage1NameError.IsVisible = false;
            _language1 = true;

        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            _testInputLanguage1NameError = true;
            _inputLanguage1NameError.IsVisible = true;
            _inputLanguage1NameError.Text = "This field must contain only letters";
            _language1 = false;
        }
        else
        {
            _language1Name = "";
            _testInputLanguage1NameError = false;
            _inputLanguage1NameError.IsVisible = false;
            _language1 = true;

        }
    }

    void _OnInputLanguage2Name(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputLanguage2Name.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            _language2Name = entryValue;
            _testInputLanguage2NameError = true;
            _inputLanguage2NameError.IsVisible = false;
            _language2 = true;

        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            _testInputLanguage2NameError = true;
            _inputLanguage2NameError.IsVisible = true;
            _inputLanguage2NameError.Text = "This field must contain only letters";
            _language2 = false;
        }
        else
        {
            _language2Name = "";
            _testInputLanguage2NameError = false;
            _inputLanguage2NameError.IsVisible = false;
            _language2 = true;

        }
    }

    void _OnInputLanguage3Name(Object sender, TextChangedEventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string entryValue = _inputLanguage3Name.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            _language3Name = entryValue;
            _testInputLanguage3NameError = true;
            _inputLanguage3NameError.IsVisible = false;
            _language3 = true;

        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            _testInputLanguage3NameError = true;
            _inputLanguage3NameError.IsVisible = true;
            _inputLanguage3NameError.Text = "This field must contain only letters";
            _language3 = false;
        }
        else
        {
            _language3Name = "";
            _testInputLanguage3NameError = false;
            _inputLanguage3NameError.IsVisible = false;
            _language3 = true;

        }
    }

    async void _inputSubmitbtn(object sender, EventArgs e)
    {
        _inputSubmitbtnName.BackgroundColor = Colors.Teal;
        await Task.Delay(500);
        _inputSubmitbtnName.BackgroundColor = Colors.DarkSlateGray;

        //entries 

        if (_testInputIdentificationStaffIDError == false)
        {
            _inputIdentificationStaffIDError.Text = "This field cannot be empty or blank";
            _inputIdentificationStaffIDError.IsVisible = true;
        }

        /*if (testInputIdentificationSocialSecurityError == false)
        {
            inputIdentificationSocialSecurityError.Text = "This field cannot be empty or blank";
            inputIdentificationSocialSecurityError.IsVisible = true;
        }

        if (testInputIdentificationNHISError == false)
        {
            inputIdentificationNHISError.Text = "This field cannot be empty or blank";
            inputIdentificationNHISError.IsVisible = true;
        }
        if (testInputIdentificationIntPassportError == false)
        {
            inputIdentificationIntPassportError.Text = "This field cannot be empty or blank";
            inputIdentificationIntPassportError.IsVisible = true;
        }

        if (testInputIdentificationVotersIDError == false)
        {
            inputIdentificationVotersIDError.Text = "This field cannot be empty or blank";
            inputIdentificationVotersIDError.IsVisible = true;
        }

        if (testInputIdentificationNationalIDError == false)
        {
            inputIdentificationNationalIDError.Text = "This field cannot be empty or blank";
            inputIdentificationNationalIDError.IsVisible = true;
        }

        if (testInputIdentificationDriversLicenseError == false)
        {
            inputIdentificationDriversLicenseError.Text = "This field cannot be empty or blank";
            inputIdentificationDriversLicenseError.IsVisible = true;
        }*/


        if (_testInputEmployeeDetialsSurnameError == false)
        {
            _inputEmployeeDetialsSurnameError.Text = "This field cannot be empty";
            _inputEmployeeDetialsSurnameError.IsVisible = true;
        }

        if (_testInputEmployeeDetialsFirstNameError == false)
        {
            _inputEmployeeDetialsFirstNameError.Text = "This field cannot be empty";
            _inputEmployeeDetialsFirstNameError.IsVisible = true;
        }

        if (_testInputEmployeeDetialsDirectorateError == false)
        {
            _inputEmployeeDetialsDirectorateError.Text = "This field cannot be empty";
            _inputEmployeeDetialsDirectorateError.IsVisible = true;
        }

        if (_testInputEmployeeDetialsDepartmentError == false)
        {
            _inputEmployeeDetialsDepartmentError.Text = "This field cannot be empty";
            _inputEmployeeDetialsDepartmentError.IsVisible = true;
        }

        if (_testInputEmployeeDetialsUnitError == false)
        {
            _inputEmployeeDetialsUnitError.IsVisible = true;
            _inputEmployeeDetialsUnitError.Text = "This field cannot be empty";
        }


        if (_testInputEmployeeDetialsJobClassError == false)
        {
            _inputEmployeeDetialsJobClassError.IsVisible = true;
            _inputEmployeeDetialsJobClassError.Text = "This field cannot be empty";
        }

        if (_testInputEmployeeDetialsJobTitleError == false)
        {
            _inputEmployeeDetialsJobTitleError.IsVisible = true;
            _inputEmployeeDetialsJobTitleError.Text = "This field cannot be empty";
        }

        if (_testInputEmployeeDetialsJobGradeError == false)
        {
            _inputEmployeeDetialsJobGradeError.IsVisible = true;
            _inputEmployeeDetialsJobGradeError.Text = "This field cannot be empty";
        }

        //pickers

        if (_testInputSubMetroError == false)
        {
            _inputLgsSubMetroError.Text = "This field cannot be empty";
            _inputLgsSubMetroError.IsVisible = true;
        }

        if (_testInputPaymentModeError == false)
        {
            _inputIdentificationPaymentModeError.Text = "This field cannot be empty ";
            _inputIdentificationPaymentModeError.IsVisible = true;
        }

        if (_testInputEmployementDetialsTitleError == false)
        {
            _inputEmployeeDetialsTitleError.Text = "This field cannot be empty";
            _inputEmployeeDetialsTitleError.IsVisible = true;

        }

        /* if (testInputBiographicalDataSexError == false)
         {
             inputBiograhicalDataSexError.Text = "This field cannot be empty";
             inputBiograhicalDataSexError.IsVisible = true;
         }

         if (testInputBiographicalMaritalStatusError == false)
         {
             inputBiograhicalDataMaritalStatusError.Text = "This field cannot be empty";
             inputBiograhicalDataMaritalStatusError.IsVisible = true;
         }

         if (testInputBiographicalRegionError == false)
         {
             inputBiographicalRegionError.IsVisible = true;
             inputBiographicalRegionError.Text = "This field cannot be empty";
         }

         if (testInputBiographicalDataCountriesError == false)
         {
             inputBiographicalDataCountriesError.Text = "This field cannot be empty";
             inputBiographicalDataCountriesError.IsVisible = true;

         }

        if (_testInputResidentialRegionError == false)
        {
            _inputResidentialRegionError.IsVisible = true;
            _inputResidentialRegionError.Text = "This field cannot be empty";
        }

        if (_testInputNextOfKinRegionError == false)
        {
            _inputNextOfKinRegionError.IsVisible = true;
            _inputNextOfKinRegionError.Text = "This field cannot be empty";
        }

        if (_testInputNextOfKinCountriesError == false)
        {
            _inputNextOfKinCountriesError.Text = "This field cannot be empty";
            _inputNextOfKinCountriesError.IsVisible = true;

        }

        if (_testInputDependant1TitleError == false)
        {
            _inputDependant1TitleError.IsVisible = true;
            _inputDependant1TitleError.Text = "This field cannot be empty";

        }

        if (_testInputDependant2TitleError == false)
        {
            _inputDependant2TitleError.IsVisible = true;
            _inputDependant2TitleError.Text = "This field cannot be empty";

        }

        if (_testInputDependant3TitleError == false)
        {
            _inputDependant3TitleError.IsVisible = true;
            _inputDependant3TitleError.Text = "This field cannot be empty";

        }

        if (_testInputDependant4TitleError == false)
        {
            _inputDependant4TitleError.IsVisible = true;
            _inputDependant4TitleError.Text = "This field cannot be empty";

        }

        if (_testInputDependant5TitleError == false)
        {
            _inputDependant5TitleError.IsVisible = true;
            _inputDependant5TitleError.Text = "This field cannot be empty";

        }*/

        /*if(testInputLanguageSpoken1Error == false)
        {
            inputLanguageSpoken1Error.IsVisible = false;
            inputLanguageSpoken1Error.Text = "";
        }

        */

        //date picker
        if (_testInputEmployeeDetialsAppointmentDateError == false)
        {
            _inputEmployeeDetailsAppointmentDateError.IsVisible = true;
            _inputEmployeeDetailsAppointmentDateError.Text = "Please select a date";
        }
        else
        {
            _inputEmployeeDetailsAppointmentDateError.IsVisible = false;
            _inputEmployeeDetailsAppointmentDateError.Text = string.Empty;
        }

        bool readyToGo = (_language1 && _language2 && _language3 && _isvalidDependant5MiddleName && _isvalidDependant5FirstName && _isvalidDependant5Surname && _isvalidDependant4MiddleName
            && _isvalidDependant4FirstName && _isvalidDependant4Surname && _isvalidDependant3MiddleName && _isvalidDependant3FirstName && _isvalidDependant3Surname && _isvalidDependant2MiddleName
            && _isvalidDependant2FirstName && _isvalidDependant2Surname && _isvalidDependant1MiddleName && _isvalidDependant1FirstName && _isvalidDependant1Surname && _isvalidNextOfKinFirstName
            && _isvalidNextOfKinSurname && _isvalidMaidenName && _isvalidJobGrade && _isvalidJobTitle && _isvalidJobClass && _isvalidSupervisor && _isvalidUnit && _isvalidDepartment
            && _isvalidDirectorate && _isvalidFirstAppointmentDate && _isvalidEmployeeMiddleName && _isvalidEmployeeFirstName && _isvalidEmployeeSurname && _isvalidEmployeeTitle
            && _isvalidStaffID);

        if (readyToGo)
        {


            /*_LgsSubMetro;
            _identificationStaffID;
            _identificationSocialSecurity;
            _identificationNHIS;
            _identificationIntPassport;
            _identificationIntPassportExpiryDate;
            _identificationVotersID;
            _identificationNationalID;
            _identificationDriversLicense;
            _identificationPaymentMode;
            _employementDetialsTitle;
            _employeeDetialsSurname;
            _employeeDetialsFirstName;
            _employeeDetialsMiddleName;
            _employeeDetialsDirectorate;
            _employeeDetialsDepartment;
            _employeeDetialsUnit;
            _employeeDetialsImmediateSupervisor;
            _employeeDetialsCostCenter;
            _employeeDetialsJobClass;
            _employeeDetialsJobTitle;
            _employeeDetialsJobGrade;
            _employeeDetialsGradeLevel;
            _employeeDetialsGradePoint;
            _employeeDetialsAppointmentDate;
            _employeeDetialsRetirementDate;
            _employeeDetialsLastPromotionDate;
            _bankDetialsBankName;
            _bankDetialsBankBranchName;
            _bankDetialsBankAccount;
            _biographicalDataMaidenName;
            _biographicalDataSex;
            _biographicalMaritalStatus;
            _biographicalDataPlaceOfBirth;
            _biographicalDataHomeTown;
            _biographicalRegion;
            _biographicalCountries;
            _biographicalDataReligion;
            _biographicalDataDateOfBirth;
            _residentialHouseNo;
            _residentialStreetName;
            _residentialArea;
            _residentialRegion;
            _residentialTownCity;
            _otherPostalAddress;
            _otherEmailAddress;
            _otherPhoneNo;
            _otherMobileNo;
            _disableState;
            _disableReason;
            _nextOfKinSurname;
            _nextOfKinFirstName;
            _nextOfKinRelationship;
            _nextOfKinContactHouseNo;
            _nextOfKinContactStreetName;
            _nextOfKinContactArea;
            _nextOFKinRegion;
            _nextOfKinCountries;
            _nextOfKinContactCityTown;
            _nextOfKinContactPhoneNo;
            _dependant1Title;
            _dependant1Surname;
            _dependant1FirstName;
            _dependant1MiddleName;
            _dependant1DateOfBirth;
            _dependant1Relationship;
            _dependant2Title;
            _dependant2Surname;
            _dependant2FirstName;
            _dependant2MiddleName;
            _dependant2DateOfBirth;
            _dependant2Relationship;
            _dependant3Title;
            _dependant3Surname;
            _dependant3FirstName;
            _dependant3MiddleName;
            _dependant3DateOfBirth;
            _dependant3Relationship;
            _dependant4Title;
            _dependant4Surname;
            _dependant4FirstName;
            _dependant4MiddleName;
            _dependant4DateOfBirth;
            _dependant4Relationship;
            _dependant5Title;
            _dependant5Surname;
            _dependant5FirstName;
            _dependant5MiddleName;
            _dependant5DateOfBirth;
            _dependant5Relationship;
            _educationInstitutionName;
            _educationQualificationObtained;
            _educationTo;
            _educationFrom;
            _educationCourseStudied;
            _educationEntryCertificate;
            _skills1Type;
            _skills1InstitutionName;
            _skills1YearObtained;
            _skills2Type;
            _skills2InstitutionName;
            _skills2YearObtained;
            _skills3Type;
            _skills3InstitutionName;
            _skills3YearObtained;
            _association1Name;
            _association2Name;
            _association3Name;
            _language1Name;
            _languageSpoken1;
            _languageReading1;
            _languageWriting1;
            _language2Name;
            _languageSpoken2;
            _languageReading2;
            _languageWriting2;
            _language3Name;
            _languageSpoken3;
            _languageReading3;
            _languageWriting3;*/

            bool result = await App.EmployeeRep.UpdateEmployeeByStaffID(__StaffID, _identificationStaffID, _identificationSocialSecurity, _identificationNHIS, _identificationIntPassport,
                _identificationVotersID, _identificationNationalID, _identificationDriversLicense, _employeeDetialsSurname, _employeeDetialsFirstName,
                _employeeDetialsMiddleName, _employeeDetialsDirectorate, _employeeDetialsDepartment, _employeeDetialsUnit, _employeeDetialsImmediateSupervisor,
                _employeeDetialsCostCenter, _employeeDetialsJobClass, _employeeDetialsJobTitle, _employeeDetialsJobGrade, _employeeDetialsGradeLevel,
                _employeeDetialsGradePoint, _bankDetialsBankName, _bankDetialsBankBranchName, _bankDetialsBankAccount, _biographicalDataMaidenName,
                _biographicalDataPlaceOfBirth, _biographicalDataHomeTown, _biographicalDataReligion, _residentialHouseNo, _residentialStreetName,
                _residentialArea, _residentialTownCity, _otherPostalAddress, _otherEmailAddress, _otherPhoneNo, _otherMobileNo, _disableState,
                _disableReason, _nextOfKinSurname, _nextOfKinFirstName, _nextOfKinRelationship, _nextOfKinContactHouseNo, _nextOfKinContactStreetName, _nextOfKinContactArea,
                _nextOfKinContactCityTown, _nextOfKinContactPhoneNo, _dependant1Surname, _dependant1FirstName, _dependant1MiddleName, _dependant1Relationship,
                _dependant2Surname, _dependant2FirstName, _dependant2MiddleName, _dependant2Relationship, _dependant3Surname, _dependant3FirstName,
                _dependant3MiddleName, _dependant3Relationship, _dependant4Surname, _dependant4FirstName, _dependant4MiddleName, _dependant4Relationship,
                _dependant5Surname, _dependant5FirstName, _dependant5MiddleName, _dependant5Relationship, _educationInstitutionName, _educationQualificationObtained,
                _educationCourseStudied, _educationEntryCertificate, _skills1Type, _skills2Type, _skills3Type, _skills1InstitutionName,
                _skills2InstitutionName, _skills3InstitutionName, _association1Name, _association2Name, _association3Name, _language1Name, _language2Name, _language3Name,
                _identificationIntPassportExpiryDate, _employeeDetialsAppointmentDate, _employeeDetialsRetirementDate, _employeeDetialsLastPromotionDate, _biographicalDataDateOfBirth,
                _dependant1DateOfBirth, _dependant2DateOfBirth, _dependant3DateOfBirth, _dependant4DateOfBirth, _dependant5DateOfBirth, _educationTo,
                _educationFrom, _skills1YearObtained, _skills2YearObtained, _skills3YearObtained, _LgsSubMetro, _identificationPaymentMode, _employementDetialsTitle,
                _biographicalDataSex, _biographicalMaritalStatus, _biographicalRegion, _biographicalCountries, _residentialRegion, _nextOFKinRegion,
                _nextOfKinCountries, _dependant1Title, _dependant2Title, _dependant3Title, _dependant4Title, _dependant5Title, _languageSpoken1,
                _languageSpoken2, _languageSpoken3, _languageReading1, _languageReading2, _languageReading3, _languageWriting1, _languageWriting2, _languageWriting3);

        }
        _viewaddemployee.Text = App.EmployeeRep.statusMessage;
        _viewaddemployee.IsVisible = true;
    }


    //pickers

    private string _LgsSubMetro;
    private string _identificationPaymentMode;
    private string _employementDetialsTitle;
    private string _biographicalDataSex;
    private string _biographicalMaritalStatus;
    private string _biographicalRegion;
    private string _biographicalCountries;
    private string _residentialRegion;
    private string _nextOFKinRegion;
    private string _nextOfKinCountries;
    private string _dependant1Title;
    private string _dependant2Title;
    private string _dependant3Title;
    private string _dependant4Title;
    private string _dependant5Title;
    private string _languageSpoken1;
    private string _languageSpoken2;
    private string _languageSpoken3;
    private string _languageReading1;
    private string _languageReading2;
    private string _languageReading3;
    private string _languageWriting1;
    private string _languageWriting2;
    private string _languageWriting3;



    //test
    private bool _testInputSubMetroError = false;
    private bool _testInputPaymentModeError = false;
    private bool _testInputEmployementDetialsTitleError = false;
    private bool _testInputBiographicalDataSexError = false;
    private bool _testInputBiographicalMaritalStatusError = false;
    private bool _testInputBiographicalRegionError = false;
    private bool _testInputBiographicalDataCountriesError = false;
    private bool _testInputResidentialRegionError = false;
    private bool _testInputNextOfKinRegionError = false;
    private bool _testInputNextOfKinCountriesError = false;
    private bool _testInputDependant1TitleError = false;
    private bool _testInputDependant2TitleError = false;
    private bool _testInputDependant3TitleError = false;
    private bool _testInputDependant4TitleError = false;
    private bool _testInputDependant5TitleError = false;
    private bool _testInputLanguageSpoken1Error = false;
    private bool _testInputLanguageSpoken2Error = false;
    private bool _testInputLanguageSpoken3Error = false;
    private bool _testInputLanguageReading1Error = false;
    private bool _testInputLanguageReading2Error = false;
    private bool _testInputLanguageReading3Error = false;
    private bool _testInputLanguageWriting1Error = false;
    private bool _testInputLanguageWriting2Error = false;
    private bool _testInputLanguageWriting3Error = false;







    void _OnPickerSelectedItem(object sender, EventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string selectedValue = _inputLgsSubMetro.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            _testInputSubMetroError = true;
            _inputLgsSubMetroError.IsVisible = false;
            _LgsSubMetro = selectedValue;
            _isvalidSubMetro = true;
        }
        else
        {
            _testInputSubMetroError = false;
            _isvalidSubMetro = false;
        }

    }

    void _OnPickerPaymentModeSelectedItem(object sender, EventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string selectedValue = _inputIdentificationPaymentMode.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            _inputIdentificationPaymentModeError.IsVisible = false;
            _identificationPaymentMode = selectedValue;
            _testInputPaymentModeError = true;
            _isvalidPaymentMode = true;
        }
        else
        {
            _testInputPaymentModeError = true;
            _isvalidPaymentMode = false;
        }
    }

    void _OnPickerEmployeeDetialsTitleSelectedItem(object sender, EventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string selectedValue = _inputEmployeeDetialsTitle.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            _inputEmployeeDetialsTitleError.IsVisible = false;
            _employementDetialsTitle = selectedValue;
            _testInputEmployementDetialsTitleError = true;
            _isvalidEmployeeTitle = true;
        }
        else
        {
            _testInputEmployementDetialsTitleError = true;
            _isvalidEmployeeTitle = false;
        }
    }

    void _OnPickerBiographicalDataSexSelectedItem(object sender, EventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string selectedValue = _inputBiographicalDataSex.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            _inputBiograhicalDataSexError.IsVisible = false;
            _biographicalDataSex = selectedValue;
            _testInputBiographicalDataSexError = true;
        }
        else
        {
            _biographicalDataSex = "";
            _testInputBiographicalDataSexError = false;
        }
    }

    void _OnPickerBiographicalDataMatrialStatusSelectedItem(object sender, EventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string selectedValue = _inputBiographicalDataMaritalStatus.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            _inputBiograhicalDataMaritalStatusError.IsVisible = false;
            _testInputBiographicalMaritalStatusError = true;
            _biographicalMaritalStatus = selectedValue;
        }
        else
        {
            _biographicalMaritalStatus = "";
            _testInputBiographicalMaritalStatusError = false;
        }
    }

    void _OnPickerBiographicalDataRegionSelectedItem(object sender, EventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string selectedValue = _inputBiographicalDataRegion.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            _inputBiographicalRegionError.IsVisible = false;
            _testInputBiographicalRegionError = true;
            _biographicalRegion = selectedValue;

        }
        else
        {
            _biographicalRegion = "";
            _testInputBiographicalRegionError = false;
        }

    }

    void _OnPickerBiographicalDataCountriesSelectedItem(object sender, EventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string selectedValue = _inputbiographicalDataCountries.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            _inputBiographicalDataCountriesError.IsVisible = false;
            _testInputBiographicalDataCountriesError = true;
            _biographicalCountries = selectedValue;
        }
        else
        {
            _biographicalCountries = "";
            _testInputBiographicalDataCountriesError = false;
        }
    }

    void _OnPickerResidentialRegionSelectedItem(object sender, EventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string selectedValue = _inputResidentialRegion.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            _inputResidentialRegionError.IsVisible = false;
            _residentialRegion = selectedValue;
            _testInputResidentialRegionError = true;

        }
        else
        {
            _residentialRegion = "";
            _testInputResidentialRegionError = false;
        }

    }

    void _OnPickerNextOfKinRegionSelectedItem(object sender, EventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string selectedValue = _inputNextOfKinRegion.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            _inputNextOfKinRegionError.IsVisible = false;
            _nextOFKinRegion = selectedValue;
            _testInputNextOfKinRegionError = true;
        }
        else
        {
            _nextOFKinRegion = "";
            _testInputNextOfKinRegionError = false;
        }

    }

    void _OnPickerNextOfKinCountriesSelectedItem(object sender, EventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string selectedValue = _inputNextOfKinCountries.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            _inputNextOfKinCountriesError.IsVisible = false;
            _testInputNextOfKinCountriesError = true;
            _nextOfKinCountries = selectedValue;
        }
        else
        {
            _nextOfKinCountries = "";
            _testInputNextOfKinCountriesError = false;
        }
    }

    void _OnPickerDependant1TitleSelectedItem(object sender, EventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string selectedValue = _inputDependant1Title.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            _inputDependant1TitleError.IsVisible = false;
            _testInputDependant1TitleError = true;
            _dependant1Title = selectedValue;
        }
        else
        {
            _dependant1Title = "";
            _testInputDependant1TitleError = false;
        }
    }

    void _OnPickerDependant2TitleSelectedItem(object sender, EventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string selectedValue = _inputDependant2Title.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            _inputDependant2TitleError.IsVisible = false;
            _testInputDependant2TitleError = true;
            _dependant2Title = selectedValue;
        }
        else
        {
            _dependant2Title = "";
            _testInputDependant2TitleError = false;
        }
    }

    void _OnPickerDependant3TitleSelectedItem(object sender, EventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string selectedValue = _inputDependant3Title.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            _inputDependant3TitleError.IsVisible = false;
            _testInputDependant3TitleError = true;
            _dependant3Title = selectedValue;
        }
        else
        {
            _dependant3Title = "";
            _testInputDependant3TitleError = false;
        }
    }

    void _OnPickerDependant4TitleSelectedItem(object sender, EventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string selectedValue = _inputDependant4Title.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            _inputDependant4TitleError.IsVisible = false;
            _testInputDependant4TitleError = true;
            _dependant4Title = selectedValue;
        }
        else
        {
            _dependant4Title = "";
            _testInputDependant4TitleError = false;
        }
    }

    void _OnPickerDependant5TitleSelectedItem(object sender, EventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string selectedValue = _inputDependant5Title.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            _inputDependant5TitleError.IsVisible = false;
            _testInputDependant5TitleError = true;
            _dependant5Title = selectedValue;
        }
        else
        {
            _dependant5Title = "";
            _testInputDependant5TitleError = false;
        }
    }

    void _OnPickerLanguageSpoken1SelectedItem(object sender, EventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string selectedValue = _inputLanguageSpoken1.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            _languageSpoken1 = selectedValue;
            _inputLanguageSpoken1Error.IsVisible = false;
            _testInputLanguageSpoken1Error = true;
        }
        else
        {
            _languageSpoken1 = "";
            _testInputLanguageSpoken1Error = false;
        }
    }

    void _OnPickerLanguageSpoken2SelectedItem(object sender, EventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string selectedValue = _inputLanguageSpoken2.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            _languageSpoken2 = selectedValue;
            _inputLanguageSpoken2Error.IsVisible = false;
            _testInputLanguageSpoken2Error = true;
        }
        else
        {
            _languageSpoken2 = "";
            _testInputLanguageSpoken2Error = false;
        }
    }

    void _OnPickerLanguageSpoken3SelectedItem(object sender, EventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string selectedValue = _inputLanguageSpoken3.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            _languageSpoken3 = selectedValue;
            _inputLanguageSpoken3Error.IsVisible = false;
            _testInputLanguageSpoken3Error = true;
        }
        else
        {
            _languageSpoken3 = "";
            _testInputLanguageSpoken3Error = false;
        }
    }

    void _OnPickerLanguageReading1SelectedItem(object sender, EventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string selectedValue = _inputLanguageReading1.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            _languageReading1 = selectedValue;
            _inputLanguageReading1Error.IsVisible = false;
            _testInputLanguageReading1Error = true;
        }
        else
        {
            _languageReading1 = "";
            _testInputLanguageReading1Error = false;
        }
    }

    void _OnPickerLanguageReading2SelectedItem(object sender, EventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string selectedValue = _inputLanguageReading2.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            _languageReading2 = selectedValue;
            _inputLanguageReading2Error.IsVisible = false;
            _testInputLanguageReading2Error = true;
        }
        else
        {
            _languageReading2 = "";
            _testInputLanguageReading2Error = false;
        }
    }

    void _OnPickerLanguageReading3SelectedItem(object sender, EventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string selectedValue = _inputLanguageReading3.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            _languageReading3 = selectedValue;
            _inputLanguageReading3Error.IsVisible = false;
            _testInputLanguageReading3Error = true;
        }
        else
        {
            _languageReading3 = "";
            _testInputLanguageReading3Error = false;
        }
    }

    void _OnPickerLanguageWriting1SelectedItem(object sender, EventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string selectedValue = _inputLanguageWriting1.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            _languageWriting1 = selectedValue;
            _inputLanguageWriting1Error.IsVisible = false;
            _testInputLanguageWriting1Error = true;
        }
        else
        {
            _languageWriting1 = "";
            _testInputLanguageWriting1Error = false;
        }
    }

    void _OnPickerLanguageWriting2SelectedItem(object sender, EventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string selectedValue = _inputLanguageWriting2.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            _languageWriting2 = selectedValue;
            _inputLanguageWriting2Error.IsVisible = false;
            _testInputLanguageWriting2Error = true;
        }
        else
        {
            _languageWriting2 = "";
            _testInputLanguageWriting2Error = false;
        }
    }

    void _OnPickerLanguageWriting3SelectedItem(object sender, EventArgs e)
    {
        _viewaddemployee.IsVisible = false;

        string selectedValue = _inputLanguageWriting3.SelectedItem as string;
        if (!(string.IsNullOrEmpty(selectedValue)))
        {
            _languageWriting3 = selectedValue;
            _inputLanguageWriting3Error.IsVisible = false;
            _testInputLanguageWriting3Error = true;
        }
        else
        {
            _languageWriting3 = "";
            _testInputLanguageWriting3Error = false;
        }
    }



    private string __StaffID;
    private bool test__staffID = false;
    private bool _isvalidTest__staffID = false;
    void OnSearchUpdateStaffID(object sender, TextChangedEventArgs e)
    {
        _updateIfStaff.IsVisible = false;
        searchUpdate_StaffID.IsVisible = false;
        string entryValue = searchUpdateStaffID.Text;
        if (!string.IsNullOrWhiteSpace(entryValue))
        {
            __StaffID = entryValue;
            test__staffID = true;
            _isvalidTest__staffID = true;
        }
    }


    async void submitUpdate_Query(object sender, EventArgs e)
    {
        submitUpdate_QueryName.BackgroundColor = Colors.Teal;
        await Task.Delay(500);
        submitUpdate_QueryName.BackgroundColor = Colors.DarkSlateGray;

        if (!test__staffID)
        {
            error_searchUpdateStaffID.IsVisible = true;
            error_searchUpdateStaffID.Text = "This field cannot be empty";
        }

        if (_isvalidTest__staffID)
        {
            List<EmployeeDB> list = await App.EmployeeRep.GetUpdatePeopleByStaffID(__StaffID);



            if (App.EmployeeRep.testData)
            {
                foreach (EmployeeDB emp in list)
                {

                    _inputLgsSubMetro.SelectedItem = emp.LgsSubMetro;
                    _inputIdentificationStaffID.Text = emp.identificationStaffID;
                    _inputIdentificationSocialSecurity.Text = emp.identificationSocialSecurity;
                    _inputIdentificationNHIS.Text = emp.identificationNHIS;
                    _inputIdentificationIntPassport.Text = emp.identificationIntPassport;
                    _inputIdentificationPaymentMode.SelectedItem = emp.identificationPaymentMode;
                    _inputIdentificationVotersID.Text = emp.identificationVotersID;
                    _inputIdentificationNationalID.Text = emp.identificationNationalID;
                    _inputIdentificationDriversLicense.Text = emp.identificationDriversLicense;
                    string dataString = emp.identificationIntPassportExpiryDate;
                    if (!(string.IsNullOrWhiteSpace(dataString)))
                    {
                        DateTime selectedDate;
                        if (DateTime.TryParseExact(dataString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedDate))
                        {
                            _inputIdentificationIntPassportExpiryDate.Date = selectedDate;
                        }
                    }
                    else
                    {
                        DateTime specificDate = new DateTime(1960, 02, 01);
                        _inputIdentificationIntPassportExpiryDate.Date = specificDate;
                    }
                    _inputEmployeeDetialsTitle.SelectedItem = emp.employementDetialsTitle;
                    _inputEmployeeDetialsSurname.Text = emp.employeeDetialsSurname;
                    _inputEmployeeDetialsFirstName.Text = emp.employeeDetialsFirstName;
                    _inputEmployeeDetialsMiddleName.Text = emp.employeeDetialsMiddleName;
                    string dataStringA = emp.employeeDetialsAppointmentDate;
                    if (!(string.IsNullOrWhiteSpace(dataStringA)))
                    {
                        DateTime selectedDateA;
                        if (DateTime.TryParseExact(dataStringA, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedDateA))
                        {
                            _inputEmployeeDeitialsAppointmentDate.Date = selectedDateA;
                        }
                    }
                    else
                    {
                        DateTime specificDate = new DateTime(1960, 02, 01);
                        _inputEmployeeDeitialsAppointmentDate.Date = specificDate;
                    }

                    _inputEmployeeDetialsDirectorate.Text = emp.employeeDetialsDirectorate;
                    _inputEmployeeDetialsDepartment.Text = emp.employeeDetialsDepartment;
                    _inputEmployeeDetialsUnit.Text = emp.employeeDetialsUnit;
                    _inputEmployeeDetialsImmediateSupervisor.Text = emp.employeeDetialsImmediateSupervisor;
                    _inputEmployeeDetialsCostCenter.Text = emp.employeeDetialsCostCenter;
                    _inputEmployeeDetialsJobClass.Text = emp.employeeDetialsJobClass;
                    _inputEmployeeDetialsJobTitle.Text = emp.employeeDetialsJobTitle;
                    _inputEmployeeDetialsJobGrade.Text = emp.employeeDetialsJobGrade;
                    string dataStringB = emp.employeeDetialsRetirementDate;
                    if (!(string.IsNullOrWhiteSpace(dataStringB)))
                    {
                        DateTime selectedDateB;
                        if (DateTime.TryParseExact(dataStringB, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedDateB))
                        {
                            _inputEmployeeDeitialsRetirementDate.Date = selectedDateB;
                        }
                    }
                    else
                    {
                        DateTime specificDate = new DateTime(1960, 02, 01);
                        _inputEmployeeDeitialsRetirementDate.Date = specificDate;
                    }
                    _inputEmployeeDetialsGradeLevel.Text = emp.employeeDetialsGradeLevel;
                    _inputEmployeeDetialsGradePoint.Text = emp.employeeDetialsGradePoint;
                    string dataStringC = emp.employeeDetialsLastPromotionDate;
                    if (!(string.IsNullOrWhiteSpace(dataStringC)))
                    {
                        DateTime selectedDateC;
                        if (DateTime.TryParseExact(dataStringC, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedDateC))
                        {
                            _inputEmployeeDeitialsLastPromotionDate.Date = selectedDateC;
                        }
                    }
                    else
                    {
                        DateTime specificDate = new DateTime(1960, 02, 01);
                        _inputEmployeeDeitialsLastPromotionDate.Date = specificDate;
                    }
                    _inputBankDetialsBankName.Text = emp.bankDetialsBankName;
                    _inputBankDetialsBankBranchName.Text = emp.bankDetialsBankBranchName;
                    _inputBankDetialsBankAccount.Text = emp.bankDetialsBankAccount;
                    _inputBiographicalDataMaidenName.Text = emp.biographicalDataMaidenName;

                    string picker = emp.biographicalDataSex;
                    if (!(string.IsNullOrWhiteSpace(picker)))
                    {
                        _inputBiographicalDataSex.SelectedItem = picker;
                    }
                    else
                    {
                        _inputBiographicalDataSex.SelectedItem = null;
                    }

                    string pickerA = emp.biographicalMaritalStatus;
                    if (!(string.IsNullOrWhiteSpace(pickerA)))
                    {
                        _inputBiographicalDataMaritalStatus.SelectedItem = pickerA;
                    }
                    else
                    {
                        _inputBiographicalDataMaritalStatus.SelectedItem = null;
                    }

                    _inputBiographicalDataPlaceOfBirth.Text = emp.biographicalDataPlaceOfBirth;

                    string dataStringD = emp.biographicalDataDateOfBirth;
                    if (!(string.IsNullOrWhiteSpace(dataStringD)))
                    {
                        DateTime selectedDateD;
                        if (DateTime.TryParseExact(dataStringD, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedDateD))
                        {
                            _inputBiographicalDataDateOfBirthDate.Date = selectedDateD;
                        }
                    }
                    else
                    {
                        DateTime specificDate = new DateTime(1960, 02, 01);
                        _inputBiographicalDataDateOfBirthDate.Date = specificDate;

                    }

                    _inputBiographicalDataHomeTown.Text = emp.biographicalDataHomeTown;

                    string pickerB = emp.biographicalRegion;
                    if (!(string.IsNullOrWhiteSpace(pickerB)))
                    {
                        _inputBiographicalDataRegion.SelectedItem = pickerB;
                    }
                    else
                    {
                        _inputBiographicalDataRegion.SelectedItem = null;
                    }

                    string pickerC = emp.biographicalCountries;
                    if (!(string.IsNullOrWhiteSpace(pickerC)))
                    {
                        _inputbiographicalDataCountries.SelectedItem = pickerC;
                    }
                    else
                    {
                        _inputbiographicalDataCountries.SelectedItem = null;
                    }

                    _inputBiographicalDataReligionError.Text = emp.biographicalDataReligion;
                    _inputResidentialHouseNo.Text = emp.residentialHouseNo;
                    _inputResidentialStreetName.Text = emp.residentialStreetName;
                    _inputResidentialArea.Text = emp.residentialArea;
                    _inputResidentialTownCity.Text = emp.residentialTownCity;


                    _inputBiographicalDataReligion.Text = emp.biographicalDataReligion;

                    _inputOtherPostalAddress.Text = emp.otherPostalAddress;
                    _inputOtherEmailAddress.Text = emp.otherEmailAddress;
                    _inputOtherPhoneNo.Text = emp.otherPhoneNo;
                    _inputOtherMobileNo.Text = emp.otherMobileNo;

                    string dis_able = emp.disableState;

                    if (dis_able == "Yes")
                    {
                        _diba.IsChecked = true;
                        _dibb.IsChecked = false;
                        _inputDiableState.Text = emp.disableReason;
                    }
                    else if (dis_able == "No")
                    {
                        _diba.IsChecked = false;
                        _diba.IsChecked = true;
                    }

                    _inputNextOfKinSurname.Text = emp.nextOfKinSurname;
                    _inputNextOfKinFirstName.Text = emp.nextOfKinFirstName;
                    _inputNextOfKinRelationship.Text = emp.nextOfKinRelationship;
                    _inputNextOfKinContactHouseNo.Text = emp.nextOfKinContactHouseNo;
                    _inputNextOfKinContactStreetName.Text = emp.nextOfKinContactStreetName;
                    _inputNextOfKinContactArea.Text = emp.nextOfKinContactArea;
                    _inputNextOfKinContactCityTown.Text = emp.nextOfKinContactCityTown;

                    string pickerE = emp.nextOFKinRegion;
                    if (!(string.IsNullOrWhiteSpace(pickerE)))
                    {
                        _inputNextOfKinRegion.SelectedItem = pickerE;
                    }
                    else
                    {
                        _inputNextOfKinRegion.SelectedItem = null;
                    }

                    string pickerF = emp.nextOfKinCountries;
                    if (!(string.IsNullOrWhiteSpace(pickerF)))
                    {
                        _inputNextOfKinCountries.SelectedItem = pickerF;
                    }
                    else
                    {
                        _inputNextOfKinCountries.SelectedItem = null;
                    }

                    _inputNextOfKinContactPhoneNo.Text = emp.nextOfKinContactPhoneNo;

                    string pickerG = emp.dependant1Title;
                    if (!(string.IsNullOrWhiteSpace(pickerG)))
                    {
                        _inputDependant1Title.SelectedItem = pickerG;
                    }
                    else
                    {
                        _inputDependant1Title.SelectedItem = null;
                    }

                    _inputDependant1Surname.Text = emp.dependant1Surname;
                    _inputDependant1FirstName.Text = emp.dependant1FirstName;
                    _inputDependant1MiddleName.Text = emp.dependant1MiddleName;

                    string dataStringE = emp.dependant1DateOfBirth;
                    if (!(string.IsNullOrWhiteSpace(dataStringE)))
                    {
                        DateTime selectedDateE;
                        if (DateTime.TryParseExact(dataStringE, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedDateE))
                        {
                            _inputDependant1DateOfBirhtDate.Date = selectedDateE;
                        }
                    }
                    else
                    {
                        DateTime specificDate = new DateTime(1960, 02, 01);
                        _inputDependant1DateOfBirhtDate.Date = specificDate;

                    }

                    _inputDependant1Relationship.Text = emp.dependant1Relationship;


                    string pickerH = emp.dependant2Title;
                    if (!(string.IsNullOrWhiteSpace(pickerH)))
                    {
                        _inputDependant2Title.SelectedItem = pickerH;
                    }
                    else
                    {
                        _inputDependant2Title.SelectedItem = null;
                    }

                    _inputDependant2Surname.Text = emp.dependant2Surname;
                    _inputDependant2FirstName.Text = emp.dependant2FirstName;
                    _inputDependant2MiddleName.Text = emp.dependant2MiddleName;

                    string dataStringF = emp.dependant2DateOfBirth;
                    if (!(string.IsNullOrWhiteSpace(dataStringF)))
                    {
                        DateTime selectedDateF;
                        if (DateTime.TryParseExact(dataStringF, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedDateF))
                        {
                            _inputDependant2DateOfBirhtDate.Date = selectedDateF;
                        }
                    }
                    else
                    {
                        DateTime specificDate = new DateTime(1960, 02, 01);
                        _inputDependant2DateOfBirhtDate.Date = specificDate;

                    }

                    _inputDependant2Relationship.Text = emp.dependant2Relationship;

                    string pickerI = emp.dependant3Title;
                    if (!(string.IsNullOrWhiteSpace(pickerI)))
                    {
                        _inputDependant3Title.SelectedItem = pickerI;
                    }
                    else
                    {
                        _inputDependant3Title.SelectedItem = null;
                    }

                    _inputDependant3Surname.Text = emp.dependant3Surname;
                    _inputDependant3FirstName.Text = emp.dependant3FirstName;
                    _inputDependant3MiddleName.Text = emp.dependant3MiddleName;

                    string dataStringG = emp.dependant3DateOfBirth;
                    if (!(string.IsNullOrWhiteSpace(dataStringG)))
                    {
                        DateTime selectedDateG;
                        if (DateTime.TryParseExact(dataStringG, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedDateG))
                        {
                            _inputDependant3DateOfBirhtDate.Date = selectedDateG;
                        }
                    }
                    else
                    {
                        DateTime specificDate = new DateTime(1960, 02, 01);
                        _inputDependant3DateOfBirhtDate.Date = specificDate;

                    }

                    _inputDependant3Relationship.Text = emp.dependant3Relationship;

                    string pickerJ = emp.dependant4Title;
                    if (!(string.IsNullOrWhiteSpace(pickerJ)))
                    {
                        _inputDependant4Title.SelectedItem = pickerJ;
                    }
                    else
                    {
                        _inputDependant4Title.SelectedItem = null;
                    }

                    _inputDependant4Surname.Text = emp.dependant4Surname;
                    _inputDependant4FirstName.Text = emp.dependant4FirstName;
                    _inputDependant4MiddleName.Text = emp.dependant4MiddleName;

                    string dataStringH = emp.dependant4DateOfBirth;
                    if (!(string.IsNullOrWhiteSpace(dataStringH)))
                    {
                        DateTime selectedDateH;
                        if (DateTime.TryParseExact(dataStringH, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedDateH))
                        {
                            _inputDependant4DateOfBirhtDate.Date = selectedDateH;
                        }
                    }
                    else
                    {
                        DateTime specificDate = new DateTime(1960, 02, 01);
                        _inputDependant4DateOfBirhtDate.Date = specificDate;

                    }

                    _inputDependant4Relationship.Text = emp.dependant4Relationship;

                    string pickerK = emp.dependant5Title;
                    if (!(string.IsNullOrWhiteSpace(pickerK)))
                    {
                        _inputDependant5Title.SelectedItem = pickerK;
                    }
                    else
                    {
                        _inputDependant5Title.SelectedItem = null;
                    }

                    _inputDependant5Surname.Text = emp.dependant5Surname;
                    _inputDependant5FirstName.Text = emp.dependant5FirstName;
                    _inputDependant5MiddleName.Text = emp.dependant5MiddleName;

                    string dataStringI = emp.dependant5DateOfBirth;
                    if (!(string.IsNullOrWhiteSpace(dataStringI)))
                    {
                        DateTime selectedDateI;
                        if (DateTime.TryParseExact(dataStringI, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedDateI))
                        {
                            _inputDependant5DateOfBirhtDate.Date = selectedDateI;
                        }
                    }
                    else
                    {
                        DateTime specificDate = new DateTime(1960, 02, 01);
                        _inputDependant5DateOfBirhtDate.Date = specificDate;

                    }

                    _inputDependant5Relationship.Text = emp.dependant5Relationship;
                    _inputEducationInstitutionName.Text = emp.educationInstitutionName;

                    string dataStringJ = emp.educationTo;
                    if (!(string.IsNullOrWhiteSpace(dataStringJ)))
                    {
                        DateTime selectedDateJ;
                        if (DateTime.TryParseExact(dataStringJ, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedDateJ))
                        {
                            _inputEducationToDate.Date = selectedDateJ;
                        }
                    }
                    else
                    {
                        DateTime specificDate = new DateTime(1960, 02, 01);
                        _inputEducationToDate.Date = specificDate;

                    }

                    string dataStringK = emp.educationFrom;
                    if (!(string.IsNullOrWhiteSpace(dataStringK)))
                    {
                        DateTime selectedDateK;
                        if (DateTime.TryParseExact(dataStringK, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedDateK))
                        {
                            _inputEducationFromDate.Date = selectedDateK;
                        }
                    }
                    else
                    {
                        DateTime specificDate = new DateTime(1960, 02, 01);
                        _inputEducationFromDate.Date = specificDate;

                    }

                    _inputEducationQualificationObtained.Text = emp.educationQualificationObtained;
                    _inputEducationCourseStudied.Text = emp.educationCourseStudied;
                    _inputEducationEntryCertificate.Text = emp.educationEntryCertificate;
                    _inputSkills1Type.Text = emp.skills1Type;
                    _inputSkills2Type.Text = emp.skills2Type;
                    _inputSkills3Type.Text = emp.skills3Type;
                    _inputSkills1InstitutionName.Text = emp.skills1InstitutionName;
                    _inputSkills2InstitutionName.Text = emp.skills2InstitutionName;
                    _inputSkills3InstitutionName.Text = emp.skills3InstitutionName;

                    string dataStringL = emp.skills1YearObtained;
                    if (!(string.IsNullOrWhiteSpace(dataStringL)))
                    {
                        DateTime selectedDateL;
                        if (DateTime.TryParseExact(dataStringL, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedDateL))
                        {
                            _inputSkills1YearObtainedate.Date = selectedDateL;
                        }
                    }
                    else
                    {
                        DateTime specificDate = new DateTime(1960, 02, 01);
                        _inputSkills1YearObtainedate.Date = specificDate;

                    }

                    string dataStringM = emp.skills2YearObtained;
                    if (!(string.IsNullOrWhiteSpace(dataStringM)))
                    {
                        DateTime selectedDateM;
                        if (DateTime.TryParseExact(dataStringM, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedDateM))
                        {
                            _inputSkills2YearObtainedate.Date = selectedDateM;
                        }
                    }
                    else
                    {
                        DateTime specificDate = new DateTime(1960, 02, 01);
                        _inputSkills2YearObtainedate.Date = specificDate;

                    }

                    string dataStringN = emp.skills3YearObtained;
                    if (!(string.IsNullOrWhiteSpace(dataStringN)))
                    {
                        DateTime selectedDateN;
                        if (DateTime.TryParseExact(dataStringN, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedDateN))
                        {
                            _inputSkills3YearObtainedate.Date = selectedDateN;
                        }
                    }
                    else
                    {
                        DateTime specificDate = new DateTime(1960, 02, 01);
                        _inputSkills3YearObtainedate.Date = specificDate;

                    }

                    _inputAssociation1Name.Text = emp.association1Name;
                    _inputAssociation2Name.Text = emp.association2Name;
                    _inputAssociation3Name.Text = emp.association3Name;
                    _inputLanguage1Name.Text = emp.language1Name;
                    _inputLanguage2Name.Text = emp.language2Name;
                    _inputLanguage3Name.Text = emp.language3Name;


                    string pickerL = emp.languageSpoken1;
                    if (!(string.IsNullOrWhiteSpace(pickerL)))
                    {
                        _inputLanguageSpoken1.SelectedItem = pickerL;
                    }
                    else
                    {
                        _inputLanguageSpoken1.SelectedItem = null;
                    }

                    string pickerM = emp.languageSpoken2;
                    if (!(string.IsNullOrWhiteSpace(pickerM)))
                    {
                        _inputLanguageSpoken2.SelectedItem = pickerM;
                    }
                    else
                    {
                        _inputLanguageSpoken2.SelectedItem = null;
                    }

                    string pickerN = emp.languageSpoken3;
                    if (!(string.IsNullOrWhiteSpace(pickerN)))
                    {
                        _inputLanguageSpoken3.SelectedItem = pickerN;
                    }
                    else
                    {
                        _inputLanguageSpoken3.SelectedItem = null;
                    }

                    string pickerO = emp.languageReading1;
                    if (!(string.IsNullOrWhiteSpace(pickerO)))
                    {
                        _inputLanguageReading1.SelectedItem = pickerO;
                    }
                    else
                    {
                        _inputLanguageReading1.SelectedItem = null;
                    }

                    string pickerP = emp.languageReading2;
                    if (!(string.IsNullOrWhiteSpace(pickerP)))
                    {
                        _inputLanguageReading2.SelectedItem = pickerP;
                    }
                    else
                    {
                        _inputLanguageReading2.SelectedItem = null;
                    }

                    string pickerQ = emp.languageReading3;
                    if (!(string.IsNullOrWhiteSpace(pickerQ)))
                    {
                        _inputLanguageReading3.SelectedItem = pickerQ;
                    }
                    else
                    {
                        _inputLanguageReading3.SelectedItem = null;
                    }


                    string pickerR = emp.languageWriting1;
                    if (!(string.IsNullOrWhiteSpace(pickerR)))
                    {
                        _inputLanguageWriting1.SelectedItem = pickerR;
                    }
                    else
                    {
                        _inputLanguageWriting1.SelectedItem = null;
                    }

                    string pickerS = emp.languageWriting2;
                    if (!(string.IsNullOrWhiteSpace(pickerS)))
                    {
                        _inputLanguageWriting2.SelectedItem = pickerS;
                    }
                    else
                    {
                        _inputLanguageWriting2.SelectedItem = null;
                    }

                    string pickerT = emp.languageWriting3;
                    if (!(string.IsNullOrWhiteSpace(pickerT)))
                    {
                        _inputLanguageWriting3.SelectedItem = pickerT;
                    }
                    else
                    {
                        _inputLanguageWriting3.SelectedItem = null;
                    }





                    _updateIfStaff.IsVisible = true;


                }
                searchUpdate_StaffID.Text = App.EmployeeRep.statusMessage;
                searchUpdate_StaffID.IsVisible = true;
            }
            else
            {
                searchUpdate_StaffID.Text = __StaffID + " does not exist";
                searchUpdate_StaffID.IsVisible = true;

            }
        }


    }
    //basic authentication
    static bool IsEmailValid(string email)
    {
        // Regular expression for a basic email pattern
        string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

        return Regex.IsMatch(email, emailPattern);
    }

    static bool IsPhoneNumberValid(string phoneNumber)
    {
        // Regular expression to match a 10-digit number starting with 0
        string phonePattern = @"^0[0-9]{9}$";

        return Regex.IsMatch(phoneNumber, phonePattern);
    }


    //leave managament

    //add
    private bool isvalidAddStaffID = false;
    private bool isvalidAddDateApplied = false;
    private bool isvalidAddNameofHOD = false;
    private bool isvalidAddDaysRequested = false;
    private bool isvalidAddTypeofLeave = false;
    private bool isvalidAddResumeDate = false;
    private bool isvalidAddOfficer = false;
    private bool isvalidAddApprovalDate = false;
    private bool isvalidTotalLeaveDays = false;
    private bool isvalidNumberofDaysLeft = false;

    private string addStaffID;
    private string addDateApplied;
    private string addNameOfHOD;
    private string addDaysRequested = "0";
    private string addTypeofLeave;
    private string addResumeDate;
    private string addOfficer;
    private string addApprovalDate;
    private string addTotalLeaveDays;
    private string addNumberofDaysLeft;


    private bool testAddStaffIDError = false;
    private bool testAddDateAppliedError = false;
    private bool testAddNameoofHODError = false;
    private bool testAddDaysRequestedError = false;
    private bool testAddTypeofLeaveError = false;
    private bool testAddResumeDateError = false;
    private bool testAddOfficerError = false;
    private bool testAddApprovalDateError = false;
    private bool testAddTotalLeaveDays = false;



    void OnAddStaffIDTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = leaveAddStaffID.Text;

        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            testAddStaffIDError = true;
            addStaffID = entryValue;
            leaveAddStaffIDError.IsVisible = false;
            isvalidAddStaffID = true;
            leavesuccess.IsVisible = false;
        }
        else
        {
            testAddStaffIDError = false;
        }
    }

    void OnAddNameofHOD(object sender, TextChangedEventArgs e)
    {
        string entryValue = leaveAddNameofHOD.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            addNameOfHOD = entryValue;
            testAddNameoofHODError = true;
            leaveAddNameofHODError.IsVisible = false;
            isvalidAddNameofHOD = true;
            leavesuccess.IsVisible = false;

        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            leaveAddNameofHODError.IsVisible = true;
            leaveAddNameofHODError.Text = "This field must be letters";
            isvalidAddNameofHOD = false;
        }
        else
        {
            addNameOfHOD = "";
            leaveAddNameofHODError.IsVisible = false;
            isvalidAddNameofHOD = true;
        }
    }

    void OnAddDaysRequested(object sender, TextChangedEventArgs e)
    {
        string entryValue = leaveAddDaysRequested.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsDigit))
        {
            addDaysRequested = entryValue;
            isvalidAddDaysRequested = true;
            leaveAddDaysRequestedError.IsVisible = false;
            leavesuccess.IsVisible = false;

        }
        else if (!(entryValue.All(char.IsDigit)))
        {
            leaveAddDaysRequestedError.IsVisible = true;
            leaveAddDaysRequestedError.Text = "This field must be numbers only";
            isvalidAddDaysRequested = false;
        }
        else
        {
            leaveAddDaysRequestedError.IsVisible = false;
            addDaysRequested = "";
            isvalidAddDaysRequested = true;
        }
    }

    void OnAddNameofOfficer(object sender, TextChangedEventArgs e)
    {
        string entryValue = leaveAddNameofOfficer.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            addOfficer = entryValue;
            testAddOfficerError = true;
            leaveAddNameofOfficerError.IsVisible = false;
            isvalidAddOfficer = true;
            leavesuccess.IsVisible = false;
        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            leaveAddNameofOfficerError.IsVisible = true;
            leaveAddNameofOfficerError.Text = "This field must be letters";
            isvalidAddOfficer = false;
        }
        else
        {
            addOfficer = "";
            leaveAddNameofOfficerError.IsVisible = false;
            isvalidAddOfficer = true;
        }
    }


    private int a, b, c;
    void OnAddTotalLeaveDays(object sender, TextChangedEventArgs e)
    {
        string entryValue = leaveAddTotalLeaveDays.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsDigit))
        {
            addTotalLeaveDays = entryValue;
            isvalidTotalLeaveDays = true;
            leaveAddTotalLeaveDaysError.IsVisible = false;
            leavesuccess.IsVisible = false;
            a = int.Parse(addTotalLeaveDays);
            b = int.Parse(addDaysRequested);


            if (a < b)
            {
                leaveAddNumberosDaysLeftError.Text = addStaffID + " has exceed his/her leave days availalbe";
                leaveAddNumberosDaysLeftError.IsVisible = true;
                isvalidNumberofDaysLeft = false;
                c = 0;
                leaveAddNumberofDayLeft.Text = c.ToString();
                addNumberofDaysLeft = c.ToString();
            }
            else if (a > b)
            {
                leaveAddNumberosDaysLeftError.IsVisible = false;
                c = a - b;
                leaveAddNumberofDayLeft.Text = c.ToString();
                addNumberofDaysLeft = c.ToString();
                isvalidNumberofDaysLeft = true;

            }
            else
            {
                leaveAddNumberofDayLeft.Text = "0";
                addNumberofDaysLeft = "0";
                isvalidNumberofDaysLeft = true;
            }



        }
        else if (!(entryValue.All(char.IsDigit)))
        {
            leaveAddTotalLeaveDaysError.IsVisible = true;
            leaveAddTotalLeaveDaysError.Text = "This field must be numbers only";
            isvalidTotalLeaveDays = false;
        }
        else
        {
            leaveAddTotalLeaveDaysError.IsVisible = false;
            isvalidTotalLeaveDays = true;
            leaveAddNumberofDayLeft.Text = "0";
            addNumberofDaysLeft = "0";
            isvalidNumberofDaysLeft = false;
        }
    }

    async void btn_leaveAdd(object sender, EventArgs e)
    {
        btn_leaveAddButton.BackgroundColor = Colors.Teal;
        await Task.Delay(500);
        btn_leaveAddButton.BackgroundColor = Colors.DarkSlateGray;
        if (testAddStaffIDError == false)
        {
            leaveAddStaffIDError.Text = "This field cannot be empty";
            leaveAddStaffIDError.IsVisible = true;
        }

        if (testAddNameoofHODError == false)
        {
            leaveAddNameofHODError.IsVisible = true;
            leaveAddNameofHODError.Text = "This field cannot be empty";
        }

        if (testAddOfficerError == false)
        {
            leaveAddNameofOfficerError.IsVisible = true;
            leaveAddNameofOfficerError.Text = "This field cannot be empty";
        }

        if (testAddDateAppliedError == false)
        {
            leaveAddDateAppliedError.IsVisible = true;
            leaveAddDateAppliedError.Text = "Please select a date";
        }

        if (testAddTypeofLeaveError == false)
        {
            leaveAddTypeofLeaveError.IsVisible = true;
            leaveAddTypeofLeaveError.Text = "This field cannot be empty";
        }

        if (testAddResumeDateError == false)
        {
            leaveAddResumeDateError.IsVisible = true;
            leaveAddResumeDateError.Text = "Please select a date";
        }

        if (testAddApprovalDateError == false)
        {
            leaveAddApprovalDateError.IsVisible = true;
            leaveAddApprovalDateError.Text = "Please select a date";
        }

        if (isvalidAddStaffID && isvalidAddDateApplied && isvalidAddNameofHOD && isvalidAddDaysRequested && isvalidAddTypeofLeave
            && isvalidAddResumeDate && isvalidAddOfficer && isvalidAddApprovalDate && isvalidTotalLeaveDays && isvalidNumberofDaysLeft)
        {
            /*private string addStaffID;
    private string addDateApplied;
    private string addNameOfHOD;
    private string addDaysRequested = "0";
    private string addTypeofLeave;
    private string addResumeDate;
    private string addOfficer;
    private string addApprovalDate;
    private string addTotalLeaveDays;
    private string addNumberofDaysLeft*/
            await App.LeaveRep.AddLeaveEmployee(addStaffID, addDateApplied, addNameOfHOD, addDaysRequested,
                addTypeofLeave, addResumeDate, addOfficer, addApprovalDate, addTotalLeaveDays
                );

            addRecord1(addStaffID, addTypeofLeave, addDateApplied, addResumeDate, addApprovalDate, addNameOfHOD, addOfficer, addDaysRequested
                 , addTotalLeaveDays, fullPath1);
            leavesuccess.Text = App.LeaveRep.message;
            leavesuccess.IsVisible = true;

            bool done = App.LeaveRep.done;
            if (done)
            {
                leaveAddStaffID.Text = string.Empty;
                DateTime specificDate = new DateTime(1960, 02, 01);
                leaveAddDateApplied.Date = specificDate;
                leaveAddNameofHOD.Text = string.Empty;
                leaveAddDaysRequested.Text = string.Empty;
                leaveAddNumberofDayLeft.Text = string.Empty;
                leaveAddResumeDate.Date = specificDate;
                leaveAddNameofOfficer.Text = string.Empty;
                leaveAddApprovalDate.Date = specificDate;
                leaveAddTotalLeaveDays.Text = string.Empty;
            }



        }

    }


    void OnDatePickerLeaveAddDateApplied(object sender, DateChangedEventArgs e)
    {
        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desireDate = new DateTime(1960, 02, 01);
        string desireDateFormat = desireDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            testAddDateAppliedError = false;
            isvalidAddDateApplied = false;
        }
        else
        {
            testAddDateAppliedError = true;
            addDateApplied = selectedDateFormat;
            isvalidAddDateApplied = true;
            leaveAddDateAppliedError.IsVisible = false;
            leavesuccess.IsVisible = false;
        }

    }

    void OnDatePickerLeaveAddResumeDate(object sender, DateChangedEventArgs e)
    {
        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 02, 01);
        string desiredDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desiredDateFormat)
        {
            testAddResumeDateError = false;
            isvalidAddResumeDate = false;
        }
        else
        {
            testAddResumeDateError = true;
            addResumeDate = selectedDateFormat;
            isvalidAddResumeDate = true;
            leaveAddResumeDateError.IsVisible = false;
            leavesuccess.IsVisible = false;
        }

    }

    void OnDatePickerLeaveAddApprovalDate(object sender, DateChangedEventArgs e)
    {
        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 02, 01);
        string desiredDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desiredDateFormat)
        {
            testAddApprovalDateError = false;
            isvalidAddApprovalDate = false;
        }
        else
        {
            testAddApprovalDateError = true;
            addApprovalDate = selectedDateFormat;
            isvalidAddApprovalDate = true;
            leaveAddApprovalDateError.IsVisible = false;
            leavesuccess.IsVisible = false;
        }

    }

    void OnPickerAddTypeOfLeave(object sender, EventArgs e)
    {
        string selectedValue = leaveAddTypeOfLeave.SelectedItem as string;
        if (!(string.IsNullOrWhiteSpace(selectedValue)))
        {
            addTypeofLeave = selectedValue;
            testAddTypeofLeaveError = true;
            leaveAddTypeofLeaveError.IsVisible = false;
            isvalidAddTypeofLeave = true;
            leavesuccess.IsVisible = false;

        }
        else
        {
            testAddTypeofLeaveError = false;
            isvalidAddTypeofLeave = false;
        }
    }


    //udate
    private string __staffID__;
    private bool __testStaffID__ = false;
    private bool __isvalidStaffID__ = false;
    void OnleaveUpdate_StaffID_(object sender, TextChangedEventArgs e)
    {

        string entryValue = leaveUpdate_StaffID_.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            __staffID__ = leaveUpdate_StaffID_.Text;
            updateCheckSuccess.IsVisible = false;
            __isvalidStaffID__ = true;
            __testStaffID__ = true;
            errorLeaveUpdate_StaffID_.IsVisible = false;
            updateCheckSuccess.IsVisible = false;
            leaveUpdateMain.IsVisible = false;

        }


    }

    private int i, o, p;
    async void leaveUpdate_Submit_(object sender, EventArgs e)
    {
        leaveUpdate_Submit_Button.BackgroundColor = Colors.Teal;
        await Task.Delay(500);
        leaveUpdate_Submit_Button.BackgroundColor = Colors.DarkSlateGray;
        if (!__testStaffID__)
        {
            errorLeaveUpdate_StaffID_.Text = "This feild cannot be empty";
            errorLeaveUpdate_StaffID_.IsVisible = true;
            deAct.IsRunning = false;

        }

        if (__isvalidStaffID__)
        {
            leaveUpdate_StaffID_.Text = string.Empty;
            List<LeaveManagementDB> list = await App.LeaveRep.GetPeopleByStaffID(__staffID__);
            bool done = App.LeaveRep.done;
            updateCheckSuccess.Text = App.LeaveRep.message;
            updateCheckSuccess.IsVisible = true;
            if (done)
            {

                leaveUpdateMain.IsVisible = true;
                foreach (LeaveManagementDB emp in list)
                {
                    _leaveAddStaffID.Text = emp.staffID;

                    var dataString_ = emp.dateApplied;
                    if (!(string.IsNullOrWhiteSpace(dataString_)))
                    {
                        DateTime selectedDate;
                        if (DateTime.TryParseExact(dataString_, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedDate))
                        {
                            _leaveAddDateApplied.Date = selectedDate;
                        }
                    }
                    else
                    {
                        DateTime specificDate = new DateTime(1960, 02, 01);
                        _leaveAddDateApplied.Date = specificDate;

                    }

                    _leaveAddNameofHOD.Text = emp.nameOFHOD;
                    _leaveAddDaysRequested.Text = emp.daysRequested;

                    i = int.Parse(emp.totalLeave);
                    o = int.Parse(emp.daysRequested);
                    p = 0;
                    if (i <= o)
                    {
                        p = 0;
                    }
                    else if (1 > o)
                    {
                        p = i - o;
                    }
                    _leaveAddNumberofDayLeft.Text = p.ToString();

                    string picker = emp.typeOfLeave;
                    if (!(string.IsNullOrWhiteSpace(picker)))
                    {
                        _leaveAddTypeOfLeave.SelectedItem = picker;
                    }
                    else
                    {
                        _leaveAddTypeOfLeave.SelectedItem = null;
                    }

                    var dataString__ = emp.resumptionDate;
                    if (!(string.IsNullOrWhiteSpace(dataString__)))
                    {
                        DateTime selectedDate;
                        if (DateTime.TryParseExact(dataString__, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedDate))
                        {
                            _leaveAddResumeDate.Date = selectedDate;
                        }
                    }
                    else
                    {
                        DateTime specificDate = new DateTime(1960, 02, 01);
                        _leaveAddResumeDate.Date = specificDate;

                    }

                    _leaveAddNameofOfficer.Text = emp.takenOverOfficer;

                    var dataString___ = emp.resumptionDate;
                    if (!(string.IsNullOrWhiteSpace(dataString___)))
                    {
                        DateTime selectedDate;
                        if (DateTime.TryParseExact(dataString___, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedDate))
                        {
                            _leaveAddApprovalDate.Date = selectedDate;
                        }
                    }
                    else
                    {
                        DateTime specificDate = new DateTime(1960, 02, 01);
                        _leaveAddApprovalDate.Date = specificDate;

                    }
                    _leaveAddTotalLeaveDays.Text = emp.totalLeave;
                }

            }


        }


    }




    private bool _isvalidAddStaffID = false;
    private bool _isvalidAddDateApplied = false;
    private bool _isvalidAddNameofHOD = false;
    private bool _isvalidAddDaysRequested = false;
    private bool _isvalidAddTypeofLeave = false;
    private bool _isvalidAddResumeDate = false;
    private bool _isvalidAddOfficer = false;
    private bool _isvalidAddApprovalDate = false;
    private bool _isvalidTotalLeaveDays = false;
    private bool _isvalidNumberofDaysLeft = false;

    private string _addStaffID;
    private string _addDateApplied;
    private string _addNameOfHOD;
    private string _addDaysRequested = "0";
    private string _addTypeofLeave;
    private string _addResumeDate;
    private string _addOfficer;
    private string _addApprovalDate;
    private string _addTotalLeaveDays;
    private string _addNumberofDaysLeft;


    private bool _testAddStaffIDError = false;
    private bool _testAddDateAppliedError = false;
    private bool _testAddNameoofHODError = false;
    private bool _testAddDaysRequestedError = false;
    private bool _testAddTypeofLeaveError = false;
    private bool _testAddResumeDateError = false;
    private bool _testAddOfficerError = false;
    private bool _testAddApprovalDateError = false;
    private bool _testAddTotalLeaveDays = false;



    void _OnAddStaffIDTextChange(object sender, TextChangedEventArgs e)
    {
        string entryValue = _leaveAddStaffID.Text;

        if (!(string.IsNullOrWhiteSpace(entryValue)))
        {
            _testAddStaffIDError = true;
            _addStaffID = entryValue;
            _leaveAddStaffIDError.IsVisible = false;
            _isvalidAddStaffID = true;
            _showLeaveAddResult.IsVisible = false;

        }
        else
        {
            _testAddStaffIDError = false;
        }
    }

    void _OnAddNameofHOD(object sender, TextChangedEventArgs e)
    {
        string entryValue = _leaveAddNameofHOD.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            _addNameOfHOD = entryValue;
            _testAddNameoofHODError = true;
            _leaveAddNameofHODError.IsVisible = false;
            _isvalidAddNameofHOD = true;
            _showLeaveAddResult.IsVisible = false;

        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            _leaveAddNameofHODError.IsVisible = true;
            _leaveAddNameofHODError.Text = "This field must be letters";
            _isvalidAddNameofHOD = false;
        }
        else
        {
            _addNameOfHOD = "";
            _leaveAddNameofHODError.IsVisible = false;
            _isvalidAddNameofHOD = true;
        }
    }

    private int _a, _b, _c;

    void _OnAddDaysRequested(object sender, TextChangedEventArgs e)
    {
        string entryValue = _leaveAddDaysRequested.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsDigit))
        {
            _addDaysRequested = entryValue;
            _isvalidAddDaysRequested = true;
            _leaveAddDaysRequestedError.IsVisible = false;
            _showLeaveAddResult.IsVisible = false;

        }
        else if (!(entryValue.All(char.IsDigit)))
        {
            _leaveAddDaysRequestedError.IsVisible = true;
            _leaveAddDaysRequestedError.Text = "This field must be numbers only";
            _isvalidAddDaysRequested = false;

        }
        else
        {
            _leaveAddDaysRequestedError.IsVisible = false;
            _addDaysRequested = "0";
            _isvalidAddDaysRequested = true;
        }

        _b = int.Parse(_addDaysRequested);


    }

    void _OnAddNameofOfficer(object sender, TextChangedEventArgs e)
    {
        string entryValue = _leaveAddNameofOfficer.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsLetter))
        {
            _addOfficer = entryValue;
            _testAddOfficerError = true;
            _leaveAddNameofOfficerError.IsVisible = false;
            _isvalidAddOfficer = true;
            _showLeaveAddResult.IsVisible = false;

        }
        else if (!(entryValue.All(char.IsLetter)))
        {
            _leaveAddNameofOfficerError.IsVisible = true;
            _leaveAddNameofOfficerError.Text = "This field must be letters";
            _isvalidAddOfficer = false;
        }
        else
        {
            _addOfficer = "";
            _leaveAddNameofOfficerError.IsVisible = false;
            _isvalidAddOfficer = true;
        }
    }


    void _OnAddTotalLeaveDays(object sender, TextChangedEventArgs e)
    {
        string entryValue = _leaveAddTotalLeaveDays.Text;
        if (!(string.IsNullOrWhiteSpace(entryValue)) && entryValue.All(char.IsDigit))
        {
            _addTotalLeaveDays = entryValue;
            _isvalidTotalLeaveDays = true;
            leaveAddTotalLeaveDaysError.IsVisible = false;
            _showLeaveAddResult.IsVisible = false;
            _a = int.Parse(_addTotalLeaveDays);

        }
        else if (!(entryValue.All(char.IsDigit)))
        {
            _leaveAddTotalLeaveDaysError.IsVisible = true;
            _leaveAddTotalLeaveDaysError.Text = "This field must be numbers only";
            _isvalidTotalLeaveDays = false;
        }
        else
        {
            _leaveAddTotalLeaveDaysError.IsVisible = false;
            _isvalidTotalLeaveDays = true;
            _leaveAddNumberofDayLeft.Text = "0";
            _addNumberofDaysLeft = "0";
            _isvalidNumberofDaysLeft = false;
        }
    }

    async void __btn_leaveAdd(object sender, EventArgs e)
    {
        __btn_leaveAddButton.BackgroundColor = Colors.Teal;
        await Task.Delay(500);
        __btn_leaveAddButton.BackgroundColor = Colors.DarkSlateGray;
        if (_testAddStaffIDError == false)
        {
            _leaveAddStaffIDError.Text = "This field cannot be empty";
            _leaveAddStaffIDError.IsVisible = true;
        }

        if (_testAddNameoofHODError == false)
        {
            _leaveAddNameofHODError.IsVisible = true;
            _leaveAddNameofHODError.Text = "This field cannot be empty";
        }

        if (_testAddOfficerError == false)
        {
            _leaveAddNameofOfficerError.IsVisible = true;
            _leaveAddNameofOfficerError.Text = "This field cannot be empty";
        }

        if (_testAddDateAppliedError == false)
        {
            _leaveAddDateAppliedError.IsVisible = true;
            _leaveAddDateAppliedError.Text = "Please select a date";
        }

        if (_testAddTypeofLeaveError == false)
        {
            _leaveAddTypeofLeaveError.IsVisible = true;
            _leaveAddTypeofLeaveError.Text = "This field cannot be empty";
        }

        if (_testAddResumeDateError == false)
        {
            _leaveAddResumeDateError.IsVisible = true;
            _leaveAddResumeDateError.Text = "Please select a date";
        }

        if (_testAddApprovalDateError == false)
        {
            _leaveAddApprovalDateError.IsVisible = true;
            _leaveAddApprovalDateError.Text = "Please select a date";
        }

        if (_a < _b)
        {
            _leaveAddNumberosDaysLeftError.Text = _addStaffID + " has exceed his/her leave days availalbe";
            _leaveAddNumberosDaysLeftError.IsVisible = true;
            _isvalidNumberofDaysLeft = false;
            _c = 0;
            _leaveAddNumberofDayLeft.Text = _c.ToString();
            _addNumberofDaysLeft = _c.ToString();
        }
        else if (_a > _b)
        {
            _leaveAddNumberosDaysLeftError.IsVisible = false;
            _c = _a - _b;
            _leaveAddNumberofDayLeft.Text = _c.ToString();
            _addNumberofDaysLeft = _c.ToString();
            _isvalidNumberofDaysLeft = true;
        }
        else
        {
            _leaveAddNumberofDayLeft.Text = "0";
            _addNumberofDaysLeft = "0";
            _isvalidNumberofDaysLeft = true;
        }


        if (_isvalidAddStaffID && _isvalidAddDateApplied && _isvalidAddNameofHOD && _isvalidAddDaysRequested && _isvalidAddTypeofLeave
            && _isvalidAddResumeDate && _isvalidAddOfficer && _isvalidAddApprovalDate && _isvalidTotalLeaveDays && _isvalidNumberofDaysLeft)
        {
            // _showLeaveAddResult.Text = _addStaffID + " " + _addDateApplied + " " + _addNameOfHOD + " " + _addDaysRequested + " " + _addTypeofLeave + " " + _addResumeDate + " " + _addOfficer + " " + _addApprovalDate + " " + _addTotalLeaveDays + " " + _addNumberofDaysLeft;

            bool result = await App.LeaveRep.UpdateAddLeaveEmployee(__staffID__, _addStaffID, _addDateApplied, _addNameOfHOD, _addDaysRequested,
                 _addTypeofLeave, _addResumeDate, _addOfficer, _addApprovalDate, _addTotalLeaveDays);

            if (result)
            {
                _leaveAddStaffID.Text = string.Empty;
                DateTime specificDate = new DateTime(1960, 02, 01);
                _leaveAddDateApplied.Date = specificDate;
                _leaveAddNameofHOD.Text = string.Empty;
                _leaveAddDaysRequested.Text = string.Empty;
                _leaveAddNumberofDayLeft.Text = string.Empty;
                _leaveAddResumeDate.Date = specificDate;
                _leaveAddNameofOfficer.Text = string.Empty;
                _leaveAddApprovalDate.Date = specificDate;
                _leaveAddTotalLeaveDays.Text = string.Empty;
            }
            _showLeaveAddResult.IsVisible = true;
            _showLeaveAddResult.Text = App.LeaveRep.message;

        }





    }
    async void _btn_leaveAdd(object sender, EventArgs e)
    {

        bool result = await App.LeaveRep.UpdateAddLeaveEmployee(__staffID__, _addStaffID, _addDateApplied, _addNameOfHOD, _addDaysRequested,
             _addTypeofLeave, _addResumeDate, _addOfficer, _addApprovalDate, _addTotalLeaveDays);

        //_showLeaveAddResult.Text = App.LeaveRep.message;
    }
    void _OnDatePickerLeaveAddDateApplied(object sender, DateChangedEventArgs e)
    {
        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desireDate = new DateTime(1960, 02, 01);
        string desireDateFormat = desireDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desireDateFormat)
        {
            _testAddDateAppliedError = false;
            _isvalidAddDateApplied = false;
        }
        else
        {
            _testAddDateAppliedError = true;
            _addDateApplied = selectedDateFormat;
            _isvalidAddDateApplied = true;
            _leaveAddDateAppliedError.IsVisible = false;
            _showLeaveAddResult.IsVisible = false;

        }

    }

    void _OnDatePickerLeaveAddResumeDate(object sender, DateChangedEventArgs e)
    {
        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 02, 01);
        string desiredDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desiredDateFormat)
        {
            _testAddResumeDateError = false;
            _isvalidAddResumeDate = false;
        }
        else
        {
            _testAddResumeDateError = true;
            _addResumeDate = selectedDateFormat;
            _isvalidAddResumeDate = true;
            _leaveAddResumeDateError.IsVisible = false;
            _showLeaveAddResult.IsVisible = false;

        }

    }

    void _OnDatePickerLeaveAddApprovalDate(object sender, DateChangedEventArgs e)
    {
        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desiredDate = new DateTime(1960, 02, 01);
        string desiredDateFormat = desiredDate.ToString("dd/MM/yyyy");

        if (selectedDateFormat == desiredDateFormat)
        {
            _testAddApprovalDateError = false;
            _isvalidAddApprovalDate = false;
        }
        else
        {
            _testAddApprovalDateError = true;
            _addApprovalDate = selectedDateFormat;
            _isvalidAddApprovalDate = true;
            _leaveAddApprovalDateError.IsVisible = false;
            _showLeaveAddResult.IsVisible = false;

        }

    }

    void _OnPickerAddTypeOfLeave(object sender, EventArgs e)
    {
        string selectedValue = _leaveAddTypeOfLeave.SelectedItem as string;
        if (!(string.IsNullOrWhiteSpace(selectedValue)))
        {
            _addTypeofLeave = selectedValue;
            _testAddTypeofLeaveError = true;
            _leaveAddTypeofLeaveError.IsVisible = false;
            _isvalidAddTypeofLeave = true;
            _showLeaveAddResult.IsVisible = false;

        }

        else
        {
            _testAddTypeofLeaveError = false;
            _isvalidAddTypeofLeave = false;
        }
    }

    private string leave_delete_staffID;
    private bool test_leave_delete_staff_id = false;
    private bool isvalid_leave_delete_staff_id = false;
    void OnLeaveDeleteStaffID(object sender, TextChangedEventArgs e)
    {
        string entryValue = leave_delete_StaffID.Text;
        if (!(string.IsNullOrEmpty(entryValue)))
        {
            leave_delete_staffID = entryValue;
            test_leave_delete_staff_id = true;
            isvalid_leave_delete_staff_id = true;
            leave_delete_staffid_error.IsVisible = false;
            delete_leave_status.IsVisible = false;
        }

    }

    async void OnDeleteStaffIDSubmit(object sender, EventArgs e)
    {
        OnDeleteStaffIDSubmitButton.BackgroundColor = Colors.Teal;
        await Task.Delay(500);
        OnDeleteStaffIDSubmitButton.BackgroundColor = Colors.DarkSlateGray;
        if (test_leave_delete_staff_id == false)
        {
            leave_delete_staffid_error.Text = "This field cannot be empty";
            leave_delete_staffid_error.IsVisible = true;
        }

        if (isvalid_leave_delete_staff_id)
        {
            bool result = await App.LeaveRep.DeleteAddLeaveEmployee(leave_delete_staffID);
            delete_leave_status.Text = App.LeaveRep.message;
            delete_leave_status.IsVisible = true;

            if (result)
            {
                leave_delete_StaffID.Text = string.Empty;
            }
        }

    }


    //performance managment
    //add
    private string performancePlanning;
    private string performanceMidYear;
    private string performanceEndYear;
    private string performanceDepartmentName;
    private bool test_performancename = false;





    void OnPerformanceDepartmentNameTextChange(object sender, TextChangedEventArgs e)
    {
        performanceUpdate_status.IsVisible = false;
        error_performanceDepartname.IsVisible = false;
        string entryValue = performanceDepartname.Text;
        if (!string.IsNullOrEmpty(entryValue))
        {
            performanceDepartmentName = entryValue;
            test_performancename = true;
        }
    }
    void OnDatePickerPerformancePlanning(object sender, DateChangedEventArgs e)
    {
        performanceUpdate_status.IsVisible = false;

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desireDate = new DateTime(1960, 02, 01);
        string desireDateFormant = desireDate.ToString("dd/MM/yyyy");

        if (desireDateFormant == selectedDateFormat)
        {
            performancePlanning = "0";
        }
        else
        {
            performancePlanning = selectedDateFormat;
        }
    }

    void OnDatePickerPerformanceMidYear(object sender, DateChangedEventArgs e)
    {
        performanceUpdate_status.IsVisible = false;

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desireDate = new DateTime(1960, 02, 01);
        string desireDateFormant = desireDate.ToString("dd/MM/yyyy");

        if (desireDateFormant == selectedDateFormat)
        {
            performanceMidYear = "0";
        }
        else
        {
            performanceMidYear = selectedDateFormat;
        }
    }

    void OnDatePickerPerformanceEndYear(object sender, DateChangedEventArgs e)
    {
        performanceUpdate_status.IsVisible = false;

        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desireDate = new DateTime(1960, 02, 01);
        string desireDateFormant = desireDate.ToString("dd/MM/yyyy");

        if (desireDateFormant == selectedDateFormat)
        {
            performanceEndYear = "0";
        }
        else
        {
            performanceEndYear = selectedDateFormat;
        }
    }

    async void performance_btn(object sender, EventArgs e)
    {
        performance_btnButton.BackgroundColor = Colors.Teal;
        await Task.Delay(500);
        performance_btnButton.BackgroundColor = Colors.DarkSlateGray;
        if (!test_performancename)
        {
            System.Diagnostics.Debug.WriteLine("error");
            error_performanceDepartname.IsVisible = true;
            error_performanceDepartname.Text = "This field cannot be empty";
        }
        else
        {
            System.Diagnostics.Debug.WriteLine(performanceDepartmentName + " " + performancePlanning + " " + performanceMidYear + " " + performanceEndYear);

            await App.PerformanceRep.AddData(performanceDepartmentName, performancePlanning, performanceMidYear, performanceEndYear);
            performanceUpdate_status.Text = App.PerformanceRep.statusMessage;
            performanceUpdate_status.IsVisible = true;

            string isSuccess = App.PerformanceRep.statusMessage;
            if (isSuccess.Equals("Success"))
            {
                if (File.Exists(fullPath2))
                {
                    addRecord2(performanceDepartmentName, performancePlanning, performanceMidYear, performanceEndYear, fullPath2);
                }
            }

        }
    }

    //update

    private string _performancePlanning;
    private string _performanceMidYear;
    private string _performanceEndYear;
    private string _performanceDepartmentName;
    private bool _test_performancename = false;

    void _OnPerformanceDepartmentNameTextChange(object sender, TextChangedEventArgs e)
    {
        _error_performanceDepartname.IsVisible = false;
        performupdatebtn.IsVisible = false;
        _check_exitstPerformance.IsVisible = false;
        showPerfomanceUpdate.IsVisible = false;
        _performanceUpdate_status.IsVisible = false;
        string entryValue = _performanceDepartname.Text;
        if (!string.IsNullOrEmpty(entryValue))
        {
            _performanceDepartmentName = entryValue;
            _test_performancename = true;
        }
    }
    void _OnDatePickerPerformancePlanning(object sender, DateChangedEventArgs e)
    {
        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desireDate = new DateTime(1960, 02, 01);
        string desireDateFormant = desireDate.ToString("dd/MM/yyyy");

        if (desireDateFormant == selectedDateFormat)
        {
            _performancePlanning = "0";
        }
        else
        {
            _performancePlanning = selectedDateFormat;
        }
    }

    void _OnDatePickerPerformanceMidYear(object sender, DateChangedEventArgs e)
    {
        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desireDate = new DateTime(1960, 02, 01);
        string desireDateFormant = desireDate.ToString("dd/MM/yyyy");

        if (desireDateFormant == selectedDateFormat)
        {
            _performanceMidYear = "0";
        }
        else
        {
            _performanceMidYear = selectedDateFormat;
        }
    }

    void _OnDatePickerPerformanceEndYear(object sender, DateChangedEventArgs e)
    {
        var selectedDate = e.NewDate;
        string selectedDateFormat = selectedDate.ToString("dd/MM/yyyy");

        DateTime desireDate = new DateTime(1960, 02, 01);
        string desireDateFormant = desireDate.ToString("dd/MM/yyyy");

        if (desireDateFormant == selectedDateFormat)
        {
            _performanceEndYear = "0";
        }
        else
        {
            _performanceEndYear = selectedDateFormat;
        }
    }


    async void _performance_btn(object sender, EventArgs e)
    {

        performupdatebtn.BackgroundColor = Colors.Teal;
        await Task.Delay(500);
        performupdatebtn.BackgroundColor = Colors.DarkSlateGray;
        if (!_test_performancename)
        {
            System.Diagnostics.Debug.WriteLine("error update");
            _error_performanceDepartname.IsVisible = true;
            _error_performanceDepartname.Text = "This field cannot be empty";
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("cannn");
            System.Diagnostics.Debug.WriteLine(_performanceDepartmentName + " " + _performancePlanning + " " + _performanceMidYear + " " + _performanceEndYear);
            App.PerformanceRep.UpdateData(_performanceDepartmentName, _performanceDepartmentName, _performancePlanning, _performanceMidYear, _performanceEndYear);
            _performanceUpdate_status.IsVisible = true;
            _performanceUpdate_status.Text = App.PerformanceRep.statusMessage;
        }
    }


    async void _performanceCheckDepartment(object sender, EventArgs e)
    {
        _performanceCheckDepartmentButton.BackgroundColor = Colors.Teal;
        await Task.Delay(500);
        _performanceCheckDepartmentButton.BackgroundColor = Colors.DarkSlateGray;
        if (_test_performancename)
        {
            List<PerformanceDB> list = await App.PerformanceRep.GetPerformanceRecord(_performanceDepartmentName);
            bool done = App.PerformanceRep.done;
            _check_exitstPerformance.IsVisible = true;
            _check_exitstPerformance.Text = App.PerformanceRep.statusMessage;

            if (done)
            {
                showPerfomanceUpdate.IsVisible = true;
                performupdatebtn.IsVisible = true;
                foreach (PerformanceDB data in list)
                {
                    var dataString_ = data.planningStage;
                    if (!(string.IsNullOrWhiteSpace(dataString_)))
                    {
                        DateTime selectedDate;
                        if (DateTime.TryParseExact(dataString_, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedDate))
                        {
                            _performancePlanningStage.Date = selectedDate;
                        }
                    }
                    else
                    {
                        DateTime specificDate = new DateTime(1960, 02, 01);
                        _performancePlanningStage.Date = specificDate;

                    }

                    var dataStringa__ = data.midYear;
                    if (!(string.IsNullOrWhiteSpace(dataStringa__)))
                    {
                        DateTime selectedDate;
                        if (DateTime.TryParseExact(dataStringa__, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedDate))
                        {
                            _performanceMidYeatStage.Date = selectedDate;
                        }
                    }
                    else
                    {
                        DateTime specificDate = new DateTime(1960, 02, 01);
                        _performanceMidYeatStage.Date = specificDate;

                    }

                    var dataStringc__ = data.endYear;
                    if (!(string.IsNullOrWhiteSpace(dataStringc__)))
                    {
                        DateTime selectedDate;
                        if (DateTime.TryParseExact(dataStringc__, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedDate))
                        {
                            _performanceEndYearStage.Date = selectedDate;
                        }
                    }
                    else
                    {
                        DateTime specificDate = new DateTime(1960, 02, 01);
                        _performanceEndYearStage.Date = specificDate;

                    }
                }
            }
        }



    }
    private string performanaceValue;
    private bool test_performanceValue = false;
    void deleteperformanceTextChange(object sender, TextChangedEventArgs e)
    {
        statusdeleteperformance__.IsVisible = false;
        errordeleteperformance__.IsVisible = false;
        string entryValue = deleteperformance__.Text;
        if (!string.IsNullOrEmpty(entryValue))
        {
            performanaceValue = entryValue;
            test_performanceValue = true;
        }
    }
    async void delete_performancerecord(object sender, EventArgs e)
    {
        delete_performancerecordButton.BackgroundColor = Colors.Teal;
        await Task.Delay(500);
        delete_performancerecordButton.BackgroundColor = Colors.DarkSlateGray;
        if (test_performanceValue)
        {
            bool result = await App.PerformanceRep.DeletePerformanceData(performanaceValue);
            statusdeleteperformance__.Text = App.PerformanceRep.statusMessage;
            statusdeleteperformance__.IsVisible = true;
            System.Diagnostics.Debug.WriteLine(performanaceValue);
        }
        else
        {
            errordeleteperformance__.Text = "The field cannot be empty";
            errordeleteperformance__.IsVisible = true;
        }
    }
    //_showAllPerformanceReview


    //excel files

    //excel files
    private void addFileRecord(string Staff_ID_No, string Social_Security_No, string Payment_Mode, string Sub_Metro, string NHIS_No, string Drivers_License_No, string Voters_ID_No, string INTL_Passport_No, string Expiry_Date, string Title, string Surname,
        string First_Name, string Middle_Name, string First_Appointment_Date, string Directorate, string Department, string Unit, string Cost_Center, string Job_Class, string Job_Title, string Job_Grade, string Grade_Level,
        string Grade_Point, string Date_of_Last_Promotion, string Retirement_Date, string Name_of_Immediate_Supervisor, string Name_of_Bank, string Branch_Name_Code, string Account_Number, string Maiden_name, string Sex, string Marital_Status,
        string Place_of_Birth, string Date_of_Birth, string Home_Town, string Region, string Nationality, string Religion, string House_No, string Street_Name, string Area, string Town_City, string Residential_Region, string Postal_Address,
        string Email_Address, string Office_Phone_No, string Mobile_Cell_Phone_No, string Disable, string If_yes_Specify, string Next_of_kin_Surname, string Next_of_kin_FirstName, string Next_of_kin_Relationship, string Next_of_kin_House_No,
        string Next_of_kin_Street_Name, string Next_of_kin_Area, string Next_of_kin_City_Town, string Next_of_kin_State_Region, string Next_of_kin_Country, string Contact_Phone_No, string Title1, string Surname1, string First_Name1, string Middle_Name1, string Date_of_Birth1,
        string Relationship1, string Title2, string Surname2, string First_Name2, string Middle_Name2, string Date_of_Birth2, string Relationship2, string Title3, string Surname3, string First_Name3, string Middle_Name3,
        string Date_of_Birth3, string Relationship3, string Title4, string Surname4, string First_Name4, string Middle_Name4, string Date_of_Birth4, string Relationship4, string Title5, string Surname5, string First_Name5,
        string Middle_Name5, string Date_of_Birth5, string Relationship5, string Name_of_Institution_School, string Period_Attend_From, string Period_Attend_To, string Qualification, string Main_Course_of_Study, string Entry_Certificate,
        string Skill_Training1, string Training_Institution_Organization1, string Year_Obtained1, string Skill_Training2, string Training_Institution_Organization2, string Year_Obtained2, string Skill_Training3, string Training_Institution_Organization3,
        string Year_Obtained3, string Professional_Societies_and_Affiliations1, string Professional_Societies_and_Affiliations2, string Professional_Societies_and_Affiliations3, string Language1, string Spoken1, string Reading1, string Writing1,
        string Language2, string Spoken2, string Reading2, string Writing2, string Language3, string Spoken3, string Reading3, string Writing3, string filePath)
    {
        try
        {
            using (StreamWriter file = File.AppendText(filePath))
            {
                file.Write(Staff_ID_No + "," + Social_Security_No + "," + Payment_Mode + "," + Sub_Metro + "," + NHIS_No + "," + Drivers_License_No + "," + Voters_ID_No + "," + INTL_Passport_No + "," + Expiry_Date + "," + Title + "," + Surname
        + "," + First_Name + "," + Middle_Name + "," + First_Appointment_Date + "," + Directorate + "," + Department + "," + Unit + "," + Cost_Center + "," + Job_Class + "," + Job_Title + "," + Job_Grade + "," + Grade_Level
        + "," + Grade_Point + "," + Date_of_Last_Promotion + "," + Retirement_Date + "," + Name_of_Immediate_Supervisor + "," + Name_of_Bank + "," + Branch_Name_Code + "," + Account_Number + "," + Maiden_name + "," + Sex + "," + Marital_Status
        + "," + Place_of_Birth + "," + Date_of_Birth + "," + Home_Town + "," + Region + "," + Nationality + "," + Religion + "," + House_No + "," + Street_Name + "," + Area + "," + Town_City + "," + Residential_Region + "," + Postal_Address
        + "," + Email_Address + "," + Office_Phone_No + "," + Mobile_Cell_Phone_No + "," + Disable + "," + If_yes_Specify + "," + Next_of_kin_Surname + "," + Next_of_kin_FirstName + "," + Next_of_kin_Relationship + "," + Next_of_kin_House_No
        + "," + Next_of_kin_Street_Name + "," + Next_of_kin_Area + "," + Next_of_kin_City_Town + "," + Next_of_kin_State_Region + "," + Next_of_kin_Country + "," + Contact_Phone_No + "," + Title1 + "," + Surname1 + "," + First_Name1 + "," + Middle_Name1 + "," + Date_of_Birth1
        + "," + Relationship1 + "," + Title2 + "," + Surname2 + "," + First_Name2 + "," + Middle_Name2 + "," + Date_of_Birth2 + "," + Relationship2 + "," + Title3 + "," + Surname3 + "," + First_Name3 + "," + Middle_Name3
        + "," + Date_of_Birth3 + "," + Relationship3 + "," + Title4 + "," + Surname4 + "," + First_Name4 + "," + Middle_Name4 + "," + Date_of_Birth4 + "," + Relationship4 + "," + Title5 + "," + Surname5 + "," + First_Name5
        + "," + Middle_Name5 + "," + Date_of_Birth5 + "," + Relationship5 + "," + Name_of_Institution_School + "," + Period_Attend_From + "," + Period_Attend_To + "," + Qualification + "," + Main_Course_of_Study + "," + Entry_Certificate
        + "," + Skill_Training1 + "," + Training_Institution_Organization1 + "," + Year_Obtained1 + "," + Skill_Training2 + "," + Training_Institution_Organization2 + "," + Year_Obtained2 + "," + Skill_Training3 + "," + Training_Institution_Organization3
        + "," + Year_Obtained3 + "," + Professional_Societies_and_Affiliations1 + "," + Professional_Societies_and_Affiliations2 + "," + Professional_Societies_and_Affiliations3 + "," + Language1 + "," + Spoken1 + "," + Reading1 + "," + Writing1
        + "," + Language2 + "," + Spoken2 + "," + Reading2 + "," + Writing2 + "," + Language3 + "," + Spoken3 + "," + Reading3 + "," + Writing3 + "\n");
            }
        }
        catch (Exception e)
        {
            string error = $"Error was found!: {e.Message}";
        }

    }

    private void searchMatch()
    {
        Textwork.Text = "hello3";
        int positionSearch = 0;

        try
        {
            string[] lines = File.ReadAllLines(fullPath);
            Textwork.Text = lines[1].ToString();
            for(int i = 0; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(",");

                if (recordMatch("STAFFF", fields, positionSearch)){
                    Textwork.Text = string.Join(", ", fields);
                    break;
                }
            }

           
        }catch(Exception e)
        {
            Textwork.Text = "ID does not exist " + e.Message;
        }
    }

    private bool recordMatch(string searchTerm, string[] record, int positionOfSearchTerm)
    {
        return record.Length > positionOfSearchTerm && record[positionOfSearchTerm].Equals(searchTerm);

    }
    private void addRecord1(string staffID, string typeOfLeave, string dateApplied, string dateOfResumption,
        string approvalDate, string nameOfHOD, string officer, string requestedDays, string totalLeave, string filePath)
    {
        try
        {
            int a = int.Parse(totalLeave);
            int b = int.Parse(requestedDays);
            int c = a - b;
            string d = c.ToString();
            using (StreamWriter file = File.AppendText(filePath))
            {
                file.Write(staffID + "," + typeOfLeave + "," + dateApplied + "," + dateOfResumption + "," + approvalDate + "," + nameOfHOD
                    + "," + officer + "," + requestedDays + "," + d + "," + totalLeave + "\n");
            }
        }
        catch (Exception e)
        {
            System.Diagnostics.Debug.WriteLine($"Error was found: {e.Message}");
        }
    }

    private void addRecord2(string department, string planningStage, string midYear, string endYear, string filePath)
    {
        try
        {
            using (StreamWriter file = File.AppendText(filePath))
            {
                file.Write(department + "," + planningStage + "," + midYear + "," + endYear + "\n");
            }
        }
        catch (Exception e)
        {
            System.Diagnostics.Debug.WriteLine($"Error was found: {e.Message}");
        }
    }

}
