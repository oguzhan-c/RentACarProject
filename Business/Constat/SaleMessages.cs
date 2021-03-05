using Entities.Concrute;
using System;
using System.Collections.Generic;

namespace Business.Constat
{
    //Northwint e özel mesajlar olduğu için static yaptık
    public static class SaleMessages
    {
        public static string Added = "Sale Added";
        public static string NameInvalid = "Sale Name InValid";
        public static string Listed = "SalesListed"; 
        public static string MaintenanceTime = "System in progress";
        public static string Updated = "Sale Info Updated";
        public static string Deleted = "SaleInfo Deleted";
        public static string ListedById = "Sales Listed By Id";
    }
}
