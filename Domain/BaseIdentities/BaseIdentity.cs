namespace Domain.BaseIdentities
{
    public abstract class BaseIdentity
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public IdentityRole Role { get; set; }

        public BaseIdentity(string fullName, string email, string phoneNumber, IdentityRole role)
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Role = role;
        }
    }
}
