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

            StreamReader r = new StreamReader(@"F:\EPI-USE Labs Recruiting Exercise 2020\Testing\TestRun\TestRun\system_data.json");
            string json = r.ReadToEnd();
            Root door = JsonConvert.DeserializeObject<Root>(json);
            string status = "";
            foreach (var item in door.system_data.doors)
            {
                if (item.id == doorID)
                {
                    item.status = "closed";
                    JsonSerializer serializer = new JsonSerializer();
                    using (StreamWriter sw = new StreamWriter(@"F:\EPI-USE Labs Recruiting Exercise 2020\Testing\TestRun\TestRun\Test\system_data.json"))
                    using (JsonWriter writer = new JsonTextWriter(sw))
                    {
                        serializer.Serialize(writer, door);
                    }
                    return status = "Door: " + doorID + " Locked!";
                    break;
                }
            }
            return status;
        }

        public string UnlockDoor(string doorID)
        {

            StreamReader r = new StreamReader(@"F:\EPI-USE Labs Recruiting Exercise 2020\Testing\TestRun\TestRun\system_data.json");
            string json = r.ReadToEnd();
            Root door = JsonConvert.DeserializeObject<Root>(json);
            string status = "";
            foreach (var item in door.system_data.doors)
            {
                if (item.id == doorID)
                {
                    item.status = "open";
                    JsonSerializer serializer = new JsonSerializer();
                    using (StreamWriter sw = new StreamWriter(@"F:\EPI-USE Labs Recruiting Exercise 2020\Testing\TestRun\TestRun\Test\system_data.json"))
                    using (JsonWriter writer = new JsonTextWriter(sw))
                    {
                        serializer.Serialize(writer, door);
                    }
                    return status = "Door: " + doorID + " Unlocked!";
                    break;
                }
            }
            return status;
        }
    }
}
