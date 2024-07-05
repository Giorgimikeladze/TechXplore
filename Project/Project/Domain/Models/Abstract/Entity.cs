﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Abstract
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
