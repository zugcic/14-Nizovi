using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vsite.CSharp.Testovi
{
    [TestClass]
    public class TestNizoviKaoArgumenti
    {
        bool NizoviSuJednaki(string[] niz1, string[] niz2)
        {
            if (niz1.Length != niz2.Length)
                return false;
            for (int i = 0; i < niz1.Length; ++i)
            {
                if (niz1[i] != niz2[i])
                    return false;
            }
            return true;
        }

        [TestMethod]
        public void NizoviKaoArgumenti_PozivMetodeSamVragMijenjaJedanČlan()
        {
            string[] niz1 = new string[] { "jedan", "dva", "tri", "četiri", "pet" };
            string[] niz2 = (string[])niz1.Clone();

            string[] niz3 = new string[] { "ponedjeljak", "utorak", "srijeda", "četvrtak" };
            string[] niz4 = (string[])niz3.Clone();

            NizoviKaoArgumenti.SamVrag(niz2);
            NizoviKaoArgumenti.SamVrag(niz4);

            Assert.IsFalse(NizoviSuJednaki(niz1, niz2) && NizoviSuJednaki(niz3, niz4));
        }
    }
}
