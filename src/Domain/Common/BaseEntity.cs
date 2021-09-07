﻿namespace Domain.Common
{
    using System;
    using System.Collections.Generic;
    using Todo;

    public abstract class BaseEntity: IEntity, IAuditableEntity, IHaveDomainEvents
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string LastModifiedBy { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}