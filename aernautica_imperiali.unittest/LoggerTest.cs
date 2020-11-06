using System;
using System.Threading.Channels;
using NUnit.Framework;

namespace aernautica_imperiali.unittest {
    public class LoggerTest {
        
        [SetUp]
        public void Setup() {
        }
        
        [Test]
        public void SingletonTest() {
            Logger logger = Logger.GetInstance();
            Logger logger2 = Logger.GetInstance();
            
            Assert.AreSame(logger,logger2);
        }
    }
}