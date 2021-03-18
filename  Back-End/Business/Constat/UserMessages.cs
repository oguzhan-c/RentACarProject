using Core.Entities.Concrute;
using Entities.Concrute;
using Entities.Dtos;
using System;
using System.Collections.Generic;

namespace Business.Constat
{
    //Northwint e özel mesajlar olduğu için static yaptık
    public static class UserMessages
    {
        public static string Added = "User Added";
        public static string NameInvalid = "User Name InValid";
        public static string Listed = "Users Listed";
        public static string Updated = "User Info Updated";
        public static string Deleted = "User Info Deleted";
        public static string ListedById = "Users Listed By Id";
        public static string UserDetaislListed = "User Details Listed";
        public static string UserAlreadyExist = "UserAlreadyExist";
        public static string UserAlreadyDeleted = "UserAlreadyDeleted";
        public static string ThisClaimsIsNotExist = "ThisClaimsIsNotExist";
        public static string UserDetailsİsNotExist = "UserDetailsİsNotExist";
        public static string UserNotFound = "UserNotFound";
        public static string PasswordError = "PasswordError";
        public static string SuccessfulLogin = "SuccessfulLogin";
        public static string MailDoNotFound = "MailDoNotFound";
        public static string MailIsNotExist = "MailIsNotExist";
        internal static string AccessTokenCreated = "AccessTokenCreated";
    }
}
