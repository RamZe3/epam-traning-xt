using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WebTask1.Models
{
    public class UserRollProv : RoleProvider
    {
        public override bool IsUserInRole(string username, string roleName)
        {
            JsonConverter jsonConverter = new JsonConverter();
            User user = jsonConverter.DictOfUsers[username];
            if (username == "admin" && roleName == "admin")
            {
                return true;
            }
            else if (user.role == roleName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetRoleForUser(string username)
        {
            JsonConverter jsonConverter = new JsonConverter();
            return jsonConverter.DictOfUsers[username].role;
        }

        public void AddUserToRole(string username, string roleName)
        {
            JsonConverter jsonConverter = new JsonConverter();
            jsonConverter.DictOfUsers[username].role = roleName;
            jsonConverter.WriteUsersOnFile();
        }

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            if (username == "admin")
            {
                return new[] { "admin" };
            }

            JsonConverter jsonConverter = new JsonConverter();
            User user;
            if (jsonConverter.DictOfUsers.TryGetValue(username, out user))
            {
                return new[] { jsonConverter.DictOfUsers[username].role };
            }
            return new[] { "user" };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}