using BrewzDomainDataAccessLayer;
using BrewzTest.Mocks;
using BrewzWPF.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewzTest
{
    [TestClass]
    public class BrewerDataServiceTest
    {
        private IBrewerRepository repository;

        [TestInitialize]
        public void Init()
        {
            repository = new MockRepository();
        }

        [TestMethod]
        public void GetBrewerDetailTest()
        {
            var service = new BrewerDataService(repository);

            var brewer = service.GetBrewer(1);

            Assert.IsNotNull(brewer);
            Assert.AreEqual(brewer.Name, "Jupiler");
        }
    }
}
