Nizovi
======

InicijalizacijaNiza
-------------------
Primjer inicijalizacije niza objekata vrijednosnog, odnosno referentnog tipa.


ProvjeraIndeksa
---------------
Dohvaćanje članova dvodimenzionalnog niza na siguran (provjera indeksa) i na 
nesiguran način.
Za nesiguran način moramo metodi dodati atribut unsafe te moramo u postavkama
prevoditelja navesti da dozvoljavamo nesiguran pristup.
Pri sigurnom pristupu neispravan indeks će baciti IndexOutOfRangeException.


NizoviKaoArgumenti
------------------
Niz kao argument metode: prenosi se referenca pa možemo mijenjati članove niza.


NizoviKaoPovratnaVrijednost
---------------------------
Niz kao povratna vrijednost: vraća se referenca. Ako želimo onemogućiti promjene,
moramo vratiti presliku.


