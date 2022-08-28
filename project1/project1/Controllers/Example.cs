using System.Collection.Generic;

namespace project1.Controllers;

[ApiController]
[Route("[controller]")]
{
    public class Example: ControllerBase
    {
        public hubstaff.client hubstaff_api = new hubstaff.client("pHR18-G-9c05NoyBtji3a8A2KsFKOuZcSZK4gT5V9vc");
        public string auth(string email, string password)
        {
            hubstaff_api.auth(email,password);
            string token = hubstaff_api.get_auth_token();
            System.Console.WriteLine("Your authatication token is: "+token);
            return token;
        }
        public void screenshots(string start_time, string stop_time,int offset, Dictionary<string, string> options, string auth_token)
        {

            hubstaff_api.set_auth_token(auth_token);
            var screenshots_data = hubstaff_api.screehshots(start_time, stop_time, options, offset);
            
            foreach(var screenshot in screenshots_data["screenshots"])
            {
               System.Console.WriteLine("Image returned: "+screenshot["url"]);
            }
        }

    }
}