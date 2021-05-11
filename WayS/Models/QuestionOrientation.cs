using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayS.Models
{
    class QuestionOrientation : Question
    {
        private string bareme;

        public string Bareme
        {
            get => bareme;
            set => bareme = value;
        }
    }
}
