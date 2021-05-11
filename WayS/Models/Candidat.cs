using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayS.Models
{
    class Candidat
    {
        private int id;
        private string pseudo;
        private int score;
        private int age;
        private string niveau;
        private int experience;
        private string localisation;
        private string hobby;

        public int Id
        {
            get => id;
            set => id = value;
        }
        public string Pseudo
        {
            get => pseudo;
            set => pseudo = value;
        }
        public int Score
        {
            get => score;
            set => score = value;
        }
        public int Age
        {
            get => age;
            set => age = value;
        }
        public string Niveau
        {
            get => niveau;
            set => niveau = value;
        }
        public int Experience
        {
            get => experience;
            set => experience = value;
        }
        public string Localisation
        {
            get => localisation;
            set => localisation = value;
        }

        public string Hobby
        {
            get => hobby;
            set => hobby = value;
        }
    }
}
