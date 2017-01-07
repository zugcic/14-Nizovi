using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vsite.CSharp;

namespace Vsite.CSharp.Testovi
{
    [TestClass]
    public class TestInicijalizacijeNiza : ConsoleTest
    {
        [TestMethod]
        public void InicijalizacijaNiza_NizIntovaSNeinicijaliziranimČlanovimaSadržiNule()
        {
            InicijalizacijaNiza.InicijalizacijaNizaVrijednosnogTipa();
            Assert.IsTrue(cw.Count >= 5);
            Assert.IsTrue(cw.GetString().EndsWith(typeof(int).ToString()));
            for (int i = 0; i < 4; ++i)
                Assert.AreEqual(0, cw.GetInt());
        }

        [TestMethod]
        public void InicijalizacijaNiza_NizIntovaSInicijaliziranimČlanovimaSadržiČlanoveRazličiteOdNule()
        {
            InicijalizacijaNiza.InicijalizacijaNizaVrijednosnogTipa();
            Assert.AreEqual(10, cw.Count);
            Assert.IsTrue(cw.GetString().EndsWith(typeof(int).ToString()));
            for (int i = 0; i < 4; ++i)
                Assert.AreEqual(0, cw.GetInt());

            Assert.IsTrue(cw.GetString().EndsWith(typeof(int).ToString()));
            for (int i = 0; i < 4; ++i)
                Assert.AreNotEqual(0, cw.GetInt());
        }

        [TestMethod]
        public void InicijalizacijaNiza_NizKontrolaSNeinicijaliziranimČlanovimaSadržiNullReference()
        {
            InicijalizacijaNiza.InicijalizacijaNizaReferentnogTipa();
            Assert.IsTrue(cw.Count >= 5);
            Assert.IsTrue(cw.GetString().EndsWith(typeof(System.Windows.Forms.Control).ToString()));
            for (int i = 0; i < 4; ++i)
                Assert.IsNull(cw.GetObject());
        }

        [TestMethod]
        public void InicijalizacijaNiza_NizKontrolaSInicijaliziranimČlanovimaSadržiReferenceNaObjekte()
        {
            InicijalizacijaNiza.InicijalizacijaNizaReferentnogTipa();
            Assert.AreEqual(10, cw.Count);
            Assert.IsTrue(cw.GetString().EndsWith(typeof(System.Windows.Forms.Control).ToString()));
            for (int i = 0; i < 4; ++i)
                Assert.IsNull(cw.GetObject());

            Assert.IsTrue(cw.GetString().EndsWith(typeof(System.Windows.Forms.Control).ToString()));
            for (int i = 0; i < 4; ++i)
            {
                object obj = cw.GetObject();
                Assert.IsNotNull(obj);
                Assert.IsTrue(obj.GetType().IsSubclassOf(typeof(System.Windows.Forms.Control)));
            }
        }
    }
}
