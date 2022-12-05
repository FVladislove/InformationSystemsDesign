using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InformationSystemsDesign.Models;

namespace InformationSystemsDesign.Data
{
    public class InformationSystemsDesignContext : DbContext
    {
        public InformationSystemsDesignContext (DbContextOptions<InformationSystemsDesignContext> options)
            : base(options)
        {
        }

        public DbSet<InformationSystemsDesign.Models.GLPR> GLPR { get; set; } = default!;
    }
}
