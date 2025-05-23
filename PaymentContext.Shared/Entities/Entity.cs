﻿using Flunt.Notifications;

namespace PaymentContext.Shared.Entities
{
    public abstract class Entity : Notifiable<Notification>
    {
        private IList<string> Notifications;

        public Entity()
        {
            Id = Guid.NewGuid();

        }
        public Guid Id { get; private set; }
    }
}
