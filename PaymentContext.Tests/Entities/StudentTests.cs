using PaymentContext.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var subscription = new Subscription ( DateTime.Now.AddDays(5) );
            var student = new Student ( "Alex", "Matias", "128.193.356-24", "alexmatias.am162@gmail.com");
            student.AddSubscription(subscription);
        }
    }
}
