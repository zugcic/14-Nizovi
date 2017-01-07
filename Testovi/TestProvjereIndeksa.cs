using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vsite.CSharp.Testovi
{
    [TestClass]
    public class TestProvjereIndeksa
    {
        private int[,] GenerirajNiz(int maxPrviIndeks, int maxDrugiIndeks)
        {
            int[,] dvaDNiz = new int[maxPrviIndeks, maxDrugiIndeks];
            for (int i = 0; i < maxPrviIndeks; ++i)
                for (int j = 0; j < maxDrugiIndeks; ++j)
                    dvaDNiz[i, j] = (i + 1) * 10 + j + 1;
            return dvaDNiz;
        }

        [TestMethod]
        public void ProvjeraIndeksa_ZbrojiSigurnoVraćaZbrojSvihČlanovaZaNiz5x5()
        {
            int[,] niz = GenerirajNiz(5, 5);
            Assert.AreEqual(825, ProvjeraIndeksa.ZbrojiSigurno(niz));
        }

        [TestMethod]
        public void ProvjeraIndeksa_ZbrojiSigurnoVraćaZbrojSvihČlanovaZaNiz10x6()
        {
            int[,] niz = GenerirajNiz(3, 2);
            Assert.AreEqual(129, ProvjeraIndeksa.ZbrojiSigurno(niz));
        }

        [TestMethod]
        public void ProvjeraIndeksa_ZbrojiSigurnoBacaIznimkuZaPrevelikiPrviIndeks()
        {
            try
            {
                int[,] niz = GenerirajNiz(2, 2);
                ProvjeraIndeksa.ZbrojiSigurno(niz, 3, 1);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(IndexOutOfRangeException));
            }
        }

        [TestMethod]
        public void ProvjeraIndeksa_ZbrojiSigurnoBacaIznimkuZaPrevelikiDrugiIndeks()
        {
            try
            {
                int[,] niz = GenerirajNiz(2, 2);
                ProvjeraIndeksa.ZbrojiSigurno(niz, 1, 3);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(IndexOutOfRangeException));
            }
        }

        [TestMethod]
        public void ProvjeraIndeksa_ZbrojiNesigurnoVraćaZbrojSvihČlanovaZaNiz5x5()
        {
            int[,] niz = GenerirajNiz(5, 5);
            Assert.AreEqual(825, ProvjeraIndeksa.ZbrojiNesigurno(niz));
        }
    }
}
