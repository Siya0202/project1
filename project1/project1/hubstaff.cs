using Newtonsoft.Json.Linq;
using System.Collection.Generic;

namespace hubstaff
{
    public class client
    {
        public string app_token="";
        public string auth_token="";
         public client(string app_token)
        {
            this.app_token = app_token;
        }
        public string get_auth_token()
        {
            return this.auth_token;   
        }
        public void set_auth_token(string auth_token)
        {
            this.auth_token = auth_token;
        }
        public string get_app_token()
        {
            return this.app_token;
        }

        private config.config_class config = new config.config_class();

        public Dictionary<string, string> auth(string email,string password)
        {
            Dictionary<string, string> returned_data = new Dictionary<string, string>();

            auth_space.authClass _auth = new auth_space.authClass();
            string auth = get_auth_token();

            var data = _auth.gen_auth(this.app_token, email, password, config.base_url + config.auth_url, 1).Result;
            JObject auth_token_json;
            if(data == "fail"){
                returned_data["error"] =  "Error occured";
                returned_data["auth_token"] =  null;
                return returned_data;
            }else
            {
                auth_token_json = JObject.Parse(data);
            }
            if(auth_token_json["error"] != null){
                returned_data["error"] = auth_token_json["error"].ToString();
                return returned_data;
            }else
            {
                returned_data["auth_token"] = auth_token_json["user"]["auth_token"].ToString();
                set_auth_token(returned_data["auth_token"]);
            }

            returned_data["error"] =  "";
           
            return returned_data;
        }
        public JObject users(int organization_memberships = 1, int project_memberships = 1,int offset = 0)
        {
            user_space.userClass _users = new user_space.userClass();
            return JObject.Parse(_users.get_users(get_app_token(), get_auth_token(), organization_memberships, project_memberships,offset, config.base_url + config.users).Result);
        }
        public JObject find_user(int id)
        {
            
            user_space.userClass _users = new user_space.userClass();
            return JObject.Parse(_users.find_user(get_app_token(), get_auth_token(), config.base_url + string.Format(config.find_user, id)).Result);
        }
        public JObject find_user_orgs(int id,int offset = 0)
        {
            user_space.userClass _users = new user_space.userClass();
            return JObject.Parse(_users.find_user_orgs(get_app_token(), get_auth_token(),offset,config.base_url + string.Format(config.find_user_org, id)).Result);
        }
        public JObject find_user_projects(int id, int offset = 0)
        {
            user_space.userClass _users = new user_space.userClass();
            return JObject.Parse(_users.find_user_projects(get_app_token(), get_auth_token(),offset,config.base_url + string.Format(config.find_user_projects, id)).Result);
        }

        public JObject organizations(int offset = 0)
        {
            orgs_space.orgsClass _org = new orgs_space.orgsClass();
            return JObject.Parse(_org.get_organizations(get_app_token(), get_auth_token(), offset, config.base_url + config.orgs).Result);
        }

        public JObject find_organization(int id)
        {
            orgs_space.orgsClass _org = new orgs_space.orgsClass();
            return JObject.Parse(_org.find_organization(get_app_token(), get_auth_token(), config.base_url + string.Format(config.find_org, id)).Result);
        }
        public JObject find_org_projects(int id,int offset = 0)
        {
            orgs_space.orgsClass _org = new orgs_space.orgsClass();
            return JObject.Parse(_org.find_org_projects(get_app_token(), get_auth_token(),offset,config.base_url + string.Format(config.find_org_proj, id)).Result);
        }
        public JObject find_org_members(int id, int offset = 0)
        {
            orgs_space.orgsClass _org = new orgs_space.orgsClass();
            return JObject.Parse(_org.find_org_members(get_app_token(), get_auth_token(),offset,config.base_url + string.Format(config.find_org_members, id)).Result);
        }
    }
}