using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTask1.Models
{
    public class User
    {
        public string id { get; set; }
        public string name { get; set; }
        public string dateOfBirth { get; set; }
        public int age { get; set; }
        public string pass { get; set; }

        public Award[] awards { get; set; } = new Award[10];
        public int AwardCount { get; set; } = 0; 

        public User(string id, string name, string dateOfBirth, int age, string pass)
        {
            this.id = id;
            this.name = name;
            this.dateOfBirth = dateOfBirth;
            this.age = age;
            this.pass = pass;
        }

        public User()
        {
        }

        public override string ToString()
        {
            string Awards = "";

            if (awards[0] == null)
            {
                Awards = "Отсутствуют";
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    if (awards[i] == null)
                    {
                        break;
                    }
                    Awards += awards[i].ToString() + ", ";
                }
            }
            return "Логин : " + name + " Награды : " + Awards; 
        }

        public void AddAward(Award award)
        {
            awards[AwardCount] = award;
            AwardCount++;
        }

        public void DeleteAwardByName(string awardName)
        {
            int countOfAwards = 0;
            for (int i = 0; i < AwardCount; i++)
            {
                if (awards[i].Title == awardName)
                {
                    awards[i] = null;
                    countOfAwards++;
                }
            }
            for (int i = 0; i < AwardCount; i++)
            {
                if (awards[i] == null)
                {
                    for (int j = i; j < AwardCount; j++)
                    {
                        awards[i] = awards[j+1];
                    }
                }
            }
            AwardCount -= countOfAwards;
        }

    }
}