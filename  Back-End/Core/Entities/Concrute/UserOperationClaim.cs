using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Concrute
{
    public class UserOperationClaim : IEntity
    {
        [Key]
        public int  UserOperationClaimId { get; set; }
        public int claimId { get; set; }
        public int UserId { get; set; }
    }
}