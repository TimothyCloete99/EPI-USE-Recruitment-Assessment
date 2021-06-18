using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestRun;

/// <summary>
/// The User class contains the encrypt, decrypt and validate methods for the registered_users.json file
/// </summary>
class Users
{
    /// <summary>
    /// Encrypt method encrypts only the passwords from the registered_users.json file and stores it in a object list
    /// </summary>
    public void Encrypt()
    {
        StreamReader r = new StreamReader(@"F:\EPI-USE Labs Recruiting Exercise 2020\Testing\TestRun\registered_users.json");
        string json = r.ReadToEnd();
        RootUser users = JsonConvert.DeserializeObject<RootUser>(json); 


        foreach (var i in users.registered_users) 
        {
            byte[] encData_byte = new byte[i.password.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(i.password);
            string encodedData = Convert.ToBase64String(encData_byte);
            i.password = encodedData;   //Encrypting every password in the registered_users list
        }

    }
    /// <summary>
    /// Decrypt method decrypts the passwords for the validation method.
    /// </summary>
    public void Decrypt()
    {
        StreamReader r = new StreamReader(@"F:\EPI-USE Labs Recruiting Exercise 2020\Testing\TestRun\registered_users.json");
        string json = r.ReadToEnd();
        RootUser users = JsonConvert.DeserializeObject<RootUser>(json);
        foreach (var item in users.registered_users)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            string password = item.password;
            password = password.Replace('-', '+').Replace('_', '/').PadRight(4 * ((password.Length + 3) / 4), '='); // certain passwords is not a multiple of 4 long.
                                                                                                                    // It needs to be padded to a multiple of 4 using '=' characters.
            byte[] todecode_byte = Convert.FromBase64String(password);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            password = new String(decoded_char);
            item.password = password; //Decrypting every password in the registered_users list
        }


    }
    /// <summary>
    /// Validate method makes use of the Decrypt method to firstly decrypt the passwords before starting with validating the username and password.
    /// Valdiate method returns a boolean value whether the username and password is correct or incorrect.
    /// </summary>
    /// <param name="Username">This paramater will receive the username from the input of the user in the main program </param>
    /// <param name="Password">This paramater will receive the password from the input of the user in the main program </param>
    /// <returns>returns a boolean value whether the username and password is correct or incorrect.</returns>

    public bool Validate(string Username, string Password)
    {
        Decrypt();
        StreamReader r = new StreamReader(@"F:\EPI-USE Labs Recruiting Exercise 2020\Testing\TestRun\registered_users.json");
        string json = r.ReadToEnd();

        RootUser users = JsonConvert.DeserializeObject<RootUser>(json);

        bool status = false;
        foreach (var item in users.registered_users)
        {
            if (item.username == Username && item.password == Password)  //Checks if user's input for the username and password is equal to the username and password in the registered_users list
            {
                status = true;
                break;
            }
            else
            {
                status = false;
            }
        }
        return status;
        

    }
       
        
    }
