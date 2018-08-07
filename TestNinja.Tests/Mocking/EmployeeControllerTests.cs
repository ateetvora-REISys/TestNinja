using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TestNinja.Mocking;

namespace TestNinja.Tests.Mocking
{
    [TestFixture()]
    public class EmployeeControllerTests
    {
        [Test]
        public void DeleteEmployee_WhenCalled_DeletesARecord()
        {
            var employeeStorage = new Mock<IEmployeeStorage>();
            var employeeController = new EmployeeController(employeeStorage.Object);

            employeeController.DeleteEmployee(1);

            employeeStorage.Verify(t => t.DeleteEmployee(1));
        }
    }
}
