using Backend_Test.Domain.Exceptions;
using Backend_Test.Utilities.Constants;

namespace Backend_Test.Domain.Models
{
    public record Person
    {
        public long Id { get; init; }
        public string Firstname { get; init; }
        public string Lastname { get; init; }
        public int YearOfBirth { get; init; }

        public Person(long id, string firstname, string lastname, int yearOfBirth)
        {
            if (yearOfBirth > DateTime.Now.Year)
            {
                throw new BadRequestException(ErrorMessage.InvalidYearOfBirth);
            }
            else if (yearOfBirth < 0)
            {
                throw new BadRequestException(ErrorMessage.NegativeYearOfBirth);
            }

            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            YearOfBirth = yearOfBirth;
        }
    }

}
