using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace QueryLibrary
{
    public class Vacancy
    {
        public int idVacancy;
        public int idUserPlacement;
        [Obsolete]
        public string photo;
        public string nameVacancy;
        public int idTypeJob;
        public decimal payment;
        public string geoInfCity;
        public DateTime datePlacement;
        public string description;
        public VacancyState vacancyState;
        public VacancyFormed vacanceFormed;
    }
}
