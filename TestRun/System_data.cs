using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TestRun
{

    public class Area
    {
        public string id { get; set; }
        public string name { get; set; }
        public string parent_area { get; set; }
        public List<string> child_area_ids { get; set; }

        public List<Area> child_area = new List<Area>(); //Creating a child_area lists

        public List<Door> area_doors = new List<Door>(); //Creating a area_doors lists

        public List<AccessRule> access_rules = new List<AccessRule>(); //Creating access_rules

        public void GetAllChildren(List<Area> areas) //GetAllChildren gets all children areas and stores it in the child_area list 
        {
            foreach (Area child in areas)
            {
                if (child.parent_area == this.id) //if the parent area id of the current area is equal to the area's id then add area the child_area list
                {
                    this.child_area.Add(child);

                }
            }


            //
            foreach (Area child in child_area) //repeqts the method
            {
                child.GetAllChildren(areas);
            }


        }

        public void GetAreaDoors(List<Door> AreaDoors) //GetAreaDoors method get all the doors of the areas and store it in the area_doors list
        {


            foreach (Door door in AreaDoors)
            {
                if (this.id == door.parent_area) //If the id of the area is equal to the parent area id of the door then add the door to the area_doors list
                {
                    this.area_doors.Add(door);
                }
            }
        }

        public void GetAccessRules(List<AccessRule> accessRule) //GetAccessRules method get all the Access rules of the doors and store it in the access_rules list
        {

            foreach (Door door in area_doors)
            {
                foreach (AccessRule rule in accessRule)
                {
                    foreach (String a in rule.doors)
                    {
                        if (a == door.id)   //If rule equals to door id then add rule to access_rules list
                        {
                            this.access_rules.Add(rule);
                        }
                    }
                }
            }

        }


        public string GetDoors() //GetDoor method returns a string with each door of the area
        {
            
            string doors = "";
            foreach (var item in area_doors)
            {
                    if (item.status == "open")  //If the door status is open
                    {

                        doors += " " + item.name + " (UNLOCKED),"; //Join the string with the name of the door and (UNLOCKED) followed by a ","
                    }
                    else
                    {
                        doors += " " + item.name + " (UNLOCKED),"; //Join the string with the name of the door and (LOCKED) followed by a ","
                }
                
            }
            return doors.Substring(0, doors.Length - 1);//Removing the ',' at the end of the string and returing the string 
        }

        public string GetRules() //GetRules method returns a string with each acces rule of the doors
        {
            List<AccessRule> accessRules = access_rules.Distinct().ToList(); //Removes duplicate values in this case duplicate rules
            string areas = "";
            foreach (var item in accessRules)
            {
                areas += " " + item.name + ","; //Joining string with each area name with a ","
            }
            return areas.Substring(0, areas.Length - 1); //Removing the ',' at the end of the string and returing the string 
        }

        private string CalculateSpace(int count) //Created a method that will calculate the amount spaces it will make
        {
            string s = "";
            for (int i = 0; i <= count; i++)
            {
                s += " ";
            }
            return s;
        }

           
            public void Display(int indent) //Display method display it in the correct hierarchy format
        {   
            Console.WriteLine(CalculateSpace(indent)+@"\-"+this.name.ToUpper()); //Display each area in uppercase
            Console.WriteLine(CalculateSpace(indent + 2) + "|- [Doors]"+ this.GetDoors()); //Display doors for each area using the GetDoors method
            Console.WriteLine(CalculateSpace(indent + 2) + "|- [Access Rules]" +this.GetRules()); //Display access rules for each door using the GetRules method
            foreach (var child in child_area)
            {
                child.Display(indent + 2); //Recursive function will repeat outputting the display method unitl the end of the child area
            }
        }
    }

    public class Door
    {
        public string id { get; set; }
        public string name { get; set; }
        public string parent_area { get; set; }
        public string status { get; set; }
    }

    public class AccessRule
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<string> doors { get; set; }
    }

    public class SystemData //SystemData class containing the lists of areas, doors, and access_rules
    {
        public List<Area> areas { get; set; } // List created based on the Area class
        public List<Door> doors { get; set; } // List created based on the Door class
        public List<AccessRule> access_rules { get; set; } // List created based on the AccessRule class
    }

    public class Root
    {
        public SystemData system_data { get; set; }  //creating a root with the SystemData class containing the lists of areas, doors, and access_rules
    }
}


