using System;

namespace Vsite.CSharp
{
    public class ProvjeraIndeksa
    {
        public static int ZbrojiSigurno(int[,] niz, int nPrviIndeks, int nDrugiIndex)
        {
            int zbroj = 0;
			//  Napisati petlju koja će zbrojiti članove do [nPrviIndeks, nDrugiIndex] dvodimenzionalnog niza
			for (int i = 0;i < nPrviIndeks;++i) {
				for (int j = 0;j < nDrugiIndex;++j) {

					zbroj += niz[i, j];
				}
			}
            return zbroj;
        }

        public static int ZbrojiSigurno(int[,] niz)
        {
            return ZbrojiSigurno(niz, niz.GetLength(0), niz.GetLength(1));
        }

        unsafe public static int ZbrojiNesigurno(int[,] niz, int nPrviIndeks, int nDrugiIndex)
        {	  //unsafe kaže clru-u da neradi provjere
            int zbroj = 0;
            // 'fixed' omogućava da se dohvati adresa članova 'polje' te ih se fiksira tako da ih GC ne može realocirati
			//fixed kaže da garbage collector nesmije dirati objekte koji se dolje nalaze, odnsosno koji se koriste
            fixed (int* element = niz)
            {
                int duljinaDrugeDimenzije = niz.GetLength(1);
				for(int i = 0;i<nPrviIndeks;++i) {

					int* tekući = element + i * duljinaDrugeDimenzije;
					for (int j = 0;j < nDrugiIndex;++j) {

						zbroj += *tekući;
						++tekući;
					}
				}
                // TODO: Napisati petlju koja će zbrojiti članove do [nPrviIndeks, nDrugiIndex] dvodimenzionalnog niza
            }
            return zbroj;
        }

        public static int ZbrojiNesigurno(int[,] niz)
        {
            return ZbrojiNesigurno(niz, niz.GetLength(0), niz.GetLength(1));
        }


        static void Main(string[] args)
        {
            const int MaxPrviIndeks = 10;
            const int MaxDrugiIndeks = 5;

            int[,] dvaDNiz = new int[MaxPrviIndeks, MaxDrugiIndeks];
                for (int r = 0; r < MaxPrviIndeks; ++r)
                    for (int s = 0; s < MaxDrugiIndeks; ++s)
                        dvaDNiz[r, s] = (r + 1) * 10 + s + 1;

            Console.WriteLine("Pozivam Sigurno:");
            Console.WriteLine(ZbrojiSigurno(dvaDNiz));
            Console.WriteLine();

            try
            {
                Console.WriteLine("Pozivam Sigurno s prevelikim prvim indeksom:");
                Console.WriteLine(ZbrojiSigurno(dvaDNiz, MaxPrviIndeks + 1, 1));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine();

            try
            {
                Console.WriteLine("Pozivam Sigurno s prevelikim drugim indeksom:");
                Console.WriteLine(ZbrojiSigurno(dvaDNiz, 1, MaxDrugiIndeks + 1));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine();

            Console.WriteLine();

            try
            {
                Console.WriteLine("Pozivam Nesigurno:");
                Console.WriteLine(ZbrojiNesigurno(dvaDNiz));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine();

            try
            {
                Console.WriteLine("Pozivam Nesigurno s prevelikim prvim indeksom:");
                Console.WriteLine(ZbrojiNesigurno(dvaDNiz, MaxPrviIndeks + 1, 1));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine();

            try
            {
                Console.WriteLine("Pozivam Nesigurno s prevelikim drugim indeksom:");
                Console.WriteLine(ZbrojiNesigurno(dvaDNiz, 1, MaxDrugiIndeks + 1));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine();

            try
            {
                Console.WriteLine("Pozivam Nesigurno s oba indeksa prevelika:");
                Console.WriteLine(ZbrojiNesigurno(dvaDNiz, MaxPrviIndeks + 1, MaxDrugiIndeks + 1));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("GOTOVO!!!");
            Console.ReadKey();
        }
    }
}
