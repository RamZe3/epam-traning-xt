using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text.Json;

namespace WebTask1.Models
{
    public class JsonConverter
    {
        public string pathUsers = @"C:\Users\Рамиль\Desktop\users.txt";
        public string pathAwards = @"C:\Users\Рамиль\Desktop\awards.txt";

        public Dictionary<string, User> DictOfUsers;
        public Dictionary<string, Award> DictOfAwards;

        public JsonConverter()
        {
            try
            {
                string UsersJson = File.ReadAllText(pathUsers);
                DictOfUsers = JsonSerializer.Deserialize<Dictionary<string, User>>(UsersJson);
            }
            catch(Exception e)
            {
                DictOfUsers = new Dictionary<string, User>();
            }

            try
            {
                string AwardsJson = File.ReadAllText(pathAwards);
                DictOfAwards = JsonSerializer.Deserialize<Dictionary<string, Award>>(AwardsJson);
            }
            catch (Exception e)
            {
                DictOfAwards = new Dictionary<string, Award>();
            }
        }

        public bool CheckUserInDict(string user)
        {
            foreach (var IUser in DictOfUsers)
            {
                if (IUser.Key == user)
                {
                    return true;
                }
            }
            return false;
        }

        public void WriteUsersOnFile()
        {
            string jsonString = JsonSerializer.Serialize(DictOfUsers);
            File.WriteAllText(pathUsers, jsonString);
        }

        public void AddUsersOnDict(User user)
        {
            DictOfUsers.Add(user.name, user);
        }
        public void DeleteUserOnDict(string user)
        {
            DictOfUsers.Remove(user);
        }

        public bool CheckAwardInDict(string award)
        {
            foreach (var Iaward in DictOfAwards)
            {
                if (Iaward.Key == award)
                {
                    return true;
                }
            }
            return false;
        }

        public void WriteAwardsOnFile()
        {
            string jsonString = JsonSerializer.Serialize(DictOfAwards);
            File.WriteAllText(pathAwards, jsonString);
        }

        public void AddAwardsOnDict(Award award)
        {
            DictOfAwards.Add(award.Title, award);
        }

        public void DeleteAwardsOnDict(string title)
        {
            DictOfAwards.Remove(title);
        }
    }
}