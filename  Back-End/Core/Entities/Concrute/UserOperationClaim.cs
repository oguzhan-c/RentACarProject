using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Concrute
{
    public class UserOperationClaim : IEntity
    {
        [Key]
        public int  Id { get; set; }
        public int OperationClaimId { get; set; }
        public int UserId { get; set; }
    }
}