using System;
using System.IO;

namespace config
{
    class config_class
    {
        public string root_folder = Directory.GetCurrentDirectory()+"/";
        public config_class()
        {
            if(Path.GetFileName(Directory.GetCurrentDirectory()) != "hubstaff")
            {
                root_folder =  Directory.GetCurrentDirectory()+"/hubstaff/";
            }
            Environment.SetEnvironmentVariable("app_token","pHR18-G-9c05NoyBtji3a8A2KsFKOuZcSZK4gT5V9vc");
            Environment.SetEnvironmentVariable("auth_token","5WZ1SCto37HBhH-AR1jn0kC3FXROO4b39CREMSyt_1U");
        }
        
        public string base_url = "https://api.hubstaff.com/v1/";
        public string auth_url = "auth";
        public string users = "users";
        public string find_user = "users/{0}";
        public string find_user_org = "users/{0}/organizations";
        public string find_user_projects = "users/{0}/projects";
        
        public string orgs = "organizations";
        public string find_org = "organizations/{0}";
        public string find_org_proj = "organizations/{0}/projects";
        public string find_org_members = "organizations/{0}/members";

        public string proj = "projects";
        public string find_proj = "projects/{0}";
        public string find_proj_members = "projects/{0}/members";
        public string activities = "activities";
        public string screenshots = "screenshots";
    }
}