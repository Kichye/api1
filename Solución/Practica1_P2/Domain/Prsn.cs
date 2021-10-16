using System;

namespace QueryApi.Domain
{
    public record Per (int Id, string FirstName, string LastName, string Email, char Gender, string Job, int Age);
}