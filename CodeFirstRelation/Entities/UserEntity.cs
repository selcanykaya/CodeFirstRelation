using CodeFirstRelation.Entities;

namespace CodeFirstRelation.Entities
{
    public class UserEntity : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        // Relational
        public List<PostEntity> Posts { get; set; }
    }
}
