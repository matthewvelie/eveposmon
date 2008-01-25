using System;
using System.Collections.Generic;
using System.Text;

using libeveapi;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class libeveapiTests
    {
        [Test]
        public void CharacterListTest()
        {
            Constants.ApiPrefix = "http://localhost/";
            Constants.CharacterList = "eveposmon/Characters.xml.aspx";

            CharacterList cl = EveApi.GetAccountCharacters(0, "apiKey");

            Assert.AreEqual("Super Dud", cl.CharacterListItems[0].Name);
            Assert.AreEqual(456456456, cl.CharacterListItems[0].CharacterId);
            Assert.AreEqual("Concord", cl.CharacterListItems[0].CorporationName);
            Assert.AreEqual(786413259, cl.CharacterListItems[0].CorporationId);
        }
    }
}
