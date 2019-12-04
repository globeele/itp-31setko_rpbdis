﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4.Data
{
    public partial class LightingContext : DbContext
    {
        public LightingContext(DbContextOptions<LightingContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Call> Calls { get; set; }
        public virtual DbSet<Lamp> Lamps { get; set; }
        public virtual DbSet<Lantern> Lanterns { get; set; }
        public virtual DbSet<Master> Masters { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<SectionsLighting> SectionsLightings { get; set; }
        public virtual DbSet<Street> Streets { get; set; }

    }

}
