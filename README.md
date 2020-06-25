# ASP.NET Web API

Storitve entitet:

Pridobivanje vseh objektov
Pridobivanje objekta po id
Dodajanje novega objekta
Odstranjevanje objekta po id
Posodabljanje entitete po id
 
Dodatne storitve:
iskanje objektov entitet tako, da storitvi pošljete objekt entitete v katerem so manjkajoči podatki
npr. entiteta Država {id, imeDrzave, kontinent, clanicaNato}
v storitev bi poslali primerek entitete Država, ki bi imel vnešen le kontinent vi pa bi vrnili vse primerke držav, ki se nahajajo na kontinentu
isto storitev bi lahko uporabili tudi tako, da bi vanjo poslali zgolj podatek ali je članicaNato ali ne...
Storitev če vanjo pošljete entiteto, ki nima definiranega ničesar vrača vse primerke


API je dokumentiran z Swaggerjem.
Baza je EntityFramework(CodeFirst).


Slika: 
https://i.imgur.com/HAUbSRE.png 
