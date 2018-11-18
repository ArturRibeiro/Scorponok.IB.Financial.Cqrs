﻿
using FluentValidation.Results;

namespace Scorponok.IB.Financial.Domain.Core.Models
{
    public abstract class Entity<T>
    {
        public T Id { get; protected set; }

        public bool IsValid => Validate().IsValid;

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<T>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<T> a, Entity<T> b) => !(a == b);

        public override int GetHashCode() =>(GetType().GetHashCode() * 907) + Id.GetHashCode();

        public abstract ValidationResult Validate();
    }
}