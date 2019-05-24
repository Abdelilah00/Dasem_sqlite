using System;

namespace DasemBeniSanssen.Classes
{
    class Tables
    {
        public class Ticket
        {
            int idTicket, idProduct, idCamion, idCompany, idClient, netKg, brut;
            DateTime enterDate, exitDate;
            bool credit,attend;
            float netM3;

            

            public int IdTicket { get => idTicket; set => idTicket = value; }
            public int IdProduct { get => idProduct; set => idProduct = value; }
            public int IdCamion { get => idCamion; set => idCamion = value; }
            public int IdCompany { get => idCompany; set => idCompany = value; }
            public int IdClient { get => idClient; set => idClient = value; }
            public int NetKg { get => netKg; set => netKg = value; }
            public DateTime EnterDate { get => enterDate; set => enterDate = value; }
            public DateTime ExitDate { get => exitDate; set => exitDate = value; }
            public bool Credit { get => credit; set => credit = value; }
            public int Brut { get => brut; set => brut = value; }
            public float NetM3 { get => netM3; set => netM3 = value; }
            public bool Attend { get => attend; set => attend = value; }
        }
        public class Camion
        {
            int idCamion, tare;
            String matricule;


            public int IdCamion { get => idCamion; set => idCamion = value; }
            public int Tare { get => tare; set => tare = value; }
            public string Matricule { get => matricule; set => matricule = value; }
        }
        public class Product
        {
            int idProduct, prix;
            float density;
            String productName;


            public int IdProduct { get => idProduct; set => idProduct = value; }
            public int Prix { get => prix; set => prix = value; }
            public float Density { get => density; set => density = value; }
            public string ProductName { get => productName; set => productName = value; }
        }
        public class Client
        {
            String clientName;
            int idClient;

            public string ClientName { get => clientName; set => clientName = value; }
            public int IdClient { get => idClient; set => idClient = value; }
        }
    }
}
