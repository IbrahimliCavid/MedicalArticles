﻿using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ServiceAboutItemDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Deleted { get; set; }
        public int ServiceAboutId { get; set; }
        public ServiceAbout ServiceAbout { get; set; }
    }
}