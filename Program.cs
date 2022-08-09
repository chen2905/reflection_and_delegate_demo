using reflection_and_delegate_demo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace reflection_and_delegate_demo1
    {
    class Program
        {
        static void Main(string[] args)
            {
            var homeController = new HomeController();
            var homeControllerType = homeController.GetType();
            var property = homeControllerType.GetProperties()
                .FirstOrDefault(pr=>pr.IsDefined(typeof(DataAttribute),true));


            var getMethod = property.GetMethod;

            var stopWatch = Stopwatch.StartNew();
            for (int i = 0; i < 10000; i++)
                {
                var dict = (IDictionary<string, object>)getMethod.Invoke(homeController, Array.Empty<object>());
                Console.WriteLine("after invoke constructor: " + dict["Name"].ToString());
                }

            //Console.WriteLine("homeControllerType: " + homeControllerType.ToString());
            //Console.WriteLine("homeControllerType property: " + property.ToString());

            Console.WriteLine("time used:" + stopWatch.Elapsed);


            var deleg = getMethod.CreateDelegate(typeof(Func<HomeController, IDictionary<string, object>>));


            Console.ReadLine();

         

            }
        }
    }
