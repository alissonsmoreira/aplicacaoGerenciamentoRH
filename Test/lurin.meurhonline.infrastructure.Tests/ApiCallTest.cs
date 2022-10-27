using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.infrastructure.invoke;
using lurin.meurhonline.infrastructure.invoke.interfaces;

namespace lurin.meurhonline.infrastructure.Tests
{
    [TestClass]
    public class ApiCallTest
    {                   
        [TestMethod]
        [Ignore]
        public void Token_SUCESS()
        {
            IApiInvoke apiInvoke = new ApiInvoke();

            try
            {
                var result = apiInvoke.PostReturn<TokenModel>(1);

                if (result == null)
                    Assert.IsNull(result);

                Assert.IsNotNull(result);
            }
            catch (ApplicationException ex)
            {
                throw (ex);
            }
        }
    }
}