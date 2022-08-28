using System;
using System.Collection.Generic;
Using System.Net.Http;
Using System.Threading.Tasks;

namespace connection 
{
     class connection_class
    {
		public async Task<string> make_connection(Dictionary<string, string>  fields,Dictionary<string, string> parameters,String url,int type = 0)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                
                var post = new Dictionary<string, string>();
                string get_string = "?";
                foreach(KeyValuePair<string, string> entry in fields)
                {
                    if(parameters[entry.Key] == "header")
                    {
                        client.DefaultRequestHeaders.Add(entry.Key,entry.Value);
                    }else
                    {
                        if(type == 1)
                            post[entry.Key] = entry.Value;
                        else
                            get_string += entry.Key+"="+entry.Value+"&";
                    }

                }
                HttpResponseMessage response;
                get_string = get_string.Remove(get_string.Length - 1);
				if(type == 0)
                {
                    response = await client.GetAsync(url+get_string);
                }else
                {
                    response = await client.PostAsync(url, new FormUrlEncodedContent(post));
                }
                if(response.StatusCode.ToString() == "NotFound")
                {
                    return "{'error':'Record not found'}";
                }
                if (response.IsSuccessStatusCode)
                {
					return await response.Content.ReadAsStringAsync();
                }
                
            }
			return "{'error':'Couldn't connect to server'}";
		
        }
    }
}