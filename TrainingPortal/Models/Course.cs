using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TrainingPortal.Models
{
    public class Course
    {
        public long Id { get; set; }

        private string _key;

        public string Key
        {
            get
            {
                if(_key == null)
                {
                    _key = Regex.Replace(Title.ToLower(), "[^a-z0-9]", "-");
                }
                return _key;
            }
            set
            {
                _key = value;
            }
        }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Source { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public DateTime Posted { get; set; }
    }
}
