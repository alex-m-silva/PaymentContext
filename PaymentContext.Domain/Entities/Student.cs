﻿using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;
        public Student(Name name, Document document, Email email)
        {
            
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();
            AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            var hasActiveSubscription = false;
            foreach (var item in _subscriptions)
            {
                if(item.Active)
                    hasActiveSubscription = true;
            }

            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsFalse(hasActiveSubscription, "Student.Subscriptions", "Já existe uma assinatura ativa"));
        }
    }
}
