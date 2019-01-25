using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnCampusRecruitment.Models
{
    public enum SchoolDegree
    {
        [Display(Name = "Matric(Science)")]
        MatricScience,
        [Display(Name = "Matric(Arts)")]
        MatricArts,
        [Display(Name = "O-Level")]
        Olevel
    }
    public enum CollegeDegree
    {
        [Display(Name = "F.Sc(Pre-Engineering)")]
        FScEngineering,
        [Display(Name = "F.Sc(Pre-Medical)")]
        FScMedical,
        [Display(Name = "I.Com")]
        ICom,
        [Display(Name = "ICS")]
        ICS,
        [Display(Name = "A-Level")]
        Alevel
    }
    public enum JobType
    {
        [Display(Name = "Full Time/Permanent(First Shift (Day))")]
        Permanent_First_Shift,
        [Display(Name = "Full Time/Permanent(Second Shift(Afternoon))")]
        Permanent_Second_Shift,
        [Display(Name = "Full Time/Permanent(Third Shift (Night))")]
        Permanent_Third_Shift,
        [Display(Name = "Full Time/Permanent(Rotating)")]
        Permanent_Rotating,
        [Display(Name = "Part Time(First Shift (Morning))")]
        Part_Time_First_Shift,
        [Display(Name = "Part Time(Second Shift (Afternoon))")]
        Part_Time_Second_Shift,
        [Display(Name = "Part Time(Third Shift (Night))")]
        Part_Time_Third_Shift,
        [Display(Name = "Part Time(Rotating)")]
        Part_Time_Rotating
    }
    public enum Age
    {
        [Display(Name = "More than 18")]
        More_Then_18,
        [Display(Name = "20-25")]
        Between_20_To_25,
        [Display(Name = "25-30")]
        Between_25_To_30,
        [Display(Name = "30-35")]
        Between_30_To_35,
        [Display(Name = "35-40")]
        Between_35_To_40,
        [Display(Name = "40-45")]
        Between_40_To_45,
        [Display(Name = "45-50")]
        Between_45_To_50,
        [Display(Name = "50-55")]
        Between_50_To_55,
        [Display(Name = "55-60")]
        Between_55_To_60,
        [Display(Name = "60+")]
        More_Then_60
    }
    public enum MinimumEducation
    {
        [Display(Name = "Certificate")]
        Certificate,
        [Display(Name = "Matric/O-Level")]
        SSC,
        [Display(Name = "Intermediate/A-Level")]
        Inter,
        [Display(Name = "Bachelor's Degree")]
        Bachelor,
        [Display(Name = "Master's Degree")]
        Master,
        [Display(Name = "M.Phil/Ph.D")]
        PhD
    }
    public enum DegreeTitle
    {
        [Display(Name = "Botany")]
        Botany,
        [Display(Name = "Biotechnology")]
        Biotechnology,
        [Display(Name = "Chemistry")]
        Chemistry,
        [Display(Name = "Computer Science")]
        Computer_Science,
        [Display(Name = "Environmental Science")]
        Environmental_Science,
        [Display(Name = "Mathematics")]
        Mathematics,
        [Display(Name = "Microbiology")]
        Microbiology,
        [Display(Name = "Physics")]
        Physics,
        [Display(Name = "Zoology")]
        Zoology,
        [Display(Name = "Economics")]
        Economics,
        [Display(Name = "Education")]
        Education,
        [Display(Name = "Fine Arts")]
        Fine_Arts,
        [Display(Name = "Geography")]
        Geography,
        [Display(Name = "Law")]
        Law,
        [Display(Name = "Mass Communications")]
        Mass_Communications,
        [Display(Name = "Management Studies")]
        Management_Studies,
        [Display(Name = "Philosophy & IDC")]
        Philosophy_IDC,
        [Display(Name = "Physical Education")]
        Physical_Education,
        [Display(Name = "Political Science")]
        Political_Science,
        [Display(Name = "Psychology")]
        Psychology,
        [Display(Name = "Sociology")]
        Sociology,
        [Display(Name = "Statistics")]
        Statistics,
        [Display(Name = "English")]
        English,
        [Display(Name = "French*")]
        French,
        [Display(Name = "Islamic Studies")]
        Islamic_Studies,       
        [Display(Name = "Persian")]
        Persian,
        [Display(Name = "Punjabi")]
        Punjabi,
        [Display(Name = "Urdu")]
        Urdu,
        [Display(Name = "Electrical Engineering")]
        Electrical_Engineering
    }
    public enum GenderSelect
    {
        Male, Female, [Display(Name = "Doesn't Matter")]
        Both
    }
    public enum OwnershipType
    {
        [Display(Name = "Sole Proprietorship")]
        SoleProprietorship,
        Public,
        Private,
        NGO
    }
    public enum Gender
    {
        Male, Female
    }
    public enum University
    {
        [Display(Name = "Govt. College University Lahore")]
        GCU
    }
    public enum LastUsed
    {
        [Display(Name = "Currently Using")]
        Using,
        [Display(Name = "1 Year Ago")]
        Year1,
        [Display(Name = "2 Years Ago")]
        Year2,
        [Display(Name = "3 Years Ago")]
        Year3,
        [Display(Name = "4 Years Ago")]
        Year4,
        [Display(Name = "5 Years Ago")]
        Year5,
        [Display(Name = "6 Years Ago")]
        Year6,
        [Display(Name = "7 Years Ago")]
        Year7,
        [Display(Name = "8 Years Ago")]
        Year8,
        [Display(Name = "9 Years Ago")]
        Year9,
        [Display(Name = "More than 10 Years Ago")]
        Year10
    }
    public enum Usage
    {
        [Display(Name = "Class Project")]
        ClassProject,
        [Display(Name = "Internship")]
        Internship,
        [Display(Name = "Job")]
        Job,
        [Display(Name = "General")]
        General
    }
    public enum YearExperience
    {
        [Display(Name = "Fresh")]
        Year00,
        [Display(Name = "Less Than 1 Year")]
        Year01,
        [Display(Name = "1 Year")]
        Year1,
        [Display(Name = "2 Year")]
        Year2,
        [Display(Name = "3 Year")]
        Year3,
        [Display(Name = "4 Year")]
        Year4,
        [Display(Name = "5 Year")]
        Year5,
        [Display(Name = "6 Year")]
        Year6,
        [Display(Name = "7 Year")]
        Year7,
        [Display(Name = "8 Year")]
        Year8,
        [Display(Name = "9 Year")]
        Year9,
        [Display(Name = "10 Year")]
        Year10,
        [Display(Name = "11 Year")]
        Year11,
        [Display(Name = "12 Year")]
        Year12,
        [Display(Name = "13 Year")]
        Year13,
        [Display(Name = "14 Year")]
        Year14,
        [Display(Name = "15 Year")]
        Year15,
        [Display(Name = "16 Year")]
        Year16,
        [Display(Name = "17 Year")]
        Year17,
        [Display(Name = "18 Year")]
        Year18,
        [Display(Name = "19 Year")]
        Year19,
        [Display(Name = "20 Year")]
        Year20,
        [Display(Name = "21 Year")]
        Year21,
        [Display(Name = "22 Year")]
        Year22,
        [Display(Name = "23 Year")]
        Year23,
        [Display(Name = "24 Year")]
        Year24,
        [Display(Name = "25 Year")]
        Year25,
        [Display(Name = "26 Year")]
        Year26,
        [Display(Name = "27 Year")]
        Year27,
        [Display(Name = "28 Year")]
        Year28,
        [Display(Name = "29 Year")]
        Year29,
        [Display(Name = "30 Year")]
        Year30,
        [Display(Name = "31 Year")]
        Year31,
        [Display(Name = "32 Year")]
        Year32,
        [Display(Name = "33 Year")]
        Year33,
        [Display(Name = "34 Year")]
        Year34,
        [Display(Name = "35 Year")]
        Year35,
        [Display(Name = "More Than 35 Years")]
        Year36,
    }
    public enum ExperienceYears
    {
        [Display(Name = "Fresh")]
        Year00,
        [Display(Name = "Less Than 1 Year")]
        Year01,
        [Display(Name = "1 Year")]
        Year1,
        [Display(Name = "2 Year")]
        Year2,
        [Display(Name = "3 Year")]
        Year3,
        [Display(Name = "4 Year")]
        Year4,
        [Display(Name = "5 Year")]
        Year5,
        [Display(Name = "6 Year")]
        Year6,
        [Display(Name = "7 Year")]
        Year7,
        [Display(Name = "8 Year")]
        Year8,
        [Display(Name = "9 Year")]
        Year9,
        [Display(Name = "10 Year")]
        Year10,
        [Display(Name = "11 Year")]
        Year11,
        [Display(Name = "12 Year")]
        Year12,
        [Display(Name = "13 Year")]
        Year13,
        [Display(Name = "14 Year")]
        Year14,
        [Display(Name = "15 Year")]
        Year15,
        [Display(Name = "16 Year")]
        Year16,
        [Display(Name = "17 Year")]
        Year17,
        [Display(Name = "18 Year")]
        Year18,
        [Display(Name = "19 Year")]
        Year19,
        [Display(Name = "20 Year")]
        Year20,
        [Display(Name = "21 Year")]
        Year21,
        [Display(Name = "22 Year")]
        Year22,
        [Display(Name = "23 Year")]
        Year23,
        [Display(Name = "24 Year")]
        Year24,
        [Display(Name = "25 Year")]
        Year25,
        [Display(Name = "26 Year")]
        Year26,
        [Display(Name = "27 Year")]
        Year27,
        [Display(Name = "28 Year")]
        Year28,
        [Display(Name = "29 Year")]
        Year29,
        [Display(Name = "30 Year")]
        Year30,
        [Display(Name = "31 Year")]
        Year31,
        [Display(Name = "32 Year")]
        Year32,
        [Display(Name = "33 Year")]
        Year33,
        [Display(Name = "34 Year")]
        Year34,
        [Display(Name = "35 Year")]
        Year35,
        [Display(Name = "More Than 35 Years")]
        Year36,
    }
    public enum CareerLevel
    {
        [Display(Name = "Entry Level")]
        Level1,
        [Display(Name = "Experienced Professional")]
        Level2,
        [Display(Name = "Department Head")]
        Level3,
        [Display(Name = "GM / CEO / Country Head / President")]
        Level4
    }
    public enum ExperienceType
    {
        Job,
        Internship
    }
    public enum FunctionArea
    {
        [Display(Name = "Accounting & Finance")]
        Accounting,
        [Display(Name = "Graphics & UI Design")]
        Designing,
        [Display(Name = "Product & Project Management")]
        Product_Management,
        [Display(Name = "Call Center & BPO")]
        Call_Center,
        [Display(Name = "Healthcare & Medicine")]
        Healthcare,
        [Display(Name = "Production & Manufacturing")]
        Manufacturing,
        [Display(Name = "Content Writer")]
        Content_Writer,
        [Display(Name = "Human Resources")]
        HR,
        [Display(Name = "Sales & Marketing")]
        Sales,
        [Display(Name = "Education & Academia")]
        Education,
        [Display(Name = "Software & Web Development")]
        IT,
        [Display(Name = "Social & Development Sector")]
        Social_Sector,
        [Display(Name = "Engineering")]
        Engineering,
        [Display(Name = "Office Management & Administration")]
        Administration
    }
    public enum Industry
    {
        [Display(Name = "Textiles/Garments")]
        Textiles,
        [Display(Name = "N.G.O./Social Services")]
        NGO,
        [Display(Name = "Food & Beverages")]
        Food,
        [Display(Name = "Manufacturing")]
        Manufacturing,
        [Display(Name = "Real Estate/Property")]
        Real_Estate,
        [Display(Name = "Information Technology")]
        IT,
        [Display(Name = "Education/Training")]
        Education,
        [Display(Name = "Engineering")]
        Engineering,
        [Display(Name = "Charity Organization")]
        Charity_Organization,
        [Display(Name = "Fast Moving Consumer Goods (FMCG)")]
        FMCG,
        [Display(Name = "Retail")]
        Retail,
        [Display(Name = "Healthcare/Hospital/Medical")]
        Health,
        [Display(Name = "Construction/Cement/Metals")]
        Construction,
        [Display(Name = "Services")]
        Services,
        [Display(Name = "Shipping/Marine")]
        Shipping,
        [Display(Name = "Travel/Tourism/Transportation")]
        Travel,
        [Display(Name = "AutoMobile")]
        AutoMobile,
        [Display(Name = "Advertising/PR")]
        Advertising,
        [Display(Name = "Banking/Financial Services")]
        Banking        
    }
    public enum City
    {
        [Display(Name = "Lahore")]
        Lahore,
        [Display(Name = "Faisalabad")]
        Faisalabad,
        [Display(Name = "Gujranwala")]
        Gujranwala,
        [Display(Name = "Dera Ismail Khan")]
        DIK,
        [Display(Name = "Gujrat")]
        Gujrat,
        [Display(Name = "Hafizabad")]
        Hafizabad,
        [Display(Name = "Haroonabad")]
        Haroonabad,
        [Display(Name = "Chakwal")]
        Chakwal,
        [Display(Name = "Bahawalpur")]
        Bahawalpur,
        [Display(Name = "Bahawalnagar")]
        Bahawalnagar,
        [Display(Name = "Wah Cantt")]
        Wah_Cantt,
        [Display(Name = "Rawalpindi")]
        Rawalpindi,
        [Display(Name = "Sargodha")]
        Sargodha,
        [Display(Name = "Vehari")]
        Vehari,
        [Display(Name = "Quetta")]
        Quetta,
        [Display(Name = "Muzaffargarh")]
        Muzaffargarh,
        [Display(Name = "Karachi")]
        Karachi,
        [Display(Name = "Kasur")]
        Kasur,
        [Display(Name = "Jhang")]
        Jhang,
        [Display(Name = "Islamabad")]
        Islamabad,
        [Display(Name = "Hyderabad")]
        Hyderabad,
        [Display(Name = "Okara")]
        OKARA,
        [Display(Name = "Haripur")]
        Haripur,
        [Display(Name = "Peshawar")]
        PESHAWAR,
        [Display(Name = "Muzaffargarh")]
        MUZAFFARGARH,
        [Display(Name = "Sargodha")]
        SARGODHA,
        [Display(Name = "Rahim Yar Khan")]
        RAHIMYAR,
        [Display(Name = "Multan")]
        MULTAN,
        [Display(Name = "Abbottabad")]
        ABBOTTABAD,
        [Display(Name = "Chakwal")]
        CHAKWAL,        
        [Display(Name = "Dera Ghazi Khan")]
        DG_KHAN,
        [Display(Name = "Chitral")]
        CHITRAL,
        [Display(Name = "Gujar Khan")]
        GUJAR_KHAN,
        [Display(Name = "Hafiz Abad")]
        Hafiz_Abad       
    }
}