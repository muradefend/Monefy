using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Monefy.Model.Expences
{
    [XmlInclude(typeof(CarExpence))]
    [XmlInclude(typeof(ClothesExpence))]
    [XmlInclude(typeof(CommunicationsExpence))]
    [XmlInclude(typeof(EatingOutExpence))]
    [XmlInclude(typeof(EntertainmentExpence))]
    [XmlInclude(typeof(FoodExpence))]
    [XmlInclude(typeof(GiftsExpence))]
    [XmlInclude(typeof(HealthExpence))]
    [XmlInclude(typeof(HouseExpence))]
    [XmlInclude(typeof(PetsExpence))]
    [XmlInclude(typeof(SportsExpence))]
    [XmlInclude(typeof(TaxiExpence))]
    [XmlInclude(typeof(ToiletryExpence))]
    [XmlInclude(typeof(TransportExpence))]
    public class Expence
    {
        public double TotalSum { get; set; }

        public DateTime ExecutionDate { get; set; }
    }
}
