﻿using Core.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.LocationService.Service.Dto
{
    public class LocationDto
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }
        [Phone]
        public string Phone { get; set; }
        public string Address { get; set; }
        [Column(TypeName = "money")]
        public decimal RentalFees { get; set; }
        public string Discriminator { get; set; }

    }
}
