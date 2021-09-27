using System.Collections.Generic;

namespace sep27
{
    public class S1 : ISolution
    {
        public int NumUniqueEmails(string[] emails)
        {
            var emailSet = new HashSet<string>();
            foreach (var email in emails)
            {
                emailSet.Add(ParseEmail(email));
            }
            return emailSet.Count;
        }

        private string ParseEmail(string email)
        {
            var parts = email.Split('@');

            // local name 
            var tempLocal = parts[0];
            var localNameParts = tempLocal.Split('+');
            var localName = localNameParts[0].Replace(".", "");
            // domain 
            var domain = parts[1];
            return $"{localName}@{domain}";
        }
    }
}