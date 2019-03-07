
using System;
using System.Collections.Generic;
using System.Web;


public class PRMS
{

    public bool GetUser(User LoginUser)
    {
        bool Confirmation;
        User ReturnUser = new User();
        Manager Get = new Manager();
        Confirmation = Get.GetUser(LoginUser);
        return Confirmation;

    }
    public Boolean AddUser(User NewUser)
    {
        bool confirmation;
        Manager Add = new Manager();
        confirmation = Add.AddUser(NewUser);
        return confirmation;
    }
    public String GetRoles(User LoginUser)
    {
        Manager Roles = new Manager();
        return Roles.GetRoles(LoginUser);
    }

    public bool UploadResume(string resume)
    {
        bool confirmation = false;

        Manager userManager = new Manager();
        confirmation = userManager.UploadResume(resume);

        return confirmation;
    }

    public bool AddCandidate (User newCandidate)
    {
        bool confirmation = false;

        Manager userManager = new Manager();
        confirmation = userManager.AddCandidate(newCandidate);

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

    public int GetUserIDByEmail (string email)
    {
        int userID;

        Manager userManager = new Manager();
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

    public bool AssignCandidateToJobPosting(int userid, int jobpostingid)
    {
        bool confirmation = false;

        Administrators administrationManager = new Administrators();
        confirmation = administrationManager.AddCandidateToJobPosting(userid, jobpostingid);

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

    /* public bool AddSkillSet(string SkillsetDescription, int ProfessionId)
     {
         bool confirmation = false;

         AdministratorManager administratorManager = new AdministratorManager();
         confirmation = administratorManager.AddSkillSet(SkillsetDescription,ProfessionId);

         return confirmation;
     }*/

    public bool AddSkillSet(string SkillsetDescription, string ProfessionId)
    {
        bool confirmation = false;

        Skillsets skillsetsManager = new Skillsets();
        confirmation = skillsetsManager.AddSkillSet(SkillsetDescription, ProfessionId);

        return confirmation;
    }
}