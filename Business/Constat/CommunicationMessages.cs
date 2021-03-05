using Entities.Concrute;
using System;
using System.Collections.Generic;

namespace Business.Constat
{
    //Northwint e özel mesajlar olduğu için static yaptık
    public static class CommunicationMessages
    {
        public static string Added = "Communication Added";
        public static string NameInvalid = "Communication Name InValid";
        public static string Listed = "Communications Listed";
        public static string Updated = "Communication Info Updated";
        public static string Deleted = "Communication Info Deleted";
        public static string ListedById = "Communications Listed By Id";
    }
}
