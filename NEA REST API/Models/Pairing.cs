using System;
using System.Collections.Generic;

namespace NEA_Rest_API.Models;

public partial class Pairing
{
    public int PairingId { get; set; }
    public int User1 { get; set; }

    public int User2 { get; set; }
}
