using Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Dto
{
    public class StatusDto
    {
        public ActionResult Status { get; set; }
        public string Message { get; set; }
    }
}
