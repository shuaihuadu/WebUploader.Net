#define UNITTEST
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebUploader.Net.Utilities;

namespace WebUploader.Net.Tests
{
    [TestClass]
    public class WebuploaderConfigTest
    {
        [TestCategory("bvt")]
        [TestMethod]
        public void ConfigTest()
        {
            var defaultConfig = ConfigHelper.DefaultUploaderConfig;
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(defaultConfig));
            Assert.AreEqual(51200000, defaultConfig.SizeLimit);
        }
    }
}
