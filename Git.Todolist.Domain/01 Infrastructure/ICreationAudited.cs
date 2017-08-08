using System;

namespace Git.Todolist.Domain
{
    public interface ICreationAudited
    {
        string Id { get; set; }
        string CreatorUserId { get; set; }
        DateTime? CreatorTime { get; set; }
    }
}