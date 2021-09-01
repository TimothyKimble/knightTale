// NOTE This is the same setup for Node for creating AUTH0. All that is the same. 

using System;
using System.Collections.Generic;

namespace knightTale.Models
{
    public class Account
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
    }
}