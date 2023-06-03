using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCRanks.Application.PCRanks
{
    public class PCRanksDto
    {

        public string UserName { get; set; } = default!;
        public string GameName { get; set; } = default!;
        public string GameResolution { get; set; } = default!;
        public string? GameSettings { get; set; }
        public string? Fps { get; set; }
        public string? Cpu { get; set; }
        public string? Gpu { get; set; }
        public string? Mobo { get; set; }
        public string? Psu { get; set; }

        public string? EncodedName {get; set; }
        public bool IsEditable { get; set; }
    }
}
