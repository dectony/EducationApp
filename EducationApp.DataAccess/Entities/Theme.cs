﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.DataAccess.Entities
{
    public class Theme
    {
        public int ThemeId { get; set; }
        public string ThemeName { get; set; }
        public string ContentFilePath { get; set; }

        public virtual List<Quiz> Quizes { get; set; }
    }
}
