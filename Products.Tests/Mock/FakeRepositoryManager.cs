using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Products.Contracts;

namespace Products.Tests.Mock
{
    public class FakeRepositoryManager
    {
        public Mock<IRepositoryManager> Mock;
        public IRepositoryManager Repository;

        public FakeRepositoryManager()
        {
            Mock = new Mock<IRepositoryManager>();

            Repository = Mock.Object;
        }
    }
}
