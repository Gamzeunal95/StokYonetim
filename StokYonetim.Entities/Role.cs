﻿namespace StokYonetim.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}