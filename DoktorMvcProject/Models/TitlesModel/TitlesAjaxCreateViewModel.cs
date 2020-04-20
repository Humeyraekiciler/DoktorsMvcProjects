using DoktorMvcProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoktorMvcProject.Models.TitlesModel
{
    public class TitlesAjaxCreateViewModel
    {
        public List<Titles> title_list { get; set; }

        public Titles titles { get; set; }
    }
}
