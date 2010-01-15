using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BarisGorselDLL;
using System.Data.SqlClient;
using System.Data;

namespace familytree
{
    class Person : ConnectionImporter
    {
        public int Id;
        public string Name;
        public string Surmane;
        public int parentId;
        public int coupleId;
        public int Sex;
        public bool Dead;
        public string Photo;
        public DateTime Birthdate;

        public Person ReturnPerson(int Id)
        {
            ConnectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=familytree;Integrated Security=True";
            Connect();
            SqlCommand cmd = new SqlCommand("USP_FAMILYTREE_PERSON_GET", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Id);
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            cmd.Dispose();
            cmd = null;
            adapter.Dispose();
            adapter = null;
            Person kisi = new Person();
            kisi.Id = int.Parse(dataTable.Rows[0]["id"].ToString());
            kisi.Name = dataTable.Rows[0]["name"].ToString();
            kisi.Surmane = dataTable.Rows[0]["surname"].ToString();
            if (dataTable.Rows[0]["parentID"].ToString() == "")
            {
                kisi.parentId = 0;
            }
            else
            {
                kisi.parentId = int.Parse(dataTable.Rows[0]["parentID"].ToString());
            }
            if (dataTable.Rows[0]["coupleID"].ToString() == "")
            {
                kisi.coupleId = 0;
            }
            else
            {
                kisi.coupleId = int.Parse(dataTable.Rows[0]["coupleID"].ToString());
            }
            kisi.Birthdate = DateTime.Parse(dataTable.Rows[0]["birthdate"].ToString());
            kisi.Photo = dataTable.Rows[0]["photo"].ToString();
            kisi.Sex = int.Parse(dataTable.Rows[0]["sex"].ToString());
            kisi.Dead = bool.Parse(dataTable.Rows[0]["dead"].ToString());
            return kisi;
        }

        public Person Baba()
        {
            ConnectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=familytree;Integrated Security=True";
            Connect();
            SqlCommand cmd = new SqlCommand("USP_FAMILYTREE_PERSON_BABA", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Id);
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            cmd.Dispose();
            cmd = null;
            adapter.Dispose();
            adapter = null;
            int babaId = int.Parse(dataTable.Rows[0]["id"].ToString());
            Person baba = ReturnPerson(babaId);
            return baba;
        }

        public Person Anne()
        {
            ConnectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=familytree;Integrated Security=True";
            Connect();
            SqlCommand cmd = new SqlCommand("USP_FAMILYTREE_PERSON_ANNE", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Id);
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            cmd.Dispose();
            cmd = null;
            adapter.Dispose();
            adapter = null;
            if (dataTable.Rows[0]["id"].ToString() == "")
            { return null; }
            int anneId = int.Parse(dataTable.Rows[0]["id"].ToString());
            Person anne = ReturnPerson(anneId);
            return anne;
        }

        public List<Person> Kardes()
        {
            ConnectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=familytree;Integrated Security=True";
            Connect();
            SqlCommand cmd = new SqlCommand("USP_FAMILYTREE_PERSON_KARDES", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Id);
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            cmd.Dispose();
            cmd = null;
            adapter.Dispose();
            adapter = null;
            List<Person> KardesList = new List<Person>();
            foreach (DataRow p in dataTable.Rows)
            {
                Person yeniKardes = ReturnPerson(int.Parse(p["id"].ToString()));
                KardesList.Add(yeniKardes);
            }

            return KardesList;
        }
        public List<Person> Kucukkardes()
        {
            IEnumerable<Person> kardesler = from x in Kardes()
                                            where x.Birthdate >= Birthdate
                                            select x;
            return kardesler.ToList();
        }

        public List<Person> Abla()
        {
            IEnumerable<Person> ablalar = from x in Kardes()
                                          where x.Sex == 0 && x.Birthdate < Birthdate
                                          select x;
            List<Person> yeniAbla = ablalar.ToList();
            return yeniAbla;
        }

        public List<Person> Agabey()
        {
            IEnumerable<Person> agabeyler = from x in Kardes()
                                            where x.Sex == 1 && x.Birthdate < Birthdate
                                            select x;
            List<Person> yeniAgabey = agabeyler.ToList();
            return yeniAgabey;
        }


        public List<Person> Amca()
        {
            IEnumerable<Person> amcalar = from x in Baba().Kardes()
                                          where x.Sex == 1
                                          select x;
            List<Person> yeniAmca = amcalar.ToList();


            return yeniAmca;
        }

        public List<Person> Hala()
        {
            IEnumerable<Person> halalar = from x in Baba().Kardes()
                                          where x.Sex == 0
                                          select x;
            List<Person> yeniHala = halalar.ToList();


            return yeniHala;
        }

        public List<Person> Dayi()
        {
            IEnumerable<Person> dayilar = from x in Anne().Kardes()
                                          where x.Sex == 1
                                          select x;
            return dayilar.ToList();
        }

        public List<Person> Teyze()
        {
            IEnumerable<Person> teyzeler = from x in Anne().Kardes()
                                           where x.Sex == 0
                                           select x;
            return teyzeler.ToList();
        }


        public List<Person> Yenge()
        {
            List<Person> yengeler = new List<Person>();
            foreach (Person p in Amca())
            {
                if (p.Es() != null)
                    yengeler.Add(p.Es());
            }
            foreach (Person p in Dayi())
            {
                if (p.Es() != null)
                    yengeler.Add(p.Es());
            }
            foreach (Person p in Kardes())
            {
                if (p.Sex == 1)
                {
                    if (p.Es() != null)
                    {
                        yengeler.Add(p.Es());
                    }
                }
            }
            return yengeler;
        }

        public List<Person> Eniste()
        {
            List<Person> enisteler = new List<Person>();
            foreach (Person p in Hala())
            {
                if (p.Es() != null)
                    enisteler.Add(p.Es());
            }
            foreach (Person p in Teyze())
            {
                if (p.Es() != null)
                    enisteler.Add(p.Es());
            }
            foreach (Person p in Kardes())
            {
                if (p.Sex == 0)
                {
                    if (p.Es() != null)
                    {
                        enisteler.Add(p.Es());
                    }
                }
            }
            return enisteler;
        }
        public List<Person> Gelin()
        {
            List<Person> gelinler = new List<Person>();
            foreach (Person p in Cocuk())
            {
                if (p.Es() != null)
                {
                    if (p.Es().Sex == 0)
                    {
                        gelinler.Add(p.Es());
                    }
                }
            }
            return gelinler;
        }
        public List<Person> Damat()
        {
            List<Person> damatlar = new List<Person>();
            foreach (Person p in Cocuk())
            {
                if (p.Es() != null)
                {
                    if (p.Es().Sex == 1)
                    {
                        damatlar.Add(p.Es());
                    }
                }
            }
            return damatlar;
        }
        public List<Person> Dede()
        {

            List<Person> dedeler = new List<Person>();
            if (Anne().Baba() != null)
                dedeler.Add(Anne().Baba());
            if (Baba().Baba() != null)
                dedeler.Add(Baba().Baba());
            return dedeler;
        }

        public Person Anneanne()
        {
            if (Anne().Anne() != null)
                return Anne().Anne();
            else
                return null;
        }

        public Person Babaanne()
        {
            if (Baba().Anne() != null)
                return Baba().Anne();
            else
                return null;
        }

        public List<Person> Gorumce()
        {
            List<Person> gorumceler = new List<Person>();
            if (Es() != null)
                if (Es().Sex == 1)
                {
                    IEnumerable<Person> yeniGorumce = from x in Es().Kardes()
                                                      where x.Sex == 0
                                                      select x;
                    gorumceler.AddRange(yeniGorumce.ToList());

                }
            return gorumceler;
        }
        public List<Person> Baldiz()
        {
            List<Person> baldizlar = new List<Person>();
            if (Es() != null)
                if (Es().Sex == 0)
                {
                    IEnumerable<Person> yeniGorumce = from x in Es().Kardes()
                                                      where x.Sex == 0
                                                      select x;
                    baldizlar.AddRange(yeniGorumce.ToList());

                }
            return baldizlar;
        }
        public List<Person> Kayinbirader()
        {
            List<Person> kayinbiraderler = new List<Person>();
            if (Es() != null)
                if (Es().Sex == 0)
                {
                    IEnumerable<Person> yeniKayinbirader = from x in Es().Kardes()
                                                           where x.Sex == 1
                                                           select x;
                    kayinbiraderler.AddRange(yeniKayinbirader.ToList());

                }
            return kayinbiraderler;
        }
        public List<Person> Bacanak()
        {
            List<Person> bacanaklar = new List<Person>();
            if (Es() != null)
                if (Es().Sex == 0)
                {
                    foreach (Person x in Es().Kardes())
                    {
                        if (x.Sex == 0)
                        {
                            if (x.Es() != null)
                            {
                                bacanaklar.Add(x.Es());
                            }
                        }
                    }

                }
            return bacanaklar;
        }
        public List<Person> Elti()
        {
            List<Person> eltiler = new List<Person>();
            if (Es() != null)
                if (Es().Sex == 1)
                {
                    foreach (Person x in Es().Kardes())
                    {
                        if (x.Sex == 1)
                        {
                            if (x.Es() != null)
                            {
                                eltiler.Add(x.Es());
                            }
                        }
                    }

                }
            return eltiler;
        }

        public Person Kayinanne()
        {
            return Es().Anne();
        }
        public Person Kayinbaba()
        {
            return Es().Baba();
        }
        public List<Person> Torun()
        {
            List<Person> torunlar = new List<Person>();
            foreach (Person c in Cocuk())
            {
                torunlar.AddRange(c.Cocuk());
            }
            return torunlar;
        }
        public List<Person> Kuzen()
        {
            List<Person> kuzenler = new List<Person>();
            foreach (Person a in Amca())
            {
                kuzenler.AddRange(a.Cocuk());
            }
            foreach (Person a in Dayi())
            {
                kuzenler.AddRange(a.Cocuk());
            }
            foreach (Person a in Teyze())
            {
                kuzenler.AddRange(a.Cocuk());
            }
            foreach (Person a in Hala())
            {
                kuzenler.AddRange(a.Cocuk());
            }
            return kuzenler;
        }

        public List<Person> Yegen()
        {
            List<Person> yegenler = new List<Person>();
            foreach (Person p in Kardes())
            {
                if (p.Cocuk().Count > 0)
                    yegenler.AddRange(p.Cocuk());
            }
            return yegenler;
        }

        public List<Person> Cocuk()
        {
            ConnectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=familytree;Integrated Security=True";
            Connect();
            SqlCommand cmd = new SqlCommand("USP_FAMILYTREE_PERSON_COCUK", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Id);
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            cmd.Dispose();
            cmd = null;
            adapter.Dispose();
            adapter = null;
            List<Person> CocukList = new List<Person>();

            foreach (DataRow p in dataTable.Rows)
            {
                if (p["id"].ToString() != "")
                {
                    Person yeniCocuk = ReturnPerson(int.Parse(p["id"].ToString()));
                    CocukList.Add(yeniCocuk);
                }
            }

            return CocukList;
        }
        public Person Es()
        {
            ConnectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=familytree;Integrated Security=True";
            Connect();
            SqlCommand cmd = new SqlCommand("USP_FAMILYTREE_PERSON_ES", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Id);
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            cmd.Dispose();
            cmd = null;
            adapter.Dispose();
            adapter = null;
            if (dataTable.Rows.Count == 0)
                return null;
            else
            {
                int esId = int.Parse(dataTable.Rows[0]["id"].ToString());
                Person es = ReturnPerson(esId);
                return es;
            }
        }



        public List<Person> Liste()
        {
            ConnectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=familytree;Integrated Security=True";
            Connect();
            SqlCommand cmd = new SqlCommand("USP_FAMILYTREE_PEOPLE_GETLIST", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Isim", _Isim);
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            cmd.Dispose();
            cmd = null;
            adapter.Dispose();
            adapter = null;
            List<Person> People = new List<Person>();
            foreach (DataRow satir in dataTable.Rows)
            {
                Person newPerson = new Person();
                newPerson.Id = int.Parse(satir["id"].ToString());
                newPerson.Name = satir["name"].ToString();
                newPerson.Surmane = satir["surname"].ToString();
                if (satir["id"].ToString() == "")
                {
                    newPerson.Id = 0;
                }
                else
                {
                    newPerson.Id = int.Parse(satir["id"].ToString());
                }
                if (satir["parentID"].ToString() == "")
                {
                    newPerson.parentId = 0;
                }
                else
                {
                    newPerson.parentId = int.Parse(satir["parentID"].ToString());
                }
                if (satir["coupleID"].ToString() == "")
                {
                    newPerson.coupleId = 0;
                }
                else
                {
                    newPerson.coupleId = int.Parse(satir["coupleID"].ToString());
                }
                newPerson.Birthdate = DateTime.Parse(satir["birthdate"].ToString());
                newPerson.Photo = satir["photo"].ToString();
                newPerson.Sex = int.Parse(satir["sex"].ToString());
                newPerson.Dead = bool.Parse(satir["dead"].ToString());
                People.Add(newPerson);
                newPerson = null;
            }
            dataTable.Dispose();
            dataTable = null;
            Disconnect();
            return People;
        }
        private int YasSiniri = 16;
        public bool IsBaba(Person gelen)
        {
            if (Baba() == gelen)
                return true;

            return false;
        }

        public bool IsAnne(Person gelen)
        {
            if (Anne() == gelen)
                return true;

            return false;
        }

        public bool IsKardes(Person gelen)
        {
            if (Kardes().Contains(gelen))
                return true;
            return false;
        }

        public bool IsKucukkardes(Person gelen)
        {
            return (Kucukkardes().Contains(gelen));
        }

        public bool IsAbla(Person gelen)
        {
            return (Abla().Contains(gelen));
        }

        public bool IsAgabey(Person gelen)
        {
            return Agabey().Contains(gelen);
        }

        public bool IsAmca(Person gelen)
        {
            return Amca().Contains(gelen);
        }

        public bool IsHala(Person gelen)
        {
            return Hala().Contains(gelen);
        }

        public bool IsDayi(Person gelen)
        {
            return Dayi().Contains(gelen);
        }

        public bool IsTeyze(Person gelen)
        {
            return Teyze().Contains(gelen);
        }

        public bool IsYenge(Person gelen)
        {
            return Yenge().Contains(gelen);
        }

        public bool IsEniste(Person gelen)
        {
            return Eniste().Contains(gelen);
        }

        public bool IsGelin(Person gelen)
        {
            return Gelin().Contains(gelen);
        }

        public bool IsDamat(Person gelen)
        {
            return Damat().Contains(gelen);
        }

        public bool IsDede(Person gelen)
        {
            return Dede().Contains(gelen);
        }

        public bool IsAnneanne(Person gelen)
        {
            if (Anneanne() == gelen)
                return true;
            return false;
        }

        public bool IsBabaanne(Person gelen)
        {
            if (Babaanne() == gelen)
                return true;
            return false;
        }

        public bool IsGorumce(Person gelen)
        {
            return Gorumce().Contains(gelen);
        }

        public bool IsBaldiz(Person gelen)
        {
            return Baldiz().Contains(gelen);
        }

        public bool IsKayinbirader(Person gelen)
        {
            return Kayinbirader().Contains(gelen);
        }

        public bool IsBacanak(Person gelen)
        {
            return Bacanak().Contains(gelen);
        }

        public bool IsElti(Person gelen)
        {
            return Elti().Contains(gelen);
        }

        public bool IsKayinanne(Person gelen)
        {
            if (Kayinanne() == gelen)
                return true;
            return false;
        }

        public bool IsKayinbaba(Person gelen)
        {
            if (Kayinbaba() == gelen)
                return true;
            return false;
        }

        public bool IsTorun(Person gelen)
        {
            return Torun().Contains(gelen);
        }

        public bool IsKuzen(Person gelen)
        {
            return Kuzen().Contains(gelen);
        }

        public bool IsYegen(Person gelen)
        {
            return Yegen().Contains(gelen);
        }

        public bool IsCocuk(Person gelen)
        {
            return Cocuk().Contains(gelen);
        }

        public bool IsEs(Person gelen)
        {
            if (Es() == gelen)
                return true;
            return false;
        }

        public string Iliski(Person gelen)
        {
            if (IsAbla(gelen)) return "Abla";
            if (IsAgabey(gelen)) return "Ağabey";
            if (IsAmca(gelen)) return "Amca";
            if (IsAnne(gelen)) return "Anne"; 
            if (IsAnneanne(gelen)) return "Anneanne";
            if (IsBaba(gelen)) return "Baba";
            if (IsBabaanne(gelen)) return "Babaanne";
            if (IsBacanak(gelen)) return "Bacanak";
            if (IsBaldiz(gelen)) return "Baldız";
            if (IsCocuk(gelen)) return "Çocuk";
            if (IsDamat(gelen)) return "Damat";
            if (IsDayi(gelen)) return "Dayı";
            if (IsDede(gelen)) return "Dede";
            if (IsElti(gelen)) return "Elti";
            if (IsEniste(gelen)) return "Enişte";
            if (IsEs(gelen)) return "Es";
            if (IsGelin(gelen)) return "Gelin";
            if (IsGorumce(gelen)) return "Görümce";
            if (IsHala(gelen)) return "Hala";
            if (IsKardes(gelen)) return "Kardeş";
            if (IsKayinanne(gelen)) return "Kayınanne";
            if (IsKayinbaba(gelen)) return "Kayınbaba";
            if (IsKayinbirader(gelen)) return "Kayınbirader";
            if (IsKucukkardes(gelen)) return "Küçük Kardeş";
            if (IsKuzen(gelen)) return "Kuzen";
            if (IsTeyze(gelen)) return "Teyze";
            if (IsTorun(gelen)) return "Torun";
            if (IsYegen(gelen)) return "Yeğen";
            if (IsYenge(gelen)) return "Yenge";
            return null;
        }
    }
}