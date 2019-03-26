
using System;
using System.Collections.Generic;
using System.Web;


public class PRMS
{

    public bool GetUser(User LoginUser)
    {
        bool Confirmation;
        User ReturnUser = new User();
        Users Get = new Users();
        Confirmation = Get.GetUser(LoginUser);
        return Confirmation;

    }
    public Boolean AddUser(User NewUser)
    {
        bool confirmation;
        Users Add = new Users();
        confirmation = Add.AddUser(NewUser);
        return confirmation;
    }


    public String GetRoles(User LoginUser)
    {
        Users Roles = new Users();
        return Roles.GetRoles(LoginUser);
    }

    public bool UploadResume(string resume)
    {
        bool confirmation = false;

        Users userManager = new Users();
        confirmation = userManager.UploadResume(resume);

        return confirmation;
    }

    public bool AddCandidate(User newCandidate)
    {
        bool confirmation = false;

        Users userManager = new Users();
        confirmation = userManager.AddCandidate(newCandidate);

        return confirmation;
    }

    public bool AddAccount(User newCandidate)
    {
        bool confirmation = false;

        Users userManager = new Users();
        confirmation = userManager.AddAccount(newCandidate);

        return confirmation;
    }

    public bool AddUserProfessions(int userID, int professionID)
    {
        bool confirmation = false;

        Professions professionManager = new Professions();
        confirmation = professionManager.AddUserProfession(userID, professionID);

        return confirmation;
    }

    public bool AddUserSkills(int userID, int skillID)
    {
        bool confirmation = false;

        Skillsets skillsetsManager = new Skillsets();
        confirmation = skillsetsManager.AddUserSkill(userID, skillID);

        return confirmation;
    }

    public bool AddUserRegions(int userID, int regionID)
    {
        bool confirmation = false;

        Regions regionsManager = new Regions();
        confirmation = regionsManager.AddUserRegion(userID, regionID);

        return confirmation;
    }

    public int GetUserIDByEmail(string email)
    {
        int userID;

        Users userManager = new Users();
        userID = userManager.GetUserIDByEmail(email);

        return userID;
    }

    public Profession[] GetProfessions()
    {
        Profession[] professions;

        Professions professionManager = new Professions();
        professions = professionManager.GetProfessions();

        return professions;
    }

    public Skillset[] GetSkillsets()
    {
        Skillset[] skillsets;

        Skillsets skillsetManager = new Skillsets();
        skillsets = skillsetManager.GetSkillsets();

        return skillsets;
    }

    public Region[] GetRegions()
    {
        Region[] regions;

        Regions regionManager = new Regions();
        regions = regionManager.GetRegions();

        return regions;
    }

    public List<JobPosting> GetAllJobPostings()
    {
        List<JobPosting> jobPostingsList = new List<JobPosting>();

        JobPostings jobPostingManager = new JobPostings();
        jobPostingsList = jobPostingManager.GetAllJobPostings();

        return jobPostingsList;
    }

    public List<User> GetQualifiedCandidates(int jobPostingID)
    {
        List<User> candidateList = new List<User>();

        Administrators administrationManager = new Administrators();
        candidateList = administrationManager.GetQualifiedCandidates(jobPostingID);

        return candidateList;
    }

    public bool AssignCandidateToJobPosting(int userid, int jobpostingid, string date)
    {
        bool confirmation = false;

        Administrators administrationManager = new Administrators();
        confirmation = administrationManager.AddCandidateToJobPosting(userid, jobpostingid, date);

        return confirmation;
    }

    public bool AddRegion(string description)
    {
        bool confirmation = false;

        Regions regionManager = new Regions();
        confirmation = regionManager.AddRegion(description);

        return confirmation;
    }

    public bool AddProfession(string professiondescription)
    {
        bool confirmation = false;

        Professions professionManager = new Professions();
        confirmation = professionManager.AddProfession(professiondescription);

        return confirmation;

    }

    public JobPosting GetJobPosting(int JobPostingID)
    {
        JobPostings JobPostingManager = new JobPostings();
        return JobPostingManager.GetJobPosting(JobPostingID);
    }

    public bool AddSkillSet(string SkillSetDescription, int ProfessionID)
    {
        bool confirmation = false;

        Skillsets skillsetsManager = new Skillsets();
        confirmation = skillsetsManager.AddSkillSet(SkillSetDescription, ProfessionID);

        return confirmation;
    }


    /*<<<<<<< HEAD*/
    public bool UpdateProfession(string UpdatedProfessionDescription, int ProfessionID)
    {
        bool confirmation = false;

        Professions professionManager = new Professions();
        confirmation = professionManager.UpdateProfession(UpdatedProfessionDescription, ProfessionID);

        return confirmation;
    }

    public bool UpdateRegion(string UpdatedRegionDescription, int RegionID)
    {
        bool confirmation = false;

        Regions RegionManager = new Regions();
        confirmation = RegionManager.UpdateRegion(UpdatedRegionDescription, RegionID);

        return confirmation;
    }

    public bool UpdateSkillSet(string UpdatedSkillSetDescription, int skillsetid, int ProfessionID)
    {
        bool confirmation = false;

        Skillsets skillsetManager = new Skillsets();
        confirmation = skillsetManager.UpdateSkillSet(UpdatedSkillSetDescription, skillsetid, ProfessionID);

        return confirmation;
    }
    /*=======
    >>>>>>> 7157f084cd2c4ada7d90d505dd940b818ce2ed9e*/
    public bool AddJobSkillSets(int jobID, int skill)
    {
        bool confirmation = false;

        Skillsets skillsetsManager = new Skillsets();
        confirmation = skillsetsManager.AddJobSkill(jobID, skill);

        return confirmation;
    }

    public int AddJobPosting(JobPosting job)
    {
        JobPostings jobPostingManager = new JobPostings();
        return jobPostingManager.AddJobPosting(job);
    }
    public List<User> GetAssignedCandidates(int jobPostingID)
    {
        List<User> candidateList = new List<User>();

        Administrators administrationManager = new Administrators();
        candidateList = administrationManager.GetAssignedCandidates(jobPostingID);

        return candidateList;

    }
    public bool ChangeStatus(int UserID, int JobpostingID, string Status, string Date)
    {
        Administrators administrationManager = new Administrators();
        return administrationManager.UpdateCandidateJobStatus(UserID, JobpostingID, Status, Date);
        /*<<<<<<< HEAD

        =======
        >>>>>>> 7157f084cd2c4ada7d90d505dd940b818ce2ed9e*/
    }
}