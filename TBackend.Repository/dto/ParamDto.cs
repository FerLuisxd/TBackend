using System;
using System.Collections.Generic;
using TBackend.Entity;
using System.ComponentModel.DataAnnotations;

namespace TBackend.Repository.dto
{
    public class ParamsDto
    {
        public float Kills { get; set; }
        public float Deaths { get; set; }
        public float Assists { get; set; }
        public float Damage { get; set; }
    }
}