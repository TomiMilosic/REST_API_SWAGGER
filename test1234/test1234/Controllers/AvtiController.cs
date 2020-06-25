using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.Extensions.Logging;
using System.Data.Entity;
using System.Xml.Serialization;
using System.IO;
using System.Collections.ObjectModel;

namespace test1234.Controllers
{
    [ApiController]
    [Route("avti")]
    public class AvtiController : ControllerBase
    {
        public ObservableCollection<Avto> seznamAvtov = new ObservableCollection<Avto>();

        public XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Avto>));
        //TextWriter pisi = new StreamWriter("podatki.xml");

        public AvtiController()
        {

            ObservableCollection<Avto> nekseznam = new ObservableCollection<Avto>();
            using (TextReader beri = new StreamReader("podatki.xml"))
            {
                nekseznam = (ObservableCollection<Avto>)serializer.Deserialize(beri);
            }
            if (nekseznam.Count == 0)
            {
                seznamAvtov.Add(new Avto { id = 1, Znamka = "volkswagen", Model = "golf", cena = 20000, nov = Avto.Nov.da });
                seznamAvtov.Add(new Avto { id = 2, Znamka = "Mazda", Model = "Mazda2", cena = 21000, nov = Avto.Nov.ne });
                seznamAvtov.Add(new Avto { id = 3, Znamka = "BMW", Model = "M4", cena = 35000, nov = Avto.Nov.da });
                seznamAvtov.Add(new Avto { id = 4, Znamka = "Audi", Model = "A4", cena = 40000, nov = Avto.Nov.ne });
                seznamAvtov.Add(new Avto { id = 5, Znamka = "Jaguar", Model = "F-type", cena = 60000, nov = Avto.Nov.ne });
                seznamAvtov.Add(new Avto { id = 6, Znamka = "Fiat", Model = "Punto", cena = 2000, nov = Avto.Nov.da });
                using (TextWriter pisi = new StreamWriter("podatki.xml"))
                {
                    serializer.Serialize(pisi, seznamAvtov);
                }
            }
           
        }

       


        [HttpGet]
        public ObservableCollection<Avto> Get()
        {
            ObservableCollection<Avto> nekseznam = new ObservableCollection<Avto>();
            using (TextReader beri = new StreamReader("podatki.xml"))
            {
                nekseznam = (ObservableCollection<Avto>)serializer.Deserialize(beri);
            }
            return nekseznam;
        }

        [HttpGet("{id}")]
        public ActionResult<Avto> GetPoId(int id)
        {
            ObservableCollection<Avto> nekseznam = new ObservableCollection<Avto>();
            using (TextReader beri = new StreamReader("podatki.xml"))
            {
                nekseznam = (ObservableCollection<Avto>)serializer.Deserialize(beri);
            }
            foreach (var item in nekseznam)
            {
                if (item.id == id)
                {
                    return Ok(item);
                }
            }

          
            return null;
        }

        [HttpPost]
        public ObservableCollection<Avto> Add([FromBody] Avto avto)
        {
            ObservableCollection<Avto> nekseznam = new ObservableCollection<Avto>();
            using (TextReader beri = new StreamReader("podatki.xml"))
            {
                nekseznam = (ObservableCollection<Avto>)serializer.Deserialize(beri);
            }


            nekseznam.Add(avto);

            using (TextWriter pisi = new StreamWriter("podatki.xml"))
            {
                serializer.Serialize(pisi, nekseznam);
            }

            return nekseznam;
        }



        [HttpDelete("{idavta}")]
        public ObservableCollection<Avto> Delete(int idavta)
        {
            ObservableCollection<Avto> nekseznam = new ObservableCollection<Avto>();

            using (TextReader beri= new StreamReader("podatki.xml"))
            {
                nekseznam = (ObservableCollection<Avto>)serializer.Deserialize(beri); 
            }
            foreach (var item in nekseznam)
            {
                if (item.id == idavta)
                {
                    nekseznam.Remove(item);
                    break;
                }
            }
            

            using (TextWriter pisi= new StreamWriter("podatki.xml"))
            {
                serializer.Serialize(pisi, nekseznam);
            }
          
            return nekseznam;
        }

        [HttpPut]
        public ObservableCollection<Avto> Poosodobi([FromBody] Avto avto)
        {

            ObservableCollection<Avto> nekseznam = new ObservableCollection<Avto>();
            using (TextReader beri = new StreamReader("podatki.xml"))
            {
                nekseznam = (ObservableCollection<Avto>)serializer.Deserialize(beri);
            }

            foreach (var item in nekseznam)
            {
                if (item.id == avto.id)
                {
                    item.Znamka = avto.Znamka;
                    item.Model = avto.Model;
                    item.cena = avto.cena;
                    item.nov = avto.nov;
                    break;
                }
            }
            using (TextWriter pisi = new StreamWriter("podatki.xml"))
            {
                serializer.Serialize(pisi, nekseznam);
            }

            return nekseznam;
        }

        [Route("wish")]
        [HttpGet]
        public List<Avto> PoZelji([FromBody] Avto avto)
        {

            ObservableCollection<Avto> nekseznam = new ObservableCollection<Avto>();
            using (TextReader beri = new StreamReader("podatki.xml"))
            {
                nekseznam = (ObservableCollection<Avto>)serializer.Deserialize(beri);
            }
            List<Avto> temp = new List<Avto>();
            
            temp = nekseznam.ToList();

            temp = temp.FindAll(x => x.nov == avto.nov);
            if (avto.Znamka != "")
            {
                temp = temp.FindAll(x => x.Znamka == avto.Znamka);
            }

            if (avto.Model != "")
            {
                temp = temp.FindAll(x => x.Model == avto.Model);
            }

            if (avto.cena != 0)
            {
                temp = temp.FindAll(x => x.cena == avto.cena);
            }

            if (avto.id != 0)
            {
                temp = temp.FindAll(x => x.id == avto.id);
            }

            return temp;
        }


        [HttpGet("storitev1/{cena}")]
        public List<Avto> Storitev1(int cena)
        {
            ObservableCollection<Avto> nekseznam = new ObservableCollection<Avto>();
            using (TextReader beri = new StreamReader("podatki.xml"))
            {
                nekseznam = (ObservableCollection<Avto>)serializer.Deserialize(beri);
            }

            List<Avto> temp = new List<Avto>();
            foreach (var item in nekseznam)
            {
                if (item.cena>cena)
                {
                    temp.Add(item);
                }
            }

            return temp;
        }

        [HttpGet("storitev2")]
        public List<Avto> Storitev1()
        {
            ObservableCollection<Avto> nekseznam = new ObservableCollection<Avto>();
            using (TextReader beri = new StreamReader("podatki.xml"))
            {
                nekseznam = (ObservableCollection<Avto>)serializer.Deserialize(beri);
            }

            List<Avto> temp = new List<Avto>();

            temp = nekseznam.OrderByDescending(x => x.cena).ToList();//najdrazji najcenejsi

            return temp;
        }

    }
}
