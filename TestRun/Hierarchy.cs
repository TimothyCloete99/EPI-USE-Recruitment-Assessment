using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestRun
{
    /// <summary>
    /// The hierarchy class contains the view Hierarchy method which would be called by the main program
    /// </summary>
    class Hierarchy
    {
        /// <summary>
        /// ViewHierarchy method prints the system_data.json file in a hierarchy format.
        /// </summary>
        public void ViewHierarchy()
        { 
            StreamReader r = new StreamReader(@"F:\EPI-USE Labs Recruiting Exercise 2020\Testing\TestRun\system_data.json");
            string json = r.ReadToEnd();
            Root data_root = JsonConvert.DeserializeObject<Root>(json);  //Declaring the root from System_data class using Json convert Deserialing the object with the json path 

            //Declaring each list from the System_data class to access each section of the json file 
            List<Area> AllAreas = data_root.system_data.areas;  
            List<Door> AreaDoors = data_root.system_data.doors;
            List<AccessRule> AccessRules = data_root.system_data.access_rules;



            Area area = null;   //Declaring the Area class and set it equal to zero

            foreach (var item in AllAreas) // looping through the Areas
            {

                if (item.parent_area == null)  //Searching for the root area, where parent_area is equal null.
                {
                    area = item;
                    area.GetAllChildren(AllAreas);  //Calls for the method GetAllChildren in the area class that will receive the list of All Areas
                    
                }
                item.GetAreaDoors(AreaDoors);   //Calls for the method GetAreaDoors in the area class that will receive the list of Area doors
                item.GetAccessRules(AccessRules);   //Calls for the method GetAccessRules in the area class that will receive the list of Access Rules
            }
            area.Display(0);    //Calls for the Display method in the area class that will receives a zero (indicating the spaces required)
        }
    }
    }
