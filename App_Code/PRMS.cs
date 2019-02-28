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

}