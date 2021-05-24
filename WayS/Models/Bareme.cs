using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayS.Models
{
    class Bareme
    {
        private int id;
        private string baremeTitle;
        private string description;
        private string formationTitle;

        public int Id
        {
            get => id;
            set => id = value;
        }
        public string BaremeTitle
        {
            get => baremeTitle;
            set => baremeTitle = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public string FormationTitle
        {
            get => formationTitle;
            set => formationTitle = value;
        }
    }
}
