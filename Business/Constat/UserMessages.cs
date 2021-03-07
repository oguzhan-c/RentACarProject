using Entities.Concrute;
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
        internal static string UserDetaislListed = "User Details Listed";
        internal static string UserAlreadyExist;
        internal static string UserAlreadyDeleted;
    }
}
