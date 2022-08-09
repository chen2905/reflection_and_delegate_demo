using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace reflection_and_delegate_demo
    {
  public  class HomeController 
        {

        public HomeController()
            {
            this.Data = new Dictionary<string, object>
                {
                ["Name"] = "reflection and delegate demo project"
                };
            }

        [Data]
        public IDictionary<string,object> Data { get; set; }

        }

    }
