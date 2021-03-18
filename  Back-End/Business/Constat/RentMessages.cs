using Entities.Concrute;
using System;
using System.Collections.Generic;

namespace Business.Constat
{
    //Northwint e özel mesajlar olduğu için static yaptık
    public static class RentMessages
    {
        public static string Added = "Rent Added";
        public static string NameInvalid = "Rent Name InValid";
        public static string Listed = "Rents Listed";
        public static string Updated = "Rent Info Updated";
        public static string Deleted = "Rent Info Deleted";
        public static string ListedById = "Rents Listed By Id";
        public static string RentDetailsListed = "Rent Details Listed";
        internal static string CarIsAlreadyRentBySomeone;
        internal static string ThisCarCanRent;
        internal static List<Rent> NoBodyDidNotRentACar;
    }
}
