using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Tests.Mock
{
    public class FakeLogger<T>
    {
        public Mock<ILogger<T>> Mock;
        public ILogger<T> Logger;

        public FakeLogger()
        {
            Mock = new Mock<ILogger<T>>();

            Logger = Mock.Object;
        }

    }
}
