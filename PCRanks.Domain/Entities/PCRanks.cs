using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCRanks.Domain.Entities
{
    public class PCRanks
    {
        public int Id { get; set; }
        public string UserName { get; set; } = default!;
        public string GameName { get; set; } = default!;
        public string GameResolution { get; set; } = default!;
        public string? GameSettings { get; set; }
        public string? Fps { get; set; }
        public PCSpecsDetails PCSpecs { get; set; } = default!;

        public string? About { get; set; }

        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; }

        public string EncodedName { get; private set; } = default!;

       public void EncodeName() => EncodedName = UserName.ToLower().Replace(" ", "-");

    }
}
