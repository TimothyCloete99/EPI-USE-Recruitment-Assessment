using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestRun
{
    public class Doors
    {

        public string LockDoor(string doorID)
        {

            StreamReader r = new StreamReader(@"F:\EPI-USE Labs Recruiting Exercise 2020\Testing\TestRun\system_data.json");
            string json = r.ReadToEnd();
            Root doors = JsonConvert.DeserializeObject<Root>(json);

            foreach (var item in doors.system_data.doors)
            {
                if (item.id == doorID)
                {
                    item.status = "closed";
                }
            }
            return "Door " + doorID + " Locked!";
        }

        public string UnlockDoor(string doorID)
        {

            StreamReader r = new StreamReader(@"F:\EPI-USE Labs Recruiting Exercise 2020\Testing\TestRun\system_data.json");
            string json = r.ReadToEnd();
            Root doors = JsonConvert.DeserializeObject<Root>(json);

            foreach (var item in doors.system_data.doors)
            {
                if (item.id == doorID)
                {
                    item.status = "open";
                }
            }
            return "Door " + doorID + " Unlocked!";
        }
    }
}
