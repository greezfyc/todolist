﻿using System.Data.Entity.ModelConfiguration;
using Git.Todolist.Domain.Entity;

namespace Git.Todolist.Mapping
{
    public class LogMap : EntityTypeConfiguration<LogEntity>
    {
        public LogMap()
        {
            this.ToTable("Todolist_Log");
            this.HasKey(t => t.Id);
        }
    }
}