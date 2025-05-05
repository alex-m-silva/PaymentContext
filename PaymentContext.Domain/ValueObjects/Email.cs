using PaymentContext.Shared.ValueObject;
using Flunt.Validations;
using Flunt.Notifications;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsEmail(Address, "Email.address", "E-mail inválido")
            );
        }

        public string Address { get; private set; }
    }
}
