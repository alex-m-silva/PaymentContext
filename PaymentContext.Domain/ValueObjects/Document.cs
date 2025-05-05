using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObject;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type)
        {
            Type = type;
            Number = number; 
            
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsTrue(Validate(), "Document.Number", "Documento inválido")
            );
        }

        public string Number { get; private set; }
        public EDocumentType Type { get; set; }

        private bool Validate()
        {
            if (string.IsNullOrEmpty(Number))
                return false;
            if (Type == EDocumentType.CPF && Number.Length != 11)
                return false;
            if (Type == EDocumentType.CNPJ && Number.Length != 14)
                return false;
            return true;
        }
    }
}
