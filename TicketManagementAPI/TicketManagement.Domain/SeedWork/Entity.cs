using MediatR;
using System;
using System.Collections.Generic;

namespace TicketManagement.Domain.SeedWork
{
    public abstract class Entity<T> where T : struct
    {
        int? _requestedHashCode;
        T _Id;

        private List<INotification> _domainEvents;

        public virtual T Id
        {
            get
            {
                return _Id;
            }
            protected set
            {
                _Id = value;
            }
        }

        public List<INotification> DomainEvents => _domainEvents;

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            if (_domainEvents is null) return;
            _domainEvents.Remove(eventItem);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity<T>))
                return false;
            if (Object.ReferenceEquals(this, obj))
                return true;
            if (this.GetType() != obj.GetType())
                return false;
            Entity<T> item = (Entity<T>)obj;

            return item.Id.Equals(this.Id);
        }

        public override int GetHashCode()
        {

            if (!_requestedHashCode.HasValue)
                _requestedHashCode = this.Id.GetHashCode() ^ 31;

            return _requestedHashCode.Value;

        }

        public static bool operator ==(Entity<T> left, Entity<T> right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null));
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity<T> left, Entity<T> right)
        {
            return !(left == right);
        }
    }
}
