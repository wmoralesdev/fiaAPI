using Domain.BaseIdentities;
using Domain.Inscriptions;
using Domain.Presentations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Attendants
{
    public class Attendant : BaseIdentity
    {
        public virtual ICollection<Inscription> Inscriptions { get; set; }

        public Attendant(string fullName, string email, string phoneNumber, IdentityRole role)
            : base(fullName, email, phoneNumber, role)
        {
        }
    }
}
